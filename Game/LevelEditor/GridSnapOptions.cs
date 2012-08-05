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
        }

        private void inMetersCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (inMetersCheck.Checked)
            {
                gridWidthBox.Value = (int)ConvertUnits.ToSimUnits(Decimal.ToInt32(gridWidthBox.Value));
                gridHeightBox.Value = (int)ConvertUnits.ToSimUnits(Decimal.ToInt32(gridHeightBox.Value));
            }
            else
            {
                gridWidthBox.Value = (int)ConvertUnits.ToDisplayUnits(Decimal.ToInt32(gridWidthBox.Value));
                gridHeightBox.Value = (int)ConvertUnits.ToDisplayUnits(Decimal.ToInt32(gridHeightBox.Value));
            }
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


    }
}
