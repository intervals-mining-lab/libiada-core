namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;

/// <summary>
/// The abstract sequence tests.
/// </summary>
[TestFixture]
public class AbstractSequenceTests
{
    /// <summary>
    /// The to string test.
    /// </summary>
    [Test]
    public void ToStringTest()
    {
        const string expected = "abcabccc";
        ComposedSequence composedSequence = new(expected);
        Assert.That(composedSequence.ToString(), Is.EqualTo(expected));
        Sequence sequence = new(expected);
        Assert.That(sequence.ToString(), Is.EqualTo(expected));
    }

    /// <summary>
    /// The to string delimiter test.
    /// </summary>
    [Test]
    public void ToStringDelimiterTest()
    {
        const string source = "abcabccc";
        ComposedSequence composedSequence = new(source);
        Sequence sequence = new(source);

        string expected = "a b c a b c c c";
        Assert.Multiple(() =>
        {
            Assert.That(composedSequence.ToString(" "), Is.EqualTo(expected));
            Assert.That(sequence.ToString(" "), Is.EqualTo(expected));
        });

        expected = "acbcccacbcccccc";
        Assert.Multiple(() =>
        {
            Assert.That(composedSequence.ToString("c"), Is.EqualTo(expected));
            Assert.That(sequence.ToString("c"), Is.EqualTo(expected));
        });
    }

    /// <summary>
    /// The to string long delimiter test.
    /// </summary>
    [Test]
    public void ToStringLongDelimiterTest()
    {
        const string source = "abcabccc";
        ComposedSequence composedSequence = new(source);
        Sequence sequence = new(source);

        string expected = "a - b - c - a - b - c - c - c";
        Assert.Multiple(() =>
        {
            Assert.That(composedSequence.ToString(" - "), Is.EqualTo(expected));
            Assert.That(sequence.ToString(" - "), Is.EqualTo(expected));
        });

        expected = "a, b, c, a, b, c, c, c";
        Assert.Multiple(() =>
        {
            Assert.That(composedSequence.ToString(", "), Is.EqualTo(expected));
            Assert.That(sequence.ToString(", "), Is.EqualTo(expected));
        });
    }
}
