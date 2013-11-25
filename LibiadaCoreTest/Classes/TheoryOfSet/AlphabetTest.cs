using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibiadaCoreTest.Classes.TheoryOfSet
{
    [TestFixture]
    public class AlphabetTest
    {
        private Alphabet AlBase;
        private Alphabet AlBase2;

        [SetUp]
        public void Init()
        {
            AlBase = new Alphabet();
            AlBase2 = new Alphabet();
        }

        [Test]
        public void ConstrutorTest()
        {
            Alphabet a1 = new Alphabet();
            Assert.IsNotNull(a1);
        }

        [Test]
        public void AddSameTest()
        {
            try
            {
                AlBase.Add(new ValueInt(2));
                AlBase.Add(new ValueInt(2));
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
            AlBase.Add(new ValueInt(2));
            AlBase.Add(new ValueInt(3));
            AlBase.Add(new ValueInt(4));
            AlBase.Add(new ValueInt(5));
            Assert.AreEqual(new ValueInt(2), AlBase[0]);
            Assert.AreEqual(new ValueInt(3), AlBase[1]);
            Assert.AreEqual(new ValueInt(4), AlBase[2]);
            Assert.AreEqual(new ValueInt(5), AlBase[3]);
        }

        [Test]
        public void IndependNumberTest()
        {
            AlBase.Add(new ValueInt(2));
            AlBase.Add(new ValueInt(1));
            AlBase.Add(new ValueInt(3));
            AlBase.Add(new ValueInt(4));
            AlBase[0] = new ValueInt(3);
            Assert.AreEqual(new ValueInt(2), AlBase[0]);
            Assert.AreEqual(new ValueInt(1), AlBase[1]);
            Assert.AreEqual(new ValueInt(3), AlBase[2]);
            Assert.AreEqual(new ValueInt(4), AlBase[3]);
        }

        [Test]
        public void IndependStringTest()
        {
            AlBase.Add(new ValueString("2"));
            AlBase.Add(new ValueString("3"));
            AlBase.Add(new ValueString("5"));
            AlBase.Add(new ValueString("1"));
            //AlBase.Add("1");
            AlBase[0] = new ValueString("3");
            Assert.AreEqual(new ValueString("2"), AlBase[0]);
            Assert.AreEqual(new ValueString("3"), AlBase[1]);
            Assert.AreEqual(new ValueString("5"), AlBase[2]);
            Assert.AreEqual(new ValueString("1"), AlBase[3]);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullTest()
        {
            AlBase.Add(null);
        }

        [Test]
        public void PowerTest()
        {
            AlBase.Add(new ValueInt(100));
            AlBase.Add(new ValueInt(200));
            AlBase.Add(new ValueInt(300));
            Assert.AreEqual(3, AlBase.Power);
        }

        [Test]
        public void RemoveTest()
        {
            AlBase.Add(new ValueInt(100));
            AlBase.Add(new ValueInt(200));
            AlBase.Add(new ValueInt(300));
            AlBase.Add(new ValueInt(400));
            AlBase.Remove(2);
            Assert.AreEqual(3, AlBase.Power);
            Assert.AreEqual(new ValueInt(400), AlBase[2]);
        }

        [Test]
        public void CloneTest()
        {
            Assert.AreNotSame(AlBase, AlBase.Clone());

            Assert.IsTrue(AlBase.Equals(AlBase.Clone()));
        }

        [Test]
        public void EqualsTest()
        {
            AlBase.Add(new ValueChar('a'));
            AlBase.Add(new ValueChar('b'));
            AlBase.Add(new ValueChar('c'));
            AlBase2.Add(new ValueChar('a'));
            AlBase2.Add(new ValueChar('b'));
            AlBase2.Add(new ValueChar('c'));
            Assert.IsTrue(AlBase.Equals(AlBase.Clone()));
            Assert.IsTrue(AlBase.Equals(AlBase2));
        }

        [Test]
        public void EqualsForAlphabetWithEqualsCompositionButNotEqualsOrderTest()
        {
            AlBase.Add(new ValueChar('a'));
            AlBase.Add(new ValueChar('b'));
            AlBase.Add(new ValueChar('c'));
            AlBase2.Add(new ValueChar('a'));
            AlBase2.Add(new ValueChar('b'));
            AlBase2.Add(new ValueChar('c'));
            Assert.IsTrue(AlBase.Equals(AlBase.Clone()));
            Assert.IsTrue(AlBase.Equals(AlBase2));
        }

        [Test]
        public void ContainsTest()
        {
            AlBase.Add(new ValueChar('a'));
            AlBase.Add(new ValueChar('b'));
            AlBase.Add(new ValueChar('c'));
            Assert.IsTrue(AlBase.Contains(new ValueChar('a')));
            Assert.IsTrue(AlBase.Contains(new ValueChar('b')));
            Assert.IsTrue(AlBase.Contains(new ValueChar('c')));
            Assert.IsFalse(AlBase.Contains(new ValueChar('d')));
        }

        [Test]
        public void IndexOfTest()
        {
            AlBase.Add(new ValueChar('a'));
            AlBase.Add(new ValueChar('b'));
            AlBase.Add(new ValueChar('c'));
            Assert.IsTrue(AlBase.IndexOf(new ValueChar('d')).Equals(-1));
            Assert.IsTrue(AlBase.IndexOf(new ValueChar('a')).Equals(0));
            Assert.IsTrue(AlBase.IndexOf(new ValueChar('c')).Equals(2));
        }

        /// <summary>
        /// Тест проверки ненарушения целостности при возвращении значения
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            AlBase.Add(new ValueChar('a'));
            AlBase.Add(new ValueChar('b'));
            AlBase.Add(new ValueChar('c'));
            AlBase.Add(new ValueChar('d'));
            AlBase.Add(new ValueChar('e'));
            IBaseObject[] testArray = AlBase.ToArray();
            ((ValueChar) testArray[4]).Value = 'x';
            ((ValueChar)testArray[2]).Value = 'y';
            ((ValueChar)testArray[0]).Value = 'z';
            Assert.AreEqual(new ValueChar('e'), AlBase[4]);
            Assert.AreEqual(new ValueChar('c'), AlBase[2]);
            Assert.AreEqual(new ValueChar('a'), AlBase[0]);
        }

        /// <summary>
        /// Тест проверки ненарушения целостности при возвращении значения
        /// </summary>
        [Test]
        public void ToListTest()
        {
            AlBase.Add(new ValueChar('a'));
            AlBase.Add(new ValueChar('b'));
            AlBase.Add(new ValueChar('c'));
            AlBase.Add(new ValueChar('d'));
            AlBase.Add(new ValueChar('e'));

            List<IBaseObject> testList = AlBase.ToList();

            ((ValueChar)testList[4]).Value = new ValueChar('x');
            ((ValueChar)testList[2]).Value = new ValueChar('y');
            ((ValueChar)testList[0]).Value = new ValueChar('z');
            Assert.AreEqual(new ValueChar('e'), AlBase[4]);
            Assert.AreEqual(new ValueChar('c'), AlBase[2]);
            Assert.AreEqual(new ValueChar('a'), AlBase[0]);
        }
    }
}