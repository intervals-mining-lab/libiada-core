namespace LibiadaCoreTest.Classes.Root
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The congeneric chain test.
    /// </summary>
    [TestFixture]
    public class CongenericChainTest
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
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            message = new ValueChar('1');
            this.congenericChain = new CongenericChain(10, message);
            this.wrongMessage = new ValueChar('2');
        }

        /// <summary>
        /// The constructor test.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual(10, this.congenericChain.Length);
            Assert.AreEqual(message, this.congenericChain.Element);
        }

        /// <summary>
        /// The independence message test.
        /// </summary>
        [Test]
        public void IndependenceMessageTest()
        {
            this.congenericChain = new CongenericChain(10, message);

            var newMessage = (ValueChar)this.congenericChain.Element;

            Assert.AreNotSame(this.congenericChain.Element, newMessage);
        }

        /// <summary>
        /// The add test.
        /// </summary>
        [Test]
        public void AddTest()
        {
            this.congenericChain.Add(message, 3);
            Assert.AreEqual(message, this.congenericChain.Get(3));
        }

        /// <summary>
        /// The wrong message test.
        /// </summary>
        [Test]
        public void WrongMessageTest()
        {
            this.congenericChain.Add(this.wrongMessage, 4);
            Assert.AreNotEqual(this.wrongMessage, this.congenericChain.Get(4));
            Assert.AreEqual(NullValue.Instance(), this.congenericChain.Get(4));
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            this.congenericChain.Add(message, 3);
            this.congenericChain.RemoveAt(3);
            Assert.AreNotEqual(message, this.congenericChain.Get(3));
            Assert.AreEqual(NullValue.Instance(), this.congenericChain.Get(3));
        }
    }
}