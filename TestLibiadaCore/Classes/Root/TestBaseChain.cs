using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestBaseChain
    {
        private BaseChain ChainBase;

        ///<summary>
        /// ��������������� �����
        ///</summary>
        [SetUp]
        public void Init()
        {
            ChainBase = new BaseChain(10);
        }

        ///<summary>
        /// ��������� ����������� � ������� ������
        ///</summary>
        [Test]
        public void TestConstructor()
        {
            Chain chain = new Chain(100);
            Assert.AreEqual(100, chain.Length);
        }

        ///<summary>
        /// ��������� ������� �������� ���� ������������� ������
        ///</summary>
        [Test]
        public void TestConstructorLessZero()
        {
            try
            {
                new Chain(-10);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� [] ��������� ��������
        ///</summary>
        [Test]
        public void TestGetbyThis()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase[0]).value, '1');
        }

        ///<summary>
        /// ��������� [] ��������� ��������
        ///</summary>
        [Test]
        public void TestSetByThis()
        {
            ChainBase[0] = new ValueChar('1');
            Assert.AreEqual((ValueChar)ChainBase.GetItem(0), '1');
        }


        ///<summary>
        /// ��������� ���������
        ///</summary>
        [Test]
        public void TestGet()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase.Get(0)).value, '1');
        }

        ///<summary>
        /// ��������� ����������
        ///</summary>
        [Test]
        public void TestSet()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar) ChainBase.GetItem(0), '1');
        }

        ///<summary>
        /// ��������� ������� ��������
        ///</summary>
        [Test]
        public void TestRemove()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase[0]).value, '1');

            ChainBase.RemoveAt(0);
            Assert.AreEqual(ChainBase[0], NullValue.Instance());
        }

        ///<summary>
        /// ��������� ��������� ������ ����
        ///</summary>
        [Test]
        public void TestGetLength()
        {
            Assert.AreEqual(10, ChainBase.Length);
        }


        ///<summary>
        /// ���������  ������������ 
        ///</summary>
        [Test]
        public void TestClone()
        {
            ChainBase[0] = new ValueChar('1');
            ChainBase[1] = new ValueChar('2');
            ChainBase[2] = new ValueChar('3');
            ChainBase[3] = new ValueChar('4');
            ChainBase[4] = new ValueChar('5');
            ChainBase[5] = new ValueChar('6');
            ChainBase[6] = new ValueChar('7');
            ChainBase[7] = new ValueChar('8');
            ChainBase[8] = new ValueChar('9');
            ChainBase[9] = new ValueChar('A');

            BaseChain ItsClone = (BaseChain) ChainBase.Clone();
            Assert.AreEqual(ChainBase, ItsClone);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestEqualsPsevdo()
        {
            Chain Empty = new Chain(10);
            Assert.AreEqual(Empty, NullValue.Instance());

            Empty.Add(Empty.Clone(), 2);
            Assert.AreEqual(Empty, NullValue.Instance());

            Empty.Add(new ValueChar('1'), 5);
            Assert.AreNotEqual(Empty, NullValue.Instance());
        }
    }
}