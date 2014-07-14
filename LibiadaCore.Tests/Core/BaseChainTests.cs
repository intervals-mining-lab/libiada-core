namespace LibiadaCore.Tests.Core
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    // TODO: FIX ORDER OF ARGUMENTS IN ALL AreEqual

    /// <summary>
    /// The base chain test.
    /// </summary>
    [TestFixture]
    public class BaseChainTests
    {
        /// <summary>
        /// The chain base.
        /// </summary>
        private BaseChain chainBase;

        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            chainBase = new BaseChain(10);
        }

        /// <summary>
        /// The constructor test.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            var chain = new Chain(100);
            Assert.AreEqual(100, chain.GetLength());
        }

        /// <summary>
        /// The constructor less zero test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorLessZeroTest()
        {
            new BaseChain(-10);
        }

        /// <summary>
        /// The get by this test.
        /// </summary>
        [Test]
        public void GetByThisTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)chainBase[0], '1');
        }

        /// <summary>
        /// The set by this test.
        /// </summary>
        [Test]
        public void SetByThisTest()
        {
            chainBase[0] = new ValueChar('1');
            Assert.AreEqual((ValueChar)chainBase.Get(0), '1');
        }

        /// <summary>
        /// The get test.
        /// </summary>
        [Test]
        public void GetTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)chainBase.Get(0), '1');
        }

        /// <summary>
        /// The set test.
        /// </summary>
        [Test]
        public void SetTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)chainBase.Get(0), '1');
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)chainBase[0], '1');

            chainBase.RemoveAt(0);
            Assert.AreEqual(chainBase[0], NullValue.Instance());
        }

        /// <summary>
        /// The get length test.
        /// </summary>
        [Test]
        public void GetLengthTest()
        {
            Assert.AreEqual(10, chainBase.GetLength());
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            chainBase = new BaseChain("123456789A");

            var itsClone = (BaseChain)chainBase.Clone();
            Assert.AreEqual(chainBase, itsClone);
            Assert.AreNotSame(chainBase, itsClone);
        }
    }
}