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
            this.previewTab = new System.Windows.Forms.TabPage();
            this.shapeParameters = new System.Windows.Forms.GroupBox();
            this.commonParameters = new System.Windows.Forms.GroupBox();
            this.materialScale = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.materialBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeBox = new System.Windows.Forms.ComboBox();
            this.previewScreen = new LevelEditor.PreviewScreen();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xnaScreen = new LevelEditor.XnaScreen();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.previewTab.SuspendLayout();
            this.commonParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tabControl.Controls.Add(this.previewTab);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(304, 765);
            this.tabControl.TabIndex = 0;
            // 
            // previewTab
            // 
            this.previewTab.Controls.Add(this.shapeParameters);
            this.previewTab.Controls.Add(this.commonParameters);
            this.previewTab.Controls.Add(this.label1);
            this.previewTab.Controls.Add(this.shapeBox);
            this.previewTab.Controls.Add(this.previewScreen);
            this.previewTab.Location = new System.Drawing.Point(4, 22);
            this.previewTab.Name = "previewTab";
            this.previewTab.Padding = new System.Windows.Forms.Padding(3);
            this.previewTab.Size = new System.Drawing.Size(296, 739);
            this.previewTab.TabIndex = 0;
            this.previewTab.Text = "Preview";
            this.previewTab.UseVisualStyleBackColor = true;
            // 
            // shapeParameters
            // 
            this.shapeParameters.Location = new System.Drawing.Point(3, 498);
            this.shapeParameters.Name = "shapeParameters";
            this.shapeParameters.Size = new System.Drawing.Size(284, 128);
            this.shapeParameters.TabIndex = 8;
            this.shapeParameters.TabStop = false;
            this.shapeParameters.Text = "Shape Parameters";
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
            // previewScreen
            // 
            this.previewScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.previewScreen.Location = new System.Drawing.Point(3, 3);
            this.previewScreen.Name = "previewScreen";
            this.previewScreen.Size = new System.Drawing.Size(290, 290);
            this.previewScreen.TabIndex = 0;
            this.previewScreen.Text = "previewScreen";
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
            this.splitContainer1.Panel1.Controls.Add(this.xnaScreen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1128, 765);
            this.splitContainer1.SplitterDistance = 851;
            this.splitContainer1.TabIndex = 1;
            // 
            // xnaScreen
            // 
            this.xnaScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xnaScreen.Location = new System.Drawing.Point(0, 0);
            this.xnaScreen.Name = "xnaScreen";
            this.xnaScreen.Size = new System.Drawing.Size(851, 765);
            this.xnaScreen.TabIndex = 1;
            this.xnaScreen.Text = "xnaScreen";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(273, 765);
            this.propertyGrid.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1444, 795);
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
            this.previewTab.ResumeLayout(false);
            this.previewTab.PerformLayout();
            this.commonParameters.ResumeLayout(false);
            this.commonParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialScale)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage previewTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private XnaScreen xnaScreen;
        private System.Windows.Forms.ComboBox shapeBox;
        private PreviewScreen previewScreen;
        private System.Windows.Forms.ComboBox materialBox;
        private System.Windows.Forms.ComboBox colorBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox commonParameters;
        private System.Windows.Forms.GroupBox shapeParameters;
        private System.Windows.Forms.NumericUpDown materialScale;
        private System.Windows.Forms.Label label4;


    }
}

