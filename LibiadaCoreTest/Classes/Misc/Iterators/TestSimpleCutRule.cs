using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    public class TestSimpleCutRule
    {
        [Test]
        public void TestCutRule()
        {
            SimpleCutRule rule = new SimpleCutRule(100, 3, 3);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву
            iterator.Next();
            Assert.AreEqual(0, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 3);
            iterator.Next();
            Assert.AreEqual(3, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 6);
            iterator.Next();
            Assert.AreEqual(6, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 9);
            iterator.Next();
            Assert.AreEqual(9, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 12);
        }
    }
}
