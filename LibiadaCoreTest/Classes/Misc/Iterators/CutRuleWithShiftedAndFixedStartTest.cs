namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    using LibiadaCore.Classes.Misc.Iterators;

    using NUnit.Framework;

    [TestFixture]
    class CutRuleWithShiftedAndFixedStartTest
    {
        [Test]
        public void CutRuleTest()
        {
            var rule = new CutRuleWithShiftedAndFixedStart(18, 3, 5);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву

            for (int i = 8; i <= 17; i+=3)
            {
                iterator.Next();
                Assert.AreEqual(5, iterator.GetStartPosition());
                Assert.AreEqual(i, iterator.GetEndPosition());
            }
        }
    }
}
