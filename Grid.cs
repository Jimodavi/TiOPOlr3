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

        public Grid()
        {

        }
        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }
    }
}
