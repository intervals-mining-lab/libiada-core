namespace LibiadaCoreTest.Classes.Root
{
    using System;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    [TestFixture]
    public class AlphabetTest
    {
        private Alphabet AlBase;

        private Alphabet AlBase2;

        [SetUp]
        public void Init()
        {
            this.AlBase = new Alphabet();
            this.AlBase2 = new Alphabet();
        }

        [Test]
        public void ConstructorTest()
        {
            var alphabet = new Alphabet();
            Assert.IsNotNull(alphabet);
        }

        [Test]
        public void AddSameTest()
        {
            try
            {
                this.AlBase.Add(new ValueInt(2));
                this.AlBase.Add(new ValueInt(2));
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void GetTest()
        {
            this.AlBase.Add(new ValueInt(2));
            this.AlBase.Add(new ValueInt(3));
            this.AlBase.Add(new ValueInt(4));
            this.AlBase.Add(new ValueInt(5));
            Assert.AreEqual(new ValueInt(2), this.AlBase[0]);
            Assert.AreEqual(new ValueInt(3), this.AlBase[1]);
            Assert.AreEqual(new ValueInt(4), this.AlBase[2]);
            Assert.AreEqual(new ValueInt(5), this.AlBase[3]);
        }

        [Test]
        public void IndependNumberTest()
        {
            this.AlBase.Add(new ValueInt(2));
            this.AlBase.Add(new ValueInt(1));
            this.AlBase.Add(new ValueInt(3));
            this.AlBase.Add(new ValueInt(4));
            this.AlBase[0] = new ValueInt(3);
            Assert.AreEqual(new ValueInt(2), this.AlBase[0]);
            Assert.AreEqual(new ValueInt(1), this.AlBase[1]);
            Assert.AreEqual(new ValueInt(3), this.AlBase[2]);
            Assert.AreEqual(new ValueInt(4), this.AlBase[3]);
        }

        [Test]
        public void IndependentStringTest()
        {
            this.AlBase.Add(new ValueString("2"));
            this.AlBase.Add(new ValueString("3"));
            this.AlBase.Add(new ValueString("5"));
            this.AlBase.Add(new ValueString("1"));
            //AlBase.Add("1");
            this.AlBase[0] = new ValueString("3");
            Assert.AreEqual(new ValueString("2"), this.AlBase[0]);
            Assert.AreEqual(new ValueString("3"), this.AlBase[1]);
            Assert.AreEqual(new ValueString("5"), this.AlBase[2]);
            Assert.AreEqual(new ValueString("1"), this.AlBase[3]);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullTest()
        {
            this.AlBase.Add(null);
        }

        [Test]
        public void CardinalityTest()
        {
            this.AlBase.Add(new ValueInt(100));
            this.AlBase.Add(new ValueInt(200));
            this.AlBase.Add(new ValueInt(300));
            Assert.AreEqual(3, this.AlBase.Cardinality);
        }

        [Test]
        public void RemoveTest()
        {
            this.AlBase.Add(new ValueInt(100));
            this.AlBase.Add(new ValueInt(200));
            this.AlBase.Add(new ValueInt(300));
            this.AlBase.Add(new ValueInt(400));
            this.AlBase.Remove(2);
            Assert.AreEqual(3, this.AlBase.Cardinality);
            Assert.AreEqual(new ValueInt(400), this.AlBase[2]);
        }

        [Test]
        public void CloneTest()
        {
            Assert.AreNotSame(this.AlBase, this.AlBase.Clone());

            Assert.IsTrue(this.AlBase.Equals(this.AlBase.Clone()));
        }

        [Test]
        public void EqualsTest()
        {
            this.AlBase.Add(new ValueChar('a'));
            this.AlBase.Add(new ValueChar('b'));
            this.AlBase.Add(new ValueChar('c'));
            this.AlBase2.Add(new ValueChar('a'));
            this.AlBase2.Add(new ValueChar('b'));
            this.AlBase2.Add(new ValueChar('c'));
            Assert.IsTrue(this.AlBase.Equals(this.AlBase.Clone()));
            Assert.IsTrue(this.AlBase.Equals(this.AlBase2));
        }

        [Test]
        public void EqualsForAlphabetWithEqualsCompositionButNotEqualsOrderTest()
        {
            this.AlBase.Add(new ValueChar('a'));
            this.AlBase.Add(new ValueChar('b'));
            this.AlBase.Add(new ValueChar('c'));
            this.AlBase2.Add(new ValueChar('a'));
            this.AlBase2.Add(new ValueChar('b'));
            this.AlBase2.Add(new ValueChar('c'));
            Assert.IsTrue(this.AlBase.Equals(this.AlBase.Clone()));
            Assert.IsTrue(this.AlBase.Equals(this.AlBase2));
        }

        [Test]
        public void ContainsTest()
        {
            this.AlBase.Add(new ValueChar('a'));
            this.AlBase.Add(new ValueChar('b'));
            this.AlBase.Add(new ValueChar('c'));
            Assert.IsTrue(this.AlBase.Contains(new ValueChar('a')));
            Assert.IsTrue(this.AlBase.Contains(new ValueChar('b')));
            Assert.IsTrue(this.AlBase.Contains(new ValueChar('c')));
            Assert.IsFalse(this.AlBase.Contains(new ValueChar('d')));
        }

        [Test]
        public void IndexOfTest()
        {
            this.AlBase.Add(new ValueChar('a'));
            this.AlBase.Add(new ValueChar('b'));
            this.AlBase.Add(new ValueChar('c'));
            Assert.IsTrue(this.AlBase.IndexOf(new ValueChar('d')).Equals(-1));
            Assert.IsTrue(this.AlBase.IndexOf(new ValueChar('a')).Equals(0));
            Assert.IsTrue(this.AlBase.IndexOf(new ValueChar('c')).Equals(2));
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

            this.AlBase.Add(a);
            this.AlBase.Add(new ValueChar('b'));
            this.AlBase.Add(c);
            this.AlBase.Add(new ValueChar('d'));
            this.AlBase.Add(e);

            Assert.AreNotSame(e, this.AlBase[4]);
            Assert.AreNotSame(c, this.AlBase[2]);
            Assert.AreNotSame(a, this.AlBase[0]);
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
            this.AlBase.Add(a);
            this.AlBase.Add(b);
            this.AlBase.Add(c);
            this.AlBase.Add(d);
            this.AlBase.Add(e);

            Assert.AreNotSame(e, this.AlBase[4]);
            Assert.AreNotSame(c, this.AlBase[2]);
            Assert.AreNotSame(a, this.AlBase[0]);
        }
    }
}