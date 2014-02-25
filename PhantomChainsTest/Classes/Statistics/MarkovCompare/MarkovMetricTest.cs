namespace PhantomChainsTest.Classes.Statistics.MarkovCompare
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    using global::PhantomChains.Classes.Statistics.MarkovChain;

    using global::PhantomChains.Classes.Statistics.MarkovCompare;

    using PhantomChainsTest.Classes.Statistics.MarkovChain.Generators;

    /// <summary>
    /// The markov metric test.
    /// </summary>
    [TestFixture]
    internal class MarkovMetricTest
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
            var markov = new MarkovChainNotUniformStatic<Chain, Chain>(2, 0, new MockGenerator());
            markov.Teach(this.testChain, TeachingMethod.Cycle);
            var ma = new MarkovMetrics();
            Assert.AreEqual(ma.GetMiddleArith(markov), ma.GetMiddleArith(markov));
        }
    }
}