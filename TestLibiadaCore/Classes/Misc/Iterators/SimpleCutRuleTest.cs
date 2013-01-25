using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Misc.Iterators
{
    [TestFixture]
    public class SimpleCutRuleTest
    {
        [Test]
        public void TestCutRule()
        {
            SimpleCutRule rule = new SimpleCutRule(100, 3, 3);
            CutRuleIterator iterator = rule.getIterator(); //объект, который бегает по массиву
            iterator.next();
            Assert.AreEqual(0, iterator.getStartPos());
            Assert.AreEqual(iterator.getStopPos(), 3);
            iterator.next();
            Assert.AreEqual(3, iterator.getStartPos());
            Assert.AreEqual(iterator.getStopPos(), 6);
            iterator.next();
            Assert.AreEqual(6, iterator.getStartPos());
            Assert.AreEqual(iterator.getStopPos(), 9);
            iterator.next();
            Assert.AreEqual(9, iterator.getStartPos());
            Assert.AreEqual(iterator.getStopPos(), 12);
        }
    }
}
