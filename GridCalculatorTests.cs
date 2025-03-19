using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr3.Tests
{
    [TestClass()]
    class GridCalculatorTests
    {
        [TestMethod()]
        public void GridCalculatorCreationTest()
        {
            int rows = 20;
            int columns = 19;
            GridCalculator actual = new GridCalculator(new Grid(rows, columns));
            Assert.IsNotNull(actual, "Сбой создания объекста GridCalculator. Ожидается not null объект класса.");
        }
    }
}