namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Iterators;

using NUnit.Framework;

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
        var rule = new SimpleCutRule(100, 3, 3);
        CutRuleIterator iterator = rule.GetIterator();

        for (int i = 0; i <= 12; i += 3)
        {
            iterator.Next();
            Assert.AreEqual(i, iterator.GetStartPosition());
            Assert.AreEqual(i + 3, iterator.GetEndPosition());
        }
    }
}
