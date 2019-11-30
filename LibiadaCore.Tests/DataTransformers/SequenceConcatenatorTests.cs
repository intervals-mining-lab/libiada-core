namespace LibiadaCore.Tests.DataTransformers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.DataTransformers;

    using NUnit.Framework;


    [TestFixture]
    public class SequenceConcatenatorTests
    {
        public static Chain[] sourceChains = { new Chain("BBAACBACCB"), new Chain("ACTTGATACG"), new Chain("CCACGCTTAC"), };

        public static Chain expectedChain = new Chain("BBAACBACCBACTTGATACGCCACGCTTAC");

        public static int[] order = new[] { 0, 1, 2 };

        [Test]
        public void ConcatenateTest()
        {
            var result = SequenceConcatenator.Concatenate(sourceChains, order);
            Assert.AreEqual(expectedChain, result);
        }
        [Test]
        public void ConcatenateOrderTest()
        {
            var result = SequenceConcatenator.ConcatenateOrder(sourceChains);
            Trace.WriteLine(result);
            Assert.AreEqual(expectedChain, result);
        }

        [Test]
        public void GenerateConcatenationsTest()
        {
            Chain[] expectedChains =
            {
            new Chain("BBAACBACCBACTTGATACGCCACGCTTAC"),
            new Chain("BBAACBACCBCCACGCTTACACTTGATACG"),
            new Chain("ACTTGATACGBBAACBACCBCCACGCTTAC"),
            new Chain("ACTTGATACGCCACGCTTACBBAACBACCB"),
            new Chain("CCACGCTTACBBAACBACCBACTTGATACG"), 
            new Chain("CCACGCTTACACTTGATACGBBAACBACCB")
            };
            var result = SequenceConcatenator.GenerateConcatenations(sourceChains);
            Assert.AreEqual(expectedChains, result);
        }

        

    }
}
