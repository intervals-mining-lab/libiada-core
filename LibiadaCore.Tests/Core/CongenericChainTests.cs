namespace LibiadaCore.Tests.Core
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The congeneric chain test.
    /// </summary>
    [TestFixture]
    public class CongenericChainTests
    {
        /// <summary>
        /// The message.
        /// </summary>
        private ValueChar message;

        /// <summary>
        /// The wrong message.
        /// </summary>
        private ValueChar wrongMessage;

        /// <summary>
        /// The congeneric chain.
        /// </summary>
        private CongenericChain congenericChain;

        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            message = new ValueChar('1');
            congenericChain = new CongenericChain(message, 10);
            wrongMessage = new ValueChar('2');
        }

        /// <summary>
        /// The constructor test.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(10, congenericChain.GetLength());
            Assert.AreEqual(message, congenericChain.Element);
        }

        /// <summary>
        /// The independence message test.
        /// </summary>
        [Test]
        public void IndependenceMessageTest()
        {
            congenericChain = new CongenericChain(message, 10);

            var newMessage = (ValueChar)congenericChain.Element;

            Assert.AreNotSame(congenericChain.Element, newMessage);
        }

        /// <summary>
        /// The add test.
        /// </summary>
        [Test]
        public void AddTest()
        {
            congenericChain.Add(message, 3);
            Assert.AreEqual(message, congenericChain.Get(3));
        }

        /// <summary>
        /// The wrong message test.
        /// </summary>
        [Test]
        public void WrongMessageTest()
        {
            congenericChain.Add(wrongMessage, 4);
            Assert.AreNotEqual(wrongMessage, congenericChain.Get(4));
            Assert.AreEqual(NullValue.Instance(), congenericChain.Get(4));
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            congenericChain.Add(message, 3);
            congenericChain.RemoveAt(3);
            Assert.AreNotEqual(message, congenericChain.Get(3));
            Assert.AreEqual(NullValue.Instance(), congenericChain.Get(3));
        }
    }
}