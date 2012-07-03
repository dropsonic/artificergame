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
            this.SuspendLayout();
            
            // 
            // GraphicDevicePanel
            // 
            this.GraphicDevicePanel.AutoScroll = true;
            this.GraphicDevicePanel.Location = new System.Drawing.Point(260, 54);
            this.GraphicDevicePanel.Name = "GraphicDevicePanel";
            this.GraphicDevicePanel.Size = new System.Drawing.Size(602, 499);
            this.GraphicDevicePanel.TabIndex = 0;
            this.GraphicDevicePanel.Controls.Add(this.xnaScreen);
            // 
            // XnaScreen
            // 
            this.xnaScreen.Dock = System.Windows.Forms.DockStyle.None;
            this.xnaScreen.Location = new System.Drawing.Point(0, 0);
            this.xnaScreen.Name = "XnaScreen";
            this.xnaScreen.Size = new System.Drawing.Size(1280, 720);
            this.xnaScreen.TabIndex = 0;
            this.xnaScreen.Text = "XnaScreen";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 701);
            this.Controls.Add(this.GraphicDevicePanel);
            this.Name = "MainForm";
            this.Text = "LevelEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private XnaScreen xnaScreen;
        private System.Windows.Forms.Panel GraphicDevicePanel;
    }
}

