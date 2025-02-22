namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.DataTransformers;
using Libiada.Core.Tests.Core;

/// <summary>
/// The dissimilar sequences factory tests.
/// </summary>
[TestFixture(TestOf = typeof(DissimilarSequenceFactory))]
public class DissimilarSequenceFactoryTests
{
    /// <summary>
    /// The dissimilar order computation tests.
    /// </summary>
    /// <param name="sequenceIndex">
    /// The sequence index.
    /// </param>
    /// <param name="resultIndex">
    /// The result index.
    /// </param>
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    public void DissimilarOrderTest(int sequenceIndex, int resultIndex)
    {
        ComposedSequence result = DissimilarSequenceFactory.Create(SequencesStorage.CompusedSequences[sequenceIndex]);
        ComposedSequence expected = SequencesStorage.DissimilarSequences[resultIndex];
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// The dissimilar of dissimilar order computation tests.
    /// </summary>
    /// <param name="sequenceIndex">
    /// The sequence index.
    /// </param>
    /// <param name="resultIndex">
    /// The result index.
    /// </param>
    [TestCase(0, 3)]
    [TestCase(1, 4)]
    [TestCase(2, 5)]
    public void DissimilarSecondOrderTest(int sequenceIndex, int resultIndex)
    {
        ComposedSequence result = DissimilarSequenceFactory.Create(SequencesStorage.CompusedSequences[sequenceIndex]);
        result = DissimilarSequenceFactory.Create(result);
        ComposedSequence expected = SequencesStorage.DissimilarSequences[resultIndex];
        Assert.That(result, Is.EqualTo(expected));
    }
}
