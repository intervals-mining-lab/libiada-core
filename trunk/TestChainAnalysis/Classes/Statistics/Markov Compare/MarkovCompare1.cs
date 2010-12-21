using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.Statistics.MarkovChain;
using NUnit.Framework;
using TestChainAnalysis.Classes.Statistics.MarkovChain.Generators;
using ChainAnalises.Classes.Statistics.MarkovCompare;

namespace TestChainAnalysis.Classes.Statistics.Markov_Compare
{
    [TestFixture]
    class MarkovMetric
    {
        private Chain TestChain1;

        [SetUp]
        public void Init()
        {
            TestChain1 = new Chain(8);
            TestChain1.Add((ValueString)"A", 0);
            TestChain1.Add((ValueString)"G", 1);
            TestChain1.Add((ValueString)"T", 2);
            TestChain1.Add((ValueString)"A", 3);
            TestChain1.Add((ValueString)"A", 4);
            TestChain1.Add((ValueString)"G", 5);
            TestChain1.Add((ValueString)"T", 6);
            TestChain1.Add((ValueString)"C", 7);
        }

        [Test]
        public void CompareSameChain()
        {
            MarkovChainNotUniformStatic<Chain, Chain> Markov = new MarkovChainNotUniformStatic<Chain, Chain>(2, 0, new MockGenerator());
            Markov.Teach(TestChain1, TeachingMethod.Cycle);
            MarkovMetrics ma = new MarkovMetrics();
            Assert.AreEqual(ma.GetMiddleArith(Markov), ma.GetMiddleArith(Markov));
        }
    }
}
