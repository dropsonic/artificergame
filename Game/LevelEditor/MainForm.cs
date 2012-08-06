using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FarseerTools;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics;
using LevelEditor.Commands;
using LevelEditor.Helpers;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Collision.Shapes;
using GameLogic;

namespace LevelEditor
{
    using Color = Microsoft.Xna.Framework.Color;
    using Point = System.Drawing.Point;
    using System.Collections.ObjectModel;


    public partial class MainForm : Form
    {
        const string DefaultFormText = "Level Editor";

        ObjectLevelManager _objectLevelManager;
        CommandManager _commandManager;
        AssetCreator _assetCreator;
        Cursor _levelScreenCursor = Cursors.Arrow;
        MouseToolState _mouseToolState;
        JointCreationHelper _jointHelper;
        FixtureAttachmentHelper _attachmentHelper;
        GridSnap _gridSnap;

        Timer _updateTimer = new Timer();
        Timer _propertyGridTimer = new Timer();

        
        string _currentFileName = null;

        /// <summary>
        /// Имя текущего файла. Если создан новый уровень, то это null.
        /// </summary>
        string CurrentFileName
        {
            get { return _currentFileName; }
            set
            {
                _currentFileName = value;
                if (String.IsNullOrEmpty(value))
                    this.Text = DefaultFormText;
                else
                    this.Text = String.Format("{0} - \"{1}\"", DefaultFormText, value);
            }
        }

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

            this.Text = DefaultFormText; //устанавливаем стандартный заголовок

            SetPropertyGridAttributes();

            _updateTimer.Enabled = false;
            _updateTimer.Tick += new EventHandler(UpdatePreview);
            _updateTimer.Interval = 10;

            _propertyGridTimer.Enabled = false;
            _propertyGridTimer.Tick += (object sen, EventArgs args) => { propertyGrid.Refresh(); };
            _propertyGridTimer.Interval = 100;

            propertyGrid.SelectedObjectsChanged += new EventHandler(propertyGrid_SelectedObjectsChanged);

            ConvertUnits.SetDisplayUnitToSimUnitRatio((float)levelScreen.Size.Height / 100);

            this.shapeParametersControl.SelectedTab = this.emptyTab;

            levelScreen.DrawCurrentGameObject = false;
            objectScreen.DrawCurrentGameObject = false;

            InitializeStatusStrip();

            ShowReadyStatus();
        }
        private void propertyGrid_SelectedObjectsChanged(object sender, EventArgs args)
        {
            ShowSelectedObject(propertyGrid.SelectedObject);
            UpdateAssociatedJointList(propertyGrid.SelectedObject);
        }

        private void SetPropertyGridAttributes()
        {
            TypeDescriptor.AddAttributes(typeof(Body), new Attribute[] { new TypeConverterAttribute(typeof(ExpandableObjectConverter))});
            TypeDescriptor.AddAttributes(typeof(Joint), new Attribute[] { new TypeConverterAttribute(typeof(ExpandableObjectConverter)) });
            TypeDescriptor.AddAttributes(typeof(List<Sprite>), new Attribute[] { new TypeConverterAttribute(typeof(TypeConverters.ExpandableListConverter<Sprite>)) });
            TypeDescriptor.AddAttributes(typeof(ReadOnlyCollection<Joint>), new Attribute[] { new TypeConverterAttribute(typeof(TypeConverters.ExpandableListConverter<Joint>)) });
            TypeDescriptor.AddAttributes(typeof(ReadOnlyCollection<GameObjectPart>), new Attribute[] { new TypeConverterAttribute(typeof(TypeConverters.ExpandableListConverter<GameObjectPart>)) });
            TypeDescriptor.AddAttributes(typeof(ReadOnlyCollection<GameObject>), new Attribute[] { new TypeConverterAttribute(typeof(TypeConverters.ExpandableListConverter<GameObject>)) });
            TypeDescriptor.AddAttributes(typeof(GameObjectPart), new Attribute[] { new TypeConverterAttribute(typeof(ExpandableObjectConverter)) });
            TypeDescriptor.AddAttributes(typeof(GameObject), new Attribute[] { new TypeConverterAttribute(typeof(ExpandableObjectConverter)) });
            TypeDescriptor.AddAttributes(typeof(JointEdge), new Attribute[] { new TypeConverterAttribute(typeof(TypeConverters.ExpandableJointEdgeConverter)) });
        }

        private void associatedJointsList_SelectedValueChanged(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = associatedJointsList.SelectedItem;
        }

        private void createdJointsList_SelectedValueChanged(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = createdJointsList.SelectedItem;
        }

        private void UpdateAssociatedJointList(object selectedObject)
        {
            //возможно стоит показывать вообще все джоинты для данного объекта
            if (propertyGrid.SelectedObject is GameObject)
            {
                associatedJointsList.Items.Clear();
                foreach (Joint joint in _objectLevelManager.GameLevel.Joints)
                    foreach (GameObjectPart part in ((GameObject)propertyGrid.SelectedObject))
                    {
                        JointEdge iterator = part.Body.JointList;
                        while (iterator != null)
                        {
                            if (joint == iterator.Joint)
                                associatedJointsList.Items.Insert(0, iterator.Joint);
                            iterator = iterator.Next;
                        }
                    }
            }
            else if (propertyGrid.SelectedObject is GameObjectPart)
            {
                associatedJointsList.Items.Clear();

                JointEdge iterator = ((GameObjectPart)propertyGrid.SelectedObject).Body.JointList;
                while (iterator != null)
                {
                    associatedJointsList.Items.Insert(0, iterator.Joint);
                    iterator = iterator.Next;
                }
            }
            else if (propertyGrid.SelectedObject is Joint)
            {
                bool sameList = false;
                foreach (Joint joint in associatedJointsList.Items)
                {
                    if (joint == propertyGrid.SelectedObject)
                        sameList = true;
                }
                if (!sameList) associatedJointsList.Items.Clear();
            }
            else if(propertyGrid.SelectedObject == null)
                associatedJointsList.Items.Clear();
        }

        private void InitializeCommandManager()
        {
            _commandManager = new CommandManager();

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
            _mouseToolState = MouseToolState.Default;
            _objectLevelManager = new ObjectLevelManager(levelScreen.Camera, levelScreen.GraphicsDevice);
            _objectLevelManager.Simulator.SimulateChanged += new EventHandler(Simulator_SimulateChanged);
            levelScreen.UpdateSubscriber = _objectLevelManager.Simulator.Update;
            levelScreen.GameLevel = _objectLevelManager.GameLevel;
            objectScreen.GameObject = _objectLevelManager.SeparateEditObject;
            //load assetCreator Materials
            _assetCreator = ContentService.GetContentService().AssetCreator;
            _assetCreator.UseTexture = setAsTextureCheck.Checked;
            _assetCreator.DrawOutline = drawOutlineCheck.Checked;

            foreach (string material in Directory.GetFiles("Content\\" + ContentService.GetMaterial()))
            {
                string filename = System.IO.Path.GetFileNameWithoutExtension(material);
                _assetCreator.LoadMaterial(filename, ContentService.GetContentService().LoadTexture(material));
                materialBox.Items.Add(filename);
            }

            foreach (string shape in Directory.GetFiles("Content\\" + ContentService.GetShape()))
            {
                string filename = System.IO.Path.GetFileNameWithoutExtension(shape);
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

            foreach (JointType joint in Enum.GetValues(typeof(JointType)))
            {
                jointsBox.Items.Add(joint);
            }
            InitializeCommandManager();
            PopulateDebugViewMenu();

            //Если этого не сделать то не будут вовремя вызваны методы initialize наследников GraphicsDeviceControl
            viewTabControl.SelectedIndex = 1;
            viewTabControl.SelectedIndex = 0;

            _gridSnap = new GridSnap();
            objectScreen.GridSnap = _gridSnap;
            levelScreen.GridSnap = _gridSnap;
        }

        /// <summary>
        /// Загружает общие для формы и её элементов настройки.
        /// </summary>
        private void LoadSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;

            this.Location = settings.MainFormLocation;
            this.Size = settings.MainFormSize;
            this.WindowState = settings.MainFormWindowState;

            toolStripContainer.SuspendLayout();
            mainToolStrip.Parent = GetToolStripParentByName(toolStripContainer, settings.mainToolStripParentName);
            mainToolStrip.Location = settings.mainToolStripLocation;
            toolsToolStrip.Parent = GetToolStripParentByName(toolStripContainer, settings.toolsToolStripParentName);
            toolsToolStrip.Location = settings.toolsToolStripLocation;
            simulationToolStrip.Parent = GetToolStripParentByName(toolStripContainer, settings.simulationToolStripParentName);
            simulationToolStrip.Location = settings.simulationToolStripLocation;
            toolStripContainer.ResumeLayout(true);
        }

        /// <summary>
        /// Сохраняет общие для формы и её элементов настройки.
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;

            if (this.Location.X < 0 || this.Location.Y < 0)
                settings.MainFormLocation = new System.Drawing.Point(0, 0);
            else
                settings.MainFormLocation = this.Location;

            if (this.WindowState == FormWindowState.Minimized)
                settings.MainFormWindowState = FormWindowState.Normal;
            else
                settings.MainFormWindowState = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)
                settings.MainFormSize = this.Size;
            else
                settings.MainFormSize = this.RestoreBounds.Size;

            settings.mainToolStripLocation = mainToolStrip.Location;
            settings.mainToolStripParentName = GetToolStripParentName(mainToolStrip);
            settings.toolsToolStripLocation = toolsToolStrip.Location;
            settings.toolsToolStripParentName = GetToolStripParentName(toolsToolStrip);
            settings.simulationToolStripLocation = simulationToolStrip.Location;
            settings.simulationToolStripParentName = GetToolStripParentName(simulationToolStrip);
        }

        private string GetToolStripParentName(ToolStrip toolStrip)
        {
            var panel = toolStrip.Parent as ToolStripPanel;
            var defaultName = String.Empty;
            if (panel == null)
                return defaultName;
            var container = panel.Parent as ToolStripContainer;
            if (container == null)
                return defaultName;
            if (panel == container.LeftToolStripPanel)
                return "LeftToolStripPanel";
            if (panel == container.RightToolStripPanel)
                return "RightToolStripPanel";
            if (panel == container.TopToolStripPanel)
                return "TopToolStripPanel";
            if (panel == container.BottomToolStripPanel)
                return "BottomToolStripPanel";
            return defaultName;
        }

        private ToolStripPanel GetToolStripParentByName(ToolStripContainer container, string parentName)
        {
            if (parentName == "LeftToolStripPanel")
                return container.LeftToolStripPanel;
            if (parentName == "RightToolStripPanel")
                return container.RightToolStripPanel;
            if (parentName == "TopToolStripPanel")
                return container.TopToolStripPanel;
            if (parentName == "BottomToolStripPanel")
                return container.BottomToolStripPanel;
            return null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeAfterLoad();
            LoadSettings();
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
            if (_objectLevelManager.Simulator.State == SimulationState.Stopped)
            {
                PropertyDescriptor propertyDescriptor = e.ChangedItem.PropertyDescriptor;
                object selectedObject = propertyGrid.SelectedObject;
                
               
                //TODO: исправить: вылетает при вызове этой ф-ии: propertyDescriptor.GetValue(selectedObject);
                //_commandManager.Execute(new PropertyGridChangeParamCommand(selectedObject, propertyDescriptor, e.OldValue, propertyDescriptor.GetValue(selectedObject), () => propertyGrid.Refresh()));
            }
            
            propertyGrid.Refresh();
        }

        private void jointsBox_SelectedValueChanged(object sender, EventArgs e)
        {
            addNewJointAction.Checked = true;
            SetMouseToolButtonsState(addNewJointAction);
        }

        private void ShowSelectedObject(object selectedObject)
        {
            objectScreen.SelectedItemsDisplay.SelectedItem = levelScreen.SelectedItemsDisplay.SelectedItem = null;
            if (viewTabControl.SelectedTab == levelPage)
            {
                levelScreen.SelectedItemsDisplay.SelectedItem = selectedObject;
            }
            else
            {
                objectScreen.SelectedItemsDisplay.SelectedItem = selectedObject;
            }
        }

        private void viewTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCreatedJointList(true);
            associatedJointsList.Items.Clear();
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
            _updateTimer.Enabled = true;
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

            _updateTimer.Enabled = false;
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

        private void ShowLevelScreenMousePosition()
        {
            Vector2 pos = ConvertUnits.ToSimUnits(levelScreen.MousePosition);
            toolStripMousePosLabel.Text = String.Format("(X={0:0.00}, Y={1:0.00})", pos.X, pos.Y);
        }

        private void ShowObjectScreenMousePosition()
        {
            Vector2 pos = ConvertUnits.ToSimUnits(objectScreen.MousePosition);
            toolStripMousePosLabel.Text = String.Format("(X={0:0.00}, Y={1:0.00})", pos.X, pos.Y);
        }

        private void levelScreen_MouseEnter(object sender, EventArgs e)
        {
            levelScreen.DrawCurrentGameObject = true;
            Cursor = _levelScreenCursor;
            ShowLevelScreenMousePosition();
        }

        private void levelScreen_MouseLeave(object sender, EventArgs e)
        {
            levelScreen.DrawCurrentGameObject = false;
            Cursor = Cursors.Arrow;

            toolStripMousePosLabel.Text = String.Empty;
        }

        private void levelScreen_MouseMove(object sender, MouseEventArgs e)
        {
            Point snappedPoint = _gridSnap.SnapToGrid(e.Location);
            levelScreen.MousePosition = new Vector2(snappedPoint.X, snappedPoint.Y);
            _objectLevelManager.Simulator.MousePosition = new Vector2(e.X,e.Y);
            ShowLevelScreenMousePosition();
            HandleLevelScreenMouseInput(MouseEvents.Move, e);
        }

        private void levelScreen_MouseDown(object sender, MouseEventArgs e)
        {
            HandleLevelScreenMouseInput(MouseEvents.Down, e);
        }

        private void levelScreen_MouseUp(object sender, MouseEventArgs e)
        {
            HandleLevelScreenMouseInput(MouseEvents.Up, e);
        }

        private void levelScreen_MouseClick(object sender, MouseEventArgs e)
        {
            HandleLevelScreenMouseInput(MouseEvents.Click, e);
        }

        GameObject movingObject;
        GameObjectPart movingPart;
        Vector2 previousPosition;
        private void HandleLevelScreenMouseInput(MouseEvents mouseEvent,MouseEventArgs args)
        {
            //TODO: для каждого типа своя ф-ия с передачей mouseEvent
            switch (_mouseToolState)
            {
                case MouseToolState.Default:
                    break;

                case MouseToolState.MouseJoint:
                    switch (mouseEvent)
                    {
                        case MouseEvents.Down:
                            {
                                _objectLevelManager.Simulator.CreateMouseJoint();
                                levelPage.Focus();
                                break;
                            }
                        case MouseEvents.Up:
                            {
                                _objectLevelManager.Simulator.RemoveMouseJoint();
                                break;
                            }
                        case MouseEvents.Move:
                            {
                                _objectLevelManager.Simulator.UpdateMouseJoint();
                                break;
                            }
                    }
                    break;

                case MouseToolState.PlaceObject:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        _commandManager.Execute(new AddObjectCommand(_objectLevelManager.PreviewObject, _objectLevelManager.GameLevel, levelScreen.MousePosition));
                    }
                    break;
                    

                case MouseToolState.SelectObject:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        propertyGrid.SelectedObject = CommonHelpers.FindGameObject(ConvertUnits.ToSimUnits(Vector2.Transform(levelScreen.MousePosition, Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix()))), _objectLevelManager.GameLevel);
                    }
                    if (mouseEvent == MouseEvents.Down)
                    {
                        previousPosition = ConvertUnits.ToSimUnits(Vector2.Transform(levelScreen.MousePosition, Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix())));
                        GameObject foundObject = CommonHelpers.FindGameObject(previousPosition, _objectLevelManager.GameLevel);
                        if (foundObject == propertyGrid.SelectedObject)
                            movingObject = foundObject;
                    }
                    if (mouseEvent == MouseEvents.Move)
                    {
                        if (movingObject != null)
                        {
                            Vector2 currentPosition = ConvertUnits.ToSimUnits(Vector2.Transform(levelScreen.MousePosition, Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix())));
                            Vector2 delta = currentPosition - previousPosition;
                            previousPosition = currentPosition;
                            foreach (GameObjectPart gop in movingObject)
                            {
                                gop.Body.Position = currentPosition;
                            }
                        }
                    }
                    if (mouseEvent == MouseEvents.Up)
                    {
                        movingObject = null;
                    }
                    break;

                case MouseToolState.SelectObjectPart:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        propertyGrid.SelectedObject = CommonHelpers.FindGameObjectPart(ConvertUnits.ToSimUnits(Vector2.Transform(levelScreen.MousePosition, Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix()))), _objectLevelManager.GameLevel);
                    }
                    if (mouseEvent == MouseEvents.Down)
                    {
                        previousPosition = ConvertUnits.ToSimUnits(Vector2.Transform(levelScreen.MousePosition, Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix())));
                        GameObjectPart foundPart = CommonHelpers.FindGameObjectPart(previousPosition, _objectLevelManager.GameLevel);
                        if (foundPart == propertyGrid.SelectedObject)
                            movingPart = foundPart;
                    }
                    if (mouseEvent == MouseEvents.Move)
                    {
                        if (movingPart != null)
                        {
                            Vector2 currentPosition = ConvertUnits.ToSimUnits(Vector2.Transform(levelScreen.MousePosition, Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix())));
                            Vector2 delta = currentPosition - previousPosition;
                            previousPosition = currentPosition;
                            movingPart.Body.Position += delta;
                        }
                    }
                    if (mouseEvent == MouseEvents.Up)
                    {
                        movingPart = null;
                    }
                    break;
                    
                case MouseToolState.PlaceJoint:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        if (_jointHelper != null)
                        {
                            Vector2 simPosition = ConvertUnits.ToSimUnits(Vector2.Transform(new Vector2(args.X, args.Y), Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix())));
                            _jointHelper.NextStep(simPosition);
                            ShowTooltipStatus(_jointHelper.CurrentStateMessage);
                            if (_jointHelper.CreatedJoint != null)
                            {
                                _commandManager.Execute(new Commands.AddLevelJointCommand(_objectLevelManager.GameLevel, _jointHelper.CreatedJoint));
                                UpdateCreatedJointList(false);
                                createdJointsList.SelectedIndex = 0;
                                propertyGrid.SelectedObject = createdJointsList.Items[0];
                            }
                        }
                    }
                    break;
                case MouseToolState.AttachFixture:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        if (_attachmentHelper != null)
                        {
                            Vector2 simPosition = ConvertUnits.ToSimUnits(Vector2.Transform(new Vector2(args.X, args.Y), Matrix.Invert(levelScreen.GameLevel.Camera.GetViewMatrix())));
                            _attachmentHelper.NextStep(simPosition);
                            HandlePreviewDisplay();
                            ShowTooltipStatus(_attachmentHelper.StatusMessage);
                            if (_attachmentHelper.Finished)
                            {
                                Body body;
                                List<Shape> shapes;
                                _attachmentHelper.GetAttachmentResult(out body, out shapes);

                                Vector2 offset = Vector2.Transform(ConvertUnits.ToDisplayUnits(body.Position) - new Vector2(args.X, args.Y), Matrix.CreateRotationZ(-body.Rotation));
                                Texture2D rotatedTexture = ((-body.Rotation + _objectLevelManager.PreviewObject[0].Body.Rotation)==0) ? 
                                                                                        _objectLevelManager.PreviewObject[0].Sprites[0].Texture :
                                                                                        _assetCreator.CreateRotatedTexture(_objectLevelManager.PreviewObject[0].Sprites[0], -body.Rotation + _objectLevelManager.PreviewObject[0].Body.Rotation);
                                _commandManager.Execute(new Commands.AttachFixtureCommand(_objectLevelManager.GameLevel, body, shapes, new Sprite(rotatedTexture,offset)));
                            }
                        }
                    }
                    break;
            }
        }

        private void objectScreen_MouseEnter(object sender, EventArgs e)
        {
            objectScreen.DrawCurrentGameObject = true;
            Cursor = _levelScreenCursor;
            ShowObjectScreenMousePosition();
        }

        private void objectScreen_MouseLeave(object sender, EventArgs e)
        {
            objectScreen.DrawCurrentGameObject = false;
            Cursor = Cursors.Arrow;
            toolStripMousePosLabel.Text = String.Empty;
        }

        private void objectScreen_MouseMove(object sender, MouseEventArgs e)
        {
            Point snappedPoint = _gridSnap.SnapToGrid(e.Location);
            objectScreen.MousePosition = new Vector2(snappedPoint.X, snappedPoint.Y);
            ShowObjectScreenMousePosition();
            HandleObjectScreenMouseInput(MouseEvents.Move, e);
        }

        private void objectScreen_MouseClick(object sender, MouseEventArgs e)
        {
            HandleObjectScreenMouseInput(MouseEvents.Click, e);
        }

        private void objectScreen_MouseUp(object sender, MouseEventArgs e)
        {
            HandleObjectScreenMouseInput(MouseEvents.Up, e);
        }

        private void objectScreen_MouseDown(object sender, MouseEventArgs e)
        {
            HandleObjectScreenMouseInput(MouseEvents.Down, e);
        }

        private void HandleObjectScreenMouseInput(MouseEvents mouseEvent, MouseEventArgs args)
        {
            //TODO: для каждого типа своя ф-ия с передачей mouseEvent
            switch (_mouseToolState)
            {
                case MouseToolState.Default:
                    break;

                case MouseToolState.MouseJoint:
                    break;

                case MouseToolState.PlaceObject:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        _commandManager.Execute(new AddObjectPartCommand(_objectLevelManager.PreviewObject, _objectLevelManager.SeparateEditObject, ConvertUnits.ToSimUnits(objectScreen.MousePosition)));
                    }
                    break;

                case MouseToolState.SelectObject:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        propertyGrid.SelectedObject = objectScreen.GameObject;
                    }
                    if (mouseEvent == MouseEvents.Down)
                    {
                        if(objectScreen.GameObject == propertyGrid.SelectedObject)
                            movingObject = objectScreen.GameObject;
                        previousPosition = ConvertUnits.ToSimUnits(Vector2.Transform(objectScreen.MousePosition, Matrix.Invert(objectScreen.Camera.GetViewMatrix())));
                    }
                    if (mouseEvent == MouseEvents.Move)
                    {
                        if (movingObject != null)
                        {
                            Vector2 currentPosition = ConvertUnits.ToSimUnits(Vector2.Transform(objectScreen.MousePosition, Matrix.Invert(objectScreen.Camera.GetViewMatrix())));
                            Vector2 delta = currentPosition - previousPosition;
                            previousPosition = currentPosition;
                            foreach (GameObjectPart gop in movingObject)
                            {
                                gop.Body.Position += delta;
                                
                            }
                        }
                    }
                    if (mouseEvent == MouseEvents.Up)
                    {
                        movingObject = null;
                    }
                    break;

                case MouseToolState.SelectObjectPart:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        propertyGrid.SelectedObject = CommonHelpers.FindGameObjectPart(ConvertUnits.ToSimUnits(Vector2.Transform(objectScreen.MousePosition, Matrix.Invert(objectScreen.Camera.GetViewMatrix()))), _objectLevelManager.SeparateEditObject);
                    }
                    if (mouseEvent == MouseEvents.Down)
                    {
                        previousPosition = ConvertUnits.ToSimUnits(Vector2.Transform(objectScreen.MousePosition, Matrix.Invert(objectScreen.Camera.GetViewMatrix())));
                        GameObjectPart foundPart = CommonHelpers.FindGameObjectPart(previousPosition, _objectLevelManager.SeparateEditObject);
                        if (foundPart == propertyGrid.SelectedObject)
                            movingPart = foundPart;
                    }
                    if (mouseEvent == MouseEvents.Move)
                    {
                        if (movingPart != null)
                        {
                            Vector2 currentPosition = ConvertUnits.ToSimUnits(Vector2.Transform(objectScreen.MousePosition, Matrix.Invert(objectScreen.Camera.GetViewMatrix())));
                            Vector2 delta = currentPosition - previousPosition;
                            previousPosition = currentPosition;
                            movingPart.Body.Position += delta;
                        }
                    }
                    if (mouseEvent == MouseEvents.Up)
                    {
                        movingPart = null;
                    }
                    break;

                case MouseToolState.PlaceJoint:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        if (_jointHelper != null)
                        {
                            Vector2 simPosition = ConvertUnits.ToSimUnits(Vector2.Transform(new Vector2(args.X, args.Y), Matrix.Invert(objectScreen.Camera.GetViewMatrix())));
                            _jointHelper.NextStep(simPosition);
                            ShowTooltipStatus(_jointHelper.CurrentStateMessage);
                            if (_jointHelper.CreatedJoint != null)
                            {
                                _commandManager.Execute(new Commands.AddObjectJointCommand(_objectLevelManager.SeparateEditObject, _jointHelper.CreatedJoint));
                                UpdateCreatedJointList(false);
                                createdJointsList.SelectedIndex = 0;
                                propertyGrid.SelectedObject = createdJointsList.Items[0];
                            }
                        }
                    }
                    break;
                case MouseToolState.AttachFixture:
                    if (mouseEvent == MouseEvents.Click)
                    {
                        if (_attachmentHelper != null)
                        {
                            Vector2 simPosition = ConvertUnits.ToSimUnits(Vector2.Transform(new Vector2(args.X, args.Y), Matrix.Invert(objectScreen.Camera.GetViewMatrix())));
                            _attachmentHelper.NextStep(simPosition);
                            HandlePreviewDisplay();
                            ShowTooltipStatus(_attachmentHelper.StatusMessage);
                            if (_attachmentHelper.Finished)
                            {
                                Body body;
                                List<Shape> shapes;
                                _attachmentHelper.GetAttachmentResult(out body, out shapes);

                                Vector2 offset = Vector2.Transform(ConvertUnits.ToDisplayUnits(body.Position) - new Vector2(args.X, args.Y), Matrix.CreateRotationZ(-body.Rotation));
                                Texture2D rotatedTexture = ((-body.Rotation + _objectLevelManager.PreviewObject[0].Body.Rotation) == 0) ?
                                                                                        _objectLevelManager.PreviewObject[0].Sprites[0].Texture :
                                                                                        _assetCreator.CreateRotatedTexture(_objectLevelManager.PreviewObject[0].Sprites[0], -body.Rotation + _objectLevelManager.PreviewObject[0].Body.Rotation);
                                _commandManager.Execute(new Commands.AttachGameObjectFixtureCommand(_objectLevelManager.SeparateEditObject, body, shapes, new Sprite(rotatedTexture, offset)));
                            }
                        }
                    }
                    break;
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
                _commandManager.Execute("StartSimulation");
            else
                _commandManager.Execute("StopSimulation");

            //Меняем уровень, который отрисовывается
            levelScreen.GameLevel = _objectLevelManager.GameLevel;
            SetDebugViewMenu();
            HandlePreviewDisplay();
        }

        void Simulator_SimulateChanged(object sender, EventArgs e)
        {
            if (_objectLevelManager.Simulator.State == SimulationState.Stopped)
            {
                simulateAction.Text = "Start";
                simulateAction.ToolTipText = "Start simulation";
                simulateAction.Image = LevelEditor.Properties.Resources.PlayHS;
                pauseSimulationAction.Enabled = false;
                ShowReadyStatus();

                _propertyGridTimer.Enabled = false;
                propertyGrid.SelectedObject = false;
                createdJointsList.SelectedItem = null;
            }
            else
            {
                simulateAction.Text = "Stop";
                simulateAction.ToolTipText = "Stop simulation";
                simulateAction.Image = LevelEditor.Properties.Resources.StopHS;
                pauseSimulationAction.Enabled = true;

                _propertyGridTimer.Enabled = true;
                SwitchToSimulation();

                ShowSimulationStatus();
            }
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
            SetMouseToolButtonsState(addPreviewObjectAction);
        }

        private void selectObjectPartAction_Execute(object sender, EventArgs e)
        {
            SetMouseToolButtonsState(selectObjectPartAction);
        }

        private void selectObjectAction_Execute(object sender, EventArgs e)
        {
            SetMouseToolButtonsState(selectObjectAction);
        }

        private void useMouseJointAction_Execute(object sender, EventArgs e)
        {
            SetMouseToolButtonsState(useMouseJointAction);
        }

        private void editCurrentObjectAction_Execute(object sender, EventArgs e)
        {
            SetMouseToolButtonsState(editCurrentObjectAction);
        }

        private void attachFixtureAction_Execute(object sender, EventArgs e)
        {
            SetMouseToolButtonsState(attachFixture);
        }

        private void addNewJointAction_Execute(object sender, EventArgs e)
        {
            SetMouseToolButtonsState(addNewJointAction);
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

        private void resetSettingsAction_Execute(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            LoadSettings();
        }

        private void undoAction_Execute(object sender, EventArgs e)
        {
            _commandManager.Undo();
            UpdateCreatedJointList(false);
        }

        private void undoAction_Update(object sender, EventArgs e)
        {
            if (undoAction.Enabled != _commandManager.CanUndo)
                undoAction.Enabled = _commandManager.CanUndo;
        }

        private void redoAction_Execute(object sender, EventArgs e)
        {
            _commandManager.Redo();
            UpdateCreatedJointList(false);
        }

        private void redoAction_Update(object sender, EventArgs e)
        {
            if (redoAction.Enabled != _commandManager.CanRedo)
                redoAction.Enabled = _commandManager.CanRedo;
        }


        private void openLevelAction_Execute(object sender, EventArgs e)
        {
            pauseSimulationAction.DoExecute();
            if (openLevelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_objectLevelManager.Simulator.State != SimulationState.Stopped)
                    simulateAction.DoExecute();

                try
                {
                    _commandManager.Execute(new OpenLevelCommand(openLevelDialog.FileName, _objectLevelManager));
                    _currentFileName = openLevelDialog.FileName;
                }
                catch (Exception ex)
                {
                    ShowErrorStatus(ex);
                }
            }
        }

        private DialogResult fileExistsCallback(string fileName)
        {
            return MessageBox.Show(String.Format("\"{0}\" already exists. Overwrite?", Path.GetFileName(fileName)), "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void saveLevelAction_Execute(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_currentFileName))
            {
                try
                {
                    _commandManager.Execute(new SaveLevelCommand(_currentFileName, _objectLevelManager.GameLevel));
                }
                catch (Exception ex)
                {
                    ShowErrorStatus(ex);
                }
            }
        }

        private void saveLevelAction_Update(object sender, EventArgs e)
        {
            bool newValue;
            if (String.IsNullOrEmpty(_currentFileName))
                newValue = false;
            else
                newValue = true;

            if (saveLevelAction.Enabled != newValue)
                saveLevelAction.Enabled = newValue;
        }

        private void saveAsLevelAction_Execute(object sender, EventArgs e)
        {
            pauseSimulationAction.DoExecute();
            if (saveLevelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_objectLevelManager.Simulator.State != SimulationState.Stopped)
                    simulateAction.DoExecute();

                try
                {
                    _commandManager.Execute(new SaveLevelCommand(saveLevelDialog.FileName, _objectLevelManager.GameLevel, fileExistsCallback));
                    _currentFileName = saveLevelDialog.FileName;
                }
                catch (Exception ex)
                {
                    ShowErrorStatus(ex);
                }
            }
        }

        private void exportLevelAction_Execute(object sender, EventArgs e)
        {

        }

        private void drawAssociatedJoints_Execute(object sender, EventArgs e)
        {
            levelScreen.SelectedItemsDisplay.DrawAssociatedJoints = drawAssociatedJoints.Checked;
            objectScreen.SelectedItemsDisplay.DrawAssociatedJoints = drawAssociatedJoints.Checked;
            ShowSelectedObject(propertyGrid.SelectedObject);
        }

        private void setLevelParametersAction_Execute(object sender, EventArgs e)
        {
            LevelScreenOptionsForm options = new LevelScreenOptionsForm(levelScreen.Size.Width, levelScreen.Size.Height, (int)ConvertUnits.ToSimUnits(levelScreen.Size.Height),_objectLevelManager.Simulator.GameLevel.World.Gravity.X,_objectLevelManager.Simulator.GameLevel.World.Gravity.Y);
            if (options.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                levelScreen.Width = options.Width;
                levelScreen.Height = options.Height;
                ConvertUnits.SetDisplayUnitToSimUnitRatio((float)levelScreen.Size.Height / (float)options.HeightInMeters);
                _objectLevelManager.Simulator.GameLevel.World.Gravity.X = options.GravityX;
                _objectLevelManager.Simulator.GameLevel.World.Gravity.Y = options.GravityY;
            }
        }

        private void clearLevelAction_Execute(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clear level?", "Level Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _objectLevelManager = new ObjectLevelManager(levelScreen.Camera, levelScreen.GraphicsDevice);
                _objectLevelManager.Simulator.SimulateChanged += new EventHandler(Simulator_SimulateChanged);
                levelScreen.UpdateSubscriber = _objectLevelManager.Simulator.Update;
                levelScreen.GameLevel = _objectLevelManager.GameLevel;
                objectScreen.GameObject = _objectLevelManager.SeparateEditObject;
                CreatePreview();
            }
        }

        private void setGridSnapAction_Execute(object sender, EventArgs e)
        {
            GridSnapOptions options = new GridSnapOptions(_gridSnap.GridWidth, _gridSnap.GridHeight, _gridSnap.InMeters);
            if (options.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _gridSnap.GridWidth = options.GridWidth;
                _gridSnap.GridHeight = options.GridHeight;
                _gridSnap.InMeters = options.InMeters;
            }
        }

        private void switchGridSnapAction_Execute(object sender, EventArgs e)
        {
            _gridSnap.Enabled = switchGridSnapAction.Checked;
        }

        private void changeLevelPropertiesAction_Execute(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = _objectLevelManager.GameLevel;
        }
        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if(propertyGrid.SelectedObject is GameObject)
                {
                    _commandManager.Execute(new RemoveObjectCommand((GameObject)propertyGrid.SelectedObject, _objectLevelManager.GameLevel));
                    propertyGrid.SelectedObject = null;
                }
                UpdateCreatedJointList(false);
            }

            
        }
    }
}
