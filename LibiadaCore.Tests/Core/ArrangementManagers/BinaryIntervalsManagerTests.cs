namespace LibiadaCore.Tests.Core.ArrangementManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The binary intervals manager tests.
    /// </summary>
    [TestFixture]
    public class BinaryIntervalsManagerTests
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
        /// The get binary interval test.
        /// </summary>
        [Test]
        public void GetBinaryIntervalTest()
        {
            var intervalManager = chains[2].GetRelationIntervalsManager(elements["A"], elements["C"]);
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(1));
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(2));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));

            intervalManager = chains[2].GetRelationIntervalsManager(elements["C"], elements["A"]);
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(1));
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(2));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));
            Assert.AreEqual(3, intervalManager.GetBinaryInterval(4));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(5));

            intervalManager = chains[2].GetRelationIntervalsManager(elements["C"], elements["T"]);
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(1));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(2));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(4));
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(4));
        }

        /// <summary>
        /// The get binary interval in incomplete chain test.
        /// </summary>
        [Test]
        public void GetBinaryIntervalIncompleteChainTest()
        {
            // A C A _ C C _ A A A C C A
            // A _ A _ _ _ _ A A A _ _ A
            // _ C _ _ C C _ _ _ _ C C _
            var chain = new Chain(13);

            chain.Set(elements["A"], 0);
            chain.Set(elements["C"], 1);
            chain.Set(elements["A"], 2);

            chain.Set(elements["C"], 4);
            chain.Set(elements["C"], 5);

            chain.Set(elements["A"], 7);
            chain.Set(elements["A"], 8);
            chain.Set(elements["A"], 9);
            chain.Set(elements["C"], 10);
            chain.Set(elements["C"], 11);
            chain.Set(elements["A"], 12);

            var intervalManager = chain.GetRelationIntervalsManager(elements["A"], elements["C"]);
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(1));
            Assert.AreEqual(2, intervalManager.GetBinaryInterval(2));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(4));
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(5));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(6));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(7));

            intervalManager = chain.GetRelationIntervalsManager(elements["C"], elements["A"]);
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(1));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(2));
            Assert.AreEqual(2, intervalManager.GetBinaryInterval(3));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(4));
            Assert.AreEqual(1, intervalManager.GetBinaryInterval(5));
            Assert.AreEqual(-1, intervalManager.GetBinaryInterval(6));
        }
    }
}
