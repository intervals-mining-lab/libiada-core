namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Iterators;

/// <summary>
/// The simple cut rule test.
/// </summary>
[TestFixture]
public class SimpleCutRuleTests
{
    /// <summary>
    /// The cut rule test.
    /// </summary>
    [Test]
    public void CutRuleTest()
    {
        SimpleCutRule rule = new(100, 3, 3);
        CutRuleIterator iterator = rule.GetIterator();

        for (int i = 0; i <= 12; i += 3)
        {
            iterator.Next();
            Assert.Multiple(() =>
            {
                Assert.That(iterator.GetStartPosition(), Is.EqualTo(i));
                Assert.That(iterator.GetEndPosition(), Is.EqualTo(i + 3));
            });
        }
    }
}
