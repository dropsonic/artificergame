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

        public LevelScreenOptionsForm(int width, int height, int heightInMeters)
        {
            InitializeComponent();

            heightBox.Value = Height = height;
            widthBox.Value = Width = width;
            meterHeightBox.Value = HeightInMeters = heightInMeters;
        }

        private void valueChanged(object sender, EventArgs e)
        {
            Height = Decimal.ToInt32(heightBox.Value);
            Width = Decimal.ToInt32(widthBox.Value);
            HeightInMeters = Decimal.ToInt32(meterHeightBox.Value);
        }


    }
}
