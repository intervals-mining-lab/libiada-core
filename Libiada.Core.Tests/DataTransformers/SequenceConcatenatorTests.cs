namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.DataTransformers;
using Libiada.Core.Tests.Core;

[TestFixture]
public class SequenceConcatenatorTests
{
    [Test]
    public void ConcatenateTest()
    {
        int[] sequencesIndexes = [0, 2, 1];
        List<ComposedSequence> sourceSequences = SequencesStorage.ConcatinationSequences;
        ComposedSequence result = SequenceConcatenator.Concatenate([sourceSequences[0], sourceSequences[1], sourceSequences[2]], sequencesIndexes);
        Assert.That(result, Is.EqualTo(sourceSequences[4]));
    }

    [Test]
    public void ConcatenateAsOrderedTest()
    {
        List<ComposedSequence> sourceSequences = SequencesStorage.ConcatinationSequences;
        ComposedSequence result = SequenceConcatenator.ConcatenateAsOrdered([sourceSequences[0], sourceSequences[1], sourceSequences[2]]);
        Assert.That(result, Is.EqualTo(sourceSequences[3]));
    }

    [Test]
    public void GenerateConcatenationsTest()
    {
        List<ComposedSequence> sourceSequences = SequencesStorage.ConcatinationSequences;
        ComposedSequence[] expectedSequences =
        [
            sourceSequences[3],
            sourceSequences[4],
            sourceSequences[5],
            sourceSequences[6],
            sourceSequences[7],
            sourceSequences[8]
        ];

        IEnumerable<ComposedSequence> result = SequenceConcatenator.GenerateConcatenations([sourceSequences[0], sourceSequences[1], sourceSequences[2]]);
        Assert.That(result, Is.EqualTo(expectedSequences));
    }
}
