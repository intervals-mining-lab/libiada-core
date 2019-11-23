namespace LibiadaCore.Tests.Core
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

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
            Assert.AreEqual(100, chain.Length);
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
            Assert.AreEqual(10, chain.Length);
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

        [TestCase(9, 0, "C", 10)]
        [TestCase(9, 2, "A", 11)]
        [TestCase(9, 2, "B", 12)]
        [TestCase(9, 5, "B", 13)]
        [TestCase(9, 7, "A", 14)]
        [TestCase(9, 7, "C", 15)]
        [TestCase(9, 8, "B", 16)]
        [TestCase(9, 0, "A", 17)]
        [TestCase(9, 1, "B", 17)]
        [TestCase(9, 2, "C", 17)]
        [TestCase(9, 3, "A", 17)]
        [TestCase(9, 4, "B", 17)]
        [TestCase(9, 5, "C", 17)]
        [TestCase(9, 6, "A", 17)]
        [TestCase(9, 7, "B", 17)]
        [TestCase(9, 8, "C", 17)]
        public void SetInFullSequenceTests(int sourceIndex, int index, string element, int expectedIndex)
        {
            Chain source = ChainsStorage.Chains[sourceIndex];
            char[] charArraySource = source.ToString().ToCharArray();
            Chain expected = ChainsStorage.Chains[expectedIndex];

            source.Set(new ValueString(element), index);
            Assert.AreEqual(expected, source);

            charArraySource[index] = element[0];
            expected = new Chain(new string(charArraySource));
            Assert.AreEqual(expected, source);
        }

        [TestCase(18, 0, "A", 19)]
        [TestCase(18, 1, "A", 20)]
        [TestCase(19, 1, "A", 21)]
        [TestCase(19, 1, "B", 22)]
        [TestCase(19, 0, "B", 23)]
        [TestCase(19, 3, "A", 24)]
        [TestCase(19, 5, "B", 25)]
        [TestCase(25, 3, "B", 26)]
        [TestCase(29, 0, "A", 27)]
        public void SetInSparseSequenceTests(int sourceIndex, int index, string element, int expectedIndex)
        {
            Chain source = ChainsStorage.Chains[sourceIndex];
            Chain expected = ChainsStorage.Chains[expectedIndex];

            source.Set(new ValueString(element), index);
            Assert.AreEqual(expected, source);
        }
    }
}
