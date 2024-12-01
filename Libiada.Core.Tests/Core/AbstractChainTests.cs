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
        Chain chain = new(expected);
        Assert.That(chain.ToString(), Is.EqualTo(expected));
        BaseChain baseChain = new(expected);
        Assert.That(baseChain.ToString(), Is.EqualTo(expected));
    }

    /// <summary>
    /// The to string delimiter test.
    /// </summary>
    [Test]
    public void ToStringDelimiterTest()
    {
        const string source = "abcabccc";
        Chain chain = new(source);
        BaseChain baseChain = new(source);

        string expected = "a b c a b c c c";
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
        Chain chain = new(source);
        BaseChain baseChain = new(source);

        string expected = "a - b - c - a - b - c - c - c";
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
