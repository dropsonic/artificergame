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
        public bool InMeters { get; set; }

        public GridSnapOptions(int gridWidth, int gridHeight, bool inMeters)
        {
            InitializeComponent();

            if (inMeters)
            {
                gridWidthBox.Value = (int)ConvertUnits.ToSimUnits(gridWidth);
                gridHeightBox.Value = (int)ConvertUnits.ToSimUnits(gridHeight);
            }
            else
            {
                gridWidthBox.Value = gridWidth;
                gridHeightBox.Value = gridHeight;
            }
            InMeters = inMeters;
            inMetersCheck.Checked = inMeters;

            ShowDisplayUnits();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (InMeters)
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
            InMeters = inMetersCheck.Checked;
            ShowDisplayUnits();
        }

        private void ShowDisplayUnits()
        {
            if (InMeters)
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
