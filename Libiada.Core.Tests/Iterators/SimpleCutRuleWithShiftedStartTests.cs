namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Iterators;

/// <summary>
/// The simple cut rule with shifted start test.
/// </summary>
[TestFixture]
public class SimpleCutRuleWithShiftedStartTests
{
    /// <summary>
    /// The cut rule test.
    /// </summary>
    [Test]
    public void CutRuleTest()
    {
        SimpleCutRuleWithShiftedStart rule = new(18, 3, 5, 5);
        CutRuleIterator iterator = rule.GetIterator();

        for (int i = 5; i <= 11; i += 3)
        {
            iterator.Next();
            Assert.Multiple(() =>
            {
                Assert.That(iterator.GetStartPosition(), Is.EqualTo(i));
                Assert.That(iterator.GetEndPosition(), Is.EqualTo(i + 5));
            });
        }
    }
}
