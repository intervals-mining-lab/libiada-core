using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    public class SimpleCutRuleWithBeginEndTest
    {
        [Test]
        public void CutRuleTest()
        {
            SimpleCutRuleWithBeginEnd rule = new SimpleCutRuleWithBeginEnd(18, 3, 5, 5);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву
            iterator.Next();
            Assert.AreEqual(5, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 10);
            iterator.Next();
            Assert.AreEqual(8, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 13);
            iterator.Next();
            Assert.AreEqual(11, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 16);
        }
    }
}
