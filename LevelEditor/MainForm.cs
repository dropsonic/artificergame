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
using LevelEditor.Commands;

namespace LevelEditor
{
    using Color = Microsoft.Xna.Framework.Color;
    using Microsoft.Xna.Framework.Input;

    public partial class MainForm : Form
    {
        ObjectLevelManager _objectLevelManager;
        CommandManager _commandManager;
        AssetCreator _assetCreator;
        Cursor _levelScreenCursor = Cursors.Arrow;

        System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();

        Dictionary<string,Color> _colorDictionary = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static).Where((prop) => prop.PropertyType == typeof(Color))
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

            InitializeStatusStrip();

            ShowReadyStatus();
        }

        private void InitializeCommandManager()
        {
            _commandManager = new CommandManager();

            _commandManager.AddCommand(new AddPreviewObjectCommand(_objectLevelManager));

            _commandManager.AddCommand(new StartSimulationCommand(_objectLevelManager.Simulator));
            _commandManager.AddCommand(new PauseSimulationCommand(_objectLevelManager.Simulator));
            _commandManager.AddCommand(new StopSimulationCommand(_objectLevelManager.Simulator));

            _commandManager.AddCommand(new SimulationSpeedHalfCommand(_objectLevelManager.Simulator));
            _commandManager.AddCommand(new SimulationSpeedNormalCommand(_objectLevelManager.Simulator));
            _commandManager.AddCommand(new SimulationSpeedDoubleCommand(_objectLevelManager.Simulator));
            _commandManager.AddCommand(new SimulationSpeedIncreaseCommand(_objectLevelManager.Simulator));
            _commandManager.AddCommand(new SimulationSpeedDecreaseCommand(_objectLevelManager.Simulator));
        }

        private void InitializeAfterLoad()
        {
            _objectLevelManager = new ObjectLevelManager(levelScreen.Camera, levelScreen.GraphicsDevice);
            propertyGrid.SelectedObject = _objectLevelManager.PreviewObject[0].Body;
            levelScreen.GameLevel = _objectLevelManager.GameLevel;

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

            foreach (string colorName in _colorDictionary.Keys)
            {
                colorBox.Items.Add(colorName);
            }

            InitializeCommandManager();
            PopulateDebugViewMenu();
        }

        /// <summary>
        /// Загружает общие для формы и её элементов настройки.
        /// </summary>
        private void LoadSettings()
        {

        }

        /// <summary>
        /// Сохраняет общие для формы и её элементов настройки.
        /// </summary>
        private void SaveSettings()
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeAfterLoad();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
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
        
        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGrid.Refresh();
        }

        #region DebugView
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
            levelScreen.GameLevel.World.ProcessChanges();
            SetDebugViewMenu();
        }
        #endregion

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
                CreatePreview();
                ShowCurrentNormalStatus();
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex);
            }
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
                ShowCurrentNormalStatus();
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
                ShowCurrentNormalStatus();
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
                ShowCurrentNormalStatus();
        }

        private void capsuleBottomRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckCapsuleParams(capsuleHeight.Value, e.NewValue, capsuleTopRadius.Value))
            {
                ShowWarningStatus("Capsule height must be greater then 2 minimum radiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowCurrentNormalStatus();
        }

        private void capsuleTopRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckCapsuleParams(capsuleHeight.Value, capsuleBottomRadius.Value, e.NewValue))
            {
                ShowWarningStatus("Capsule height must be greater then 2 minimum radiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowCurrentNormalStatus();
        }

        private void roundedRectangleHeight_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(e.NewValue, roundedRectangleYRadius.Value))
            {
                ShowWarningStatus("Rounded rectangle height must be greater then 2 YRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowCurrentNormalStatus();
        }

        private void roundedRectangleYRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(roundedRectangleHeight.Value, e.NewValue))
            {
                ShowWarningStatus("Rounded rectangle height must be greater then 2 yRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowCurrentNormalStatus();
        }

        private void roundedRectangleWidth_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(e.NewValue, roundedRectangleXRadius.Value))
            {
                ShowWarningStatus("Rounded rectangle width must be greater then 2 yRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowCurrentNormalStatus();
        }

        private void roundedRectangleXRadius_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!CheckRoundedRectangleParams(roundedRectangleWidth.Value, e.NewValue))
            {
                ShowWarningStatus("Rounded rectangle width must be greater then 2 xRadiuses.");
                e.KeepOldValue = true;
            }
            else
                ShowCurrentNormalStatus();
        }
        #endregion

        #region MouseHandlers
        private void levelScreen_MouseEnter(object sender, EventArgs e)
        {
            levelScreen.DrawCurrentGameObject = true;
            Cursor = _levelScreenCursor;
        }

        private void levelScreen_MouseLeave(object sender, EventArgs e)
        {
            levelScreen.DrawCurrentGameObject = false;
            Cursor = Cursors.Arrow;
        }

        private void levelScreen_MouseMove(object sender, MouseEventArgs e)
        {
            levelScreen.MouseState = e;
            _objectLevelManager.Simulator.MousePosition = levelScreen.MousePosition;
            _objectLevelManager.Simulator.UpdateMouseJoint();
        }

        private void levelScreen_MouseDown(object sender, MouseEventArgs e)
        {
            _objectLevelManager.Simulator.MousePosition = levelScreen.MousePosition;
            _objectLevelManager.Simulator.CreateMouseJoint();
            levelPage.Focus();
        }

        private void levelScreen_MouseUp(object sender, MouseEventArgs e)
        {
            _objectLevelManager.Simulator.RemoveMouseJoint();
        }

        private void levelScreen_MouseClick(object sender, MouseEventArgs e)
        {
            if (addPreviewObjectAction.Checked)
                _commandManager.Execute("AddPreviewObject");
            if (selectObjectPartAction.Checked)
            {
                levelScreen.GameLevel.World.TestPoint(ConvertUnits.ToSimUnits(Vector2.Transform(levelScreen.MousePosition, Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix()))));
            }
        }
        #endregion

        #region UpdateULPoint
        private void UpdateAbsoluteULPoint(object sender)
        {
            levelScreen.AbsoluteULPoint = new Vector2(-((System.Windows.Forms.TabPage)sender).DisplayRectangle.X, -((System.Windows.Forms.TabPage)sender).DisplayRectangle.Y);    
        }

        private void levelPage_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateAbsoluteULPoint(sender);
        }

        private void levelPage_MouseWheel(object sender, MouseEventArgs e)
        {
            UpdateAbsoluteULPoint(sender);
        }
        #endregion

        #region Actions
        bool _simulateActionState = false;
        private void simulateAction_Execute(object sender, EventArgs e)
        {
            if (!_simulateActionState && _objectLevelManager.Simulator.SimulationSpeed <= 0)
            {
                ShowWarningStatus("Невозможно начать симуляцию с отрицательным или нулевым значением скорости времени. Значение скорости установлено в 1x.");
                _commandManager.Execute("SimulationSpeedNormal");
                return;
            }

            _simulateActionState = !_simulateActionState;
            if (_simulateActionState)
            {
                simulateAction.Text = "Stop";
                simulateAction.ToolTipText = "Stop simulation";
                simulateAction.Image = LevelEditor.Properties.Resources.StopHS;
                pauseSimulationAction.Enabled = true;

                _commandManager.Execute("StartSimulation");

                ShowSimulationStatus();
            }
            else
            {
                simulateAction.Text = "Start";
                simulateAction.ToolTipText = "Start simulation";
                simulateAction.Image = LevelEditor.Properties.Resources.PlayHS;
                pauseSimulationAction.Enabled = false;
                ShowReadyStatus();

                _commandManager.Execute("StopSimulation");
            }

            //Меняем уровень, который отрисовывается
            levelScreen.GameLevel = _objectLevelManager.GameLevel;
            SetDebugViewMenu();
        }

        bool pauseSimulationActionState = false;
        private void pauseSimulationAction_Execute(object sender, EventArgs e)
        {
            pauseSimulationActionState = !pauseSimulationActionState;

            if (pauseSimulationActionState)
            {
                _commandManager.Execute("PauseSimulation");
                pauseSimulationAction.Text = "Continue";
                pauseSimulationAction.ToolTipText = "Continue simulation";
                pauseSimulationAction.Image = LevelEditor.Properties.Resources.ContinueHS;
            }
            else
            {
                _commandManager.Execute("StartSimulation");
                pauseSimulationAction.Text = "Pause";
                pauseSimulationAction.ToolTipText = "Pause simulation";
                pauseSimulationAction.Image = LevelEditor.Properties.Resources.PauseHS;
            }

            ShowSimulationStatus();
        }

        private void addPreviewObjectAction_Execute(object sender, EventArgs e)
        {
            if (addPreviewObjectAction.Checked)
            {
                if (_objectLevelManager.PreviewObject[0].Sprite.Texture != null)
                {
                    levelScreen.PreviewGameObject = _objectLevelManager.PreviewObject;
                    //levelScreen.DrawCurrentGameObject = addPreviewObjectAction.Checked;
                }
                else
                {
                    addPreviewObjectAction.Checked = false;
                    ShowWarningStatus("Необходимо установить текстуру.");
                }
            }
            else
            {
                levelScreen.PreviewGameObject = null;
            }
            SetLevelScreenCursor();
            

        }

        private void selectObjectPartAction_Execute(object sender, EventArgs e)
        {
            SetLevelScreenCursor();
        }



        private void changeSimulationActionState(bool halfAction, bool normalAction, bool doubleAction)
        {
            simulationSpeedNormalAction.Checked = halfAction;
            simulationSpeedHalfAction.Checked = normalAction;
            simulationSpeedDoubleAction.Checked = doubleAction;
        }

        private void simulationSpeedHalfAction_Execute(object sender, EventArgs e)
        {
            changeSimulationActionState(true, false, false);
            _commandManager.Execute("SimulationSpeedHalf");
            ShowSimulationStatus();
        }

        private void simulationSpeedNormalAction_Execute(object sender, EventArgs e)
        {
            changeSimulationActionState(false, true, false);
            _commandManager.Execute("SimulationSpeedNormal");
            ShowSimulationStatus();
        }

        private void simulationSpeedDoubleAction_Execute(object sender, EventArgs e)
        {
            changeSimulationActionState(false, false, true);
            _commandManager.Execute("SimulationSpeedDouble");
            ShowSimulationStatus();
        }

        private void simulationSpeedIncDecChanged()
        {
            if (_objectLevelManager.Simulator.SimulationSpeed == 0.50f)
                changeSimulationActionState(true, false, false);
            else if (_objectLevelManager.Simulator.SimulationSpeed == 1.00f)
                changeSimulationActionState(false, true, false);
            else if (_objectLevelManager.Simulator.SimulationSpeed == 2.00f)
                changeSimulationActionState(false, false, true);
            else
                changeSimulationActionState(false, false, false);

            ShowSimulationStatus();
        }

        private void simulationSpeedIncreaseAction_Execute(object sender, EventArgs e)
        {
            _commandManager.Execute("SimulationSpeedIncrease");
            simulationSpeedIncDecChanged();
        }

        private void simulationSpeedDecreaseAction_Execute(object sender, EventArgs e)
        {
            _commandManager.Execute("SimulationSpeedDecrease");
            simulationSpeedIncDecChanged();
        }


        #endregion
    }
}
