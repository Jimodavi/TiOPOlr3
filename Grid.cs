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
            //todo реализовать метод get позднее до конца
            get { return 9; }
            //todo реализовать метод set позднее до конца
            set { }
        }
    }
}
