using LibiadaCore.Classes.Misc.Iterators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.Iterators
{
    [TestFixture]
    class FromFixStartCutRuleTest
    {
        [Test]
        public void CutRuleTest()
        {
            const int length = 12;
            const int step = 3;
            var rule = new CutRuleWithFixedStart(length, step);
            CutRuleIterator iterator = rule.GetIterator(); //объект, который бегает по массиву

            for (int i = step; i <= length; i += step)
            {
                iterator.Next();
                Assert.AreEqual(0, iterator.GetStartPosition());
                Assert.AreEqual(i, iterator.GetEndPosition());
            }
        }
    }
}
