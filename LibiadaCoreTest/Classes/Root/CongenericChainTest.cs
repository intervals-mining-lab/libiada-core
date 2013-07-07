using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class CongenericChainTest
    {
        private ValueChar message;
        private ValueChar WrongMessage;
        private CongenericChain CongenericChain;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            message = new ValueChar('1');
            CongenericChain = new CongenericChain(10, message);
            WrongMessage = new ValueChar('2');
        }

        ///<summary>
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(10, CongenericChain.Length);
            Assert.AreEqual(message, CongenericChain.Element);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void IndependenseMessageTest()
        {
            CongenericChain = new CongenericChain(10, message);

            ValueChar newMessage = (ValueChar) CongenericChain.Element;
            newMessage.Value = '2';

            Assert.IsFalse(newMessage.Equals(CongenericChain.Element));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void AddTest()
        {
            CongenericChain.Add(message, 3);
            Assert.AreEqual(message, CongenericChain.Get(3));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void WrongMessageTest()
        {
            CongenericChain.Add(WrongMessage, 4);
            Assert.AreNotEqual(WrongMessage, CongenericChain.Get(4));
            Assert.AreEqual(NullValue.Instance(), CongenericChain.Get(4));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void RemoveTest()
        {
            CongenericChain.Add(message, 3);
            CongenericChain.RemoveAt(3);
            Assert.AreNotEqual(message, CongenericChain.Get(3));
            Assert.AreEqual(NullValue.Instance(), CongenericChain.Get(3));
        }
    }
}