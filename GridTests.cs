using Microsoft.VisualStudio.TestTools.UnitTesting;
using lr3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3.Tests
{
    [TestClass()]
    public class GridTests
    {
        [TestMethod()]
        public void GridCreationTest()
        {
            Grid actual = new Grid();
            Assert.IsNotNull(actual, "Сбой создания сетки. Ожидается not null объект класса.");
        }

        [TestMethod()]
        public void GridCreationWithParamsTest()
        {
            int expected_rows = 6;
            int expected_columns = 6;
            Grid actual = new Grid(expected_rows,expected_columns);
            Assert.IsNotNull(actual, "Сбой создания сетки c аргументами. Ожидается not null объект класса.");
        }

        [TestMethod()]
        public void GridGetRowsTest()
        {
            int expected_rows = 6;
            Grid actual = new Grid(expected_rows, expected_rows);
            try
            {
                Assert.AreEqual(expected_rows, actual.rows);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой получения строк сетки. Ожидается " + expected_rows + "строк. Фактически " + actual.rows + " строк.");
            }
        }

        [TestMethod()]
        public void GridGetColumnTest()
        {
            int expected_columns = 7;
            Grid actual = new Grid(expected_columns, expected_columns);
            try
            {
                Assert.AreEqual(expected_columns, actual.columns);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой получения столбцов сетки. Ожидается " + expected_columns + "столбцов. Фактически " + actual.columns + " столбцов.");
            }
        }

        [TestMethod()]
        public void GridCellCreationTest()
        {
            int expected = 9;
            int rows = 2;
            int columns = 3;
            Grid actual = new Grid(rows,columns);
            int cell_row = 0;
            int cell_column = 1;
            actual[cell_row, cell_column] = expected;

            try
            {
                Assert.AreEqual(expected, actual[cell_row,cell_column]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой получения значения ячейки сетки. Ожидается " + expected + ". Фактически " + actual[cell_row,cell_column] + " .");
            }
        }

        [TestMethod()]
        public void GridIncCellTest()
        {
            int expected = 3;
            int rows = 5;
            int columns = 4;
            Grid actual = new Grid(rows, columns);
            int cell_row = 2;
            int cell_column = 2;
            actual[cell_row, cell_column] = expected - 1;
            actual.IncCell(cell_row, cell_column);

            try
            {
                Assert.AreEqual(expected, actual[cell_row, cell_column]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения ячейки сетки. Ожидается " + expected + ". Фактически " + actual[cell_row, cell_column] + " .");
            }
        }

        [TestMethod()]
        public void GridIncPastMaxCellTest()
        {
            int expected = Grid.mine_value;
            int rows = 7;
            int columns = 7;
            Grid actual = new Grid(rows, columns);
            int cell_row = 3;
            int cell_column = 0;
            actual[cell_row, cell_column] = expected;
            actual.IncCell(cell_row, cell_column);

            try
            {
                Assert.AreEqual(expected, actual[cell_row, cell_column]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения ячейки сетки больше максимума. Ожидается " + expected + ". Фактически " + actual[cell_row, cell_column] + " .");
            }
        }

        [TestMethod()]
        public void GridUpAdjacentIncTest()
        {
            int expected = 1;
            int rows = 4;
            int columns = 4;
            Grid actual = new Grid(rows, columns);
            int cell_row = 2;
            int cell_column = 3;

            try
            {
                actual.UpAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row-1, cell_column]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения соседней ячейки сверху. Ожидается " + expected + ". Фактически " + actual[cell_row-1, cell_column] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeUpAdjacentIncTest()
        {
            int rows = 13;
            int columns = 11;
            Grid actual = new Grid(rows, columns);
            int cell_row = 0;
            int cell_column = 6;

            try
            {
                actual.UpAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException)
            {
                throw new AssertFailedException("Сбой увеличения значения соседней ячейки сверху вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }

        [TestMethod()]
        public void GridRightUpAdjacentIncTest()
        {
            int expected = 1;
            int rows = 94;
            int columns = 25;
            Grid actual = new Grid(rows, columns);
            int cell_row = 25;
            int cell_column = 12;

            try
            {
                actual.RightUpAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row - 1, cell_column + 1]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения соседней ячейки справа сверху. Ожидается " + expected + ". Фактически " + actual[cell_row - 1, cell_column + 1] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeRightUpAdjacentIncTest()
        {
            int rows = 42;
            int columns = 76;
            Grid actual = new Grid(rows, columns);
            int cell_row = 36;
            int cell_column = 75;

            try
            {
                actual.RightUpAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки справа сверху вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }

        [TestMethod()]
        public void GridRightAdjacentIncTest()
        {
            int expected = 1;
            int rows = 55;
            int columns = 5;
            Grid actual = new Grid(rows, columns);
            int cell_row = 49;
            int cell_column = 2;

            try
            {
                actual.RightAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row, cell_column + 1]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки справа сверху. Ожидается " + expected + ". Фактически " + actual[cell_row - 1, cell_column + 1] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeRightAdjacentIncTest()
        {
            int rows = 13;
            int columns = 17;
            Grid actual = new Grid(rows, columns);
            int cell_row = 7;
            int cell_column = 16;

            try
            {
                actual.RightAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки справа вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }

        [TestMethod()]
        public void GridRightDownAdjacentIncTest()
        {
            int expected = 1;
            int rows = 80;
            int columns = 14;
            Grid actual = new Grid(rows, columns);
            int cell_row = 48;
            int cell_column = 12;

            try
            {
                actual.RightDownAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row + 1, cell_column + 1]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки справа снизу. Ожидается " + expected + ". Фактически " + actual[cell_row + 1, cell_column + 1] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeRightDownAdjacentIncTest()
        {
            int rows = 64;
            int columns = 84;
            Grid actual = new Grid(rows, columns);
            int cell_row = 63;
            int cell_column = 33;

            try
            {
                actual.RightDownAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки справа снизу вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }

        [TestMethod()]
        public void GridDownAdjacentIncTest()
        {
            int expected = 1;
            int rows = 69;
            int columns = 21;
            Grid actual = new Grid(rows, columns);
            int cell_row = 57;
            int cell_column = 2;

            try
            {
                actual.DownAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row + 1, cell_column]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки снизу. Ожидается " + expected + ". Фактически " + actual[cell_row + 1, cell_column] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeDownAdjacentIncTest()
        {
            int rows = 64;
            int columns = 84;
            Grid actual = new Grid(rows, columns);
            int cell_row = 63;
            int cell_column = 33;

            try
            {
                actual.DownAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки снизу вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }

        [TestMethod()]
        public void GridLeftDownAdjacentIncTest()
        {
            int expected = 1;
            int rows = 69;
            int columns = 21;
            Grid actual = new Grid(rows, columns);
            int cell_row = 57;
            int cell_column = 2;

            try
            {
                actual.DownAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row + 1, cell_column]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки снизу. Ожидается " + expected + ". Фактически " + actual[cell_row + 1, cell_column] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeLeftDownAdjacentIncTest()
        {
            int rows = 9;
            int columns = 6;
            Grid actual = new Grid(rows, columns);
            int cell_row = 2;
            int cell_column = 0;

            try
            {
                actual.LeftDownAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки снизу вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }

        [TestMethod()]
        public void GridLeftAdjacentIncTest()
        {
            int expected = 1;
            int rows = 79;
            int columns = 47;
            Grid actual = new Grid(rows, columns);
            int cell_row = 42;
            int cell_column = 10;

            try
            {
                actual.LeftAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row, cell_column - 1]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки слева. Ожидается " + expected + ". Фактически " + actual[cell_row, cell_column - 1] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeLeftAdjacentIncTest()
        {
            int rows = 25;
            int columns = 65;
            Grid actual = new Grid(rows, columns);
            int cell_row = 18;
            int cell_column = 0;

            try
            {
                actual.LeftAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки слева вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }

        [TestMethod()]
        public void GridLeftUpAdjacentIncTest()
        {
            int expected = 1;
            int rows = 67;
            int columns = 75;
            Grid actual = new Grid(rows, columns);
            int cell_row = 16;
            int cell_column = 32;

            try
            {
                actual.LeftUpAdjacentInc(cell_row, cell_column);
                Assert.AreEqual(expected, actual[cell_row - 1, cell_column - 1]);
            }
            catch (Exception)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки слева сверху. Ожидается " + expected + ". Фактически " + actual[cell_row - 1, cell_column - 1] + " .");
            }
        }

        [TestMethod()]
        public void GridOutOfRangeLeftUpAdjacentIncTest()
        {
            int rows = 82;
            int columns = 24;
            Grid actual = new Grid(rows, columns);
            int cell_row = 0;
            int cell_column = 7;

            try
            {
                actual.LeftUpAdjacentInc(cell_row, cell_column);
            }
            catch (IndexOutOfRangeException)
            {
                throw new AssertFailedException("Сбой увеличения значения сосендней ячейки слева сверху вне границ. Ожидается остановка обращения к индексу вне границ сетки.");
            }
        }
    }
}