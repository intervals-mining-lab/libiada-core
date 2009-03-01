using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis
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
    }
}