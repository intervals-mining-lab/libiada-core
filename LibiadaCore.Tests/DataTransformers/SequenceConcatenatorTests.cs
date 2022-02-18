namespace LibiadaCore.Tests.DataTransformers
{
    using System.Diagnostics;

    using LibiadaCore.Core;
    using LibiadaCore.DataTransformers;
    using LibiadaCore.Tests.Core;

    using NUnit.Framework;


    [TestFixture]
    public class SequenceConcatenatorTests
    {
        [Test]
        public void ConcatenateTest()
        {
            var sequencesIndexes = new[] { 0, 2, 1 };
            var sourceChains = ChainsStorage.ConcatinationChains;
            var result = SequenceConcatenator.Concatenate(new[] { sourceChains[0], sourceChains[1], sourceChains[2] }, sequencesIndexes);
            Assert.AreEqual(sourceChains[4], result);
        }

        [Test]
        public void ConcatenateAsOrderedTest()
        {
            var sourceChains = ChainsStorage.ConcatinationChains;
            var result = SequenceConcatenator.ConcatenateAsOrdered(new[] { sourceChains[0], sourceChains[1], sourceChains[2] });
            Trace.WriteLine(result);
            Assert.AreEqual(sourceChains[3], result);
        }

        [Test]
        public void GenerateConcatenationsTest()
        {
            var sourceChains = ChainsStorage.ConcatinationChains;
            Chain[] expectedChains =
            {
                sourceChains[3],
                sourceChains[4],
                sourceChains[5],
                sourceChains[6],
                sourceChains[7],
                sourceChains[8]
            };

            var result = SequenceConcatenator.GenerateConcatenations(new[] { sourceChains[0], sourceChains[1], sourceChains[2] });
            Assert.AreEqual(expectedChains, result);
        }
    }
}
