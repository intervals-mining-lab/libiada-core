namespace PhantomChains.Tests
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain.Generators;

    using NUnit.Framework;

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
            var m1 = new ValuePhantom { new ValueString('1'), new ValueString('2'), new ValueString('3') };
            var m2 = new ValuePhantom { new ValueString('4'), new ValueString('3') };
            var m3 = new ValuePhantom { new ValueString('a') };

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