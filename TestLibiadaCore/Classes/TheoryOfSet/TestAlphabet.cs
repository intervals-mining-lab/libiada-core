using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.TheoryOfSet
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestAlphabet
    {
        private Alphabet AlBase = null;
        private Alphabet AlBase2 = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            AlBase = new Alphabet();
            AlBase2 = new Alphabet();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestConstrutor()
        {
            Alphabet A1 = new Alphabet();
            Assert.IsNotNull(A1);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestAddSame()
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

        ///<summary>
        ///</summary>
        [Test]
        public void TestGet()
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

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndependNumber()
        {
            AlBase.Add(new ValueInt(2));
            AlBase.Add(new ValueInt(1));
            AlBase.Add(new ValueInt(3));
            AlBase.Add(new ValueInt(4));
            //AlBase.Add(1);
            AlBase[0] = new ValueInt(3);
            Assert.AreEqual(new ValueInt(2), AlBase[0]);
            Assert.AreEqual(new ValueInt(1), AlBase[1]);
            Assert.AreEqual(new ValueInt(3), AlBase[2]);
            Assert.AreEqual(new ValueInt(4), AlBase[3]);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndependString()
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

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndependPlace()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {1, 1});
            AlBase.Add(P1);
            AlBase.Add(P2);

            ((Place) AlBase[0]).SetValues(new long[] {1, 1});
            Assert.IsFalse(((Place) AlBase[0]).EqualsAsPlace((Place) AlBase[1]));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndependPlace1()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {1, 1});
            AlBase.Add(P1);
            AlBase.Add(P2);
            P2.SetValues(new long[] {0, 1});
            Assert.IsFalse(((Place) AlBase[0]).EqualsAsPlace((Place) (AlBase[1])));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndependPlace2()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {1, 1});
            AlBase.Add(P1);
            AlBase.Add(P2);
            //P2.SetValues(new long[] { 0, 1 });
            Place P3 = ((Place) AlBase[0]);
            P3.SetValues(new long[] {2, 2});
            Assert.IsFalse(((Place) AlBase[0]).EqualsAsPlace((Place) (AlBase[1])));
        }

        ///<summary>
        ///</summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNull()
        {
            AlBase.Add(null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestPower()
        {
            AlBase.Add(new ValueInt(100));
            AlBase.Add(new ValueInt(200));
            AlBase.Add(new ValueInt(300));
            Assert.AreEqual(AlBase.power, 3);
        }

        /// <summary>
        /// �������� ��������
        /// </summary>
        [Test]
        public void TestRemove()
        {
            AlBase.Add(new ValueInt(100));
            AlBase.Add(new ValueInt(200));
            AlBase.Add(new ValueInt(300));
            AlBase.Add(new ValueInt(400));
            AlBase.Remove(2);
            Assert.AreEqual(AlBase.power, 3);
            Assert.AreEqual(AlBase[2], new ValueInt(400));
        }

        ///<summary>
        ///</summary>
        public void TestClone()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 20));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {2, 2});
            Place P3 = new Place(ar);
            P3.SetValues(new long[] {1, 0});
            AlBase.Add(P1);
            AlBase.Add(P2);
            AlBase.Add(P3);
            AlBase.Clone();
            Assert.AreNotSame(AlBase, AlBase.Clone());

            //Assert.IsTrue(AlBase.Equals(AlBase.Clone()));
        }

        /// <summary>
        /// ����������� ��������� ���������
        /// </summary>
        [Test]
        public void TestEquals()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 20));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {2, 2});
            Place P3 = new Place(ar);
            P3.SetValues(new long[] {1, 0});
            AlBase.Add(P1);
            AlBase.Add(P2);
            AlBase.Add(P3);
            //AlBase.Clone();

            AlBase2.Add(P1);
            AlBase2.Add(P2);
            AlBase2.Add(P3);
            Assert.IsTrue(AlBase.Equals(AlBase.Clone()));
            Assert.IsTrue(AlBase.Equals(AlBase2));
        }

        /// <summary>
        /// ����������� ��������� ���������
        /// </summary>
        [Test]
        public void TestEqualsForAlphabetWithEqualsCompositionButNotEqualsOrder()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 20));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {2, 2});
            Place P3 = new Place(ar);
            P3.SetValues(new long[] {1, 0});
            AlBase.Add(P1);
            AlBase.Add(P2);
            AlBase.Add(P3);

            AlBase2.Add(P1);
            AlBase2.Add(P3);
            AlBase2.Add(P2);
            Assert.IsTrue(AlBase.Equals(AlBase.Clone()));
            Assert.IsTrue(AlBase.Equals(AlBase2));
        }

        /// <summary>
        /// ���� �� 
        /// </summary>
        [Test]
        public void TestContains()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 20));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {2, 2});
            Place P3 = new Place(ar);
            P3.SetValues(new long[] {1, 0});
            AlBase.Add(P1);
            AlBase.Add(P2);
            AlBase.Add(P3);
            Assert.IsTrue(AlBase.Contains(P2) & AlBase.Contains(P2) & AlBase.Contains(P2));
        }

        /// <summary>
        /// ���� ��
        /// </summary>
        [Test]
        public void TestGetEnumerableInWorkMode()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 20));

            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});

            Place P2 = new Place(ar);
            P2.SetValues(new long[] {2, 2});

            Place P3 = new Place(ar);
            P3.SetValues(new long[] {1, 0});

            AlBase.Add(P1);
            AlBase.Add(P2);
            AlBase.Add(P3);

            IEnumerator IE = AlBase.GetEnumerator();

            IE.MoveNext();
            Assert.IsTrue((IE.Current).Equals(P1));

            IE.MoveNext();
            Assert.IsTrue((IE.Current).Equals(P2));

            IE.MoveNext();
            Assert.IsTrue((IE.Current).Equals(P3));

            Assert.IsFalse(IE.MoveNext());
        }


        /// <summary>
        /// ���� ��
        /// </summary>
        [Test]
        public void TestGetEnumerableAfterChageMOde()
        {
            try
            {
                ArrayList ar = new ArrayList(2);
                ar.Add(new Dimension(0, 10));
                ar.Add(new Dimension(0, 20));

                Place P1 = new Place(ar);
                P1.SetValues(new long[] { 0, 1 });

                Place P2 = new Place(ar);
                P2.SetValues(new long[] { 2, 2 });

                Place P3 = new Place(ar);
                P3.SetValues(new long[] { 1, 0 });

                AlBase.Add(P1);
                AlBase.Add(P2);
                AlBase.Add(P3);

                IEnumerator IE = AlBase.GetEnumerator();
                IE.MoveNext();
                Assert.IsTrue((IE.Current).Equals(P1));

                AlBase.Remove(1);

                IE.MoveNext();
                Assert.IsTrue((IE.Current).Equals(P2));

                IE.MoveNext();
                Assert.IsTrue((IE.Current).Equals(P3));

                Assert.IsFalse(IE.MoveNext());
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

/*

        ///<summary>
        ///</summary>
        [Test]
        public void TestSerializeDeserialize()
        {
            AlBase.Add(new ValueInt(0));
            AlBase.Add(new ValueInt(1));
            AlBase.Add(new ValueInt(2));
            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, AlBase);
            MS.Position = 0;
            SF = new SoapFormatter();
            Alphabet Des_Alphabet = (Alphabet) SF.Deserialize(MS);
            Assert.AreEqual(AlBase, Des_Alphabet);
        }
*/

        ///<summary>
        ///</summary>
        [Test]
        public void TestIndexOf()
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 20));
            Place P1 = new Place(ar);
            P1.SetValues(new long[] {0, 1});
            Place P2 = new Place(ar);
            P2.SetValues(new long[] {2, 2});
            Place P3 = new Place(ar);
            P3.SetValues(new long[] {1, 0});
            AlBase.Add(P1);
            AlBase.Add(P2);
            AlBase.Add(P3);
            Assert.IsFalse(AlBase.IndexOf(P2).Equals(-1));
            Assert.IsTrue(AlBase.IndexOf(P2).Equals(1));
            Assert.IsFalse(AlBase.IndexOf(P3).Equals(3));
        }

        ///<summary>
        ///</summary>
        [Test]
        [Ignore]
        public void TestSerializeDeserializeSimpleXml()
        {
            AlBase.Add(new ValueInt(0));
            AlBase.Add(new ValueInt(1));
            AlBase.Add(new ValueInt(2));
            MemoryStream MS = new MemoryStream();
            XmlSerializer SF = new XmlSerializer(typeof (Alphabet));
            SF.Serialize(MS, AlBase);
            MS.Position = 0;
            MS.Position = 0;
            SF = new XmlSerializer(typeof (Alphabet));
            Alphabet Des_Alphabet = (Alphabet) SF.Deserialize(MS);
            Assert.AreEqual(AlBase, Des_Alphabet);
        }
    }
}