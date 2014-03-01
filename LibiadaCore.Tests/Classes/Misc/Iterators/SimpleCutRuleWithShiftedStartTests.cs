namespace LibiadaCore.Tests.Classes.Misc.Iterators
{
    using LibiadaCore.Classes.Misc.Iterators;

    using NUnit.Framework;

    /// <summary>
    /// The simple cut rule with shifted start test.
    /// </summary>
    [TestFixture]
    public class SimpleCutRuleWithShiftedStartTests
    {
        /// <summary>
        /// The cut rule test.
        /// </summary>
        [Test]
        public void CutRuleTest()
        {
            var rule = new SimpleCutRuleWithShiftedStart(18, 3, 5, 5);
            CutRuleIterator iterator = rule.GetIterator();

            for (int i = 5; i <= 11; i += 3)
            {
                iterator.Next();
                Assert.AreEqual(i, iterator.GetStartPosition());
                Assert.AreEqual(i + 5, iterator.GetEndPosition());
            }
        }
    }
}