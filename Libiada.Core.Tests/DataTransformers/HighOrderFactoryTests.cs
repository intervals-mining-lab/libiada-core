namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.DataTransformers;
using Libiada.Core.Tests.Core;

/// <summary>
/// The high order factory tests.
/// </summary>
[TestFixture(TestOf = typeof(HighOrderFactory))]
public class HighOrderFactoryTests
{
    /// <summary>
    /// The second order test.
    /// </summary>
    /// <param name="sequenceIndex">
    /// The sequence index.
    /// </param>
    /// <param name="resultIndex">
    /// The result index.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    [TestCase(0, 0, Link.Start)]
    [TestCase(1, 1, Link.End)]
    [TestCase(1, 2, Link.Start)]
    [TestCase(0, 3, Link.End)]
    [TestCase(0, 4, Link.CycleStart)]
    [TestCase(0, 5, Link.CycleEnd)]
    public void SecondOrderTest(int sequenceIndex, int resultIndex, Link link)
    {
        ComposedSequence result = HighOrderFactory.Create(SequencesStorage.CompusedSequences[sequenceIndex], link);
        ComposedSequence expected = SequencesStorage.HighOrderSequences[resultIndex];
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// The third order test.
    /// </summary>
    [Test]
    public void ThirdOrderTest()
    {
        ComposedSequence result = HighOrderFactory.Create(SequencesStorage.CompusedSequences[0], Link.End);
        result = HighOrderFactory.Create(result, Link.End);
        ComposedSequence expected = SequencesStorage.HighOrderSequences[6];
        Assert.That(result, Is.EqualTo(expected));
    }
}
