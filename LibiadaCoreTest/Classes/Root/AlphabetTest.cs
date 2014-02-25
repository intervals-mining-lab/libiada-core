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
    public class AlphabetTest
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
            this.alphabet1 = new Alphabet();
            this.alphabet2 = new Alphabet();
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
            this.alphabet1.Add(new ValueInt(2));
            this.alphabet1.Add(new ValueInt(2));
        }

        /// <summary>
        /// The get test.
        /// </summary>
        [Test]
        public void GetTest()
        {
            this.alphabet1.Add(new ValueInt(2));
            this.alphabet1.Add(new ValueInt(3));
            this.alphabet1.Add(new ValueInt(4));
            this.alphabet1.Add(new ValueInt(5));
            Assert.AreEqual(new ValueInt(2), this.alphabet1[0]);
            Assert.AreEqual(new ValueInt(3), this.alphabet1[1]);
            Assert.AreEqual(new ValueInt(4), this.alphabet1[2]);
            Assert.AreEqual(new ValueInt(5), this.alphabet1[3]);
        }

        /// <summary>
        /// The independ number test.
        /// </summary>
        [Test]
        public void IndependNumberTest()
        {
            this.alphabet1.Add(new ValueInt(2));
            this.alphabet1.Add(new ValueInt(1));
            this.alphabet1.Add(new ValueInt(3));
            this.alphabet1.Add(new ValueInt(4));
            this.alphabet1[0] = new ValueInt(3);
            Assert.AreEqual(new ValueInt(2), this.alphabet1[0]);
            Assert.AreEqual(new ValueInt(1), this.alphabet1[1]);
            Assert.AreEqual(new ValueInt(3), this.alphabet1[2]);
            Assert.AreEqual(new ValueInt(4), this.alphabet1[3]);
        }

        /// <summary>
        /// The independent string test.
        /// </summary>
        [Test]
        public void IndependentStringTest()
        {
            this.alphabet1.Add(new ValueString("2"));
            this.alphabet1.Add(new ValueString("3"));
            this.alphabet1.Add(new ValueString("5"));
            this.alphabet1.Add(new ValueString("1"));
            this.alphabet1[0] = new ValueString("3");
            Assert.AreEqual(new ValueString("2"), this.alphabet1[0]);
            Assert.AreEqual(new ValueString("3"), this.alphabet1[1]);
            Assert.AreEqual(new ValueString("5"), this.alphabet1[2]);
            Assert.AreEqual(new ValueString("1"), this.alphabet1[3]);
        }

        /// <summary>
        /// The null test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullTest()
        {
            this.alphabet1.Add(null);
        }

        /// <summary>
        /// The cardinality test.
        /// </summary>
        [Test]
        public void CardinalityTest()
        {
            this.alphabet1.Add(new ValueInt(100));
            this.alphabet1.Add(new ValueInt(200));
            this.alphabet1.Add(new ValueInt(300));
            Assert.AreEqual(3, this.alphabet1.Cardinality);
        }

        /// <summary>
        /// The remove test.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            this.alphabet1.Add(new ValueInt(100));
            this.alphabet1.Add(new ValueInt(200));
            this.alphabet1.Add(new ValueInt(300));
            this.alphabet1.Add(new ValueInt(400));
            this.alphabet1.Remove(2);
            Assert.AreEqual(3, this.alphabet1.Cardinality);
            Assert.AreEqual(new ValueInt(400), this.alphabet1[2]);
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            Assert.AreNotSame(this.alphabet1, this.alphabet1.Clone());

            Assert.IsTrue(this.alphabet1.Equals(this.alphabet1.Clone()));
        }

        /// <summary>
        /// The equals test.
        /// </summary>
        [Test]
        public void EqualsTest()
        {
            this.alphabet1.Add(new ValueChar('a'));
            this.alphabet1.Add(new ValueChar('b'));
            this.alphabet1.Add(new ValueChar('c'));
            this.alphabet2.Add(new ValueChar('a'));
            this.alphabet2.Add(new ValueChar('b'));
            this.alphabet2.Add(new ValueChar('c'));
            Assert.IsTrue(this.alphabet1.Equals(this.alphabet1.Clone()));
            Assert.IsTrue(this.alphabet1.Equals(this.alphabet2));
        }

        /// <summary>
        /// The equals for alphabet with equals composition but not equals order test.
        /// </summary>
        [Test]
        public void EqualsForAlphabetWithEqualsCompositionButNotEqualsOrderTest()
        {
            this.alphabet1.Add(new ValueChar('a'));
            this.alphabet1.Add(new ValueChar('b'));
            this.alphabet1.Add(new ValueChar('c'));
            this.alphabet2.Add(new ValueChar('a'));
            this.alphabet2.Add(new ValueChar('b'));
            this.alphabet2.Add(new ValueChar('c'));
            Assert.IsTrue(this.alphabet1.Equals(this.alphabet1.Clone()));
            Assert.IsTrue(this.alphabet1.Equals(this.alphabet2));
        }

        /// <summary>
        /// The contains test.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            this.alphabet1.Add(new ValueChar('a'));
            this.alphabet1.Add(new ValueChar('b'));
            this.alphabet1.Add(new ValueChar('c'));
            Assert.IsTrue(this.alphabet1.Contains(new ValueChar('a')));
            Assert.IsTrue(this.alphabet1.Contains(new ValueChar('b')));
            Assert.IsTrue(this.alphabet1.Contains(new ValueChar('c')));
            Assert.IsFalse(this.alphabet1.Contains(new ValueChar('d')));
        }

        /// <summary>
        /// The index of test.
        /// </summary>
        [Test]
        public void IndexOfTest()
        {
            this.alphabet1.Add(new ValueChar('a'));
            this.alphabet1.Add(new ValueChar('b'));
            this.alphabet1.Add(new ValueChar('c'));
            Assert.IsTrue(this.alphabet1.IndexOf(new ValueChar('d')).Equals(-1));
            Assert.IsTrue(this.alphabet1.IndexOf(new ValueChar('a')).Equals(0));
            Assert.IsTrue(this.alphabet1.IndexOf(new ValueChar('c')).Equals(2));
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

            this.alphabet1.Add(a);
            this.alphabet1.Add(new ValueChar('b'));
            this.alphabet1.Add(c);
            this.alphabet1.Add(new ValueChar('d'));
            this.alphabet1.Add(e);

            Assert.AreNotSame(e, this.alphabet1[4]);
            Assert.AreNotSame(c, this.alphabet1[2]);
            Assert.AreNotSame(a, this.alphabet1[0]);
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
            this.alphabet1.Add(a);
            this.alphabet1.Add(b);
            this.alphabet1.Add(c);
            this.alphabet1.Add(d);
            this.alphabet1.Add(e);

            Assert.AreNotSame(e, this.alphabet1[4]);
            Assert.AreNotSame(c, this.alphabet1[2]);
            Assert.AreNotSame(a, this.alphabet1[0]);
        }
    }
}