namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Iterators;

/// <summary>
/// The cut rule with shifted and fixed start test.
/// </summary>
[TestFixture]
public class CutRuleWithShiftedAndFixedStartTests
{
    /// <summary>
    /// The cut rule test.
    /// </summary>
    [Test]
    public void CutRuleTest()
    {
        CutRuleWithShiftedAndFixedStart rule = new(18, 3, 5);

        CutRuleIterator iterator = rule.GetIterator();

        for (int i = 8; i <= 17; i += 3)
        {
            iterator.Next();
            Assert.Multiple(() =>
            {
                Assert.That(iterator.GetStartPosition(), Is.EqualTo(5));
                Assert.That(iterator.GetEndPosition(), Is.EqualTo(i));
            });
        }
    }
}
