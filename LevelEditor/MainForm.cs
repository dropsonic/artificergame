using System;
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace LevelEditor
{
    public partial class MainForm : Form
    {
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
            updateTimer.Tick += new EventHandler(ResetTimer);
            updateTimer.Interval = 100;
            ConvertUnits.SetDisplayUnitToSimUnitRatio((float)levelScreen.Size.Height / 100);
            this.shapeParametersControl.SelectedTab = this.emptyTab;
            levelScreen.message = "Level";
            objectScreen.message = "GameObject";
            ShowReadyStatus();
        }
        void ResetTimer(Object obj, EventArgs e)
        {
            updateTimer.Enabled = false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //load assetCreator Materials
            _assetCreator = ContentService.GetContentService().AssetCreator;
            _assetCreator.UseTexture = setAsTextureCheck.Checked;
            foreach (string material in Directory.GetFiles("Content\\" + ContentService.GetMaterial()))
            {
                string filename = System.IO.Path.GetFileName(material).Split('.')[0];
                _assetCreator.LoadMaterial(filename, ContentService.GetContentService().LoadTexture(material));
                materialBox.Items.Add(filename);
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

        private void ShapeParameterSwitch(object sender, EventArgs e)
        {
            SwitchShapeParametersTab((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()));
            shapeBox.Focus();

            HandlePreview(sender,e);
        }

        private void HandlePreview(object sender, EventArgs e)
        {
            try 
            { 
                UpdatePreview();
                ShowReadyStatus();
            }
            catch (Exception ex) 
            { 
                ShowErrorStatus(ex);
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

        private void setAsTextureCheck_CheckedChanged(object sender, EventArgs e)
        {
            _assetCreator.UseTexture = setAsTextureCheck.Checked;
            HandlePreview(sender, e);
        }

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


    }
}
