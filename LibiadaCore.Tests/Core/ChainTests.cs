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
            this.chain = new Chain(10);
        }

        /// <summary>
        /// The similar chains get test.
        /// </summary>
        [Test]
        public void SimilarChainsGetTest()
        {
            var messageA = new ValueChar('a');
            var messageC = new ValueChar('c');
            var messageG = new ValueChar('g');
            var messageT = new ValueChar('t');
            var congenericChainA = new CongenericChain(10, messageA);

            this.chain.Add(messageC, 0);

            this.chain.Add(messageC, 1);

            this.chain.Add(messageA, 2);

            congenericChainA.Add(messageA, 2);

            this.chain.Add(messageC, 3);

            this.chain.Add(messageG, 4);

            this.chain.Add(messageC, 5);

            this.chain.Add(messageT, 6);

            this.chain.Add(messageT, 7);

            this.chain.Add(messageA, 8);

            congenericChainA.Add(messageA, 8);

            this.chain.Add(messageC, 9);

            var chainCreatedCongenericChain = this.chain.CongenericChain((IBaseObject)messageA);

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
            var messageA = new ValueChar('a');
            var messageC = new ValueChar('c');
            var messageG = new ValueChar('g');
            var messageT = new ValueChar('t');

            this.chain.Add(messageC, 0);
            this.chain.Add(messageC, 1);
            this.chain.Add(messageA, 2);
            this.chain.Add(messageC, 3);
            this.chain.Add(messageG, 4);
            this.chain.Add(messageC, 5);
            this.chain.Add(messageT, 6);
            this.chain.Add(messageT, 7);
            this.chain.Add(messageA, 8);
            this.chain.Add(messageC, 9);

            Assert.AreEqual(2, this.chain.Get(messageA, 1));
            Assert.AreEqual(8, this.chain.Get(messageA, 2));
            Assert.AreEqual(-1, this.chain.Get(messageA, 3));

            Assert.AreEqual(0, this.chain.Get(messageC, 1));
            Assert.AreEqual(1, this.chain.Get(messageC, 2));
            Assert.AreEqual(3, this.chain.Get(messageC, 3));
            Assert.AreEqual(5, this.chain.Get(messageC, 4));
            Assert.AreEqual(9, this.chain.Get(messageC, 5));
            Assert.AreEqual(-1, this.chain.Get(messageC, 6));

            Assert.AreEqual(4, this.chain.Get(messageG, 1));
            Assert.AreEqual(-1, this.chain.Get(messageG, 2));
            Assert.AreEqual(-1, this.chain.Get(messageG, 3));

            Assert.AreEqual(6, this.chain.Get(messageT, 1));
            Assert.AreEqual(7, this.chain.Get(messageT, 2));
            Assert.AreEqual(-1, this.chain.Get(messageT, 3));
        }

        /// <summary>
        /// The get binary interval test.
        /// </summary>
        [Test]
        public void GetBinaryIntervalTest()
        {
            var messageA = new ValueChar('a');
            var messageC = new ValueChar('c');
            var messageG = new ValueChar('g');
            var messageT = new ValueChar('t');

            this.chain.Add(messageC, 0);
            this.chain.Add(messageC, 1);
            this.chain.Add(messageA, 2);
            this.chain.Add(messageC, 3);
            this.chain.Add(messageG, 4);
            this.chain.Add(messageC, 5);
            this.chain.Add(messageT, 6);
            this.chain.Add(messageT, 7);
            this.chain.Add(messageA, 8);
            this.chain.Add(messageC, 9);

            Assert.AreEqual(1, this.chain.GetBinaryInterval(messageA, messageC, 1));
            Assert.AreEqual(1, this.chain.GetBinaryInterval(messageA, messageC, 2));
            Assert.AreEqual(-1, this.chain.GetBinaryInterval(messageA, messageC, 3));

            Assert.AreEqual(-1, this.chain.GetBinaryInterval(messageC, messageA, 1));
            Assert.AreEqual(1, this.chain.GetBinaryInterval(messageC, messageA, 2));
            Assert.AreEqual(-1, this.chain.GetBinaryInterval(messageC, messageA, 3));
            Assert.AreEqual(3, this.chain.GetBinaryInterval(messageC, messageA, 4));
            Assert.AreEqual(-1, this.chain.GetBinaryInterval(messageC, messageA, 5));

            Assert.AreEqual(-1, this.chain.GetBinaryInterval(messageC, messageT, 1));
            Assert.AreEqual(-1, this.chain.GetBinaryInterval(messageC, messageT, 2));
            Assert.AreEqual(-1, this.chain.GetBinaryInterval(messageC, messageT, 3));
            Assert.AreEqual(1, this.chain.GetBinaryInterval(messageC, messageT, 4));
            Assert.AreEqual(1, this.chain.GetBinaryInterval(messageC, messageT, 4));

            // oxo_xx_oooxxo
            var testChain = new Chain(13);
            testChain.Add(messageA, 0);
            testChain.Add(messageC, 1);
            testChain.Add(messageA, 2);

            testChain.Add(messageC, 4);
            testChain.Add(messageC, 5);

            testChain.Add(messageA, 7);
            testChain.Add(messageA, 8);
            testChain.Add(messageA, 9);
            testChain.Add(messageC, 10);
            testChain.Add(messageC, 11);
            testChain.Add(messageA, 12);

            Assert.AreEqual(1, testChain.GetBinaryInterval(messageA, messageC, 1));
            Assert.AreEqual(2, testChain.GetBinaryInterval(messageA, messageC, 2));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 3));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 4));
            Assert.AreEqual(1, testChain.GetBinaryInterval(messageA, messageC, 5));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 6));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 7));

            Assert.AreEqual(1, testChain.GetBinaryInterval(messageC, messageA, 1));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageC, messageA, 2));
            Assert.AreEqual(2, testChain.GetBinaryInterval(messageC, messageA, 3));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageC, messageA, 4));
            Assert.AreEqual(1, testChain.GetBinaryInterval(messageC, messageA, 5));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageC, messageA, 6));
        }
    }
}