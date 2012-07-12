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
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.previewPage = new System.Windows.Forms.TabPage();
            this.previewScreen = new LevelEditor.PreviewScreen();
            this.shapeParameters = new System.Windows.Forms.GroupBox();
            this.shapeParametersControl = new WindowsFormsApplication1.TabHiddenHeadersControl();
            this.circleTab = new System.Windows.Forms.TabPage();
            this.ellipseTab = new System.Windows.Forms.TabPage();
            this.arcTab = new System.Windows.Forms.TabPage();
            this.gearTab = new System.Windows.Forms.TabPage();
            this.capsuleTab = new System.Windows.Forms.TabPage();
            this.rectangleTab = new System.Windows.Forms.TabPage();
            this.roundedRectangleTab = new System.Windows.Forms.TabPage();
            this.customShapeTab = new System.Windows.Forms.TabPage();
            this.commonParameters = new System.Windows.Forms.GroupBox();
            this.materialScale = new System.Windows.Forms.NumericUpDown();
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
            this.label5 = new System.Windows.Forms.Label();
            this.circleRadius = new System.Windows.Forms.NumericUpDown();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.previewPage.SuspendLayout();
            this.shapeParameters.SuspendLayout();
            this.shapeParametersControl.SuspendLayout();
            this.circleTab.SuspendLayout();
            this.commonParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.levelPage.SuspendLayout();
            this.objectTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circleRadius)).BeginInit();
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
            this.loadLevelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
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
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.50466F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.49534F));
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
            this.shapeParameters.Size = new System.Drawing.Size(284, 196);
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
            this.shapeParametersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shapeParametersControl.Location = new System.Drawing.Point(3, 16);
            this.shapeParametersControl.Margin = new System.Windows.Forms.Padding(0);
            this.shapeParametersControl.Multiline = true;
            this.shapeParametersControl.Name = "shapeParametersControl";
            this.shapeParametersControl.SelectedIndex = 0;
            this.shapeParametersControl.Size = new System.Drawing.Size(278, 177);
            this.shapeParametersControl.TabIndex = 0;
            // 
            // circleTab
            // 
            this.circleTab.Controls.Add(this.circleRadius);
            this.circleTab.Controls.Add(this.label5);
            this.circleTab.Location = new System.Drawing.Point(4, 40);
            this.circleTab.Name = "circleTab";
            this.circleTab.Padding = new System.Windows.Forms.Padding(3);
            this.circleTab.Size = new System.Drawing.Size(270, 133);
            this.circleTab.TabIndex = 0;
            this.circleTab.Text = "Circle";
            this.circleTab.UseVisualStyleBackColor = true;
            // 
            // ellipseTab
            // 
            this.ellipseTab.Location = new System.Drawing.Point(4, 40);
            this.ellipseTab.Name = "ellipseTab";
            this.ellipseTab.Padding = new System.Windows.Forms.Padding(3);
            this.ellipseTab.Size = new System.Drawing.Size(270, 65);
            this.ellipseTab.TabIndex = 1;
            this.ellipseTab.Text = "Ellipse";
            this.ellipseTab.UseVisualStyleBackColor = true;
            // 
            // arcTab
            // 
            this.arcTab.Location = new System.Drawing.Point(4, 40);
            this.arcTab.Name = "arcTab";
            this.arcTab.Padding = new System.Windows.Forms.Padding(3);
            this.arcTab.Size = new System.Drawing.Size(270, 65);
            this.arcTab.TabIndex = 2;
            this.arcTab.Text = "Arc";
            this.arcTab.UseVisualStyleBackColor = true;
            // 
            // gearTab
            // 
            this.gearTab.Location = new System.Drawing.Point(4, 40);
            this.gearTab.Name = "gearTab";
            this.gearTab.Padding = new System.Windows.Forms.Padding(3);
            this.gearTab.Size = new System.Drawing.Size(270, 65);
            this.gearTab.TabIndex = 3;
            this.gearTab.Text = "Gear";
            this.gearTab.UseVisualStyleBackColor = true;
            // 
            // capsuleTab
            // 
            this.capsuleTab.Location = new System.Drawing.Point(4, 40);
            this.capsuleTab.Name = "capsuleTab";
            this.capsuleTab.Padding = new System.Windows.Forms.Padding(3);
            this.capsuleTab.Size = new System.Drawing.Size(270, 65);
            this.capsuleTab.TabIndex = 4;
            this.capsuleTab.Text = "Capsule";
            this.capsuleTab.UseVisualStyleBackColor = true;
            // 
            // rectangleTab
            // 
            this.rectangleTab.Location = new System.Drawing.Point(4, 40);
            this.rectangleTab.Name = "rectangleTab";
            this.rectangleTab.Padding = new System.Windows.Forms.Padding(3);
            this.rectangleTab.Size = new System.Drawing.Size(270, 65);
            this.rectangleTab.TabIndex = 5;
            this.rectangleTab.Text = "Rectangle";
            this.rectangleTab.UseVisualStyleBackColor = true;
            // 
            // roundedRectangleTab
            // 
            this.roundedRectangleTab.Location = new System.Drawing.Point(4, 40);
            this.roundedRectangleTab.Name = "roundedRectangleTab";
            this.roundedRectangleTab.Padding = new System.Windows.Forms.Padding(3);
            this.roundedRectangleTab.Size = new System.Drawing.Size(270, 65);
            this.roundedRectangleTab.TabIndex = 6;
            this.roundedRectangleTab.Text = "RoundedRectangle";
            this.roundedRectangleTab.UseVisualStyleBackColor = true;
            // 
            // customShapeTab
            // 
            this.customShapeTab.Location = new System.Drawing.Point(4, 40);
            this.customShapeTab.Name = "customShapeTab";
            this.customShapeTab.Padding = new System.Windows.Forms.Padding(3);
            this.customShapeTab.Size = new System.Drawing.Size(270, 65);
            this.customShapeTab.TabIndex = 7;
            this.customShapeTab.Text = "CustomShape";
            this.customShapeTab.UseVisualStyleBackColor = true;
            // 
            // commonParameters
            // 
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
            // materialScale
            // 
            this.materialScale.DecimalPlaces = 2;
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
            this.shapeBox.Size = new System.Drawing.Size(284, 21);
            this.shapeBox.TabIndex = 1;
            this.shapeBox.SelectedValueChanged += new System.EventHandler(this.HandlePreview);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Radius";
            // 
            // circleRadius
            // 
            this.circleRadius.Location = new System.Drawing.Point(7, 20);
            this.circleRadius.Name = "circleRadius";
            this.circleRadius.Size = new System.Drawing.Size(120, 20);
            this.circleRadius.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1444, 795);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "LevelEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.circleRadius)).EndInit();
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
        private System.Windows.Forms.NumericUpDown materialScale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage levelPage;
        private System.Windows.Forms.TabPage objectTab;
        private XnaScreen objectScreen;
        private PreviewScreen previewScreen;
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
        private System.Windows.Forms.NumericUpDown circleRadius;


    }
}

