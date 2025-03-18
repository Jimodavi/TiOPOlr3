using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3
{
    public class Grid
    {
        public readonly int rows;
        public readonly int columns;
        public readonly int[,] cells;

        public Grid()
        {

        }

        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.cells = new int[rows, columns];
        }

        public int this[int row, int column]
        {
            get { return cells[row, column]; }
            set { cells[row, column] = value; }
        }
    }
}
