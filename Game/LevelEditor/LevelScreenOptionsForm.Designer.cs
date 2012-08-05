namespace LevelEditor
{
    partial class LevelScreenOptionsForm
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
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.meterHeightBox = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gravityXBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.gravityYBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meterHeightBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gravityXBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravityYBox)).BeginInit();
            this.SuspendLayout();
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(9, 32);
            this.widthBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(120, 20);
            this.widthBox.TabIndex = 0;
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(149, 32);
            this.heightBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(120, 20);
            this.heightBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height in meters";
            // 
            // meterHeightBox
            // 
            this.meterHeightBox.Location = new System.Drawing.Point(9, 82);
            this.meterHeightBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.meterHeightBox.Name = "meterHeightBox";
            this.meterHeightBox.Size = new System.Drawing.Size(120, 20);
            this.meterHeightBox.TabIndex = 5;
            // 
            // applyButton
            // 
            this.applyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyButton.Location = new System.Drawing.Point(217, 199);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.widthBox);
            this.groupBox1.Controls.Add(this.meterHeightBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.heightBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 113);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.gravityXBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.gravityYBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 62);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gravity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "X";
            // 
            // gravityXBox
            // 
            this.gravityXBox.DecimalPlaces = 2;
            this.gravityXBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gravityXBox.Location = new System.Drawing.Point(9, 32);
            this.gravityXBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.gravityXBox.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.gravityXBox.Name = "gravityXBox";
            this.gravityXBox.Size = new System.Drawing.Size(120, 20);
            this.gravityXBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Y";
            // 
            // gravityYBox
            // 
            this.gravityYBox.DecimalPlaces = 2;
            this.gravityYBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gravityYBox.Location = new System.Drawing.Point(149, 32);
            this.gravityYBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.gravityYBox.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.gravityYBox.Name = "gravityYBox";
            this.gravityYBox.Size = new System.Drawing.Size(120, 20);
            this.gravityYBox.TabIndex = 1;
            // 
            // LevelScreenOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 232);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelScreenOptionsForm";
            this.Text = "Level Screen Options";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meterHeightBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gravityXBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravityYBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown widthBox;
        private System.Windows.Forms.NumericUpDown heightBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown meterHeightBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown gravityXBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown gravityYBox;
    }
}