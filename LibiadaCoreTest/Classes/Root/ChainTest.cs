using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCoreTest.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root
{
    [TestFixture]
    public class ChainTest
    {
        private Chain chain;

        [SetUp]
        public void Init()
        {
            chain = new Chain(10);
        }

        [Test]
        public void SimularChainsGetTest()
        {
            ValueChar messageA = new ValueChar('a');
            ValueChar messageC = new ValueChar('c');
            ValueChar messageG = new ValueChar('g');
            ValueChar messageT = new ValueChar('t');
            CongenericChain unifromChainA = new CongenericChain(10, messageA);

            chain.Add(messageC, 0);

            chain.Add(messageC, 1);

            chain.Add(messageA, 2);

            unifromChainA.Add(messageA, 2);

            chain.Add(messageC, 3);

            chain.Add(messageG, 4);

            chain.Add(messageC, 5);

            chain.Add(messageT, 6);

            chain.Add(messageT, 7);

            chain.Add(messageA, 8);

            unifromChainA.Add(messageA, 8);

            chain.Add(messageC, 9);

            BaseChain chainCreatedCongenericChain = chain.CongenericChain((IBaseObject)messageA);

            Assert.AreEqual(unifromChainA, chainCreatedCongenericChain);
        }

        [Test]
        public void IntervalsTest()
        {
            Chain temp = CalculationHelper.Chains[0];
            List<List<int>> intervals = new List<List<int>>
                {
                    new List<int> {1, 1, 4, 4, 1},
                    new List<int> {3, 1, 3, 4},
                    new List<int> {5, 3, 1, 2}
                };
            for (int i = 0; i < temp.Alphabet.Power; i++)
            {
                List<int> actualIntervals = temp.CongenericChain(i).Intervals;
                for (int j = 0; j < actualIntervals.Count; j++)
                {
                    Assert.AreEqual(intervals[i][j], actualIntervals[j], "�� ��������� {0} ��������� {1} �������", j, i);
                }
            }
        }

        [Test]
        public void GetElementPositionTest()
        {
            ValueChar messageA = new ValueChar('a');
            ValueChar messageC = new ValueChar('c');
            ValueChar messageG = new ValueChar('g');
            ValueChar messageT = new ValueChar('t');

            chain.Add(messageC, 0);
            chain.Add(messageC, 1);
            chain.Add(messageA, 2);
            chain.Add(messageC, 3);
            chain.Add(messageG, 4);
            chain.Add(messageC, 5);
            chain.Add(messageT, 6);
            chain.Add(messageT, 7);
            chain.Add(messageA, 8);
            chain.Add(messageC, 9);

            Assert.AreEqual(2,chain.Get(messageA, 1));
            Assert.AreEqual(8, chain.Get(messageA, 2));
            Assert.AreEqual(-1, chain.Get(messageA, 3));

            Assert.AreEqual(0, chain.Get(messageC, 1));
            Assert.AreEqual(1, chain.Get(messageC, 2));
            Assert.AreEqual(3, chain.Get(messageC, 3));
            Assert.AreEqual(5, chain.Get(messageC, 4));
            Assert.AreEqual(9, chain.Get(messageC, 5));
            Assert.AreEqual(-1, chain.Get(messageC, 6));

            Assert.AreEqual(4, chain.Get(messageG, 1));
            Assert.AreEqual(-1, chain.Get(messageG, 2));
            Assert.AreEqual(-1, chain.Get(messageG, 3));

            Assert.AreEqual(6, chain.Get(messageT, 1));
            Assert.AreEqual(7, chain.Get(messageT, 2));
            Assert.AreEqual(-1, chain.Get(messageT, 3));
        }

        [Test]
        public void GetBinaryIntervalTest()
        {
            ValueChar messageA = new ValueChar('a');
            ValueChar messageC = new ValueChar('c');
            ValueChar messageG = new ValueChar('g');
            ValueChar messageT = new ValueChar('t');

            chain.Add(messageC, 0);
            chain.Add(messageC, 1);
            chain.Add(messageA, 2);
            chain.Add(messageC, 3);
            chain.Add(messageG, 4);
            chain.Add(messageC, 5);
            chain.Add(messageT, 6);
            chain.Add(messageT, 7);
            chain.Add(messageA, 8);
            chain.Add(messageC, 9);

            Assert.AreEqual(1, chain.GetBinaryInterval(messageA, messageC, 1));
            Assert.AreEqual(1, chain.GetBinaryInterval(messageA, messageC, 2));
            Assert.AreEqual(-1, chain.GetBinaryInterval(messageA, messageC, 3));

            Assert.AreEqual(-1, chain.GetBinaryInterval(messageC, messageA, 1));
            Assert.AreEqual(1, chain.GetBinaryInterval(messageC, messageA, 2));
            Assert.AreEqual(-1, chain.GetBinaryInterval(messageC, messageA, 3));
            Assert.AreEqual(3, chain.GetBinaryInterval(messageC, messageA, 4));
            Assert.AreEqual(-1, chain.GetBinaryInterval(messageC, messageA, 5));

            Assert.AreEqual(-1, chain.GetBinaryInterval(messageC, messageT, 1));
            Assert.AreEqual(-1, chain.GetBinaryInterval(messageC, messageT, 2));
            Assert.AreEqual(-1, chain.GetBinaryInterval(messageC, messageT, 3));
            Assert.AreEqual(1, chain.GetBinaryInterval(messageC, messageT, 4));
            Assert.AreEqual(1, chain.GetBinaryInterval(messageC, messageT, 4));

            // oxo_xx_oooxxo
            Chain testChain = new Chain(13);
            testChain.Add(messageA, 0);
            testChain.Add(messageC, 1);
            testChain.Add(messageA, 2);

            testChain.Add(messageC, 4);
            testChain.Add(messageC, 5);

            testChain.Add(messageA, 7);
            testChain.Add(messageA, 8);
            testChain.Add(messageA, 9);
            testChain.Add(messageC, 10);
            testChain.Add(messageC, 11);
            testChain.Add(messageA, 12);

            Assert.AreEqual(1, testChain.GetBinaryInterval(messageA, messageC, 1));
            Assert.AreEqual(2, testChain.GetBinaryInterval(messageA, messageC, 2));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 3));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 4));
            Assert.AreEqual(1, testChain.GetBinaryInterval(messageA, messageC, 5));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 6));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageA, messageC, 7));

            Assert.AreEqual(1, testChain.GetBinaryInterval(messageC, messageA, 1));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageC, messageA, 2));
            Assert.AreEqual(2, testChain.GetBinaryInterval(messageC, messageA, 3));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageC, messageA, 4));
            Assert.AreEqual(1, testChain.GetBinaryInterval(messageC, messageA, 5));
            Assert.AreEqual(-1, testChain.GetBinaryInterval(messageC, messageA, 6));
        }
    }
}