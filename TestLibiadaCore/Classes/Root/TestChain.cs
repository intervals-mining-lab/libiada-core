using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestChain
    {
        private Chain ChainBase;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            ChainBase = new Chain(10);
        }


        ///<summary>
        ///</summary>
        [Test]
        public void TestSimularChainsGet()
        {
            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageC = new ValueChar('c');
            ValueChar MessageG = new ValueChar('g');
            ValueChar MessageT = new ValueChar('t');
            UniformChain UnifromChainA = new UniformChain(10, MessageA);

            ChainBase.Add(MessageC, 0);

            ChainBase.Add(MessageC, 1);

            ChainBase.Add(MessageA, 2);

            UnifromChainA.Add(MessageA, 2);

            ChainBase.Add(MessageC, 3);

            ChainBase.Add(MessageG, 4);

            ChainBase.Add(MessageC, 5);

            ChainBase.Add(MessageT, 6);

            ChainBase.Add(MessageT, 7);

            ChainBase.Add(MessageA, 8);

            UnifromChainA.Add(MessageA, 8);

            ChainBase.Add(MessageC, 9);

            ChainWithCharacteristic ChainCreatedUniformChain = ChainBase.UniformChain(MessageA);

            Assert.AreEqual(UnifromChainA, ChainCreatedUniformChain);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestIntervalsList()
        {
            Chain NotUniformChain = new Chain(10);

            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageB = new ValueChar('b');
            ValueChar MessageC = new ValueChar('c');

            NotUniformChain.Add(MessageB, 0);
            NotUniformChain.Add(MessageB, 1);
            NotUniformChain.Add(MessageA, 2);
            NotUniformChain.Add(MessageA, 3);
            NotUniformChain.Add(MessageC, 4);
            NotUniformChain.Add(MessageB, 5);
            NotUniformChain.Add(MessageA, 6);
            NotUniformChain.Add(MessageC, 7);
            NotUniformChain.Add(MessageC, 8);
            NotUniformChain.Add(MessageB, 9);

            Assert.AreEqual(4, NotUniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 1));
            Assert.AreEqual(3, NotUniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 3));
            Assert.AreEqual(2, NotUniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 4));
            Assert.AreEqual(1, NotUniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 5));
        }

        [Test]
        public void TestGetElementPosition()
        {
            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageC = new ValueChar('c');
            ValueChar MessageG = new ValueChar('g');
            ValueChar MessageT = new ValueChar('t');

            ChainBase.Add(MessageC, 0);
            ChainBase.Add(MessageC, 1);
            ChainBase.Add(MessageA, 2);
            ChainBase.Add(MessageC, 3);
            ChainBase.Add(MessageG, 4);
            ChainBase.Add(MessageC, 5);
            ChainBase.Add(MessageT, 6);
            ChainBase.Add(MessageT, 7);
            ChainBase.Add(MessageA, 8);
            ChainBase.Add(MessageC, 9);

            Assert.AreEqual(2,ChainBase.Get(MessageA, 1));
            Assert.AreEqual(8, ChainBase.Get(MessageA, 2));
            Assert.AreEqual(-1, ChainBase.Get(MessageA, 3));

            Assert.AreEqual(0, ChainBase.Get(MessageC, 1));
            Assert.AreEqual(1, ChainBase.Get(MessageC, 2));
            Assert.AreEqual(3, ChainBase.Get(MessageC, 3));
            Assert.AreEqual(5, ChainBase.Get(MessageC, 4));
            Assert.AreEqual(9, ChainBase.Get(MessageC, 5));
            Assert.AreEqual(-1, ChainBase.Get(MessageC, 6));

            Assert.AreEqual(4, ChainBase.Get(MessageG, 1));
            Assert.AreEqual(-1, ChainBase.Get(MessageG, 2));
            Assert.AreEqual(-1, ChainBase.Get(MessageG, 3));

            Assert.AreEqual(6, ChainBase.Get(MessageT, 1));
            Assert.AreEqual(7, ChainBase.Get(MessageT, 2));
            Assert.AreEqual(-1, ChainBase.Get(MessageT, 3));
        }

        [Test]
        public void TestGetBinaryInterval()
        {
            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageC = new ValueChar('c');
            ValueChar MessageG = new ValueChar('g');
            ValueChar MessageT = new ValueChar('t');

            ChainBase.Add(MessageC, 0);
            ChainBase.Add(MessageC, 1);
            ChainBase.Add(MessageA, 2);
            ChainBase.Add(MessageC, 3);
            ChainBase.Add(MessageG, 4);
            ChainBase.Add(MessageC, 5);
            ChainBase.Add(MessageT, 6);
            ChainBase.Add(MessageT, 7);
            ChainBase.Add(MessageA, 8);
            ChainBase.Add(MessageC, 9);

            Assert.AreEqual(1, ChainBase.GetBinaryInterval(MessageA, MessageC, 1));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(MessageA, MessageC, 2));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(MessageA, MessageC, 3));

            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(MessageC, MessageA, 1));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(MessageC, MessageA, 2));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(MessageC, MessageA, 3));
            Assert.AreEqual(3, ChainBase.GetBinaryInterval(MessageC, MessageA, 4));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(MessageC, MessageA, 5));

            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(MessageC, MessageT, 1));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(MessageC, MessageT, 2));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(MessageC, MessageT, 3));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(MessageC, MessageT, 4));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(MessageC, MessageT, 4));

            // oxo_xx_oooxxo
            Chain testChain = new Chain(13);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageC, 1);
            testChain.Add(MessageA, 2);

            testChain.Add(MessageC, 4);
            testChain.Add(MessageC, 5);

            testChain.Add(MessageA, 7);
            testChain.Add(MessageA, 8);
            testChain.Add(MessageA, 9);
            testChain.Add(MessageC, 10);
            testChain.Add(MessageC, 11);
            testChain.Add(MessageA, 12);

            Assert.AreEqual(1, testChain.GetBinaryInterval(MessageA, MessageC, 1));
            Assert.AreEqual(2, testChain.GetBinaryInterval(MessageA, MessageC, 2));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(MessageA, MessageC, 3));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(MessageA, MessageC, 4));
            Assert.AreEqual(1, testChain.GetBinaryInterval(MessageA, MessageC, 5));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(MessageA, MessageC, 6));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(MessageA, MessageC, 7));

            Assert.AreEqual(1, testChain.GetBinaryInterval(MessageC, MessageA, 1));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(MessageC, MessageA, 2));
            Assert.AreEqual(2, testChain.GetBinaryInterval(MessageC, MessageA, 3));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(MessageC, MessageA, 4));
            Assert.AreEqual(1, testChain.GetBinaryInterval(MessageC, MessageA, 5));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(MessageC, MessageA, 6));
        }
    }
}