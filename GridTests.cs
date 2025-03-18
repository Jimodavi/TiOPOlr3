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
    }
}