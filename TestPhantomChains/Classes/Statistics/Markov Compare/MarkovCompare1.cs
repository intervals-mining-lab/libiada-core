using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.Statistics.MarkovChain;
using PhantomChains.Classes.Statistics.MarkovCompare;
using TestPhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace TestPhantomChains.Classes.Statistics.Markov_Compare
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
