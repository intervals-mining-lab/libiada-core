namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Iterators;

/// <summary>
/// The diff cutter test.
/// </summary>
[TestFixture]
public class DiffCutterTests
{
    /// <summary>
    /// The diff test.
    /// </summary>
    [Test]
    public void DiffTest()
    {
        const string source = "reegwvwvw";
        CutRuleWithFixedStart rule = new(source.Length, 3);
        List<string> cuts = DiffCutter.Cut(source, rule);

        Assert.That(cuts[0], Is.EqualTo("ree"));
        Assert.That(cuts[1], Is.EqualTo("reegwv"));
        Assert.That(cuts[2], Is.EqualTo("reegwvwvw"));
    }
}
