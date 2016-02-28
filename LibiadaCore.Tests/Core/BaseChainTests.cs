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
        private BaseChain chain;

        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            chain = new BaseChain(10);
        }

        /// <summary>
        /// The constructor test.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            chain = new Chain(100);
            Assert.AreEqual(100, chain.GetLength());
        }

        /// <summary>
        /// The constructor less zero test.
        /// </summary>
        [Test]
        public void ConstructorLessZeroTest()
        {
            Assert.Throws<ArgumentException>(() => new BaseChain(-10));
        }

        /// <summary>
        /// The get by this test.
        /// </summary>
        [Test]
        public void GetByThisTest()
        {
            chain.Set(new ValueString('1'), 0);
            Assert.IsTrue(((ValueString)chain[0]).Equals("1"));
        }

        /// <summary>
        /// The set by this test.
        /// </summary>
        [Test]
        public void SetByThisTest()
        {
            chain[0] = new ValueString('1');
            Assert.IsTrue(((ValueString)chain.Get(0)).Equals("1"));
        }

        /// <summary>
        /// The get test.
        /// </summary>
        [Test]
        public void GetTest()
        {
            chain.Set(new ValueString('1'), 0);
            Assert.IsTrue(((ValueString)chain.Get(0)).Equals("1"));
        }

        /// <summary>
        /// The set test.
        /// </summary>
        [Test]
        public void SetTest()
        {
            chain.Set(new ValueString('1'), 0);
            Assert.IsTrue(((ValueString)chain.Get(0)).Equals("1"));
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            chain.Set(new ValueString('1'), 0);
            Assert.IsTrue(((ValueString)chain[0]).Equals("1"));

            chain.RemoveAt(0);
            Assert.AreEqual(NullValue.Instance(), chain[0]);
        }

        /// <summary>
        /// The get length test.
        /// </summary>
        [Test]
        public void GetLengthTest()
        {
            Assert.AreEqual(10, chain.GetLength());
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            chain = new BaseChain("123456789A");

            var itsClone = (BaseChain)chain.Clone();
            Assert.AreEqual(chain, itsClone);
            Assert.AreNotSame(chain, itsClone);
        }
    }
}
