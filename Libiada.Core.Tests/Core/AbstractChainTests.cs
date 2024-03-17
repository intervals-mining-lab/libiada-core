namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;

/// <summary>
/// The abstract chain tests.
/// </summary>
[TestFixture]
public class AbstractChainTests
{
    /// <summary>
    /// The to string test.
    /// </summary>
    [Test]
    public void ToStringTest()
    {
        const string expected = "abcabccc";
        var chain = new Chain(expected);
        Assert.That(chain.ToString(), Is.EqualTo(expected));
        var baseChain = new BaseChain(expected);
        Assert.That(baseChain.ToString(), Is.EqualTo(expected));
    }

    /// <summary>
    /// The to string delimiter test.
    /// </summary>
    [Test]
    public void ToStringDelimiterTest()
    {
        const string source = "abcabccc";
        var chain = new Chain(source);
        var baseChain = new BaseChain(source);

        var expected = "a b c a b c c c";
        Assert.Multiple(() =>
        {
            Assert.That(chain.ToString(" "), Is.EqualTo(expected));
            Assert.That(baseChain.ToString(" "), Is.EqualTo(expected));
        });

        expected = "acbcccacbcccccc";
        Assert.Multiple(() =>
        {
            Assert.That(chain.ToString("c"), Is.EqualTo(expected));
            Assert.That(baseChain.ToString("c"), Is.EqualTo(expected));
        });
    }

    /// <summary>
    /// The to string long delimiter test.
    /// </summary>
    [Test]
    public void ToStringLongDelimiterTest()
    {
        const string source = "abcabccc";
        var chain = new Chain(source);
        var baseChain = new BaseChain(source);

        var expected = "a - b - c - a - b - c - c - c";
        Assert.Multiple(() =>
        {
            Assert.That(chain.ToString(" - "), Is.EqualTo(expected));
            Assert.That(baseChain.ToString(" - "), Is.EqualTo(expected));
        });

        expected = "a, b, c, a, b, c, c, c";
        Assert.Multiple(() =>
        {
            Assert.That(chain.ToString(", "), Is.EqualTo(expected));
            Assert.That(baseChain.ToString(", "), Is.EqualTo(expected));
        });
    }
}
