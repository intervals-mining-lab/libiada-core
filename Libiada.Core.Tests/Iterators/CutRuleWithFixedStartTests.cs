namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Iterators;

/// <summary>
/// The from fix start cut rule test.
/// </summary>
[TestFixture]
public class CutRuleWithFixedStartTests
{
    /// <summary>
    /// The cut rule test.
    /// </summary>
    [Test]
    public void CutRuleTest()
    {
        int length = 12;
        int step = 3;
        var rule = new CutRuleWithFixedStart(length, step);
        CutRuleIterator iterator = rule.GetIterator();

        for (int i = step; i <= length; i += step)
        {
            iterator.Next();
            Assert.AreEqual(0, iterator.GetStartPosition());
            Assert.AreEqual(i, iterator.GetEndPosition());
        }
    }
}
