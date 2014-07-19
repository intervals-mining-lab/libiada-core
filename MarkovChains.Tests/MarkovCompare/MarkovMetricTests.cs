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
    internal class MarkovMetricTests
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
            this.testChain = new Chain(8);
            this.testChain.Add((ValueString)"A", 0);
            this.testChain.Add((ValueString)"G", 1);
            this.testChain.Add((ValueString)"T", 2);
            this.testChain.Add((ValueString)"A", 3);
            this.testChain.Add((ValueString)"A", 4);
            this.testChain.Add((ValueString)"G", 5);
            this.testChain.Add((ValueString)"T", 6);
            this.testChain.Add((ValueString)"C", 7);
        }

        /// <summary>
        /// The compare same chain test.
        /// </summary>
        [Test]
        public void CompareSameChainTest()
        {
            var markov = new MarkovChainNotUniformStatic(2, 0, new MockGenerator());
            markov.Teach(this.testChain, TeachingMethod.Cycle);
            var ma = new MarkovMetrics();
            Assert.AreEqual(ma.GetMiddleArith(markov), ma.GetMiddleArith(markov));
        }
    }
}