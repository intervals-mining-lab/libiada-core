﻿namespace LibiadaCore.Tests.Iterators
{
    using LibiadaCore.Iterators;

    using NUnit.Framework;

    /// <summary>
    /// The cut rule with shifted and fixed start test.
    /// </summary>
    [TestFixture]
    public class CutRuleWithShiftedAndFixedStartTests
    {
        /// <summary>
        /// The cut rule test.
        /// </summary>
        [Test]
        public void CutRuleTest()
        {
            var rule = new CutRuleWithShiftedAndFixedStart(18, 3, 5);

            CutRuleIterator iterator = rule.GetIterator();

            for (int i = 8; i <= 17; i += 3)
            {
                iterator.Next();
                Assert.AreEqual(5, iterator.GetStartPosition());
                Assert.AreEqual(i, iterator.GetEndPosition());
            }
        }
    }
}
