using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    class FromFixStartCutRuleTest
    {
        [Test]
        public void CutRuleTest()
        {
            int length = 12, step = 3;
            FromFixStartCutRule rule = new FromFixStartCutRule(length, step);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву

            for (int i = step; i <= length; i += step)
            {
                iterator.Next();
                Assert.AreEqual(0, iterator.GetStartPos());
                Assert.AreEqual(i, iterator.GetStopPos());
            }
        }
    }
}
