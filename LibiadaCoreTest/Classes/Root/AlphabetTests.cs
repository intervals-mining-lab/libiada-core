namespace LibiadaCoreTest.Classes.Root
{
    using System;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The alphabet test.
    /// </summary>
    [TestFixture]
    public class AlphabetTests
    {
        /// <summary>
        /// The alphabet 1.
        /// </summary>
        private Alphabet alphabet1;

        /// <summary>
        /// The alphabet 2.
        /// </summary>
        private Alphabet alphabet2;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            alphabet1 = new Alphabet();
            alphabet2 = new Alphabet();
        }

        /// <summary>
        /// The constructor test.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            var alphabet = new Alphabet();
            Assert.IsNotNull(alphabet);
        }

        /// <summary>
        /// The add same test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception))]
        public void AddSameTest()
        {
            alphabet1.Add(new ValueInt(2));
            alphabet1.Add(new ValueInt(2));
        }

        /// <summary>
        /// The get test.
        /// </summary>
        [Test]
        public void GetTest()
        {
            alphabet1.Add(new ValueInt(2));
            alphabet1.Add(new ValueInt(3));
            alphabet1.Add(new ValueInt(4));
            alphabet1.Add(new ValueInt(5));
            Assert.AreEqual(new ValueInt(2), alphabet1[0]);
            Assert.AreEqual(new ValueInt(3), alphabet1[1]);
            Assert.AreEqual(new ValueInt(4), alphabet1[2]);
            Assert.AreEqual(new ValueInt(5), alphabet1[3]);
        }

        /// <summary>
        /// The independ number test.
        /// </summary>
        [Test]
        public void IndependNumberTest()
        {
            alphabet1.Add(new ValueInt(2));
            alphabet1.Add(new ValueInt(1));
            alphabet1.Add(new ValueInt(3));
            alphabet1.Add(new ValueInt(4));
            alphabet1[0] = new ValueInt(3);
            Assert.AreEqual(new ValueInt(2), alphabet1[0]);
            Assert.AreEqual(new ValueInt(1), alphabet1[1]);
            Assert.AreEqual(new ValueInt(3), alphabet1[2]);
            Assert.AreEqual(new ValueInt(4), alphabet1[3]);
        }

        /// <summary>
        /// The independent string test.
        /// </summary>
        [Test]
        public void IndependentStringTest()
        {
            alphabet1.Add(new ValueString("2"));
            alphabet1.Add(new ValueString("3"));
            alphabet1.Add(new ValueString("5"));
            alphabet1.Add(new ValueString("1"));
            alphabet1[0] = new ValueString("3");
            Assert.AreEqual(new ValueString("2"), alphabet1[0]);
            Assert.AreEqual(new ValueString("3"), alphabet1[1]);
            Assert.AreEqual(new ValueString("5"), alphabet1[2]);
            Assert.AreEqual(new ValueString("1"), alphabet1[3]);
        }

        /// <summary>
        /// The null test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullTest()
        {
            alphabet1.Add(null);
        }

        /// <summary>
        /// The cardinality test.
        /// </summary>
        [Test]
        public void CardinalityTest()
        {
            alphabet1.Add(new ValueInt(100));
            alphabet1.Add(new ValueInt(200));
            alphabet1.Add(new ValueInt(300));
            Assert.AreEqual(3, alphabet1.Cardinality);
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            alphabet1.Add(new ValueInt(100));
            alphabet1.Add(new ValueInt(200));
            alphabet1.Add(new ValueInt(300));
            alphabet1.Add(new ValueInt(400));
            alphabet1.Remove(2);
            Assert.AreEqual(3, alphabet1.Cardinality);
            Assert.AreEqual(new ValueInt(400), alphabet1[2]);
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            Assert.AreNotSame(alphabet1, alphabet1.Clone());

            Assert.IsTrue(alphabet1.Equals(alphabet1.Clone()));
        }

        /// <summary>
        /// The equals test.
        /// </summary>
        [Test]
        public void EqualsTest()
        {
            alphabet1.Add(new ValueChar('a'));
            alphabet1.Add(new ValueChar('b'));
            alphabet1.Add(new ValueChar('c'));
            alphabet2.Add(new ValueChar('a'));
            alphabet2.Add(new ValueChar('b'));
            alphabet2.Add(new ValueChar('c'));
            Assert.IsTrue(alphabet1.Equals(alphabet1.Clone()));
            Assert.IsTrue(alphabet1.Equals(alphabet2));
        }

        /// <summary>
        /// The equals for alphabet with equals composition but not equals order test.
        /// </summary>
        [Test]
        public void EqualsForAlphabetWithEqualsCompositionButNotEqualsOrderTest()
        {
            alphabet1.Add(new ValueChar('a'));
            alphabet1.Add(new ValueChar('b'));
            alphabet1.Add(new ValueChar('c'));
            alphabet2.Add(new ValueChar('a'));
            alphabet2.Add(new ValueChar('b'));
            alphabet2.Add(new ValueChar('c'));
            Assert.IsTrue(alphabet1.Equals(alphabet1.Clone()));
            Assert.IsTrue(alphabet1.Equals(alphabet2));
        }

        /// <summary>
        /// The contains test.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            alphabet1.Add(new ValueChar('a'));
            alphabet1.Add(new ValueChar('b'));
            alphabet1.Add(new ValueChar('c'));
            Assert.IsTrue(alphabet1.Contains(new ValueChar('a')));
            Assert.IsTrue(alphabet1.Contains(new ValueChar('b')));
            Assert.IsTrue(alphabet1.Contains(new ValueChar('c')));
            Assert.IsFalse(alphabet1.Contains(new ValueChar('d')));
        }

        /// <summary>
        /// The index of test.
        /// </summary>
        [Test]
        public void IndexOfTest()
        {
            alphabet1.Add(new ValueChar('a'));
            alphabet1.Add(new ValueChar('b'));
            alphabet1.Add(new ValueChar('c'));
            Assert.IsTrue(alphabet1.IndexOf(new ValueChar('d')).Equals(-1));
            Assert.IsTrue(alphabet1.IndexOf(new ValueChar('a')).Equals(0));
            Assert.IsTrue(alphabet1.IndexOf(new ValueChar('c')).Equals(2));
        }

        /// <summary>
        /// Тест проверки ненарушения целостности при возвращении значения
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            var a = new ValueChar('a');
            var c = new ValueChar('c');
            var e = new ValueChar('e');

            alphabet1.Add(a);
            alphabet1.Add(new ValueChar('b'));
            alphabet1.Add(c);
            alphabet1.Add(new ValueChar('d'));
            alphabet1.Add(e);

            Assert.AreNotSame(e, alphabet1[4]);
            Assert.AreNotSame(c, alphabet1[2]);
            Assert.AreNotSame(a, alphabet1[0]);
        }

        /// <summary>
        /// Тест проверки ненарушения целостности при возвращении значения
        /// </summary>
        [Test]
        public void ToListTest()
        {
            var a = new ValueChar('a');
            var b = new ValueChar('b');
            var c = new ValueChar('c');
            var d = new ValueChar('d');
            var e = new ValueChar('e');
            alphabet1.Add(a);
            alphabet1.Add(b);
            alphabet1.Add(c);
            alphabet1.Add(d);
            alphabet1.Add(e);

            Assert.AreNotSame(e, alphabet1[4]);
            Assert.AreNotSame(c, alphabet1[2]);
            Assert.AreNotSame(a, alphabet1[0]);
        }
    }
}