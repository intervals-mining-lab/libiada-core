namespace LibiadaCore.Tests.Core
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The chain test.
    /// </summary>
    [TestFixture]
    public class ChainTests
    {
        /// <summary>
        /// The chain.
        /// </summary>
        private Chain chain;

        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            chain = new Chain(10);
        }

        /// <summary>
        /// The similar chains get test.
        /// </summary>
        [Test]
        public void SimilarChainsGetTest()
        {
            var messageA = new ValueString('a');
            var messageC = new ValueString('c');
            var messageG = new ValueString('g');
            var messageT = new ValueString('t');
            var congenericChainA = new CongenericChain(messageA, 10);

            chain.Set(messageC, 0);

            chain.Set(messageC, 1);

            chain.Set(messageA, 2);

            congenericChainA.Set(messageA, 2);

            chain.Set(messageC, 3);

            chain.Set(messageG, 4);

            chain.Set(messageC, 5);

            chain.Set(messageT, 6);

            chain.Set(messageT, 7);

            chain.Set(messageA, 8);

            congenericChainA.Set(messageA, 8);

            chain.Set(messageC, 9);

            var chainCreatedCongenericChain = chain.CongenericChain((IBaseObject)messageA);

            Assert.AreEqual(congenericChainA, chainCreatedCongenericChain);
        }

        /// <summary>
        /// The intervals test.
        /// </summary>
        [Test]
        public void IntervalsTest()
        {
            Chain temp = ChainsStorage.Chains[0];
            var intervals = new List<List<int>>
                {
                    new List<int> { 1, 1, 4, 4, 1 },
                    new List<int> { 3, 1, 3, 4 },
                    new List<int> { 5, 3, 1, 2 }
                };
            for (int i = 0; i < temp.Alphabet.Cardinality; i++)
            {
                var actualIntervals = temp.CongenericChain(i).GetIntervals(Link.Both);
                for (int j = 0; j < actualIntervals.Length; j++)
                {
                    Assert.AreEqual(intervals[i][j], actualIntervals[j], "не совпадают {0} интервалы {1} цепочки", j, i);
                }
            }
        }

        /// <summary>
        /// The get element position test.
        /// </summary>
        [Test]
        public void GetElementPositionTest()
        {
            var messageA = new ValueString('a');
            var messageC = new ValueString('c');
            var messageG = new ValueString('g');
            var messageT = new ValueString('t');

            chain.Set(messageC, 0);
            chain.Set(messageC, 1);
            chain.Set(messageA, 2);
            chain.Set(messageC, 3);
            chain.Set(messageG, 4);
            chain.Set(messageC, 5);
            chain.Set(messageT, 6);
            chain.Set(messageT, 7);
            chain.Set(messageA, 8);
            chain.Set(messageC, 9);

            Assert.AreEqual(2, chain.GetOccurrence(messageA, 1));
            Assert.AreEqual(8, chain.GetOccurrence(messageA, 2));
            Assert.AreEqual(-1, chain.GetOccurrence(messageA, 3));

            Assert.AreEqual(0, chain.GetOccurrence(messageC, 1));
            Assert.AreEqual(1, chain.GetOccurrence(messageC, 2));
            Assert.AreEqual(3, chain.GetOccurrence(messageC, 3));
            Assert.AreEqual(5, chain.GetOccurrence(messageC, 4));
            Assert.AreEqual(9, chain.GetOccurrence(messageC, 5));
            Assert.AreEqual(-1, chain.GetOccurrence(messageC, 6));

            Assert.AreEqual(4, chain.GetOccurrence(messageG, 1));
            Assert.AreEqual(-1, chain.GetOccurrence(messageG, 2));
            Assert.AreEqual(-1, chain.GetOccurrence(messageG, 3));

            Assert.AreEqual(6, chain.GetOccurrence(messageT, 1));
            Assert.AreEqual(7, chain.GetOccurrence(messageT, 2));
            Assert.AreEqual(-1, chain.GetOccurrence(messageT, 3));
        }

        /// <summary>
        /// The get binary interval test.
        /// </summary>
        [Test]
        public void GetBinaryIntervalTest()
        {
            IBaseObject messageA = new ValueString('a');
            IBaseObject messageC = new ValueString('c');
            IBaseObject messageG = new ValueString('g');
            IBaseObject messageT = new ValueString('t');

            chain.Set(messageC, 0);
            chain.Set(messageC, 1);
            chain.Set(messageA, 2);
            chain.Set(messageC, 3);
            chain.Set(messageG, 4);
            chain.Set(messageC, 5);
            chain.Set(messageT, 6);
            chain.Set(messageT, 7);
            chain.Set(messageA, 8);
            chain.Set(messageC, 9);

            Assert.AreEqual(1, chain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(1));
            Assert.AreEqual(1, chain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(2));
            Assert.AreEqual(-1, chain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(3));

            Assert.AreEqual(-1, chain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(1));
            Assert.AreEqual(1, chain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(2));
            Assert.AreEqual(-1, chain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(3));
            Assert.AreEqual(3, chain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(4));
            Assert.AreEqual(-1, chain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(5));

            Assert.AreEqual(-1, chain.GetRelationIntervalsManager(messageC, messageT).GetBinaryInterval(1));
            Assert.AreEqual(-1, chain.GetRelationIntervalsManager(messageC, messageT).GetBinaryInterval(2));
            Assert.AreEqual(-1, chain.GetRelationIntervalsManager(messageC, messageT).GetBinaryInterval(3));
            Assert.AreEqual(1, chain.GetRelationIntervalsManager(messageC, messageT).GetBinaryInterval(4));
            Assert.AreEqual(1, chain.GetRelationIntervalsManager(messageC, messageT).GetBinaryInterval(4));

            // oxo_xx_oooxxo
            var testChain = new Chain(13);
            testChain.Set(messageA, 0);
            testChain.Set(messageC, 1);
            testChain.Set(messageA, 2);

            testChain.Set(messageC, 4);
            testChain.Set(messageC, 5);

            testChain.Set(messageA, 7);
            testChain.Set(messageA, 8);
            testChain.Set(messageA, 9);
            testChain.Set(messageC, 10);
            testChain.Set(messageC, 11);
            testChain.Set(messageA, 12);

            Assert.AreEqual(1, testChain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(1));
            Assert.AreEqual(2, testChain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(2));
            Assert.AreEqual(-1, testChain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(3));
            Assert.AreEqual(-1, testChain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(4));
            Assert.AreEqual(1, testChain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(5));
            Assert.AreEqual(-1, testChain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(6));
            Assert.AreEqual(-1, testChain.GetRelationIntervalsManager(messageA, messageC).GetBinaryInterval(7));

            Assert.AreEqual(1, testChain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(1));
            Assert.AreEqual(-1, testChain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(2));
            Assert.AreEqual(2, testChain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(3));
            Assert.AreEqual(-1, testChain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(4));
            Assert.AreEqual(1, testChain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(5));
            Assert.AreEqual(-1, testChain.GetRelationIntervalsManager(messageC, messageA).GetBinaryInterval(6));
        }
    }
}
