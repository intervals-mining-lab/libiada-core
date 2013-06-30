using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root
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
        public void Init()
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
            Assert.AreEqual(message, UniformChain.Element);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndependenseMessage()
        {
            UniformChain = new UniformChain(10, message);

            ValueChar newMessage = (ValueChar) UniformChain.Element;
            newMessage.value = '2';

            Assert.IsFalse(newMessage.Equals(UniformChain.Element));
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
            Assert.AreEqual(NullValue.Instance(), UniformChain.Get(4));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestRemove()
        {
            UniformChain.Add(message, 3);
            UniformChain.RemoveAt(3);
            Assert.AreNotEqual(message, UniformChain.Get(3));
            Assert.AreEqual(NullValue.Instance(), UniformChain.Get(3));
        }
    }
}