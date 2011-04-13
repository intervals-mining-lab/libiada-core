 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;

namespace MDATest.OIPTest.TestScoreModel
{
    [TestClass]
    public class TestTie
    {
        [TestMethod]
        public void TestTie1()
        {
            Assert.AreEqual(-1, Tie.None);// Если нет лиги, должен выводить -1
        }
        [TestMethod]
        public void TestTie2()
        {
            Assert.AreEqual(0, Tie.Start);// Если начало лиги, должен выводить 0
        }
        [TestMethod]
        public void TestTie3()
        {
            Assert.AreEqual(1, Tie.Stop);// Если конец лиги, должен выводить 1
        }
    }
}
