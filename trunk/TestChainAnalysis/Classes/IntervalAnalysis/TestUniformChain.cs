using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestUniformChain
    {
        private ValueChar message = null;
        private ValueChar WrongMessage = null;
        private UniformChain UniformChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            message = new ValueChar('1');
            UniformChain = new UniformChain(10, message);
            WrongMessage = new ValueChar('2');
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(10, UniformChain.Length);
            Assert.AreEqual(message, UniformChain.Message);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndependenseMessage()
        {
            ValueChar MessageNew;

            UniformChain = new UniformChain(10, message);

            MessageNew = (ValueChar) UniformChain.Message;
            MessageNew.value = '2';

            Assert.IsFalse(MessageNew.Equals(UniformChain.Message));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestAdd()
        {
            UniformChain.Add(message, 3);
            Assert.AreEqual(message, UniformChain.Get(3));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestWrongMessage()
        {
            UniformChain.Add(WrongMessage, 4);
            Assert.AreNotEqual(WrongMessage, UniformChain.Get(4));
            Assert.AreEqual(PsevdoValue.Instance(), UniformChain.Get(4));
        }

        ///<summary>
        ///</summary>
        public void TestRemove()
        {
            UniformChain.Add(message, 3);
            UniformChain.RemoveAt(3);
            Assert.AreNotEqual(message, UniformChain.Get(3));
            Assert.AreEqual(PsevdoValue.Instance(), UniformChain.Get(3));
        }

        ///<summary>
        ///</summary>
        public void TestGetInterval()
        {
            UniformChain.Add(message, 3);
            Assert.AreEqual(4, (ValueInt) UniformChain.Intervals(LinkUp.Start)[0].Key);
            Assert.AreEqual(7, (ValueInt) UniformChain.Intervals(LinkUp.End)[0].Key);
            Assert.AreEqual(4, (ValueInt) UniformChain.Intervals(LinkUp.Both)[0].Key);
            Assert.AreEqual(7, (ValueInt) UniformChain.Intervals(LinkUp.Both)[1].Key);

            UniformChain.Add(message, 7);
            Assert.AreEqual(4, (ValueInt) UniformChain.Intervals(LinkUp.Start)[0].Key);
            Assert.AreEqual(2, UniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 4));

            Assert.AreEqual(4, (ValueInt) UniformChain.Intervals(LinkUp.End)[0].Key);
            Assert.AreEqual(3, (ValueInt) UniformChain.Intervals(LinkUp.End)[1].Key);
            Assert.AreEqual(1, UniformChain.Intervals(LinkUp.End).FrequencyFromObject((ValueInt) 4));

            Assert.AreEqual(4, (ValueInt) UniformChain.Intervals(LinkUp.Both)[0].Key);
            Assert.AreEqual(3, (ValueInt) UniformChain.Intervals(LinkUp.Both)[1].Key);
            Assert.AreEqual(2, UniformChain.Intervals(LinkUp.Both).FrequencyFromObject((ValueInt) 4));

            UniformChain.Add(message, 4);
            Assert.AreEqual(1, UniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 4));
            Assert.AreEqual(1, UniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 1));
            Assert.AreEqual(1, UniformChain.Intervals(LinkUp.Start).FrequencyFromObject((ValueInt) 3));
        }
    }
}