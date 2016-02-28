namespace LibiadaCore.Tests.Core
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The alphabet test.
    /// </summary>
    [TestFixture]
    public class AlphabetTests
    {
        /// <summary>
        /// The first alphabet.
        /// </summary>
        private Alphabet firstAlphabet;

        /// <summary>
        /// The second alphabet.
        /// </summary>
        private Alphabet secondAlphabet;

        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            firstAlphabet = new Alphabet();
            secondAlphabet = new Alphabet();
        }

        /// <summary>
        /// The constructor test.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            Assert.IsNotNull(firstAlphabet);
            Assert.AreEqual(0, firstAlphabet.Cardinality);
        }

        /// <summary>
        /// The add same test.
        /// </summary>
        [Test]
        public void AddSameTest()
        {
            firstAlphabet.Add(new ValueInt(2));
            Assert.Throws<ArgumentException>(() => firstAlphabet.Add(new ValueInt(2)));
        }

        /// <summary>
        /// The get test.
        /// </summary>
        [Test]
        public void GetTest()
        {
            firstAlphabet.Add(new ValueInt(2));
            firstAlphabet.Add(new ValueInt(3));
            firstAlphabet.Add(new ValueInt(4));
            firstAlphabet.Add(new ValueInt(5));
            Assert.AreEqual(new ValueInt(2), firstAlphabet[0]);
            Assert.AreEqual(new ValueInt(3), firstAlphabet[1]);
            Assert.AreEqual(new ValueInt(4), firstAlphabet[2]);
            Assert.AreEqual(new ValueInt(5), firstAlphabet[3]);
        }

        /// <summary>
        /// The independent number test.
        /// </summary>
        [Test]
        public void IndependentNumberTest()
        {
            firstAlphabet.Add(new ValueInt(2));
            firstAlphabet.Add(new ValueInt(1));
            firstAlphabet.Add(new ValueInt(3));
            firstAlphabet.Add(new ValueInt(4));
            firstAlphabet[0] = new ValueInt(3);
            Assert.AreEqual(new ValueInt(2), firstAlphabet[0]);
            Assert.AreEqual(new ValueInt(1), firstAlphabet[1]);
            Assert.AreEqual(new ValueInt(3), firstAlphabet[2]);
            Assert.AreEqual(new ValueInt(4), firstAlphabet[3]);
        }

        /// <summary>
        /// The independent string test.
        /// </summary>
        [Test]
        public void IndependentStringTest()
        {
            firstAlphabet.Add(new ValueString("2"));
            firstAlphabet.Add(new ValueString("3"));
            firstAlphabet.Add(new ValueString("5"));
            firstAlphabet.Add(new ValueString("1"));
            firstAlphabet[0] = new ValueString("3");
            Assert.AreEqual(new ValueString("2"), firstAlphabet[0]);
            Assert.AreEqual(new ValueString("3"), firstAlphabet[1]);
            Assert.AreEqual(new ValueString("5"), firstAlphabet[2]);
            Assert.AreEqual(new ValueString("1"), firstAlphabet[3]);
        }

        /// <summary>
        /// The null test.
        /// </summary>
        [Test]
        public void NullTest()
        {
            Assert.Throws<NullReferenceException>(() => firstAlphabet.Add(null));
        }

        /// <summary>
        /// The cardinality test.
        /// </summary>
        [Test]
        public void CardinalityTest()
        {
            firstAlphabet.Add(new ValueInt(100));
            firstAlphabet.Add(new ValueInt(200));
            firstAlphabet.Add(new ValueInt(300));
            Assert.AreEqual(3, firstAlphabet.Cardinality);
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            firstAlphabet.Add(new ValueInt(100));
            firstAlphabet.Add(new ValueInt(200));
            firstAlphabet.Add(new ValueInt(300));
            firstAlphabet.Add(new ValueInt(400));
            firstAlphabet.Remove(2);
            Assert.AreEqual(3, firstAlphabet.Cardinality);
            Assert.AreEqual(new ValueInt(400), firstAlphabet[2]);
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            Assert.AreNotSame(firstAlphabet, firstAlphabet.Clone());

            Assert.IsTrue(firstAlphabet.Equals(firstAlphabet.Clone()));
        }

        /// <summary>
        /// The equals test.
        /// </summary>
        [Test]
        public void EqualsTest()
        {
            firstAlphabet.Add(new ValueString('a'));
            firstAlphabet.Add(new ValueString('b'));
            firstAlphabet.Add(new ValueString('c'));
            secondAlphabet.Add(new ValueString('a'));
            secondAlphabet.Add(new ValueString('b'));
            secondAlphabet.Add(new ValueString('c'));
            Assert.IsTrue(firstAlphabet.Equals(firstAlphabet.Clone()));
            Assert.IsTrue(firstAlphabet.Equals(secondAlphabet));
        }

        /// <summary>
        /// The equals for alphabet with equals composition but not equals order test.
        /// </summary>
        [Test]
        public void EqualsForAlphabetWithEqualsCompositionButNotEqualsOrderTest()
        {
            firstAlphabet.Add(new ValueString('a'));
            firstAlphabet.Add(new ValueString('b'));
            firstAlphabet.Add(new ValueString('c'));
            secondAlphabet.Add(new ValueString('a'));
            secondAlphabet.Add(new ValueString('b'));
            secondAlphabet.Add(new ValueString('c'));
            Assert.IsTrue(firstAlphabet.Equals(firstAlphabet.Clone()));
            Assert.IsTrue(firstAlphabet.Equals(secondAlphabet));
        }

        /// <summary>
        /// The contains test.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            firstAlphabet.Add(new ValueString('a'));
            firstAlphabet.Add(new ValueString('b'));
            firstAlphabet.Add(new ValueString('c'));
            Assert.IsTrue(firstAlphabet.Contains(new ValueString('a')));
            Assert.IsTrue(firstAlphabet.Contains(new ValueString('b')));
            Assert.IsTrue(firstAlphabet.Contains(new ValueString('c')));
            Assert.IsFalse(firstAlphabet.Contains(new ValueString('d')));
        }

        /// <summary>
        /// The index of test.
        /// </summary>
        [Test]
        public void IndexOfTest()
        {
            firstAlphabet.Add(new ValueString('a'));
            firstAlphabet.Add(new ValueString('b'));
            firstAlphabet.Add(new ValueString('c'));
            Assert.IsTrue(firstAlphabet.IndexOf(new ValueString('d')).Equals(-1));
            Assert.IsTrue(firstAlphabet.IndexOf(new ValueString('a')).Equals(0));
            Assert.IsTrue(firstAlphabet.IndexOf(new ValueString('c')).Equals(2));
        }

        /// <summary>
        /// Testing that alphabet creates internal copy of the element
        /// so it cannot be changed from outside.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            var a = new ValueString('a');
            var c = new ValueString('c');
            var e = new ValueString('e');

            firstAlphabet.Add(a);
            firstAlphabet.Add(new ValueString('b'));
            firstAlphabet.Add(c);
            firstAlphabet.Add(new ValueString('d'));
            firstAlphabet.Add(e);

            Assert.AreNotSame(e, firstAlphabet[4]);
            Assert.AreNotSame(c, firstAlphabet[2]);
            Assert.AreNotSame(a, firstAlphabet[0]);
        }
    }
}
