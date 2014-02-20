namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    using LibiadaCore.Classes.Misc.Iterators;

    using NUnit.Framework;

    [TestFixture]
    public class SimpleCutRuleWithShiftedStartTest
    {
        [Test]
        public void CutRuleTest()
        {
            var rule = new SimpleCutRuleWithShiftedStart(18, 3, 5, 5);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву

            for (int i = 5; i <= 11; i+=3)
            {
                iterator.Next();
                Assert.AreEqual(i, iterator.GetStartPosition());
                Assert.AreEqual(i+5, iterator.GetEndPosition());
            }
        }
    }
}
