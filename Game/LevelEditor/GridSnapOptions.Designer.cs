namespace LevelEditor
{
    partial class GridSnapOptions
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
            this.gridWidthBox = new System.Windows.Forms.NumericUpDown();
            this.gridHeightBox = new System.Windows.Forms.NumericUpDown();
            this.inMetersCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeightBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridWidthBox
            // 
            this.gridWidthBox.Location = new System.Drawing.Point(9, 32);
            this.gridWidthBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.gridWidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gridWidthBox.Name = "gridWidthBox";
            this.gridWidthBox.Size = new System.Drawing.Size(120, 20);
            this.gridWidthBox.TabIndex = 0;
            this.gridWidthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gridHeightBox
            // 
            this.gridHeightBox.Location = new System.Drawing.Point(9, 80);
            this.gridHeightBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.gridHeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gridHeightBox.Name = "gridHeightBox";
            this.gridHeightBox.Size = new System.Drawing.Size(120, 20);
            this.gridHeightBox.TabIndex = 1;
            this.gridHeightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inMetersCheck
            // 
            this.inMetersCheck.AutoSize = true;
            this.inMetersCheck.Location = new System.Drawing.Point(164, 35);
            this.inMetersCheck.Name = "inMetersCheck";
            this.inMetersCheck.Size = new System.Drawing.Size(69, 17);
            this.inMetersCheck.TabIndex = 2;
            this.inMetersCheck.Text = "In meters";
            this.inMetersCheck.UseVisualStyleBackColor = true;
            this.inMetersCheck.CheckedChanged += new System.EventHandler(this.inMetersCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grid width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grid height";
            // 
            // applyButton
            // 
            this.applyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyButton.Location = new System.Drawing.Point(186, 143);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gridWidthBox);
            this.groupBox1.Controls.Add(this.inMetersCheck);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gridHeightBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // GridSnapOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 179);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridSnapOptions";
            this.Text = "Grid Snap Options";
            ((System.ComponentModel.ISupportInitialize)(this.gridWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeightBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown gridWidthBox;
        private System.Windows.Forms.NumericUpDown gridHeightBox;
        private System.Windows.Forms.CheckBox inMetersCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}