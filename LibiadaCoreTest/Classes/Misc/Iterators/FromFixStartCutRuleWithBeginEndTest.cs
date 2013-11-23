using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    class FromFixStartCutRuleWithBeginEndTest
    {
        [Test]
        public void CutRuleTest()
        {
            FromFixStartCutRuleWithBeginEnd rule = new FromFixStartCutRuleWithBeginEnd(18, 3, 5);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву

            for (int i = 8; i <= 17; i+=3)
            {
                iterator.Next();
                Assert.AreEqual(5, iterator.GetStartPos());
                Assert.AreEqual(i, iterator.GetStopPos());
            }
        }
    }
}
