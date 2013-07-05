using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    class TestFromFixStartCutRule
    {
        [Test]
        public void TestCutRule()
        {
            FromFixStartCutRule rule = new FromFixStartCutRule(12, 3);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву
            iterator.Next();
            Assert.AreEqual(0, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 3);
            iterator.Next();
            Assert.AreEqual(0, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 6);
            iterator.Next();
            Assert.AreEqual(0, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 9);
            iterator.Next();
            Assert.AreEqual(0, iterator.GetStartPos());
            Assert.AreEqual(iterator.GetStopPos(), 12);
        }
    }
}
