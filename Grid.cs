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
        public const int mine_value = 9;

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

        public void IncCell(int row, int column)
        {
            // Метод увеличивающий значение клетки сетки на 1, если значение не максимальное
            // row - строка сетки
            // column - столбец сетки
            var current_value = this[row, column];
            if (current_value == mine_value) return; 
            this[row, column] = current_value + 1;
        }

        public void UpAdjacentInc(int row, int column)
        {
            if (row > 0) IncCell(row - 1, column);
        }

        public void RightUpAdjacentInc(int row, int column)
        {
            if (row > 0 && column < columns - 1) IncCell(row - 1, column + 1); 
        }

        public void RightAdjacentInc(int row, int column)
        {
            if (column < columns - 1) IncCell(row, column + 1);
        }

        public void RightDownAdjacentInc(int row, int column)
        {
            if (row < rows - 1 && column < columns - 1) IncCell(row + 1, column + 1);
        }

        public void DownAdjacentInc(int row, int column)
        {
            if (row < rows - 1) IncCell(row + 1, column);
        }

        public void LeftDownAdjacentInc(int row, int column)
        {
            if (row < rows - 1 && column > 0) IncCell(row + 1, column);
        }
    }
}
