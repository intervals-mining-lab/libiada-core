using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.TheoryOfSet
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class AlphabetTest
    {
        private Alphabet AlBase = null;
        private Alphabet AlBase2 = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            AlBase = new Alphabet();
            AlBase2 = new Alphabet();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void ConstrutorTest()
        {
            Alphabet A1 = new Alphabet();
            Assert.IsNotNull(A1);
        }

        ///<summary>
        ///</summary>
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

        ///<summary>
        ///</summary>
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

        ///<summary>
        ///</summary>
        [Test]
        public void IndependNumberTest()
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

        ///<summary>
        ///</summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullTest()
        {
            AlBase.Add(null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PowerTest()
        {
            AlBase.Add(new ValueInt(100));
            AlBase.Add(new ValueInt(200));
            AlBase.Add(new ValueInt(300));
            Assert.AreEqual(AlBase.Power, 3);
        }

        /// <summary>
        /// �������� ��������
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            AlBase.Add(new ValueInt(100));
            AlBase.Add(new ValueInt(200));
            AlBase.Add(new ValueInt(300));
            AlBase.Add(new ValueInt(400));
            AlBase.Remove(2);
            Assert.AreEqual(AlBase.Power, 3);
            Assert.AreEqual(AlBase[2], new ValueInt(400));
        }

        ///<summary>
        ///</summary>
        public void CloneTest()
        {
            Assert.AreNotSame(AlBase, AlBase.Clone());

            //Assert.IsTrue(AlBase.Equals(AlBase.Clone()));
        }

        /// <summary>
        /// ����������� ��������� ���������
        /// </summary>
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

        /// <summary>
        /// ����������� ��������� ���������
        /// </summary>
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

        /// <summary>
        /// ���� �� 
        /// </summary>
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

        ///<summary>
        ///</summary>
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

        ///<summary>
        ///</summary>
        [Test]
        [Ignore]
        public void SerializeDeserializeSimpleXmlTest()
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