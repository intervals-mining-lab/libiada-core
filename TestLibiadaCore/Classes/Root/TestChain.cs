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
        public void Init()
        {
            ChainBase = new Chain(10);
        }


        ///<summary>
        ///</summary>
        [Test]
        public void TestSimularChainsGet()
        {
            ValueChar messageA = new ValueChar('a');
            ValueChar messageC = new ValueChar('c');
            ValueChar messageG = new ValueChar('g');
            ValueChar messageT = new ValueChar('t');
            CongenericChain UnifromChainA = new CongenericChain(10, messageA);

            ChainBase.Add(messageC, 0);

            ChainBase.Add(messageC, 1);

            ChainBase.Add(messageA, 2);

            UnifromChainA.Add(messageA, 2);

            ChainBase.Add(messageC, 3);

            ChainBase.Add(messageG, 4);

            ChainBase.Add(messageC, 5);

            ChainBase.Add(messageT, 6);

            ChainBase.Add(messageT, 7);

            ChainBase.Add(messageA, 8);

            UnifromChainA.Add(messageA, 8);

            ChainBase.Add(messageC, 9);

            BaseChain chainCreatedCongenericChain = ChainBase.CongenericChain((IBaseObject)messageA);

            Assert.AreEqual(UnifromChainA, chainCreatedCongenericChain);
        }

        [Test]
        public void TestGetElementPosition()
        {
            ValueChar messageA = new ValueChar('a');
            ValueChar messageC = new ValueChar('c');
            ValueChar messageG = new ValueChar('g');
            ValueChar messageT = new ValueChar('t');

            ChainBase.Add(messageC, 0);
            ChainBase.Add(messageC, 1);
            ChainBase.Add(messageA, 2);
            ChainBase.Add(messageC, 3);
            ChainBase.Add(messageG, 4);
            ChainBase.Add(messageC, 5);
            ChainBase.Add(messageT, 6);
            ChainBase.Add(messageT, 7);
            ChainBase.Add(messageA, 8);
            ChainBase.Add(messageC, 9);

            Assert.AreEqual(2,ChainBase.Get(messageA, 1));
            Assert.AreEqual(8, ChainBase.Get(messageA, 2));
            Assert.AreEqual(-1, ChainBase.Get(messageA, 3));

            Assert.AreEqual(0, ChainBase.Get(messageC, 1));
            Assert.AreEqual(1, ChainBase.Get(messageC, 2));
            Assert.AreEqual(3, ChainBase.Get(messageC, 3));
            Assert.AreEqual(5, ChainBase.Get(messageC, 4));
            Assert.AreEqual(9, ChainBase.Get(messageC, 5));
            Assert.AreEqual(-1, ChainBase.Get(messageC, 6));

            Assert.AreEqual(4, ChainBase.Get(messageG, 1));
            Assert.AreEqual(-1, ChainBase.Get(messageG, 2));
            Assert.AreEqual(-1, ChainBase.Get(messageG, 3));

            Assert.AreEqual(6, ChainBase.Get(messageT, 1));
            Assert.AreEqual(7, ChainBase.Get(messageT, 2));
            Assert.AreEqual(-1, ChainBase.Get(messageT, 3));
        }

        [Test]
        public void TestGetBinaryInterval()
        {
            ValueChar messageA = new ValueChar('a');
            ValueChar messageC = new ValueChar('c');
            ValueChar messageG = new ValueChar('g');
            ValueChar messageT = new ValueChar('t');

            ChainBase.Add(messageC, 0);
            ChainBase.Add(messageC, 1);
            ChainBase.Add(messageA, 2);
            ChainBase.Add(messageC, 3);
            ChainBase.Add(messageG, 4);
            ChainBase.Add(messageC, 5);
            ChainBase.Add(messageT, 6);
            ChainBase.Add(messageT, 7);
            ChainBase.Add(messageA, 8);
            ChainBase.Add(messageC, 9);

            Assert.AreEqual(1, ChainBase.GetBinaryInterval(messageA, messageC, 1));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(messageA, messageC, 2));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(messageA, messageC, 3));

            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(messageC, messageA, 1));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(messageC, messageA, 2));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(messageC, messageA, 3));
            Assert.AreEqual(3, ChainBase.GetBinaryInterval(messageC, messageA, 4));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(messageC, messageA, 5));

            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(messageC, messageT, 1));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(messageC, messageT, 2));
            Assert.AreEqual(-1, ChainBase.GetBinaryInterval(messageC, messageT, 3));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(messageC, messageT, 4));
            Assert.AreEqual(1, ChainBase.GetBinaryInterval(messageC, messageT, 4));

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