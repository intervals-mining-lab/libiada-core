using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.PhantomChains
{
    [TestFixture]
    public class TestPhantomTable
    {
        [Test]
        public void TestVolume()
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

            PhantomTable table = new PhantomTable(Test);
            Assert.AreEqual(12, table[0].Volume);
            Assert.AreEqual(4, table[1].Volume);
            Assert.AreEqual(2, table[2].Volume);
            Assert.AreEqual(1, table[3].Volume);
            Assert.AreEqual(1, table[4].Volume);

        }

        [Test]
        public void TestContent()
        {
            MessagePhantom M1 = new MessagePhantom();
            MessagePhantom M2 = new MessagePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));
            M2.Add(new ValueChar('4'));
            M2.Add(new ValueChar('3'));

            BaseChain Test = new BaseChain(3);
            Test.Add(M1, 0);
            Test.Add(M2, 1);
            Test.Add(M2, 2);

            PhantomTable table = new PhantomTable(Test);
            Assert.AreEqual(M1, table[1].Content);
            Assert.AreEqual(M2, table[2].Content);
            Assert.AreEqual(M2, table[3].Content);

        }
    }
}
