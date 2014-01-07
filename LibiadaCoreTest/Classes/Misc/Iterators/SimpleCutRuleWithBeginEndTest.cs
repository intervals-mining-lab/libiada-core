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
            var rule = new SimpleCutRuleWithBeginEnd(18, 3, 5, 5);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву

            for (int i = 5; i <= 11; i+=3)
            {
                iterator.Next();
                Assert.AreEqual(i, iterator.GetStartPosition());
                Assert.AreEqual(i+5, iterator.GetStopPosition());
            }
        }
    }
}
