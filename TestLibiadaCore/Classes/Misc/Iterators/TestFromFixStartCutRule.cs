using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Misc.Iterators
{
    [TestFixture]
    class TestFromFixStartCutRule
    {
        [Test]
        public void testCutRule()
        {
            FromFixStartCutRule rule = new FromFixStartCutRule(12, 3);
            CutRuleIterator iterator = rule.getIterator(); //объект, который бегает по массиву
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 1);
            Assert.AreEqual(iterator.getStopPos(), 3);
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 1);
            Assert.AreEqual(iterator.getStopPos(), 6);
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 1);
            Assert.AreEqual(iterator.getStopPos(), 9);
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 1);
            Assert.AreEqual(iterator.getStopPos(), 12);
        }
    }
}
