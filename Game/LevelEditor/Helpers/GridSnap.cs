using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LevelEditor.Helpers
{
    public class GridSnap
    {
        public GridSnap()
        {
            GridTile = new Point(1,1);
            Enabled = false;
        }

        public GridSnap(Point tile)
        {
            GridTile = tile;
        }

        public GridSnap(Point tile, bool enabled):this(tile)
        {
            Enabled = enabled;
        }

        public bool Enabled { get; set; }

        private Point _gridTile;
        public Point GridTile
        {
            get
            {
                return _gridTile;
            }
            set
            {
                if (value.X <= 0 || value.Y <= 0)
                    throw new ArgumentException("Infinite number of lines");
                _gridTile = value;
            }
        }

        public int GridWidth
        {
            get
            {
                return GridTile.X;
            }
            set
            {
                GridTile = new Point(value, GridTile.Y);
            }
        }

        public int GridHeight
        {
            get
            {
                return GridTile.Y;
            }
            set
            {
                GridTile = new Point(GridTile.X, value);
            }
        }

        public Point SnapToGrid(Point position)
        {
            if (Enabled)
            {
                if (position.X % GridWidth < GridWidth / 2)
                    position.X = position.X - position.X % GridWidth;
                else
                    position.X = position.X + (GridWidth - position.X % GridWidth);

                if (position.Y % GridHeight < GridHeight / 2)
                    position.Y = position.Y - position.Y % GridHeight;
                else
                    position.Y = position.Y + (GridHeight - position.Y % GridHeight);
            }
            return position;
        }
    }
}
