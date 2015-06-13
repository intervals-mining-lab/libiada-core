namespace LibiadaCore.Tests.Core
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

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
        private readonly List<Chain> chains = ChainsStorage.Chains;

        /// <summary>
        /// The elements.
        /// </summary>
        private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

        /// <summary>
        /// The similar chains get test.
        /// </summary>
        [Test]
        public void SimilarChainsGetTest()
        {
            var congenericChainA = new CongenericChain(new[] { 2, 8 }, elements["A"], 10);

            var chainCreatedCongenericChain = chains[2].CongenericChain(elements["A"]);

            Assert.AreEqual(congenericChainA, chainCreatedCongenericChain);
        }

        /// <summary>
        /// The intervals test.
        /// </summary>
        [Test]
        public void IntervalsTest()
        {
            var intervals = new List<List<int>>
                {
                    new List<int> { 1, 1, 4, 4, 1 }, 
                    new List<int> { 3, 1, 3, 4 }, 
                    new List<int> { 5, 3, 1, 2 }
                };
            for (int i = 0; i < chains[0].Alphabet.Cardinality; i++)
            {
                var actualIntervals = chains[0].CongenericChain(i).GetIntervals(Link.Both);
                for (int j = 0; j < actualIntervals.Length; j++)
                {
                    Assert.AreEqual(intervals[i][j], actualIntervals[j], "{0} and {1} intervals of sequence are not equal", j, i);
                }
            }
        }

        /// <summary>
        /// The get element position test.
        /// </summary>
        [Test]
        public void GetElementPositionTest()
        {
            Assert.AreEqual(2, chains[2].GetOccurrence(elements["A"], 1));
            Assert.AreEqual(8, chains[2].GetOccurrence(elements["A"], 2));
            Assert.AreEqual(-1, chains[2].GetOccurrence(elements["A"], 3));

            Assert.AreEqual(0, chains[2].GetOccurrence(elements["C"], 1));
            Assert.AreEqual(1, chains[2].GetOccurrence(elements["C"], 2));
            Assert.AreEqual(3, chains[2].GetOccurrence(elements["C"], 3));
            Assert.AreEqual(5, chains[2].GetOccurrence(elements["C"], 4));
            Assert.AreEqual(9, chains[2].GetOccurrence(elements["C"], 5));
            Assert.AreEqual(-1, chains[2].GetOccurrence(elements["C"], 6));

            Assert.AreEqual(4, chains[2].GetOccurrence(elements["G"], 1));
            Assert.AreEqual(-1, chains[2].GetOccurrence(elements["G"], 2));
            Assert.AreEqual(-1, chains[2].GetOccurrence(elements["G"], 3));

            Assert.AreEqual(6, chains[2].GetOccurrence(elements["T"], 1));
            Assert.AreEqual(7, chains[2].GetOccurrence(elements["T"], 2));
            Assert.AreEqual(-1, chains[2].GetOccurrence(elements["T"], 3));
        }
    }
}
