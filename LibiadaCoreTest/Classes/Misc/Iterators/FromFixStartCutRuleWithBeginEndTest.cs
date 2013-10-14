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
            iterator.Next();
            Assert.AreEqual(5, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 8);
            iterator.Next();
            Assert.AreEqual(5, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 11);
            iterator.Next();
            Assert.AreEqual(5, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 14);
            iterator.Next();
            Assert.AreEqual(5, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 17);
        }
    }
}
