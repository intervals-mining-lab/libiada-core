﻿namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Misc.Iterators;

    using NUnit.Framework;

    /// <summary>
    /// The diff cutter test.
    /// </summary>
    [TestFixture]
    public class DiffCutterTest
    {
        /// <summary>
        /// The diff test.
        /// </summary>
        [Test]
        public void DiffTest()
        {
            string source = "reegwvwvw";
            var rule = new CutRuleWithFixedStart(source.Length, 3);
            List<string> cuts = DiffCutter.Cut(source, rule);

            Assert.AreEqual("ree", cuts[0]); 
            Assert.AreEqual("reegwv", cuts[1]);
            Assert.AreEqual("reegwvwvw", cuts[2]);
        }
    }
}