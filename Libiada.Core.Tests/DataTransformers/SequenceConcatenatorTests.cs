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
        List<Chain> sourceChains = ChainsStorage.ConcatinationChains;
        Chain result = SequenceConcatenator.Concatenate([sourceChains[0], sourceChains[1], sourceChains[2]], sequencesIndexes);
        Assert.That(result, Is.EqualTo(sourceChains[4]));
    }

    [Test]
    public void ConcatenateAsOrderedTest()
    {
        List<Chain> sourceChains = ChainsStorage.ConcatinationChains;
        Chain result = SequenceConcatenator.ConcatenateAsOrdered([sourceChains[0], sourceChains[1], sourceChains[2]]);
        Assert.That(result, Is.EqualTo(sourceChains[3]));
    }

    [Test]
    public void GenerateConcatenationsTest()
    {
        List<Chain> sourceChains = ChainsStorage.ConcatinationChains;
        Chain[] expectedChains =
        [
            sourceChains[3],
            sourceChains[4],
            sourceChains[5],
            sourceChains[6],
            sourceChains[7],
            sourceChains[8]
        ];

        IEnumerable<Chain> result = SequenceConcatenator.GenerateConcatenations([sourceChains[0], sourceChains[1], sourceChains[2]]);
        Assert.That(result, Is.EqualTo(expectedChains));
    }
}
