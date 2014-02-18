using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    public class DiffCutterTest
    {
        [Test]
        public void DiffTest()
        {
            String s = "reegwvwvw";
            var rule = new CutRuleWithFixedStart(s.Length, 3);  //правило разбиения
            List<String> cuts = DiffCutter.Cut(s, rule);  //метод разрубающий строчку

            Assert.AreEqual("ree", cuts[0]);        //проверяем правильность результата
            Assert.AreEqual("reegwv", cuts[1]);
            Assert.AreEqual("reegwvwvw", cuts[2]);
        }
    }
}
