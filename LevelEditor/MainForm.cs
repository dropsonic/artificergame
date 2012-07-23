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
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Common.Decomposition;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameLogic;
using FarseerPhysics;

namespace LevelEditor
{
    using Color = Microsoft.Xna.Framework.Color;
    using Microsoft.Xna.Framework.Input;

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
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US", false);

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

        private void PopulateDebugViewMenu()
        {
            int i = 0;
            foreach (DebugViewFlags flag in Enum.GetValues(typeof(DebugViewFlags)))
            {
                i++;
                System.Windows.Forms.ToolStripMenuItem currentMenuItem = new System.Windows.Forms.ToolStripMenuItem
                {
                    Name = "debugView" + flag.ToString() + "MenuItem",
                    Size = new System.Drawing.Size(166, 22),
                    Text = flag.ToString(),
                    ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), "F" + i.ToString())))),
                    CheckOnClick = true,
                    Checked = false
                };
                currentMenuItem.Click += new EventHandler(DebugView_Click);
                debugToolStripMenuItem.DropDownItems.Add(currentMenuItem);
            }
            SetDebugViewMenu();
        }

        private void SetDebugViewMenu()
        {
            foreach (System.Windows.Forms.ToolStripMenuItem menu in debugToolStripMenuItem.DropDownItems)
            {
                menu.Checked = levelScreen.DebugViewHasFlag((DebugViewFlags)Enum.Parse(typeof(DebugViewFlags), menu.Text));
            }
        }

        private void DebugView_Click(object sender, EventArgs e)
        {
            DebugViewFlags flag = (DebugViewFlags)Enum.Parse(typeof(DebugViewFlags), ((System.Windows.Forms.ToolStripMenuItem)sender).Text);

            //Если был включен ContactNormals и выключается ContactPoints, то нужно выключить ContactNormals тоже
            if (flag.HasFlag(DebugViewFlags.ContactPoints) && levelScreen.DebugViewHasFlag(DebugViewFlags.ContactNormals))
                flag = flag | DebugViewFlags.ContactNormals;
            //Если включается ContactNormals, а ContactPoints не включен, то нужно его включить
            else if (flag.HasFlag(DebugViewFlags.ContactNormals) && !levelScreen.DebugViewHasFlag(DebugViewFlags.ContactPoints))
                flag = flag | DebugViewFlags.ContactPoints;

            levelScreen.SwitchDebugViewFlag(flag);
            SetDebugViewMenu();
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

            PopulateDebugViewMenu();
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
            levelScreen.MouseState = e;
        }

        private void levelScreen_MouseDown(object sender, MouseEventArgs e)
        {
            levelScreen.CreateMouseJoint();
            levelPage.Focus();
            //levelScreen.Focus();
        }

        private void levelScreen_MouseUp(object sender, MouseEventArgs e)
        {
            levelScreen.RemoveMouseJoint();
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

        private void simulateMenuItem_Click(object sender, EventArgs e)
        {
            if (!levelScreen.Simulate && levelScreen.SimulationSpeed <= 0)
            {
                simulationSpeedMenuItem_Click(simulationSpeedNormalMenuItem, EventArgs.Empty); //устанавливаем значение скорости в 1х.
                ShowWarningStatus("Невозможно начать симуляцию с отрицательным или нулевым значением скорости времени. Значение скорости установлено в 1x.");
            }
            else
            {
                levelScreen.Simulate = !levelScreen.Simulate;
                SetDebugViewMenu();
            }
        }

        /// <summary>
        /// Метод-хелпер для изменения состояния checked элементов меню изменения скорости симуляции.
        /// </summary>
        private void ChangeSimSpeedMenuItemsCheckedStateHelper(bool halfItem, bool normalItem, bool doubleItem)
        {
            simulationSpeedHalfMenuItem.Checked = halfItem;
            simulationSpeedNormalMenuItem.Checked = normalItem;
            simulationSpeedDoubleMenuItem.Checked = doubleItem;
        }

        private void simulationSpeedMenuItem_Click(object sender, EventArgs e)
        {
            const float inc = 0.25f; //шаг изменения скорости симуляции

            if (sender == simulationSpeedHalfMenuItem)
            {
                ChangeSimSpeedMenuItemsCheckedStateHelper(true, false, false);
                levelScreen.SimulationSpeed = 0.5f;
            }
            else if (sender == simulationSpeedNormalMenuItem)
            {
                ChangeSimSpeedMenuItemsCheckedStateHelper(false, true, false);
                levelScreen.SimulationSpeed = LevelScreen.NormalSimulationSpeed;
            }
            else if (sender == simulationSpeedDoubleMenuItem)
            {
                ChangeSimSpeedMenuItemsCheckedStateHelper(false, false, true);
                levelScreen.SimulationSpeed = 2.0f;
            }
            else if (sender == simulationSpeedIncreaseMenuItem)
            {
                ChangeSimSpeedMenuItemsCheckedStateHelper(false, false, false);
                levelScreen.SimulationSpeed += inc;
            }
            else if (sender == simulationSpeedDecreaseMenuItem)
            {
                ChangeSimSpeedMenuItemsCheckedStateHelper(false, false, false);
                levelScreen.SimulationSpeed -= inc;
            }

            if (_status == StatusType.Simulation)
                ShowSimulationStatus(levelScreen.SimulationSpeed);
            else
                ShowReadyStatus(); //для того, чтобы убрать показ предупреждения или ошибки
        }

        private void levelScreen_SimulateChanged(object sender, EventArgs e)
        {
            if (levelScreen.Simulate)
            {
                simulateMenuItem.Text = "Stop simulation";
                ShowSimulationStatus(levelScreen.SimulationSpeed);
            }
            else
            {
                simulateMenuItem.Text = "Simulate";
                ShowReadyStatus();
            }
        }

        private void UpdateLevelScreenUpperLeftLocalPoint(object sender)
        {
            levelScreen.UpperLeftLocalPoint = new Vector2(-((System.Windows.Forms.TabPage)sender).DisplayRectangle.X, -((System.Windows.Forms.TabPage)sender).DisplayRectangle.Y);    
        }

        private void levelPage_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateLevelScreenUpperLeftLocalPoint(sender);
        }

        private void levelPage_MouseWheel(object sender, MouseEventArgs e)
        {
            UpdateLevelScreenUpperLeftLocalPoint(sender);
        }
    }
}
