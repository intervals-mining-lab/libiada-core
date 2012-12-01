using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Misc.Iterators
{
    [TestFixture]
    public class TestSimpleCutRule
    {
        [Test]
        public void testCutRule()
        {
            SimpleCutRule rule = new SimpleCutRule(12, 3);
            CutRuleIterator iterator = rule.getIterator(); //объект, который бегает по массиву
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 1);
            Assert.AreEqual(iterator.getStopPos(), 3);
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 4);
            Assert.AreEqual(iterator.getStopPos(), 6);
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 7);
            Assert.AreEqual(iterator.getStopPos(), 9);
            iterator.next();
            Assert.AreEqual(iterator.getStartPos(), 10);
            Assert.AreEqual(iterator.getStopPos(), 12);
        }
    }
}
