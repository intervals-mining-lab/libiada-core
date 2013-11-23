using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    public class SimpleCutRuleTest
    {
        [Test]
        public void CutRuleTest()
        {
            SimpleCutRule rule = new SimpleCutRule(100, 3, 3);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву

            for (int i = 0; i <= 12; i+=3)
            {
                iterator.Next();
                Assert.AreEqual(i, iterator.GetStartPos());
                Assert.AreEqual(i+3, iterator.GetStopPos());
            }
        }
    }
}
