using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    public class TestDifCutter
    {
        [Test]
        public void TestDif()
        {
            String s = "reegwvwvw";
            DifCutter dif = new DifCutter();   //рубит строчку
            FromFixStartCutRule rule = new FromFixStartCutRule(s.Length, 3);  //правило разбиения
            List<String> cuts = DifCutter.Cut(s, rule);  //метод разрубающий строчку

            Assert.AreEqual(cuts[0], "ree");        //проверяем правильность результата
            Assert.AreEqual(cuts[1], "reegwv");
            Assert.AreEqual(cuts[2], "reegwvwvw");
        }
    }
}
