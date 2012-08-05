using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarseerTools;

namespace LevelEditor
{
    public partial class GridSnapOptions : Form
    {
        public int GridWidth { get; set; }
        public int GridHeight { get; set; }

        public GridSnapOptions(int gridWidth, int gridHeight)
        {
            InitializeComponent();

            gridWidthBox.Value =  gridWidth;
            gridHeightBox.Value =  gridHeight;

            ShowDisplayUnits();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (inMetersCheck.Checked)
            {
                GridWidth = (int)ConvertUnits.ToDisplayUnits(Decimal.ToInt32(gridWidthBox.Value));
                GridHeight = (int)ConvertUnits.ToDisplayUnits(Decimal.ToInt32(gridHeightBox.Value));
            }
            else
            {
                GridWidth = Decimal.ToInt32(gridWidthBox.Value);
                GridHeight = Decimal.ToInt32(gridHeightBox.Value);
            }
        }

        private void size_ValueChanged(object sender, EventArgs e)
        {
            ShowDisplayUnits();
        }

        private void ShowDisplayUnits()
        {
            if (inMetersCheck.Checked)
            {
                this.displaySize.Text = string.Format("width{0,6:G}\nheight{1,5:G}", ConvertUnits.ToDisplayUnits(Decimal.ToInt32(gridWidthBox.Value)).ToString(), ConvertUnits.ToDisplayUnits(Decimal.ToInt32(gridHeightBox.Value)).ToString());
            }
            else
            {
                this.displaySize.Text = string.Format("width{0,6:G}\nheight{1,5:G}", gridWidthBox.Value.ToString(), gridHeightBox.Value.ToString());
            }
        }
    }
}
