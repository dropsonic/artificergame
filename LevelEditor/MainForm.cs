﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FarseerTools;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Common.Decomposition;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameLogic;


namespace LevelEditor
{
    using Color = Microsoft.Xna.Framework.Color;

    public partial class MainForm : Form
    {
        GameObject currentObject;
        AssetCreator _assetCreator;
        System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
        readonly Dictionary<string, Color> colorDictionary = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static).Where((prop) => prop.PropertyType == typeof(Color))
                .ToDictionary(prop => prop.Name, prop => (Color)prop.GetValue(null, null));
        
        public MainForm()
        {
            InitializeComponent();
            Initialize();
            
        }

        private void Initialize()
        {
            updateTimer.Enabled = false;
            updateTimer.Tick += new EventHandler(UpdatePreview);
            updateTimer.Interval = 10;
            ConvertUnits.SetDisplayUnitToSimUnitRatio((float)levelScreen.Size.Height / 100);
            this.shapeParametersControl.SelectedTab = this.emptyTab;
            levelScreen.DrawCurrentGameObject = false;

            currentObject = new GameObject();
            Body body = new Body(currentObject.World);
            currentObject.AddPart(new Sprite(null,Vector2.Zero), body);
            propertyGrid.SelectedObject = currentObject[0].Body;

            InitializeStatusStrip();
            ShowReadyStatus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //load assetCreator Materials
            _assetCreator = ContentService.GetContentService().AssetCreator;
            _assetCreator.UseTexture = setAsTextureCheck.Checked;
            _assetCreator.DrawOutline = drawOutlineCheck.Checked;

            foreach (string material in Directory.GetFiles("Content\\" + ContentService.GetMaterial()))
            {
                string filename = System.IO.Path.GetFileName(material).Split('.')[0];
                _assetCreator.LoadMaterial(filename, ContentService.GetContentService().LoadTexture(material));
                materialBox.Items.Add(filename);
            }

            foreach (string shape in Directory.GetFiles("Content\\" + ContentService.GetShape()))
            {
                string filename = System.IO.Path.GetFileName(shape).Split('.')[0];
                _assetCreator.LoadShape(filename, ContentService.GetContentService().LoadTexture(shape));
                shapeFromTextureBox.Items.Add(filename);
            }
            
            foreach (ObjectType obj in Enum.GetValues(typeof(ObjectType)))
            {
                shapeBox.Items.Add(obj);
            }
            
            foreach (string colorName in colorDictionary.Keys)
            {
                colorBox.Items.Add(colorName);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                previewScreen.FrameTimer.Enabled = false;
                levelScreen.FrameTimer.Enabled = false;
                objectScreen.FrameTimer.Enabled = false;
            }
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                previewScreen.FrameTimer.Enabled = true;
                levelScreen.FrameTimer.Enabled = true;
                objectScreen.FrameTimer.Enabled = true;
            }
        }
        #region Настройка превью
        private void ShapeParameterSwitch(object sender, EventArgs e)
        {
            SwitchShapeParametersTab((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()));
            shapeBox.Focus();

            HandlePreview(sender,e);
        }

        private void HandlePreview(object sender, EventArgs e)
        {
            updateTimer.Enabled = true;
        }

        private void UpdatePreview(object sender, EventArgs e)
        {
            try
            {
                SetPreview();
                ShowReadyStatus();
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex);
            }
            SetCurrentObject();
            propertyGrid.Refresh();

            updateTimer.Enabled = false;
        }

        private void setAsTextureCheck_CheckedChanged(object sender, EventArgs e)
        {
            _assetCreator.UseTexture = setAsTextureCheck.Checked;
            HandlePreview(sender, e);
        }

        private void drawOutlineCheck_CheckedChanged(object sender, EventArgs e)
        {
            _assetCreator.DrawOutline = drawOutlineCheck.Checked;
            HandlePreview(sender, e);
        }
        #endregion

        #region Загрузка ресурсов
        private void loadMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMaterial();
                ShowReadyStatus();
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex);
            }
        }

        private void loadShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadShape();
                ShowReadyStatus();
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex);
            }
        }
        #endregion
        
        #region Проверки NumericUpDown для фигур
        private void capsuleHeight_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckCapsuleParams(e.NewValue, capsuleBottomRadius.Value, capsuleTopRadius.Value))
            {
                ShowWarningStatus("Capsule height must be greater then 2 minimum radiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowReadyStatus();
        }

        private void capsuleBottomRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckCapsuleParams(capsuleHeight.Value, e.NewValue, capsuleTopRadius.Value))
            {
                ShowWarningStatus("Capsule height must be greater then 2 minimum radiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowReadyStatus();
        }

        private void capsuleTopRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckCapsuleParams(capsuleHeight.Value, capsuleBottomRadius.Value, e.NewValue))
            {
                ShowWarningStatus("Capsule height must be greater then 2 minimum radiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowReadyStatus();
        }

        private void roundedRectangleHeight_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(e.NewValue, roundedRectangleYRadius.Value))
            {
                ShowWarningStatus("Rounded rectangle height must be greater then 2 YRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowReadyStatus();
        }

        private void roundedRectangleYRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(roundedRectangleHeight.Value, e.NewValue))
            {
                ShowWarningStatus("Rounded rectangle height must be greater then 2 yRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowReadyStatus();
        }

        private void roundedRectangleWidth_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(e.NewValue, roundedRectangleXRadius.Value))
            {
                ShowWarningStatus("Rounded rectangle width must be greater then 2 yRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowReadyStatus();
        }

        private void roundedRectangleXRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(roundedRectangleWidth.Value, e.NewValue))
            {
                ShowWarningStatus("Rounded rectangle width must be greater then 2 xRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowReadyStatus();
        }
        #endregion


        private void levelScreen_MouseEnter(object sender, EventArgs e)
        {
            levelScreen.DrawCurrentGameObject = true;
            Cursor = Cursors.Cross;
        }

        private void levelScreen_MouseMove(object sender, MouseEventArgs e)
        {
            levelScreen.CurrentObjectPosition = new Vector2(e.X, e.Y);
        }

        private void levelScreen_MouseClick(object sender, MouseEventArgs e)
        {
            if (placeObjectCheck.Checked)
                levelScreen.AddCurrentObject();
        }

        private void levelScreen_MouseLeave(object sender, EventArgs e)
        {
            levelScreen.DrawCurrentGameObject = false;
            Cursor = Cursors.Arrow;
        }

        private void placeObjectCheck_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentObject();
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGrid.Refresh();
        }

        private void simulateState_Changed(object sender, EventArgs e)
        {
            levelScreen.Simulate = !levelScreen.Simulate;
            if (levelScreen.Simulate)
            {
                simulateMenuItem.Text = "Stop simulation";
                ShowSimulationStatus();
            }
            else
            {
                simulateMenuItem.Text = "Simulate";
                ShowReadyStatus();
            }
        }
    }
}
