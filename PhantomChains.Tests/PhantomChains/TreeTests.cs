namespace PhantomChains.Tests.PhantomChains
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    using global::PhantomChains.PhantomChains;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    /// <summary>
    /// The tree tests.
    /// </summary>
    [TestFixture]
    public class TreeTests
    {
        /// <summary>
        /// The tree volume test.
        /// </summary>
        [Test]
        public void TreeVolumeTest()
        {
            var m1 = new ValuePhantom { new ValueChar('1'), new ValueChar('2'), new ValueChar('3') };
            var m2 = new ValuePhantom { new ValueChar('4'), new ValueChar('3') };
            var m3 = new ValuePhantom { new ValueChar('a') };

            var test = new BaseChain(4);
            test.Add(m1, 0);
            test.Add(m2, 1);
            test.Add(m2, 2);
            test.Add(m3, 3);

            IGenerator gen = new SimpleGenerator();
            var tree = new TreeTop(test, gen);
            Assert.AreEqual(12, tree.Volume);
            var ch1 = tree.GetChild(0);
            Assert.AreEqual(4, ch1.Volume);
            var ch2 = tree.GetChild(1);
            Assert.AreEqual(4, ch2.Volume);
            var ch3 = tree.GetChild(2);
            Assert.AreEqual(4, ch3.Volume);
        }
    }
}