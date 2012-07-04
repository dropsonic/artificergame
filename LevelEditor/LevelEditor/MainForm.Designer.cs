using WinFormsGraphicsDevice;
namespace WindowsFormsApplication1
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
            this.GraphicDevicePanel = new System.Windows.Forms.Panel();
            this.xnaScreen = new WinFormsGraphicsDevice.XnaScreen();
            this.GraphicDevicePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphicDevicePanel
            // 
            this.GraphicDevicePanel.AutoScroll = true;
            this.GraphicDevicePanel.Controls.Add(this.xnaScreen);
            this.GraphicDevicePanel.Location = new System.Drawing.Point(355, 154);
            this.GraphicDevicePanel.Name = "GraphicDevicePanel";
            this.GraphicDevicePanel.Size = new System.Drawing.Size(523, 334);
            this.GraphicDevicePanel.TabIndex = 3;
            // 
            // xnaScreen
            // 
            this.xnaScreen.Location = new System.Drawing.Point(0, 0);
            this.xnaScreen.Name = "xnaScreen";
            this.xnaScreen.Size = new System.Drawing.Size(1280, 720);
            this.xnaScreen.TabIndex = 1;
            this.xnaScreen.Text = "xnaScreen1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 708);
            this.Controls.Add(this.GraphicDevicePanel);
            this.Name = "MainForm";
            this.Text = "LevelEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GraphicDevicePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GraphicDevicePanel;
        private XnaScreen xnaScreen;


    }
}

