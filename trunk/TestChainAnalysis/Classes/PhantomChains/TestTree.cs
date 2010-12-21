using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.PhantomChains
{
    [TestFixture]
    public class TestTree
    {
        [Test]
        public void TestTreeVolume()
        {
            MessagePhantom M1 = new MessagePhantom();
            MessagePhantom M2 = new MessagePhantom();
            MessagePhantom M3 = new MessagePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));
            M2.Add(new ValueChar('4'));
            M2.Add(new ValueChar('3'));
            M3.Add(new ValueChar('a'));

            BaseChain Test = new BaseChain(4);
            Test.Add(M1, 0);
            Test.Add(M2, 1);
            Test.Add(M2, 2);
            Test.Add(M3, 3);

            IGenerator Gen = new SimpleGenerator();
            TreeTop tree = new TreeTop(Test,Gen);
            Assert.AreEqual(12, tree.Volume);
            TreeNode Ch1 = tree.GetChild(0);
            Assert.AreEqual(4, Ch1.Volume);
            TreeNode Ch2 = tree.GetChild(1);
            Assert.AreEqual(4, Ch2.Volume);
            TreeNode Ch3 = tree.GetChild(2);
            Assert.AreEqual(4, Ch3.Volume);
        }
    }
}
