using LevelEditor;
namespace LevelEditor
{
    partial class MainForm
    {
        
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMousePosLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.paramsTabControl = new System.Windows.Forms.TabControl();
            this.previewPage = new System.Windows.Forms.TabPage();
            this.previewScreen = new LevelEditor.PreviewScreen();
            this.shapeParameters = new System.Windows.Forms.GroupBox();
            this.shapeParametersControl = new WindowsFormsApplication1.TabHiddenHeadersControl();
            this.circleTab = new System.Windows.Forms.TabPage();
            this.circleRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label5 = new System.Windows.Forms.Label();
            this.ellipseTab = new System.Windows.Forms.TabPage();
            this.ellipseNumberOfEdges = new System.Windows.Forms.NumericUpDownEx();
            this.label8 = new System.Windows.Forms.Label();
            this.ellipseYRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label7 = new System.Windows.Forms.Label();
            this.ellipseXRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label6 = new System.Windows.Forms.Label();
            this.arcTab = new System.Windows.Forms.TabPage();
            this.arcRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label9 = new System.Windows.Forms.Label();
            this.arcSides = new System.Windows.Forms.NumericUpDownEx();
            this.label10 = new System.Windows.Forms.Label();
            this.arcDegrees = new System.Windows.Forms.NumericUpDownEx();
            this.label11 = new System.Windows.Forms.Label();
            this.gearTab = new System.Windows.Forms.TabPage();
            this.gearToothHeight = new System.Windows.Forms.NumericUpDownEx();
            this.label15 = new System.Windows.Forms.Label();
            this.gearTipPercentage = new System.Windows.Forms.NumericUpDownEx();
            this.label12 = new System.Windows.Forms.Label();
            this.gearNumberOfTeeth = new System.Windows.Forms.NumericUpDownEx();
            this.label13 = new System.Windows.Forms.Label();
            this.gearRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label14 = new System.Windows.Forms.Label();
            this.capsuleTab = new System.Windows.Forms.TabPage();
            this.capsuleBottomEdges = new System.Windows.Forms.NumericUpDownEx();
            this.label20 = new System.Windows.Forms.Label();
            this.capsuleBottomRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label16 = new System.Windows.Forms.Label();
            this.capsuleTopEdges = new System.Windows.Forms.NumericUpDownEx();
            this.label17 = new System.Windows.Forms.Label();
            this.capsuleTopRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label18 = new System.Windows.Forms.Label();
            this.capsuleHeight = new System.Windows.Forms.NumericUpDownEx();
            this.label19 = new System.Windows.Forms.Label();
            this.rectangleTab = new System.Windows.Forms.TabPage();
            this.rectangleWidth = new System.Windows.Forms.NumericUpDownEx();
            this.label21 = new System.Windows.Forms.Label();
            this.rectangleHeight = new System.Windows.Forms.NumericUpDownEx();
            this.label22 = new System.Windows.Forms.Label();
            this.roundedRectangleTab = new System.Windows.Forms.TabPage();
            this.roundedRectangleYRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label23 = new System.Windows.Forms.Label();
            this.roundedRectangleXRadius = new System.Windows.Forms.NumericUpDownEx();
            this.label24 = new System.Windows.Forms.Label();
            this.roundedRectangleHeight = new System.Windows.Forms.NumericUpDownEx();
            this.label25 = new System.Windows.Forms.Label();
            this.roundedRectangleWidth = new System.Windows.Forms.NumericUpDownEx();
            this.label26 = new System.Windows.Forms.Label();
            this.roundedRectangleSegments = new System.Windows.Forms.NumericUpDownEx();
            this.label27 = new System.Windows.Forms.Label();
            this.customShapeTab = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.shapeFromTextureBox = new System.Windows.Forms.ComboBox();
            this.useOriginalTextureCheck = new System.Windows.Forms.CheckBox();
            this.customShapeScale = new System.Windows.Forms.NumericUpDownEx();
            this.label28 = new System.Windows.Forms.Label();
            this.emptyTab = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.commonParameters = new System.Windows.Forms.GroupBox();
            this.drawOutlineCheck = new System.Windows.Forms.CheckBox();
            this.setAsTextureCheck = new System.Windows.Forms.CheckBox();
            this.materialScale = new System.Windows.Forms.NumericUpDownEx();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.materialBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeBox = new System.Windows.Forms.ComboBox();
            this.jointPage = new System.Windows.Forms.TabPage();
            this.createdJointsList = new System.Windows.Forms.ListBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.jointsBox = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.viewTabControl = new System.Windows.Forms.TabControl();
            this.levelPage = new System.Windows.Forms.TabPage();
            this.levelScreen = new LevelEditor.LevelScreen();
            this.objectTab = new System.Windows.Forms.TabPage();
            this.objectScreen = new LevelEditor.LevelScreen();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationSpeedHalfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationSpeedNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationSpeedDoubleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationSpeedIncreaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationSpeedDecreaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.simulationToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.simulationSpeedToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.actionList = new Crad.Windows.Forms.Actions.ActionList();
            this.undoAction = new Crad.Windows.Forms.Actions.Action();
            this.redoAction = new Crad.Windows.Forms.Actions.Action();
            this.simulateAction = new Crad.Windows.Forms.Actions.Action();
            this.pauseSimulationAction = new Crad.Windows.Forms.Actions.Action();
            this.simulationSpeedHalfAction = new Crad.Windows.Forms.Actions.Action();
            this.simulationSpeedNormalAction = new Crad.Windows.Forms.Actions.Action();
            this.simulationSpeedDoubleAction = new Crad.Windows.Forms.Actions.Action();
            this.simulationSpeedIncreaseAction = new Crad.Windows.Forms.Actions.Action();
            this.simulationSpeedDecreaseAction = new Crad.Windows.Forms.Actions.Action();
            this.resetSettingsAction = new Crad.Windows.Forms.Actions.Action();
            this.addPreviewObjectAction = new Crad.Windows.Forms.Actions.Action();
            this.editCurrentObjectAction = new Crad.Windows.Forms.Actions.Action();
            this.addNewJointAction = new Crad.Windows.Forms.Actions.Action();
            this.editJointAction = new Crad.Windows.Forms.Actions.Action();
            this.selectObjectPartAction = new Crad.Windows.Forms.Actions.Action();
            this.selectObjectAction = new Crad.Windows.Forms.Actions.Action();
            this.useMouseJointAction = new Crad.Windows.Forms.Actions.Action();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.paramsTabControl.SuspendLayout();
            this.previewPage.SuspendLayout();
            this.shapeParameters.SuspendLayout();
            this.shapeParametersControl.SuspendLayout();
            this.circleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circleRadius)).BeginInit();
            this.ellipseTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseNumberOfEdges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseYRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseXRadius)).BeginInit();
            this.arcTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcSides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcDegrees)).BeginInit();
            this.gearTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gearToothHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearTipPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearNumberOfTeeth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearRadius)).BeginInit();
            this.capsuleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleBottomEdges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleBottomRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleTopEdges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleTopRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleHeight)).BeginInit();
            this.rectangleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleHeight)).BeginInit();
            this.roundedRectangleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleYRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleXRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleSegments)).BeginInit();
            this.customShapeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customShapeScale)).BeginInit();
            this.emptyTab.SuspendLayout();
            this.commonParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialScale)).BeginInit();
            this.jointPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.viewTabControl.SuspendLayout();
            this.levelPage.SuspendLayout();
            this.objectTab.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.toolsToolStrip.SuspendLayout();
            this.simulationToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.tableLayoutPanel);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1444, 765);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1444, 861);
            this.toolStripContainer.TabIndex = 7;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolsToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.simulationToolStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripMousePosLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1444, 22);
            this.statusStrip.TabIndex = 7;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(1279, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "Ready.";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMousePosLabel
            // 
            this.toolStripMousePosLabel.AutoSize = false;
            this.toolStripMousePosLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMousePosLabel.Name = "toolStripMousePosLabel";
            this.toolStripMousePosLabel.Size = new System.Drawing.Size(150, 17);
            this.toolStripMousePosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMousePosLabel.ToolTipText = "Mouse position";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.paramsTabControl, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1444, 765);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // paramsTabControl
            // 
            this.paramsTabControl.Controls.Add(this.previewPage);
            this.paramsTabControl.Controls.Add(this.jointPage);
            this.paramsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramsTabControl.Location = new System.Drawing.Point(3, 3);
            this.paramsTabControl.Name = "paramsTabControl";
            this.paramsTabControl.SelectedIndex = 0;
            this.paramsTabControl.Size = new System.Drawing.Size(314, 759);
            this.paramsTabControl.TabIndex = 0;
            // 
            // previewPage
            // 
            this.previewPage.Controls.Add(this.previewScreen);
            this.previewPage.Controls.Add(this.shapeParameters);
            this.previewPage.Controls.Add(this.commonParameters);
            this.previewPage.Controls.Add(this.label1);
            this.previewPage.Controls.Add(this.shapeBox);
            this.previewPage.Location = new System.Drawing.Point(4, 22);
            this.previewPage.Name = "previewPage";
            this.previewPage.Padding = new System.Windows.Forms.Padding(3);
            this.previewPage.Size = new System.Drawing.Size(306, 733);
            this.previewPage.TabIndex = 0;
            this.previewPage.Text = "Preview";
            this.previewPage.UseVisualStyleBackColor = true;
            // 
            // previewScreen
            // 
            this.previewScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.previewScreen.Location = new System.Drawing.Point(3, 3);
            this.previewScreen.Name = "previewScreen";
            this.previewScreen.Size = new System.Drawing.Size(300, 300);
            this.previewScreen.TabIndex = 12;
            this.previewScreen.Text = "previewScreen";
            // 
            // shapeParameters
            // 
            this.shapeParameters.Controls.Add(this.shapeParametersControl);
            this.shapeParameters.Location = new System.Drawing.Point(6, 496);
            this.shapeParameters.Name = "shapeParameters";
            this.shapeParameters.Size = new System.Drawing.Size(284, 212);
            this.shapeParameters.TabIndex = 8;
            this.shapeParameters.TabStop = false;
            this.shapeParameters.Text = "Shape Parameters";
            // 
            // shapeParametersControl
            // 
            this.shapeParametersControl.Controls.Add(this.circleTab);
            this.shapeParametersControl.Controls.Add(this.ellipseTab);
            this.shapeParametersControl.Controls.Add(this.arcTab);
            this.shapeParametersControl.Controls.Add(this.gearTab);
            this.shapeParametersControl.Controls.Add(this.capsuleTab);
            this.shapeParametersControl.Controls.Add(this.rectangleTab);
            this.shapeParametersControl.Controls.Add(this.roundedRectangleTab);
            this.shapeParametersControl.Controls.Add(this.customShapeTab);
            this.shapeParametersControl.Controls.Add(this.emptyTab);
            this.shapeParametersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shapeParametersControl.Location = new System.Drawing.Point(3, 16);
            this.shapeParametersControl.Margin = new System.Windows.Forms.Padding(0);
            this.shapeParametersControl.Multiline = true;
            this.shapeParametersControl.Name = "shapeParametersControl";
            this.shapeParametersControl.SelectedIndex = 0;
            this.shapeParametersControl.Size = new System.Drawing.Size(278, 193);
            this.shapeParametersControl.TabIndex = 0;
            // 
            // circleTab
            // 
            this.circleTab.Controls.Add(this.circleRadius);
            this.circleTab.Controls.Add(this.label5);
            this.circleTab.Location = new System.Drawing.Point(4, 58);
            this.circleTab.Name = "circleTab";
            this.circleTab.Padding = new System.Windows.Forms.Padding(3);
            this.circleTab.Size = new System.Drawing.Size(270, 131);
            this.circleTab.TabIndex = 0;
            this.circleTab.Text = "Circle";
            this.circleTab.UseVisualStyleBackColor = true;
            // 
            // circleRadius
            // 
            this.circleRadius.DecimalPlaces = 2;
            this.circleRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.circleRadius.Location = new System.Drawing.Point(7, 20);
            this.circleRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.circleRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.circleRadius.Name = "circleRadius";
            this.circleRadius.Size = new System.Drawing.Size(120, 20);
            this.circleRadius.TabIndex = 1;
            this.circleRadius.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.circleRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Radius";
            // 
            // ellipseTab
            // 
            this.ellipseTab.Controls.Add(this.ellipseNumberOfEdges);
            this.ellipseTab.Controls.Add(this.label8);
            this.ellipseTab.Controls.Add(this.ellipseYRadius);
            this.ellipseTab.Controls.Add(this.label7);
            this.ellipseTab.Controls.Add(this.ellipseXRadius);
            this.ellipseTab.Controls.Add(this.label6);
            this.ellipseTab.Location = new System.Drawing.Point(4, 58);
            this.ellipseTab.Name = "ellipseTab";
            this.ellipseTab.Padding = new System.Windows.Forms.Padding(3);
            this.ellipseTab.Size = new System.Drawing.Size(270, 131);
            this.ellipseTab.TabIndex = 1;
            this.ellipseTab.Text = "Ellipse";
            this.ellipseTab.UseVisualStyleBackColor = true;
            // 
            // ellipseNumberOfEdges
            // 
            this.ellipseNumberOfEdges.Location = new System.Drawing.Point(6, 71);
            this.ellipseNumberOfEdges.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ellipseNumberOfEdges.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ellipseNumberOfEdges.Name = "ellipseNumberOfEdges";
            this.ellipseNumberOfEdges.Size = new System.Drawing.Size(120, 20);
            this.ellipseNumberOfEdges.TabIndex = 5;
            this.ellipseNumberOfEdges.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ellipseNumberOfEdges.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "NumberOfEdges";
            // 
            // ellipseYRadius
            // 
            this.ellipseYRadius.DecimalPlaces = 2;
            this.ellipseYRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ellipseYRadius.Location = new System.Drawing.Point(143, 20);
            this.ellipseYRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ellipseYRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ellipseYRadius.Name = "ellipseYRadius";
            this.ellipseYRadius.Size = new System.Drawing.Size(120, 20);
            this.ellipseYRadius.TabIndex = 3;
            this.ellipseYRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ellipseYRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "yRadius";
            // 
            // ellipseXRadius
            // 
            this.ellipseXRadius.DecimalPlaces = 2;
            this.ellipseXRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ellipseXRadius.Location = new System.Drawing.Point(7, 20);
            this.ellipseXRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ellipseXRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ellipseXRadius.Name = "ellipseXRadius";
            this.ellipseXRadius.Size = new System.Drawing.Size(120, 20);
            this.ellipseXRadius.TabIndex = 1;
            this.ellipseXRadius.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.ellipseXRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "xRadius";
            // 
            // arcTab
            // 
            this.arcTab.Controls.Add(this.arcRadius);
            this.arcTab.Controls.Add(this.label9);
            this.arcTab.Controls.Add(this.arcSides);
            this.arcTab.Controls.Add(this.label10);
            this.arcTab.Controls.Add(this.arcDegrees);
            this.arcTab.Controls.Add(this.label11);
            this.arcTab.Location = new System.Drawing.Point(4, 58);
            this.arcTab.Name = "arcTab";
            this.arcTab.Padding = new System.Windows.Forms.Padding(3);
            this.arcTab.Size = new System.Drawing.Size(270, 131);
            this.arcTab.TabIndex = 2;
            this.arcTab.Text = "Arc";
            this.arcTab.UseVisualStyleBackColor = true;
            // 
            // arcRadius
            // 
            this.arcRadius.DecimalPlaces = 2;
            this.arcRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.arcRadius.Location = new System.Drawing.Point(8, 19);
            this.arcRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.arcRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.arcRadius.Name = "arcRadius";
            this.arcRadius.Size = new System.Drawing.Size(120, 20);
            this.arcRadius.TabIndex = 11;
            this.arcRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.arcRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Radius";
            // 
            // arcSides
            // 
            this.arcSides.Location = new System.Drawing.Point(8, 69);
            this.arcSides.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.arcSides.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.arcSides.Name = "arcSides";
            this.arcSides.Size = new System.Drawing.Size(120, 20);
            this.arcSides.TabIndex = 9;
            this.arcSides.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.arcSides.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Sides";
            // 
            // arcDegrees
            // 
            this.arcDegrees.Location = new System.Drawing.Point(143, 19);
            this.arcDegrees.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.arcDegrees.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.arcDegrees.Name = "arcDegrees";
            this.arcDegrees.Size = new System.Drawing.Size(120, 20);
            this.arcDegrees.TabIndex = 7;
            this.arcDegrees.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.arcDegrees.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(142, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Degrees";
            // 
            // gearTab
            // 
            this.gearTab.Controls.Add(this.gearToothHeight);
            this.gearTab.Controls.Add(this.label15);
            this.gearTab.Controls.Add(this.gearTipPercentage);
            this.gearTab.Controls.Add(this.label12);
            this.gearTab.Controls.Add(this.gearNumberOfTeeth);
            this.gearTab.Controls.Add(this.label13);
            this.gearTab.Controls.Add(this.gearRadius);
            this.gearTab.Controls.Add(this.label14);
            this.gearTab.Location = new System.Drawing.Point(4, 58);
            this.gearTab.Name = "gearTab";
            this.gearTab.Padding = new System.Windows.Forms.Padding(3);
            this.gearTab.Size = new System.Drawing.Size(270, 131);
            this.gearTab.TabIndex = 3;
            this.gearTab.Text = "Gear";
            this.gearTab.UseVisualStyleBackColor = true;
            // 
            // gearToothHeight
            // 
            this.gearToothHeight.DecimalPlaces = 2;
            this.gearToothHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gearToothHeight.Location = new System.Drawing.Point(140, 72);
            this.gearToothHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.gearToothHeight.Name = "gearToothHeight";
            this.gearToothHeight.Size = new System.Drawing.Size(120, 20);
            this.gearToothHeight.TabIndex = 13;
            this.gearToothHeight.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(139, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "ToothHeight";
            // 
            // gearTipPercentage
            // 
            this.gearTipPercentage.Location = new System.Drawing.Point(6, 72);
            this.gearTipPercentage.Name = "gearTipPercentage";
            this.gearTipPercentage.Size = new System.Drawing.Size(120, 20);
            this.gearTipPercentage.TabIndex = 11;
            this.gearTipPercentage.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "TipPercentage";
            // 
            // gearNumberOfTeeth
            // 
            this.gearNumberOfTeeth.Location = new System.Drawing.Point(140, 20);
            this.gearNumberOfTeeth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.gearNumberOfTeeth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gearNumberOfTeeth.Name = "gearNumberOfTeeth";
            this.gearNumberOfTeeth.Size = new System.Drawing.Size(120, 20);
            this.gearNumberOfTeeth.TabIndex = 9;
            this.gearNumberOfTeeth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gearNumberOfTeeth.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(139, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "NumberOfTeeth";
            // 
            // gearRadius
            // 
            this.gearRadius.DecimalPlaces = 2;
            this.gearRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gearRadius.Location = new System.Drawing.Point(4, 20);
            this.gearRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.gearRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gearRadius.Name = "gearRadius";
            this.gearRadius.Size = new System.Drawing.Size(120, 20);
            this.gearRadius.TabIndex = 7;
            this.gearRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gearRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Radius";
            // 
            // capsuleTab
            // 
            this.capsuleTab.Controls.Add(this.capsuleBottomEdges);
            this.capsuleTab.Controls.Add(this.label20);
            this.capsuleTab.Controls.Add(this.capsuleBottomRadius);
            this.capsuleTab.Controls.Add(this.label16);
            this.capsuleTab.Controls.Add(this.capsuleTopEdges);
            this.capsuleTab.Controls.Add(this.label17);
            this.capsuleTab.Controls.Add(this.capsuleTopRadius);
            this.capsuleTab.Controls.Add(this.label18);
            this.capsuleTab.Controls.Add(this.capsuleHeight);
            this.capsuleTab.Controls.Add(this.label19);
            this.capsuleTab.Location = new System.Drawing.Point(4, 58);
            this.capsuleTab.Name = "capsuleTab";
            this.capsuleTab.Padding = new System.Windows.Forms.Padding(3);
            this.capsuleTab.Size = new System.Drawing.Size(270, 131);
            this.capsuleTab.TabIndex = 4;
            this.capsuleTab.Text = "Capsule";
            this.capsuleTab.UseVisualStyleBackColor = true;
            // 
            // capsuleBottomEdges
            // 
            this.capsuleBottomEdges.Location = new System.Drawing.Point(142, 123);
            this.capsuleBottomEdges.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.capsuleBottomEdges.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.capsuleBottomEdges.Name = "capsuleBottomEdges";
            this.capsuleBottomEdges.Size = new System.Drawing.Size(120, 20);
            this.capsuleBottomEdges.TabIndex = 23;
            this.capsuleBottomEdges.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.capsuleBottomEdges.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(141, 106);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "BottomEdges";
            // 
            // capsuleBottomRadius
            // 
            this.capsuleBottomRadius.DecimalPlaces = 2;
            this.capsuleBottomRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.capsuleBottomRadius.Location = new System.Drawing.Point(6, 123);
            this.capsuleBottomRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.capsuleBottomRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.capsuleBottomRadius.Name = "capsuleBottomRadius";
            this.capsuleBottomRadius.Size = new System.Drawing.Size(120, 20);
            this.capsuleBottomRadius.TabIndex = 21;
            this.capsuleBottomRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.capsuleBottomRadius.ValueChanging += new System.Windows.Forms.ValueChangingEventHandler(this.capsuleBottomRadius_ValueChanging);
            this.capsuleBottomRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 106);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "BottomRadius";
            // 
            // capsuleTopEdges
            // 
            this.capsuleTopEdges.Location = new System.Drawing.Point(142, 75);
            this.capsuleTopEdges.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.capsuleTopEdges.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.capsuleTopEdges.Name = "capsuleTopEdges";
            this.capsuleTopEdges.Size = new System.Drawing.Size(120, 20);
            this.capsuleTopEdges.TabIndex = 19;
            this.capsuleTopEdges.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.capsuleTopEdges.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(141, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "TopEdges";
            // 
            // capsuleTopRadius
            // 
            this.capsuleTopRadius.DecimalPlaces = 2;
            this.capsuleTopRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.capsuleTopRadius.Location = new System.Drawing.Point(6, 75);
            this.capsuleTopRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.capsuleTopRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.capsuleTopRadius.Name = "capsuleTopRadius";
            this.capsuleTopRadius.Size = new System.Drawing.Size(120, 20);
            this.capsuleTopRadius.TabIndex = 17;
            this.capsuleTopRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.capsuleTopRadius.ValueChanging += new System.Windows.Forms.ValueChangingEventHandler(this.capsuleTopRadius_ValueChanging);
            this.capsuleTopRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "TopRadius";
            // 
            // capsuleHeight
            // 
            this.capsuleHeight.DecimalPlaces = 2;
            this.capsuleHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.capsuleHeight.Location = new System.Drawing.Point(6, 20);
            this.capsuleHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.capsuleHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.capsuleHeight.Name = "capsuleHeight";
            this.capsuleHeight.Size = new System.Drawing.Size(120, 20);
            this.capsuleHeight.TabIndex = 15;
            this.capsuleHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.capsuleHeight.ValueChanging += new System.Windows.Forms.ValueChangingEventHandler(this.capsuleHeight_ValueChanging);
            this.capsuleHeight.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Height";
            // 
            // rectangleTab
            // 
            this.rectangleTab.Controls.Add(this.rectangleWidth);
            this.rectangleTab.Controls.Add(this.label21);
            this.rectangleTab.Controls.Add(this.rectangleHeight);
            this.rectangleTab.Controls.Add(this.label22);
            this.rectangleTab.Location = new System.Drawing.Point(4, 58);
            this.rectangleTab.Name = "rectangleTab";
            this.rectangleTab.Padding = new System.Windows.Forms.Padding(3);
            this.rectangleTab.Size = new System.Drawing.Size(270, 131);
            this.rectangleTab.TabIndex = 5;
            this.rectangleTab.Text = "Rectangle";
            this.rectangleTab.UseVisualStyleBackColor = true;
            // 
            // rectangleWidth
            // 
            this.rectangleWidth.DecimalPlaces = 2;
            this.rectangleWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rectangleWidth.Location = new System.Drawing.Point(142, 19);
            this.rectangleWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rectangleWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rectangleWidth.Name = "rectangleWidth";
            this.rectangleWidth.Size = new System.Drawing.Size(120, 20);
            this.rectangleWidth.TabIndex = 23;
            this.rectangleWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rectangleWidth.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(141, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "Width";
            // 
            // rectangleHeight
            // 
            this.rectangleHeight.DecimalPlaces = 2;
            this.rectangleHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rectangleHeight.Location = new System.Drawing.Point(6, 19);
            this.rectangleHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rectangleHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rectangleHeight.Name = "rectangleHeight";
            this.rectangleHeight.Size = new System.Drawing.Size(120, 20);
            this.rectangleHeight.TabIndex = 21;
            this.rectangleHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rectangleHeight.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(38, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Height";
            // 
            // roundedRectangleTab
            // 
            this.roundedRectangleTab.Controls.Add(this.roundedRectangleYRadius);
            this.roundedRectangleTab.Controls.Add(this.label23);
            this.roundedRectangleTab.Controls.Add(this.roundedRectangleXRadius);
            this.roundedRectangleTab.Controls.Add(this.label24);
            this.roundedRectangleTab.Controls.Add(this.roundedRectangleHeight);
            this.roundedRectangleTab.Controls.Add(this.label25);
            this.roundedRectangleTab.Controls.Add(this.roundedRectangleWidth);
            this.roundedRectangleTab.Controls.Add(this.label26);
            this.roundedRectangleTab.Controls.Add(this.roundedRectangleSegments);
            this.roundedRectangleTab.Controls.Add(this.label27);
            this.roundedRectangleTab.Location = new System.Drawing.Point(4, 58);
            this.roundedRectangleTab.Name = "roundedRectangleTab";
            this.roundedRectangleTab.Padding = new System.Windows.Forms.Padding(3);
            this.roundedRectangleTab.Size = new System.Drawing.Size(270, 131);
            this.roundedRectangleTab.TabIndex = 6;
            this.roundedRectangleTab.Text = "RoundedRectangle";
            this.roundedRectangleTab.UseVisualStyleBackColor = true;
            // 
            // roundedRectangleYRadius
            // 
            this.roundedRectangleYRadius.DecimalPlaces = 2;
            this.roundedRectangleYRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleYRadius.Location = new System.Drawing.Point(144, 124);
            this.roundedRectangleYRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.roundedRectangleYRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleYRadius.Name = "roundedRectangleYRadius";
            this.roundedRectangleYRadius.Size = new System.Drawing.Size(120, 20);
            this.roundedRectangleYRadius.TabIndex = 33;
            this.roundedRectangleYRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.roundedRectangleYRadius.ValueChanging += new System.Windows.Forms.ValueChangingEventHandler(this.roundedRectangleYRadius_ValueChanging);
            this.roundedRectangleYRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(143, 107);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 32;
            this.label23.Text = "yRadius";
            // 
            // roundedRectangleXRadius
            // 
            this.roundedRectangleXRadius.DecimalPlaces = 2;
            this.roundedRectangleXRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleXRadius.Location = new System.Drawing.Point(8, 124);
            this.roundedRectangleXRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.roundedRectangleXRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleXRadius.Name = "roundedRectangleXRadius";
            this.roundedRectangleXRadius.Size = new System.Drawing.Size(120, 20);
            this.roundedRectangleXRadius.TabIndex = 31;
            this.roundedRectangleXRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.roundedRectangleXRadius.ValueChanging += new System.Windows.Forms.ValueChangingEventHandler(this.roundedRectangleXRadius_ValueChanging);
            this.roundedRectangleXRadius.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 107);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "xRadius";
            // 
            // roundedRectangleHeight
            // 
            this.roundedRectangleHeight.DecimalPlaces = 2;
            this.roundedRectangleHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleHeight.Location = new System.Drawing.Point(144, 76);
            this.roundedRectangleHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.roundedRectangleHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleHeight.Name = "roundedRectangleHeight";
            this.roundedRectangleHeight.Size = new System.Drawing.Size(120, 20);
            this.roundedRectangleHeight.TabIndex = 29;
            this.roundedRectangleHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.roundedRectangleHeight.ValueChanging += new System.Windows.Forms.ValueChangingEventHandler(this.roundedRectangleHeight_ValueChanging);
            this.roundedRectangleHeight.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(143, 59);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 13);
            this.label25.TabIndex = 28;
            this.label25.Text = "Height";
            // 
            // roundedRectangleWidth
            // 
            this.roundedRectangleWidth.DecimalPlaces = 2;
            this.roundedRectangleWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleWidth.Location = new System.Drawing.Point(8, 76);
            this.roundedRectangleWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.roundedRectangleWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.roundedRectangleWidth.Name = "roundedRectangleWidth";
            this.roundedRectangleWidth.Size = new System.Drawing.Size(120, 20);
            this.roundedRectangleWidth.TabIndex = 27;
            this.roundedRectangleWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.roundedRectangleWidth.ValueChanging += new System.Windows.Forms.ValueChangingEventHandler(this.roundedRectangleWidth_ValueChanging);
            this.roundedRectangleWidth.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(7, 59);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 13);
            this.label26.TabIndex = 26;
            this.label26.Text = "Width";
            // 
            // roundedRectangleSegments
            // 
            this.roundedRectangleSegments.Location = new System.Drawing.Point(8, 21);
            this.roundedRectangleSegments.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.roundedRectangleSegments.Name = "roundedRectangleSegments";
            this.roundedRectangleSegments.Size = new System.Drawing.Size(120, 20);
            this.roundedRectangleSegments.TabIndex = 25;
            this.roundedRectangleSegments.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.roundedRectangleSegments.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 4);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 13);
            this.label27.TabIndex = 24;
            this.label27.Text = "Segments";
            // 
            // customShapeTab
            // 
            this.customShapeTab.Controls.Add(this.label30);
            this.customShapeTab.Controls.Add(this.shapeFromTextureBox);
            this.customShapeTab.Controls.Add(this.useOriginalTextureCheck);
            this.customShapeTab.Controls.Add(this.customShapeScale);
            this.customShapeTab.Controls.Add(this.label28);
            this.customShapeTab.Location = new System.Drawing.Point(4, 58);
            this.customShapeTab.Name = "customShapeTab";
            this.customShapeTab.Padding = new System.Windows.Forms.Padding(3);
            this.customShapeTab.Size = new System.Drawing.Size(270, 131);
            this.customShapeTab.TabIndex = 7;
            this.customShapeTab.Text = "CustomShape";
            this.customShapeTab.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(96, 13);
            this.label30.TabIndex = 13;
            this.label30.Text = "Shape from texture";
            // 
            // shapeFromTextureBox
            // 
            this.shapeFromTextureBox.FormattingEnabled = true;
            this.shapeFromTextureBox.Location = new System.Drawing.Point(2, 25);
            this.shapeFromTextureBox.Name = "shapeFromTextureBox";
            this.shapeFromTextureBox.Size = new System.Drawing.Size(262, 21);
            this.shapeFromTextureBox.TabIndex = 12;
            this.shapeFromTextureBox.SelectedValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // useOriginalTextureCheck
            // 
            this.useOriginalTextureCheck.AutoSize = true;
            this.useOriginalTextureCheck.Checked = true;
            this.useOriginalTextureCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useOriginalTextureCheck.Location = new System.Drawing.Point(148, 68);
            this.useOriginalTextureCheck.Name = "useOriginalTextureCheck";
            this.useOriginalTextureCheck.Size = new System.Drawing.Size(116, 17);
            this.useOriginalTextureCheck.TabIndex = 11;
            this.useOriginalTextureCheck.Text = "Use original texture";
            this.useOriginalTextureCheck.UseVisualStyleBackColor = true;
            this.useOriginalTextureCheck.CheckedChanged += new System.EventHandler(this.HandlePreview);
            // 
            // customShapeScale
            // 
            this.customShapeScale.DecimalPlaces = 2;
            this.customShapeScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.customShapeScale.Location = new System.Drawing.Point(4, 65);
            this.customShapeScale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.customShapeScale.Name = "customShapeScale";
            this.customShapeScale.Size = new System.Drawing.Size(120, 20);
            this.customShapeScale.TabIndex = 3;
            this.customShapeScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customShapeScale.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(1, 49);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Scale";
            // 
            // emptyTab
            // 
            this.emptyTab.Controls.Add(this.label29);
            this.emptyTab.Location = new System.Drawing.Point(4, 58);
            this.emptyTab.Name = "emptyTab";
            this.emptyTab.Padding = new System.Windows.Forms.Padding(3);
            this.emptyTab.Size = new System.Drawing.Size(270, 131);
            this.emptyTab.TabIndex = 8;
            this.emptyTab.Text = "Empty";
            this.emptyTab.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(85, 62);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(71, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Select Shape";
            // 
            // commonParameters
            // 
            this.commonParameters.Controls.Add(this.drawOutlineCheck);
            this.commonParameters.Controls.Add(this.setAsTextureCheck);
            this.commonParameters.Controls.Add(this.materialScale);
            this.commonParameters.Controls.Add(this.label4);
            this.commonParameters.Controls.Add(this.label2);
            this.commonParameters.Controls.Add(this.materialBox);
            this.commonParameters.Controls.Add(this.label3);
            this.commonParameters.Controls.Add(this.colorBox);
            this.commonParameters.Location = new System.Drawing.Point(6, 351);
            this.commonParameters.Name = "commonParameters";
            this.commonParameters.Size = new System.Drawing.Size(284, 139);
            this.commonParameters.TabIndex = 7;
            this.commonParameters.TabStop = false;
            this.commonParameters.Text = "Common Parameters";
            // 
            // drawOutlineCheck
            // 
            this.drawOutlineCheck.AutoSize = true;
            this.drawOutlineCheck.Location = new System.Drawing.Point(155, 115);
            this.drawOutlineCheck.Name = "drawOutlineCheck";
            this.drawOutlineCheck.Size = new System.Drawing.Size(85, 17);
            this.drawOutlineCheck.TabIndex = 11;
            this.drawOutlineCheck.Text = "Draw outline";
            this.drawOutlineCheck.UseVisualStyleBackColor = true;
            this.drawOutlineCheck.CheckedChanged += new System.EventHandler(this.drawOutlineCheck_CheckedChanged);
            // 
            // setAsTextureCheck
            // 
            this.setAsTextureCheck.AutoSize = true;
            this.setAsTextureCheck.Location = new System.Drawing.Point(155, 99);
            this.setAsTextureCheck.Name = "setAsTextureCheck";
            this.setAsTextureCheck.Size = new System.Drawing.Size(91, 17);
            this.setAsTextureCheck.TabIndex = 10;
            this.setAsTextureCheck.Text = "Set as texture";
            this.setAsTextureCheck.UseVisualStyleBackColor = true;
            this.setAsTextureCheck.CheckedChanged += new System.EventHandler(this.setAsTextureCheck_CheckedChanged);
            // 
            // materialScale
            // 
            this.materialScale.DecimalPlaces = 2;
            this.materialScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.materialScale.Location = new System.Drawing.Point(7, 112);
            this.materialScale.Name = "materialScale";
            this.materialScale.Size = new System.Drawing.Size(120, 20);
            this.materialScale.TabIndex = 8;
            this.materialScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.materialScale.ValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Material Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Material";
            // 
            // materialBox
            // 
            this.materialBox.FormattingEnabled = true;
            this.materialBox.Location = new System.Drawing.Point(7, 32);
            this.materialBox.Name = "materialBox";
            this.materialBox.Size = new System.Drawing.Size(264, 21);
            this.materialBox.TabIndex = 2;
            this.materialBox.SelectedValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Color";
            // 
            // colorBox
            // 
            this.colorBox.FormattingEnabled = true;
            this.colorBox.Location = new System.Drawing.Point(7, 72);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(264, 21);
            this.colorBox.TabIndex = 3;
            this.colorBox.SelectedValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Shape";
            // 
            // shapeBox
            // 
            this.shapeBox.FormattingEnabled = true;
            this.shapeBox.Location = new System.Drawing.Point(13, 324);
            this.shapeBox.Name = "shapeBox";
            this.shapeBox.Size = new System.Drawing.Size(264, 21);
            this.shapeBox.TabIndex = 1;
            this.shapeBox.SelectedValueChanged += new System.EventHandler(this.ShapeParameterSwitch);
            // 
            // jointPage
            // 
            this.jointPage.AutoScroll = true;
            this.jointPage.Controls.Add(this.createdJointsList);
            this.jointPage.Controls.Add(this.label32);
            this.jointPage.Controls.Add(this.label31);
            this.jointPage.Controls.Add(this.jointsBox);
            this.jointPage.Location = new System.Drawing.Point(4, 22);
            this.jointPage.Name = "jointPage";
            this.jointPage.Padding = new System.Windows.Forms.Padding(3);
            this.jointPage.Size = new System.Drawing.Size(306, 733);
            this.jointPage.TabIndex = 1;
            this.jointPage.Text = "Joints";
            this.jointPage.UseVisualStyleBackColor = true;
            // 
            // createdJointsList
            // 
            this.createdJointsList.FormattingEnabled = true;
            this.createdJointsList.Location = new System.Drawing.Point(5, 68);
            this.createdJointsList.Name = "createdJointsList";
            this.createdJointsList.Size = new System.Drawing.Size(293, 654);
            this.createdJointsList.TabIndex = 3;
            this.createdJointsList.SelectedValueChanged += new System.EventHandler(this.createdJointsList_SelectedValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 52);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(93, 13);
            this.label32.TabIndex = 2;
            this.label32.Text = "Created Joints List";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 3);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 13);
            this.label31.TabIndex = 1;
            this.label31.Text = "Joints";
            // 
            // jointsBox
            // 
            this.jointsBox.FormattingEnabled = true;
            this.jointsBox.Location = new System.Drawing.Point(5, 19);
            this.jointsBox.Name = "jointsBox";
            this.jointsBox.Size = new System.Drawing.Size(293, 21);
            this.jointsBox.TabIndex = 0;
            this.jointsBox.SelectedValueChanged += new System.EventHandler(this.jointsBox_SelectedValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(323, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.viewTabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1118, 759);
            this.splitContainer1.SplitterDistance = 843;
            this.splitContainer1.TabIndex = 1;
            // 
            // viewTabControl
            // 
            this.viewTabControl.Controls.Add(this.levelPage);
            this.viewTabControl.Controls.Add(this.objectTab);
            this.viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewTabControl.Location = new System.Drawing.Point(0, 0);
            this.viewTabControl.Name = "viewTabControl";
            this.viewTabControl.SelectedIndex = 0;
            this.viewTabControl.Size = new System.Drawing.Size(843, 759);
            this.viewTabControl.TabIndex = 0;
            // 
            // levelPage
            // 
            this.levelPage.AutoScroll = true;
            this.levelPage.Controls.Add(this.levelScreen);
            this.levelPage.Location = new System.Drawing.Point(4, 22);
            this.levelPage.Name = "levelPage";
            this.levelPage.Padding = new System.Windows.Forms.Padding(3);
            this.levelPage.Size = new System.Drawing.Size(835, 733);
            this.levelPage.TabIndex = 0;
            this.levelPage.Text = "Level";
            this.levelPage.UseVisualStyleBackColor = true;
            this.levelPage.Scroll += new System.Windows.Forms.ScrollEventHandler(this.levelPage_Scroll);
            this.levelPage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.levelPage_MouseWheel);
            // 
            // levelScreen
            // 
            this.levelScreen.AbsoluteULPoint = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            this.levelScreen.Camera = null;
            this.levelScreen.DrawCurrentGameObject = false;
            this.levelScreen.GameLevel = null;
            this.levelScreen.Location = new System.Drawing.Point(3, 3);
            this.levelScreen.Margin = new System.Windows.Forms.Padding(0);
            this.levelScreen.MousePosition = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            this.levelScreen.MouseState = null;
            this.levelScreen.Name = "levelScreen";
            this.levelScreen.Size = new System.Drawing.Size(1200, 800);
            this.levelScreen.TabIndex = 0;
            this.levelScreen.Text = "levelScreen";
            this.levelScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelScreen_MouseClick);
            this.levelScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.levelScreen_MouseDown);
            this.levelScreen.MouseEnter += new System.EventHandler(this.levelScreen_MouseEnter);
            this.levelScreen.MouseLeave += new System.EventHandler(this.levelScreen_MouseLeave);
            this.levelScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelScreen_MouseMove);
            this.levelScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.levelScreen_MouseUp);
            // 
            // objectTab
            // 
            this.objectTab.Controls.Add(this.objectScreen);
            this.objectTab.Location = new System.Drawing.Point(4, 22);
            this.objectTab.Name = "objectTab";
            this.objectTab.Padding = new System.Windows.Forms.Padding(3);
            this.objectTab.Size = new System.Drawing.Size(835, 733);
            this.objectTab.TabIndex = 1;
            this.objectTab.Text = "Object";
            this.objectTab.UseVisualStyleBackColor = true;
            // 
            // objectScreen
            // 
            this.objectScreen.AbsoluteULPoint = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            this.objectScreen.Camera = null;
            this.objectScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectScreen.DrawCurrentGameObject = false;
            this.objectScreen.GameLevel = null;
            this.objectScreen.Location = new System.Drawing.Point(3, 3);
            this.objectScreen.Margin = new System.Windows.Forms.Padding(0);
            this.objectScreen.MousePosition = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            this.objectScreen.MouseState = null;
            this.objectScreen.Name = "objectScreen";
            this.objectScreen.Size = new System.Drawing.Size(829, 752);
            this.objectScreen.TabIndex = 0;
            this.objectScreen.Text = "objectScreen";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(271, 759);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.levelToolStripMenuItem,
            this.resoursesToolStripMenuItem,
            this.simulationToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1444, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.actionList.SetAction(this.undoToolStripMenuItem, this.undoAction);
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Image = global::LevelEditor.Properties.Resources.Edit_UndoHS;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.actionList.SetAction(this.redoToolStripMenuItem, this.redoAction);
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Image = global::LevelEditor.Properties.Resources.Edit_RedoHS;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLevelToolStripMenuItem,
            this.loadLevelToolStripMenuItem,
            this.clearLevelToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "Level";
            // 
            // createLevelToolStripMenuItem
            // 
            this.createLevelToolStripMenuItem.Name = "createLevelToolStripMenuItem";
            this.createLevelToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.createLevelToolStripMenuItem.Text = "Create Level";
            // 
            // loadLevelToolStripMenuItem
            // 
            this.loadLevelToolStripMenuItem.Name = "loadLevelToolStripMenuItem";
            this.loadLevelToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.loadLevelToolStripMenuItem.Text = "Load Level";
            // 
            // clearLevelToolStripMenuItem
            // 
            this.clearLevelToolStripMenuItem.Name = "clearLevelToolStripMenuItem";
            this.clearLevelToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.clearLevelToolStripMenuItem.Text = "Clear Level";
            // 
            // resoursesToolStripMenuItem
            // 
            this.resoursesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMaterialToolStripMenuItem,
            this.loadShapeToolStripMenuItem});
            this.resoursesToolStripMenuItem.Name = "resoursesToolStripMenuItem";
            this.resoursesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.resoursesToolStripMenuItem.Text = "Resources";
            // 
            // loadMaterialToolStripMenuItem
            // 
            this.loadMaterialToolStripMenuItem.Name = "loadMaterialToolStripMenuItem";
            this.loadMaterialToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.loadMaterialToolStripMenuItem.Text = "Load Material";
            this.loadMaterialToolStripMenuItem.Click += new System.EventHandler(this.loadMaterialToolStripMenuItem_Click);
            // 
            // loadShapeToolStripMenuItem
            // 
            this.loadShapeToolStripMenuItem.Name = "loadShapeToolStripMenuItem";
            this.loadShapeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.loadShapeToolStripMenuItem.Text = "Load Shape";
            this.loadShapeToolStripMenuItem.Click += new System.EventHandler(this.loadShapeToolStripMenuItem_Click);
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulateMenuItem,
            this.pauseToolStripMenuItem,
            this.simulationSpeedToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // simulateMenuItem
            // 
            this.actionList.SetAction(this.simulateMenuItem, this.simulateAction);
            this.simulateMenuItem.Image = global::LevelEditor.Properties.Resources.PlayHS;
            this.simulateMenuItem.Name = "simulateMenuItem";
            this.simulateMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.simulateMenuItem.Size = new System.Drawing.Size(166, 22);
            this.simulateMenuItem.Text = "Start";
            // 
            // pauseToolStripMenuItem
            // 
            this.actionList.SetAction(this.pauseToolStripMenuItem, this.pauseSimulationAction);
            this.pauseToolStripMenuItem.Enabled = false;
            this.pauseToolStripMenuItem.Image = global::LevelEditor.Properties.Resources.PauseHS;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // simulationSpeedToolStripMenuItem
            // 
            this.simulationSpeedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulationSpeedHalfMenuItem,
            this.simulationSpeedNormalMenuItem,
            this.simulationSpeedDoubleMenuItem,
            this.simulationSpeedIncreaseMenuItem,
            this.simulationSpeedDecreaseMenuItem});
            this.simulationSpeedToolStripMenuItem.Name = "simulationSpeedToolStripMenuItem";
            this.simulationSpeedToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.simulationSpeedToolStripMenuItem.Text = "Simulation Speed";
            // 
            // simulationSpeedHalfMenuItem
            // 
            this.actionList.SetAction(this.simulationSpeedHalfMenuItem, this.simulationSpeedHalfAction);
            this.simulationSpeedHalfMenuItem.CheckOnClick = true;
            this.simulationSpeedHalfMenuItem.Image = global::LevelEditor.Properties.Resources.halfSpeed;
            this.simulationSpeedHalfMenuItem.Name = "simulationSpeedHalfMenuItem";
            this.simulationSpeedHalfMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.simulationSpeedHalfMenuItem.Size = new System.Drawing.Size(254, 22);
            this.simulationSpeedHalfMenuItem.Text = "0.50x";
            // 
            // simulationSpeedNormalMenuItem
            // 
            this.actionList.SetAction(this.simulationSpeedNormalMenuItem, this.simulationSpeedNormalAction);
            this.simulationSpeedNormalMenuItem.CheckOnClick = true;
            this.simulationSpeedNormalMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("simulationSpeedNormalMenuItem.Image")));
            this.simulationSpeedNormalMenuItem.Name = "simulationSpeedNormalMenuItem";
            this.simulationSpeedNormalMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.simulationSpeedNormalMenuItem.Size = new System.Drawing.Size(254, 22);
            this.simulationSpeedNormalMenuItem.Text = "1.00x";
            // 
            // simulationSpeedDoubleMenuItem
            // 
            this.actionList.SetAction(this.simulationSpeedDoubleMenuItem, this.simulationSpeedDoubleAction);
            this.simulationSpeedDoubleMenuItem.CheckOnClick = true;
            this.simulationSpeedDoubleMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("simulationSpeedDoubleMenuItem.Image")));
            this.simulationSpeedDoubleMenuItem.Name = "simulationSpeedDoubleMenuItem";
            this.simulationSpeedDoubleMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.simulationSpeedDoubleMenuItem.Size = new System.Drawing.Size(254, 22);
            this.simulationSpeedDoubleMenuItem.Text = "2.00x";
            // 
            // simulationSpeedIncreaseMenuItem
            // 
            this.actionList.SetAction(this.simulationSpeedIncreaseMenuItem, this.simulationSpeedIncreaseAction);
            this.simulationSpeedIncreaseMenuItem.Image = global::LevelEditor.Properties.Resources.increaseSpeed;
            this.simulationSpeedIncreaseMenuItem.Name = "simulationSpeedIncreaseMenuItem";
            this.simulationSpeedIncreaseMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.simulationSpeedIncreaseMenuItem.Size = new System.Drawing.Size(254, 22);
            this.simulationSpeedIncreaseMenuItem.Text = "Increase by 0.25";
            // 
            // simulationSpeedDecreaseMenuItem
            // 
            this.actionList.SetAction(this.simulationSpeedDecreaseMenuItem, this.simulationSpeedDecreaseAction);
            this.simulationSpeedDecreaseMenuItem.Image = global::LevelEditor.Properties.Resources.decreaseSpeed;
            this.simulationSpeedDecreaseMenuItem.Name = "simulationSpeedDecreaseMenuItem";
            this.simulationSpeedDecreaseMenuItem.ShortcutKeyDisplayString = "Ctrl+OemMinus";
            this.simulationSpeedDecreaseMenuItem.Size = new System.Drawing.Size(254, 22);
            this.simulationSpeedDecreaseMenuItem.Text = "Decrease by 0.25";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // resetToolStripMenuItem
            // 
            this.actionList.SetAction(this.resetToolStripMenuItem, this.resetSettingsAction);
            this.resetToolStripMenuItem.Image = global::LevelEditor.Properties.Resources.Erase;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.resetToolStripMenuItem.Text = "Reset to default";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton10,
            this.toolStripButton14});
            this.mainToolStrip.Location = new System.Drawing.Point(3, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(58, 25);
            this.mainToolStrip.TabIndex = 8;
            // 
            // toolStripButton10
            // 
            this.actionList.SetAction(this.toolStripButton10, this.undoAction);
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Enabled = false;
            this.toolStripButton10.Image = global::LevelEditor.Properties.Resources.Edit_UndoHS;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "Undo";
            // 
            // toolStripButton14
            // 
            this.actionList.SetAction(this.toolStripButton14, this.redoAction);
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Enabled = false;
            this.toolStripButton14.Image = global::LevelEditor.Properties.Resources.Edit_RedoHS;
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton14.Text = "Redo";
            // 
            // toolsToolStrip
            // 
            this.toolsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton8,
            this.toolStripButton13,
            this.toolStripSeparator3,
            this.toolStripButton15,
            this.toolStripButton16,
            this.toolStripSeparator4,
            this.toolStripButton9,
            this.toolStripButton11,
            this.toolStripSeparator5,
            this.toolStripButton12});
            this.toolsToolStrip.Location = new System.Drawing.Point(61, 24);
            this.toolsToolStrip.Name = "toolsToolStrip";
            this.toolsToolStrip.Size = new System.Drawing.Size(191, 25);
            this.toolsToolStrip.TabIndex = 6;
            // 
            // toolStripButton8
            // 
            this.actionList.SetAction(this.toolStripButton8, this.addPreviewObjectAction);
            this.toolStripButton8.CheckOnClick = true;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::LevelEditor.Properties.Resources.addPreviewObject;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Place object";
            // 
            // toolStripButton13
            // 
            this.actionList.SetAction(this.toolStripButton13, this.editCurrentObjectAction);
            this.toolStripButton13.CheckOnClick = true;
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = global::LevelEditor.Properties.Resources.editObject;
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton13.Text = "Edit current object";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton15
            // 
            this.actionList.SetAction(this.toolStripButton15, this.addNewJointAction);
            this.toolStripButton15.CheckOnClick = true;
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = global::LevelEditor.Properties.Resources.placeJoint;
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripButton16
            // 
            this.actionList.SetAction(this.toolStripButton16, this.editJointAction);
            this.toolStripButton16.CheckOnClick = true;
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = global::LevelEditor.Properties.Resources.editJoint;
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton9
            // 
            this.actionList.SetAction(this.toolStripButton9, this.selectObjectPartAction);
            this.toolStripButton9.CheckOnClick = true;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::LevelEditor.Properties.Resources.objectPart1;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "Select object part";
            // 
            // toolStripButton11
            // 
            this.actionList.SetAction(this.toolStripButton11, this.selectObjectAction);
            this.toolStripButton11.CheckOnClick = true;
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = global::LevelEditor.Properties.Resources._object;
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "Select object";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton12
            // 
            this.actionList.SetAction(this.toolStripButton12, this.useMouseJointAction);
            this.toolStripButton12.CheckOnClick = true;
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = global::LevelEditor.Properties.Resources.mouseJoint;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton12.Text = "Use mouse joint";
            // 
            // simulationToolStrip
            // 
            this.simulationToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.simulationToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton6,
            this.simulationSpeedToolStripLabel,
            this.toolStripButton7});
            this.simulationToolStrip.Location = new System.Drawing.Point(3, 49);
            this.simulationToolStrip.Name = "simulationToolStrip";
            this.simulationToolStrip.Size = new System.Drawing.Size(218, 25);
            this.simulationToolStrip.TabIndex = 7;
            // 
            // toolStripButton1
            // 
            this.actionList.SetAction(this.toolStripButton1, this.simulateAction);
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::LevelEditor.Properties.Resources.PlayHS;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Start";
            // 
            // toolStripButton2
            // 
            this.actionList.SetAction(this.toolStripButton2, this.pauseSimulationAction);
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::LevelEditor.Properties.Resources.PauseHS;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Pause";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.actionList.SetAction(this.toolStripButton3, this.simulationSpeedHalfAction);
            this.toolStripButton3.CheckOnClick = true;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::LevelEditor.Properties.Resources.halfSpeed;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "0.50x";
            // 
            // toolStripButton4
            // 
            this.actionList.SetAction(this.toolStripButton4, this.simulationSpeedNormalAction);
            this.toolStripButton4.CheckOnClick = true;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "1.00x";
            // 
            // toolStripButton5
            // 
            this.actionList.SetAction(this.toolStripButton5, this.simulationSpeedDoubleAction);
            this.toolStripButton5.CheckOnClick = true;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "2.00x";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.actionList.SetAction(this.toolStripButton6, this.simulationSpeedDecreaseAction);
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::LevelEditor.Properties.Resources.decreaseSpeed;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Decrease by 0.25";
            // 
            // simulationSpeedToolStripLabel
            // 
            this.simulationSpeedToolStripLabel.Name = "simulationSpeedToolStripLabel";
            this.simulationSpeedToolStripLabel.Size = new System.Drawing.Size(33, 22);
            this.simulationSpeedToolStripLabel.Text = "1.00x";
            // 
            // toolStripButton7
            // 
            this.actionList.SetAction(this.toolStripButton7, this.simulationSpeedIncreaseAction);
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::LevelEditor.Properties.Resources.increaseSpeed;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Increase by 0.25";
            // 
            // actionList
            // 
            this.actionList.Actions.Add(this.simulateAction);
            this.actionList.Actions.Add(this.pauseSimulationAction);
            this.actionList.Actions.Add(this.simulationSpeedNormalAction);
            this.actionList.Actions.Add(this.simulationSpeedDoubleAction);
            this.actionList.Actions.Add(this.simulationSpeedHalfAction);
            this.actionList.Actions.Add(this.simulationSpeedIncreaseAction);
            this.actionList.Actions.Add(this.simulationSpeedDecreaseAction);
            this.actionList.Actions.Add(this.addPreviewObjectAction);
            this.actionList.Actions.Add(this.selectObjectPartAction);
            this.actionList.Actions.Add(this.resetSettingsAction);
            this.actionList.Actions.Add(this.useMouseJointAction);
            this.actionList.Actions.Add(this.selectObjectAction);
            this.actionList.Actions.Add(this.editCurrentObjectAction);
            this.actionList.Actions.Add(this.undoAction);
            this.actionList.Actions.Add(this.redoAction);
            this.actionList.Actions.Add(this.addNewJointAction);
            this.actionList.Actions.Add(this.editJointAction);
            this.actionList.ContainerControl = this;
            // 
            // undoAction
            // 
            this.undoAction.Enabled = false;
            this.undoAction.Image = global::LevelEditor.Properties.Resources.Edit_UndoHS;
            this.undoAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoAction.Text = "Undo";
            this.undoAction.ToolTipText = "Undo last action";
            this.undoAction.Execute += new System.EventHandler(this.undoAction_Execute);
            this.undoAction.Update += new System.EventHandler(this.undoAction_Update);
            // 
            // redoAction
            // 
            this.redoAction.Enabled = false;
            this.redoAction.Image = global::LevelEditor.Properties.Resources.Edit_RedoHS;
            this.redoAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoAction.Text = "Redo";
            this.redoAction.ToolTipText = "Redo last undone action";
            this.redoAction.Execute += new System.EventHandler(this.redoAction_Execute);
            this.redoAction.Update += new System.EventHandler(this.redoAction_Update);
            // 
            // simulateAction
            // 
            this.simulateAction.Image = global::LevelEditor.Properties.Resources.PlayHS;
            this.simulateAction.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.simulateAction.Text = "Start";
            this.simulateAction.ToolTipText = "Start simulation";
            this.simulateAction.Execute += new System.EventHandler(this.simulateAction_Execute);
            // 
            // pauseSimulationAction
            // 
            this.pauseSimulationAction.Enabled = false;
            this.pauseSimulationAction.Image = global::LevelEditor.Properties.Resources.PauseHS;
            this.pauseSimulationAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.pauseSimulationAction.Text = "Pause";
            this.pauseSimulationAction.ToolTipText = "Pause simulation";
            this.pauseSimulationAction.Execute += new System.EventHandler(this.pauseSimulationAction_Execute);
            // 
            // simulationSpeedHalfAction
            // 
            this.simulationSpeedHalfAction.CheckOnClick = true;
            this.simulationSpeedHalfAction.Image = global::LevelEditor.Properties.Resources.halfSpeed;
            this.simulationSpeedHalfAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.simulationSpeedHalfAction.Text = "0.50x";
            this.simulationSpeedHalfAction.ToolTipText = "Select half simulation speed";
            this.simulationSpeedHalfAction.Execute += new System.EventHandler(this.simulationSpeedHalfAction_Execute);
            // 
            // simulationSpeedNormalAction
            // 
            this.simulationSpeedNormalAction.Checked = true;
            this.simulationSpeedNormalAction.CheckOnClick = true;
            this.simulationSpeedNormalAction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simulationSpeedNormalAction.Image = ((System.Drawing.Image)(resources.GetObject("simulationSpeedNormalAction.Image")));
            this.simulationSpeedNormalAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.simulationSpeedNormalAction.Text = "1.00x";
            this.simulationSpeedNormalAction.ToolTipText = "Select normal simulation speed";
            this.simulationSpeedNormalAction.Execute += new System.EventHandler(this.simulationSpeedNormalAction_Execute);
            // 
            // simulationSpeedDoubleAction
            // 
            this.simulationSpeedDoubleAction.CheckOnClick = true;
            this.simulationSpeedDoubleAction.Image = ((System.Drawing.Image)(resources.GetObject("simulationSpeedDoubleAction.Image")));
            this.simulationSpeedDoubleAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.simulationSpeedDoubleAction.Text = "2.00x";
            this.simulationSpeedDoubleAction.ToolTipText = "Select double simulation speed";
            this.simulationSpeedDoubleAction.Execute += new System.EventHandler(this.simulationSpeedDoubleAction_Execute);
            // 
            // simulationSpeedIncreaseAction
            // 
            this.simulationSpeedIncreaseAction.Image = global::LevelEditor.Properties.Resources.increaseSpeed;
            this.simulationSpeedIncreaseAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.simulationSpeedIncreaseAction.Text = "Increase by 0.25";
            this.simulationSpeedIncreaseAction.ToolTipText = "Increase simulation speed by 0.25";
            this.simulationSpeedIncreaseAction.Execute += new System.EventHandler(this.simulationSpeedIncreaseAction_Execute);
            // 
            // simulationSpeedDecreaseAction
            // 
            this.simulationSpeedDecreaseAction.Image = global::LevelEditor.Properties.Resources.decreaseSpeed;
            this.simulationSpeedDecreaseAction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.simulationSpeedDecreaseAction.Text = "Decrease by 0.25";
            this.simulationSpeedDecreaseAction.ToolTipText = "Decrease simulation speed by 0.25";
            this.simulationSpeedDecreaseAction.Execute += new System.EventHandler(this.simulationSpeedDecreaseAction_Execute);
            // 
            // resetSettingsAction
            // 
            this.resetSettingsAction.Image = global::LevelEditor.Properties.Resources.Erase;
            this.resetSettingsAction.Text = "Reset to default";
            this.resetSettingsAction.ToolTipText = "Reset settings to default values";
            this.resetSettingsAction.Execute += new System.EventHandler(this.resetSettingsAction_Execute);
            // 
            // addPreviewObjectAction
            // 
            this.addPreviewObjectAction.CheckOnClick = true;
            this.addPreviewObjectAction.Image = global::LevelEditor.Properties.Resources.addPreviewObject;
            this.addPreviewObjectAction.ShortcutKeys = System.Windows.Forms.Keys.Q;
            this.addPreviewObjectAction.Text = "Place object";
            this.addPreviewObjectAction.ToolTipText = "Place object on level";
            this.addPreviewObjectAction.Execute += new System.EventHandler(this.addPreviewObjectAction_Execute);
            // 
            // editCurrentObjectAction
            // 
            this.editCurrentObjectAction.CheckOnClick = true;
            this.editCurrentObjectAction.Image = global::LevelEditor.Properties.Resources.editObject;
            this.editCurrentObjectAction.Text = "Edit current object";
            this.editCurrentObjectAction.ToolTipText = "Edit current object (preview object)";
            this.editCurrentObjectAction.Execute += new System.EventHandler(this.editCurrentObjectAction_Execute);
            // 
            // addNewJointAction
            // 
            this.addNewJointAction.CheckOnClick = true;
            this.addNewJointAction.Image = global::LevelEditor.Properties.Resources.placeJoint;
            this.addNewJointAction.Execute += new System.EventHandler(this.addNewJointAction_Execute);
            // 
            // editJointAction
            // 
            this.editJointAction.CheckOnClick = true;
            this.editJointAction.Image = global::LevelEditor.Properties.Resources.editJoint;
            this.editJointAction.Execute += new System.EventHandler(this.editJointAction_Execute);
            // 
            // selectObjectPartAction
            // 
            this.selectObjectPartAction.CheckOnClick = true;
            this.selectObjectPartAction.Image = global::LevelEditor.Properties.Resources.objectPart1;
            this.selectObjectPartAction.Text = "Select object part";
            this.selectObjectPartAction.ToolTipText = "Select object part in level";
            this.selectObjectPartAction.Execute += new System.EventHandler(this.selectObjectPartAction_Execute);
            // 
            // selectObjectAction
            // 
            this.selectObjectAction.CheckOnClick = true;
            this.selectObjectAction.Image = global::LevelEditor.Properties.Resources._object;
            this.selectObjectAction.Text = "Select object";
            this.selectObjectAction.ToolTipText = "Select object in level";
            this.selectObjectAction.Execute += new System.EventHandler(this.selectObjectAction_Execute);
            // 
            // useMouseJointAction
            // 
            this.useMouseJointAction.CheckOnClick = true;
            this.useMouseJointAction.Image = global::LevelEditor.Properties.Resources.mouseJoint;
            this.useMouseJointAction.Text = "Use mouse joint";
            this.useMouseJointAction.ToolTipText = "Use mouse joint in simulation";
            this.useMouseJointAction.Execute += new System.EventHandler(this.useMouseJointAction_Execute);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1444, 861);
            this.Controls.Add(this.toolStripContainer);
            this.Name = "MainForm";
            this.Text = "LevelEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.paramsTabControl.ResumeLayout(false);
            this.previewPage.ResumeLayout(false);
            this.previewPage.PerformLayout();
            this.shapeParameters.ResumeLayout(false);
            this.shapeParametersControl.ResumeLayout(false);
            this.circleTab.ResumeLayout(false);
            this.circleTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circleRadius)).EndInit();
            this.ellipseTab.ResumeLayout(false);
            this.ellipseTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseNumberOfEdges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseYRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipseXRadius)).EndInit();
            this.arcTab.ResumeLayout(false);
            this.arcTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcSides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcDegrees)).EndInit();
            this.gearTab.ResumeLayout(false);
            this.gearTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gearToothHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearTipPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearNumberOfTeeth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearRadius)).EndInit();
            this.capsuleTab.ResumeLayout(false);
            this.capsuleTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleBottomEdges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleBottomRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleTopEdges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleTopRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsuleHeight)).EndInit();
            this.rectangleTab.ResumeLayout(false);
            this.rectangleTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleHeight)).EndInit();
            this.roundedRectangleTab.ResumeLayout(false);
            this.roundedRectangleTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleYRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleXRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedRectangleSegments)).EndInit();
            this.customShapeTab.ResumeLayout(false);
            this.customShapeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customShapeScale)).EndInit();
            this.emptyTab.ResumeLayout(false);
            this.emptyTab.PerformLayout();
            this.commonParameters.ResumeLayout(false);
            this.commonParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialScale)).EndInit();
            this.jointPage.ResumeLayout(false);
            this.jointPage.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.viewTabControl.ResumeLayout(false);
            this.levelPage.ResumeLayout(false);
            this.objectTab.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.toolsToolStrip.ResumeLayout(false);
            this.toolsToolStrip.PerformLayout();
            this.simulationToolStrip.ResumeLayout(false);
            this.simulationToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl paramsTabControl;
        private System.Windows.Forms.TabPage previewPage;
        private System.Windows.Forms.TabPage jointPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ComboBox shapeBox;
        private System.Windows.Forms.ComboBox materialBox;
        private System.Windows.Forms.ComboBox colorBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox commonParameters;
        private System.Windows.Forms.GroupBox shapeParameters;
        private System.Windows.Forms.NumericUpDownEx materialScale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage levelPage;
        private System.Windows.Forms.TabPage objectTab;
        private LevelScreen objectScreen;
        private LevelScreen levelScreen;
        private WindowsFormsApplication1.TabHiddenHeadersControl shapeParametersControl;
        private System.Windows.Forms.TabPage circleTab;
        private System.Windows.Forms.TabPage ellipseTab;
        private System.Windows.Forms.TabPage arcTab;
        private System.Windows.Forms.TabPage gearTab;
        private System.Windows.Forms.TabPage capsuleTab;
        private System.Windows.Forms.TabPage rectangleTab;
        private System.Windows.Forms.TabPage roundedRectangleTab;
        private System.Windows.Forms.TabPage customShapeTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDownEx circleRadius;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDownEx ellipseNumberOfEdges;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDownEx ellipseYRadius;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDownEx ellipseXRadius;
        private System.Windows.Forms.NumericUpDownEx arcRadius;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDownEx arcSides;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDownEx arcDegrees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDownEx gearTipPercentage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDownEx gearNumberOfTeeth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDownEx gearRadius;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDownEx gearToothHeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDownEx capsuleBottomRadius;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDownEx capsuleTopEdges;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDownEx capsuleTopRadius;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDownEx capsuleHeight;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDownEx capsuleBottomEdges;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDownEx rectangleWidth;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDownEx rectangleHeight;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDownEx roundedRectangleYRadius;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDownEx roundedRectangleXRadius;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDownEx roundedRectangleHeight;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDownEx roundedRectangleWidth;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDownEx roundedRectangleSegments;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDownEx customShapeScale;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabPage emptyTab;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox setAsTextureCheck;
        private System.Windows.Forms.CheckBox drawOutlineCheck;
        private System.Windows.Forms.CheckBox useOriginalTextureCheck;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox shapeFromTextureBox;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resoursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationSpeedHalfMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationSpeedNormalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationSpeedDoubleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationSpeedIncreaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationSpeedDecreaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private Crad.Windows.Forms.Actions.ActionList actionList;
        private Crad.Windows.Forms.Actions.Action simulateAction;
        private Crad.Windows.Forms.Actions.Action pauseSimulationAction;
        private Crad.Windows.Forms.Actions.Action simulationSpeedNormalAction;
        private Crad.Windows.Forms.Actions.Action simulationSpeedDoubleAction;
        private Crad.Windows.Forms.Actions.Action simulationSpeedHalfAction;
        private Crad.Windows.Forms.Actions.Action simulationSpeedIncreaseAction;
        private Crad.Windows.Forms.Actions.Action simulationSpeedDecreaseAction;
        private System.Windows.Forms.ToolStrip toolsToolStrip;
        private System.Windows.Forms.ToolStrip simulationToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private PreviewScreen previewScreen;
        private Crad.Windows.Forms.Actions.Action addPreviewObjectAction;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripLabel simulationSpeedToolStripLabel;
        private Crad.Windows.Forms.Actions.Action selectObjectPartAction;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private Crad.Windows.Forms.Actions.Action resetSettingsAction;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private Crad.Windows.Forms.Actions.Action useMouseJointAction;
        private Crad.Windows.Forms.Actions.Action selectObjectAction;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private Crad.Windows.Forms.Actions.Action editCurrentObjectAction;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private Crad.Windows.Forms.Actions.Action undoAction;
        private Crad.Windows.Forms.Actions.Action redoAction;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private Crad.Windows.Forms.Actions.Action addNewJointAction;
        private Crad.Windows.Forms.Actions.Action editJointAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox jointsBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMousePosLabel;
        private System.Windows.Forms.ListBox createdJointsList;
        private System.Windows.Forms.Label label32;
    }
}

