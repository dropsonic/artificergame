using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class LevelScreenOptionsForm : Form
    {
        public int Height { get; set; }
        public int Width { get; set; }
        
        public int HeightInMeters { get; set; }

        public float GravityX { get; set; }
        public float GravityY { get; set; }

        public LevelScreenOptionsForm(int width, int height, int heightInMeters, float gravityX, float gravityY)
        {
            InitializeComponent();

            heightBox.Value =  height;
            widthBox.Value =  width;
            meterHeightBox.Value =  heightInMeters;
            gravityXBox.Value = Decimal.Parse(gravityX.ToString());
            gravityYBox.Value = Decimal.Parse(gravityY.ToString());

        }


        private void applyButton_Click(object sender, EventArgs e)
        {
            Height = Decimal.ToInt32(heightBox.Value);
            Width = Decimal.ToInt32(widthBox.Value);
            HeightInMeters = Decimal.ToInt32(meterHeightBox.Value);
            GravityX = (float)Decimal.ToDouble(gravityXBox.Value);
            GravityY = (float)Decimal.ToDouble(gravityYBox.Value);
        }

    }
}
