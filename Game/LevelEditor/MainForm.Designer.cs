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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.levelPage = new System.Windows.Forms.TabPage();
            this.levelScreen = new LevelEditor.XnaScreen();
            this.objectTab = new System.Windows.Forms.TabPage();
            this.objectScreen = new LevelEditor.XnaScreen();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.useOriginalTextureCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.levelPage.SuspendLayout();
            this.objectTab.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.levelToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1444, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLevelToolStripMenuItem,
            this.loadLevelToolStripMenuItem,
            this.loadMaterialToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createLevelToolStripMenuItem
            // 
            this.createLevelToolStripMenuItem.Name = "createLevelToolStripMenuItem";
            this.createLevelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.createLevelToolStripMenuItem.Text = "Create Level";
            // 
            // loadLevelToolStripMenuItem
            // 
            this.loadLevelToolStripMenuItem.Name = "loadLevelToolStripMenuItem";
            this.loadLevelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.loadLevelToolStripMenuItem.Text = "Load Level";
            // 
            // loadMaterialToolStripMenuItem
            // 
            this.loadMaterialToolStripMenuItem.Name = "loadMaterialToolStripMenuItem";
            this.loadMaterialToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.loadMaterialToolStripMenuItem.Text = "Load Material";
            this.loadMaterialToolStripMenuItem.Click += new System.EventHandler(this.loadMaterialToolStripMenuItem_Click);
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "Level";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1444, 771);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.previewPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(304, 765);
            this.tabControl.TabIndex = 0;
            // 
            // previewPage
            // 
            this.previewPage.Controls.Add(this.useOriginalTextureCheck);
            this.previewPage.Controls.Add(this.previewScreen);
            this.previewPage.Controls.Add(this.shapeParameters);
            this.previewPage.Controls.Add(this.commonParameters);
            this.previewPage.Controls.Add(this.label1);
            this.previewPage.Controls.Add(this.shapeBox);
            this.previewPage.Location = new System.Drawing.Point(4, 22);
            this.previewPage.Name = "previewPage";
            this.previewPage.Padding = new System.Windows.Forms.Padding(3);
            this.previewPage.Size = new System.Drawing.Size(296, 739);
            this.previewPage.TabIndex = 0;
            this.previewPage.Text = "Preview";
            this.previewPage.UseVisualStyleBackColor = true;
            // 
            // previewScreen
            // 
            this.previewScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.previewScreen.Location = new System.Drawing.Point(3, 3);
            this.previewScreen.Name = "previewScreen";
            this.previewScreen.Size = new System.Drawing.Size(290, 290);
            this.previewScreen.TabIndex = 9;
            this.previewScreen.Text = "previewScreen";
            // 
            // shapeParameters
            // 
            this.shapeParameters.Controls.Add(this.shapeParametersControl);
            this.shapeParameters.Location = new System.Drawing.Point(3, 498);
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
            // customShapeScale
            // 
            this.customShapeScale.DecimalPlaces = 2;
            this.customShapeScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.customShapeScale.Location = new System.Drawing.Point(4, 20);
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
            this.label28.Location = new System.Drawing.Point(3, 3);
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
            this.commonParameters.Location = new System.Drawing.Point(3, 343);
            this.commonParameters.Name = "commonParameters";
            this.commonParameters.Size = new System.Drawing.Size(281, 149);
            this.commonParameters.TabIndex = 7;
            this.commonParameters.TabStop = false;
            this.commonParameters.Text = "Common Parameters";
            // 
            // drawOutlineCheck
            // 
            this.drawOutlineCheck.AutoSize = true;
            this.drawOutlineCheck.Location = new System.Drawing.Point(162, 119);
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
            this.setAsTextureCheck.Location = new System.Drawing.Point(162, 102);
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
            65536});
            this.materialScale.Location = new System.Drawing.Point(6, 116);
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
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Material Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Material";
            // 
            // materialBox
            // 
            this.materialBox.FormattingEnabled = true;
            this.materialBox.Location = new System.Drawing.Point(6, 35);
            this.materialBox.Name = "materialBox";
            this.materialBox.Size = new System.Drawing.Size(264, 21);
            this.materialBox.TabIndex = 2;
            this.materialBox.SelectedValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Color";
            // 
            // colorBox
            // 
            this.colorBox.FormattingEnabled = true;
            this.colorBox.Location = new System.Drawing.Point(6, 75);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(264, 21);
            this.colorBox.TabIndex = 3;
            this.colorBox.SelectedValueChanged += new System.EventHandler(this.HandlePreview);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Shape";
            // 
            // shapeBox
            // 
            this.shapeBox.FormattingEnabled = true;
            this.shapeBox.Location = new System.Drawing.Point(3, 316);
            this.shapeBox.Name = "shapeBox";
            this.shapeBox.Size = new System.Drawing.Size(148, 21);
            this.shapeBox.TabIndex = 1;
            this.shapeBox.SelectedValueChanged += new System.EventHandler(this.ShapeParameterSwitch);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(296, 739);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(313, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1128, 765);
            this.splitContainer1.SplitterDistance = 851;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.levelPage);
            this.tabControl1.Controls.Add(this.objectTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(851, 765);
            this.tabControl1.TabIndex = 0;
            // 
            // levelPage
            // 
            this.levelPage.Controls.Add(this.levelScreen);
            this.levelPage.Location = new System.Drawing.Point(4, 22);
            this.levelPage.Name = "levelPage";
            this.levelPage.Padding = new System.Windows.Forms.Padding(3);
            this.levelPage.Size = new System.Drawing.Size(843, 739);
            this.levelPage.TabIndex = 0;
            this.levelPage.Text = "Level";
            this.levelPage.UseVisualStyleBackColor = true;
            // 
            // levelScreen
            // 
            this.levelScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelScreen.Location = new System.Drawing.Point(3, 3);
            this.levelScreen.Margin = new System.Windows.Forms.Padding(0);
            this.levelScreen.Name = "levelScreen";
            this.levelScreen.Size = new System.Drawing.Size(837, 733);
            this.levelScreen.TabIndex = 0;
            this.levelScreen.Text = "levelScreen";
            // 
            // objectTab
            // 
            this.objectTab.Controls.Add(this.objectScreen);
            this.objectTab.Location = new System.Drawing.Point(4, 22);
            this.objectTab.Name = "objectTab";
            this.objectTab.Padding = new System.Windows.Forms.Padding(3);
            this.objectTab.Size = new System.Drawing.Size(843, 739);
            this.objectTab.TabIndex = 1;
            this.objectTab.Text = "Object";
            this.objectTab.UseVisualStyleBackColor = true;
            // 
            // objectScreen
            // 
            this.objectScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectScreen.Location = new System.Drawing.Point(3, 3);
            this.objectScreen.Margin = new System.Windows.Forms.Padding(0);
            this.objectScreen.Name = "objectScreen";
            this.objectScreen.Size = new System.Drawing.Size(837, 733);
            this.objectScreen.TabIndex = 0;
            this.objectScreen.Text = "objectScreen";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(273, 765);
            this.propertyGrid.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 773);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1444, 22);
            this.statusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(1429, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "Ready.";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // useOriginalTextureCheck
            // 
            this.useOriginalTextureCheck.AutoSize = true;
            this.useOriginalTextureCheck.Checked = true;
            this.useOriginalTextureCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useOriginalTextureCheck.Location = new System.Drawing.Point(170, 316);
            this.useOriginalTextureCheck.Name = "useOriginalTextureCheck";
            this.useOriginalTextureCheck.Size = new System.Drawing.Size(116, 17);
            this.useOriginalTextureCheck.TabIndex = 11;
            this.useOriginalTextureCheck.Text = "Use original texture";
            this.useOriginalTextureCheck.UseVisualStyleBackColor = true;
            this.useOriginalTextureCheck.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1444, 795);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "LevelEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.levelPage.ResumeLayout(false);
            this.objectTab.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage previewPage;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage levelPage;
        private System.Windows.Forms.TabPage objectTab;
        private XnaScreen objectScreen;
        private XnaScreen levelScreen;
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
        private System.Windows.Forms.ToolStripMenuItem loadMaterialToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private PreviewScreen previewScreen;
        private System.Windows.Forms.CheckBox setAsTextureCheck;
        private System.Windows.Forms.CheckBox drawOutlineCheck;
        private System.Windows.Forms.CheckBox useOriginalTextureCheck;


    }
}

