using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root
{
    //TODO: FIX ORDER OF ARGUMENTS IN ALL AreEqual
    [TestFixture]
    public class BaseChainTest
    {
        private BaseChain chainBase;

        [SetUp]
        public void Init()
        {
            chainBase = new BaseChain(10);
        }

        [Test]
        public void ConstructorTest()
        {
            Chain chain = new Chain(100);
            Assert.AreEqual(100, chain.Length);
        }

        [Test]
        public void ConstructorLessZeroTest()
        {
            try
            {
                new BaseChain(-10);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void GetbyThisTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) chainBase[0]).Value, '1');
        }

        [Test]
        public void SetByThisTest()
        {
            chainBase[0] = new ValueChar('1');
            Assert.AreEqual((ValueChar)chainBase.GetItem(0), '1');
        }

        [Test]
        public void GetTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) chainBase.Get(0)).Value, '1');
        }

        [Test]
        public void SetTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar) chainBase.GetItem(0), '1');
        }

        [Test]
        public void RemoveTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) chainBase[0]).Value, '1');

            chainBase.RemoveAt(0);
            Assert.AreEqual(chainBase[0], NullValue.Instance());
        }

        [Test]
        public void GetLengthTest()
        {
            Assert.AreEqual(10, chainBase.Length);
        }

        [Test]
        public void CloneTest()
        {
            chainBase = new BaseChain("123456789A");

            BaseChain itsClone = (BaseChain) chainBase.Clone();
            Assert.AreEqual(chainBase, itsClone);
            Assert.AreNotSame(chainBase, itsClone);
        }

        [Test]
        public void EqualsPsevdoTest()
        {
            Chain empty = new Chain(10);
            Assert.AreEqual(empty, NullValue.Instance());

            empty.Add(empty.Clone(), 2);
            Assert.AreEqual(empty, NullValue.Instance());

            empty.Add(new ValueChar('1'), 5);
            Assert.AreNotEqual(empty, NullValue.Instance());
        }
    }
}