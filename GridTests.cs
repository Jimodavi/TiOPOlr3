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
    }
}