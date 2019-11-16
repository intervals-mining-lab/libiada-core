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

       /* public static int[] order = OrderGenerator.GetOrders(3)[0];

        [Test]
        public void ConcatenationMethod1Test()
        {
            var result = SequenceConcatenator.Concatenate(sourceChains, order);
            Assert.AreEqual(expectedChain, result);
        }*/
        [Test]
        public void ConcatenateOrderTest()
        {
            var result = SequenceConcatenator.ConcatenateOrder(sourceChains);
            Trace.WriteLine(result);
            Assert.AreEqual(expectedChain, result);
        }



        

    }
}
