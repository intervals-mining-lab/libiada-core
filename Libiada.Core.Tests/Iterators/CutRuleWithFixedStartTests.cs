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
        const int length = 12;
        const int step = 3;
        var rule = new CutRuleWithFixedStart(length, step);
        CutRuleIterator iterator = rule.GetIterator();

        for (int i = step; i <= length; i += step)
        {
            iterator.Next();
            Assert.Multiple(() =>
            {
                Assert.That(iterator.GetStartPosition(), Is.EqualTo(0));
                Assert.That(iterator.GetEndPosition(), Is.EqualTo(i));
            });
        }
    }
}
