using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.Statistics.MarkovChain;
using PhantomChains.Classes.Statistics.MarkovCompare;
using PhantomChainsTest.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChainsTest.Classes.Statistics.Markov_Compare
{
    [TestFixture]
    class MarkovMetricTest
    {
        private Chain testChain;

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

        [Test]
        public void CompareSameChainTest()
        {
            var markov = new MarkovChainNotUniformStatic<Chain, Chain>(2, 0, new MockGenerator());
            markov.Teach(testChain, TeachingMethod.Cycle);
            var ma = new MarkovMetrics();
            Assert.AreEqual(ma.GetMiddleArith(markov), ma.GetMiddleArith(markov));
        }
    }
}
