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

        [Test]
        public void TestSpatialDependence()
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

            Assert.AreEqual(1.732, Math.Round(ChainBase.SpatialDependence(MessageC, MessageA), 3));
            Assert.AreEqual(Math.Pow(1, 1.0 / 2), ChainBase.SpatialDependence(MessageA, MessageC));
        }

        [Test]
        public void TestRedundancy()
        {
            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageB = new ValueChar('b');

            Chain testChain = new Chain(13);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageB, 12);


        }

        [Test]
        public void TestKs()
        {
            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageB = new ValueChar('b');

            // ----------- цепочки из работы Морозенко

            Chain testChain = new Chain(2);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageB, 1);

            Assert.AreEqual(0, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));


            testChain = new Chain(6);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageB, 3);

            Assert.AreEqual(0, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(27);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 4);
            testChain.Add(MessageA, 12);
            testChain.Add(MessageA, 19);
            testChain.Add(MessageB, 3);
            testChain.Add(MessageB, 9);
            testChain.Add(MessageB, 16);
            testChain.Add(MessageB, 26);

            Assert.AreEqual(0, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.546, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0.546, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.121, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(5);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageB, 1);

            Assert.AreEqual(0.75, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.75, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.3, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(12);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageB, 1);

            Assert.AreEqual(0.9091, Math.Round(testChain.K1(MessageA, MessageB), 4));
            Assert.AreEqual(0, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.9091, Math.Round(testChain.K2(MessageA, MessageB), 4));
            Assert.AreEqual(0, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.152, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(13);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageB, 12);

            Assert.AreEqual(-11, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0, testChain.K1(MessageB, MessageA));

            Assert.AreEqual(-11, Math.Round(testChain.K2(MessageA, MessageB),3));
            Assert.AreEqual(0, testChain.K2(MessageB, MessageA));

            Assert.AreEqual(0, testChain.K3(MessageA, MessageB));

            Assert.AreEqual(-1.692, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(29);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 14);
            testChain.Add(MessageA, 17);
            testChain.Add(MessageA, 18);
            testChain.Add(MessageA, 19);
            testChain.Add(MessageA, 22);
            testChain.Add(MessageB, 8);
            testChain.Add(MessageB, 10);
            testChain.Add(MessageB, 12);
            testChain.Add(MessageB, 13);
            testChain.Add(MessageB, 28);

            Assert.AreEqual(-0.22, Math.Round(testChain.K1(MessageA, MessageB), 2));
            Assert.AreEqual(0.1556, Math.Round(testChain.K1(MessageB, MessageA), 4));

            //            Assert.AreEqual(-0.509, Math.Round(testChain.K2(MessageA, MessageB), 3));
            //            Assert.AreEqual(0.1697, Math.Round(testChain.K2(MessageB, MessageA), 4));

            //            Assert.AreEqual(0, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(-0.03, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.011, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(25);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 3);
            testChain.Add(MessageA, 12);
            testChain.Add(MessageA, 13);
            testChain.Add(MessageA, 15);
            testChain.Add(MessageA, 17);
            testChain.Add(MessageA, 23);
            testChain.Add(MessageB, 6);
            testChain.Add(MessageB, 21);
            testChain.Add(MessageB, 24);

            Assert.AreEqual(0.356, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.075, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.214, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0.105, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0.15, Math.Round(testChain.K3(MessageA, MessageB), 2));

            Assert.AreEqual(0.086, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.012, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(29);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 3);
            testChain.Add(MessageA, 4);
            testChain.Add(MessageA, 6);
            testChain.Add(MessageA, 18);
            testChain.Add(MessageA, 21);
            testChain.Add(MessageB, 2);
            testChain.Add(MessageB, 17);
            testChain.Add(MessageB, 28);

            Assert.AreEqual(0.023, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.307, Math.Round(testChain.K1(MessageB, MessageA), 3));

            //            Assert.AreEqual(0.0445, Math.Round(testChain.K2(MessageA, MessageB), 4));
            //            Assert.AreEqual(0.4418, Math.Round(testChain.K2(MessageB, MessageA), 4));

            //            Assert.AreEqual(0.1402, Math.Round(testChain.K3(MessageA, MessageB), 4));

            Assert.AreEqual(0.005, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.042, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(28);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 8);
            testChain.Add(MessageA, 16);
            testChain.Add(MessageA, 18);
            testChain.Add(MessageB, 4);
            testChain.Add(MessageB, 12);
            testChain.Add(MessageB, 17);
            testChain.Add(MessageB, 19);

            Assert.AreEqual(0.614, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.402, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.614, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0.402, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0.497, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.175, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.086, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(28);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 9);
            testChain.Add(MessageA, 16);
            testChain.Add(MessageA, 24);
            testChain.Add(MessageB, 2);
            testChain.Add(MessageB, 11);
            testChain.Add(MessageB, 19);
            testChain.Add(MessageB, 25);

            Assert.AreEqual(0.69, Math.Round(testChain.K1(MessageA, MessageB), 2));
            Assert.AreEqual(0.059, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.69, Math.Round(testChain.K2(MessageA, MessageB), 2));
            Assert.AreEqual(0.059, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0.202, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.197, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.013, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(16);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 8);
            testChain.Add(MessageB, 4);
            testChain.Add(MessageB, 12);

            Assert.AreEqual(0.293, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.25, testChain.K1(MessageB, MessageA));

            Assert.AreEqual(0.293, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0.25, testChain.K2(MessageB, MessageA));

            Assert.AreEqual(0.271, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.073, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.031, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));

            
            testChain = new Chain(30);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 6);
            testChain.Add(MessageA, 10);
            testChain.Add(MessageA, 18);
            testChain.Add(MessageB, 3);
            testChain.Add(MessageB, 9);
            testChain.Add(MessageB, 13);
            testChain.Add(MessageB, 21);

            Assert.AreEqual(0.535, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.496, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.535, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0.496, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0.515, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.143, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.099, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));


            testChain = new Chain(23);
            testChain.Add(MessageA, 4);
            testChain.Add(MessageA, 8);
            testChain.Add(MessageA, 14);
            testChain.Add(MessageA, 18);
            testChain.Add(MessageB, 5);
            testChain.Add(MessageB, 9);
            testChain.Add(MessageB, 15);
            testChain.Add(MessageB, 19);

            Assert.AreEqual(0.774, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.209, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.774, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0.209, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0.402, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.269, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.055, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));


            testChain = new Chain(12);
            testChain.Add(MessageA, 4);
            testChain.Add(MessageB, 1);
            testChain.Add(MessageB, 3);
            testChain.Add(MessageB, 5);
            testChain.Add(MessageB, 8);

            Assert.AreEqual(0.2143, Math.Round(testChain.K1(MessageA, MessageB), 4));
            Assert.AreEqual(0.875, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.3429, Math.Round(testChain.K2(MessageA, MessageB), 4));
            Assert.AreEqual(0.35, Math.Round(testChain.K2(MessageB, MessageA), 2));

            Assert.AreEqual(0.3464, Math.Round(testChain.K3(MessageA, MessageB), 4));

            Assert.AreEqual(0.036, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.146, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));


            // -------------- дальше цепочки из монографии

            testChain = new Chain(26);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 6);
            testChain.Add(MessageA, 12);
            testChain.Add(MessageB, 2);
            testChain.Add(MessageB, 8);
            testChain.Add(MessageB, 19);

            Assert.AreEqual(0.607, Math.Round(testChain.K1(MessageA, MessageB), 3));
            Assert.AreEqual(0.376, Math.Round(testChain.K1(MessageB, MessageA), 3));

            Assert.AreEqual(0.607, Math.Round(testChain.K2(MessageA, MessageB), 3));
            Assert.AreEqual(0.376, Math.Round(testChain.K2(MessageB, MessageA), 3));

            Assert.AreEqual(0.478, Math.Round(testChain.K3(MessageA, MessageB), 3));

            Assert.AreEqual(0.14, Math.Round(testChain.NormalizedK1(MessageA, MessageB), 3));
            Assert.AreEqual(0.058, Math.Round(testChain.NormalizedK1(MessageB, MessageA), 3));


            testChain = new Chain(23);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 6);
            testChain.Add(MessageA, 11);
            testChain.Add(MessageA, 21);
            testChain.Add(MessageB, 1);
            testChain.Add(MessageB, 7);
            testChain.Add(MessageB, 12);
            testChain.Add(MessageB, 22);

//            Assert.AreEqual(0.798, Math.Round(testChain.PartialDependenceCoefficient(MessageA, MessageB),3));
//            Assert.AreEqual(-0.046, Math.Round(testChain.PartialDependenceCoefficient(MessageB, MessageA), 3));

//            Assert.AreEqual(0.798, Math.Round(testChain.K2(MessageA, MessageB),3));
//            Assert.AreEqual(-0.046, Math.Round(testChain.K2(MessageB, MessageA),3));

//            Assert.AreEqual(0, testChain.K3(MessageA, MessageB));

        }

        [Test]
        public void TestGetK1()
        {
            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageB = new ValueChar('b');
            ValueChar MessageC = new ValueChar('c');

            List<List<double>> result;

            Chain testChain = new Chain(2);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageB, 1);

            result = testChain.GetK1();

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);


            testChain = new Chain(28);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 8);
            testChain.Add(MessageA, 16);
            testChain.Add(MessageA, 18);
            testChain.Add(MessageB, 4);
            testChain.Add(MessageB, 12);
            testChain.Add(MessageB, 17);
            testChain.Add(MessageB, 19);

            result = testChain.GetK1();

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.614, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.402, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            testChain = new Chain(12);
            testChain.Add(MessageA, 0);
            testChain.Add(MessageA, 4);
            testChain.Add(MessageB, 1);
            testChain.Add(MessageB, 3);
            testChain.Add(MessageB, 5);
            testChain.Add(MessageB, 8);
            testChain.Add(MessageC, 2);
            testChain.Add(MessageC, 6);
            testChain.Add(MessageC, 7);
            testChain.Add(MessageC, 9);
            testChain.Add(MessageC, 10);
            testChain.Add(MessageC, 11);

            result = testChain.GetK1();

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.4055, Math.Round(result[0][1], 4));
            Assert.AreEqual(0.197, Math.Round(result[0][2], 3));
            Assert.AreEqual(0, result[1][0], 3);
            Assert.AreEqual(0, result[1][1]);
            Assert.AreEqual(0.349, Math.Round(result[1][2], 3));
            Assert.AreEqual(0.375, Math.Round(result[2][0], 3));
            Assert.AreEqual(0.388, Math.Round(result[2][1], 3));
            Assert.AreEqual(0, result[2][2]);

        }
    }
}