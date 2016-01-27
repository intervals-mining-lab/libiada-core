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
    public class MarkovMetricsTests
    {
        /// <summary>
        /// The test chain.
        /// </summary>
        private Chain testChain;

        /// <summary>
        /// The initialization method.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            testChain = new Chain(8);
            testChain.Set((ValueString)"A", 0);
            testChain.Set((ValueString)"G", 1);
            testChain.Set((ValueString)"T", 2);
            testChain.Set((ValueString)"A", 3);
            testChain.Set((ValueString)"A", 4);
            testChain.Set((ValueString)"G", 5);
            testChain.Set((ValueString)"T", 6);
            testChain.Set((ValueString)"C", 7);
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
            Assert.AreEqual(ma.GetArithmeticalMean(markov), ma.GetArithmeticalMean(markov));
        }
    }
}
