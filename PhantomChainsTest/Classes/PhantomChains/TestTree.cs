using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChainsTest.Classes.PhantomChains
{
    [TestFixture]
    public class TestTree
    {
        [Test]
        public void TestTreeVolume()
        {
            ValuePhantom m1 = new ValuePhantom();
            ValuePhantom m2 = new ValuePhantom();
            ValuePhantom m3 = new ValuePhantom();

            m1.Add(new ValueChar('1'));
            m1.Add(new ValueChar('2'));
            m1.Add(new ValueChar('3'));
            m2.Add(new ValueChar('4'));
            m2.Add(new ValueChar('3'));
            m3.Add(new ValueChar('a'));

            BaseChain test = new BaseChain(4);
            test.Add(m1, 0);
            test.Add(m2, 1);
            test.Add(m2, 2);
            test.Add(m3, 3);

            IGenerator gen = new SimpleGenerator();
            TreeTop tree = new TreeTop(test,gen);
            Assert.AreEqual(12, tree.Volume);
            TreeNode ch1 = tree.GetChild(0);
            Assert.AreEqual(4, ch1.Volume);
            TreeNode ch2 = tree.GetChild(1);
            Assert.AreEqual(4, ch2.Volume);
            TreeNode ch3 = tree.GetChild(2);
            Assert.AreEqual(4, ch3.Volume);
        }
    }
}
