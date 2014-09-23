namespace MarkovChains.Tests.MarkovCompare
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain;
    using MarkovChains.MarkovCompare;
    using MarkovChains.Tests.MarkovChain.Generators;

    using NUnit.Framework;

    /// <summary>
    /// The markov metric tests.
    /// </summary>
    [TestFixture]
    public class MarkovMetricTests
    {
        /// <summary>
        /// The test chain.
        /// </summary>
        private Chain testChain;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            testChain = new Chain(8);
            testChain.Add((ValueString)"A", 0);
            testChain.Add((ValueString)"G", 1);
            testChain.Add((ValueString)"T", 2);
            testChain.Add((ValueString)"A", 3);
            testChain.Add((ValueString)"A", 4);
            testChain.Add((ValueString)"G", 5);
            testChain.Add((ValueString)"T", 6);
            testChain.Add((ValueString)"C", 7);
        }

        /// <summary>
        /// The compare same chain test.
        /// </summary>
        [Test]
        public void CompareSameChainTest()
        {
            var markov = new MarkovChainNotCongenericStatic(2, 0, new MockGenerator());
            markov.Teach(testChain, TeachingMethod.Cycle);
            var ma = new MarkovMetrics();
            Assert.AreEqual(ma.GetMiddleArith(markov), ma.GetMiddleArith(markov));
        }
    }
}