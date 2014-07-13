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
            this.chainBase = new BaseChain(10);
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
            this.chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)this.chainBase[0], '1');
        }

        /// <summary>
        /// The set by this test.
        /// </summary>
        [Test]
        public void SetByThisTest()
        {
            this.chainBase[0] = new ValueChar('1');
            Assert.AreEqual((ValueChar)this.chainBase.Get(0), '1');
        }

        /// <summary>
        /// The get test.
        /// </summary>
        [Test]
        public void GetTest()
        {
            this.chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)this.chainBase.Get(0), '1');
        }

        /// <summary>
        /// The set test.
        /// </summary>
        [Test]
        public void SetTest()
        {
            this.chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)this.chainBase.Get(0), '1');
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            this.chainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar)this.chainBase[0], '1');

            this.chainBase.RemoveAt(0);
            Assert.AreEqual(this.chainBase[0], NullValue.Instance());
        }

        /// <summary>
        /// The get length test.
        /// </summary>
        [Test]
        public void GetLengthTest()
        {
            Assert.AreEqual(10, this.chainBase.GetLength());
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            this.chainBase = new BaseChain("123456789A");

            var itsClone = (BaseChain)this.chainBase.Clone();
            Assert.AreEqual(this.chainBase, itsClone);
            Assert.AreNotSame(this.chainBase, itsClone);
        }
    }
}