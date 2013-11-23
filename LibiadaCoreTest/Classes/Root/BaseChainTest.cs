using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root
{
    //TODO: FIX ORDER OF ARGUMENTS IN ALL AreEqual
    [TestFixture]
    public class BaseChainTest
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
        public void ConstructorTest()
        {
            Chain chain = new Chain(100);
            Assert.AreEqual(100, chain.Length);
        }

        ///<summary>
        /// ��������� ������� �������� ���� ������������� ������
        ///</summary>
        [Test]
        public void ConstructorLessZeroTest()
        {
            try
            {
                new BaseChain(-10);
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
        public void GetbyThisTest()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase[0]).Value, '1');
        }

        ///<summary>
        /// ��������� [] ��������� ��������
        ///</summary>
        [Test]
        public void SetByThisTest()
        {
            ChainBase[0] = new ValueChar('1');
            Assert.AreEqual((ValueChar)ChainBase.GetItem(0), '1');
        }


        ///<summary>
        /// ��������� ���������
        ///</summary>
        [Test]
        public void GetTest()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase.Get(0)).Value, '1');
        }

        ///<summary>
        /// ��������� ����������
        ///</summary>
        [Test]
        public void SetTest()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual((ValueChar) ChainBase.GetItem(0), '1');
        }

        ///<summary>
        /// ��������� ������� ��������
        ///</summary>
        [Test]
        public void RemoveTest()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase[0]).Value, '1');

            ChainBase.RemoveAt(0);
            Assert.AreEqual(ChainBase[0], NullValue.Instance());
        }

        ///<summary>
        /// ��������� ��������� ������ ����
        ///</summary>
        [Test]
        public void GetLengthTest()
        {
            Assert.AreEqual(10, ChainBase.Length);
        }


        ///<summary>
        /// ���������  ������������ 
        ///</summary>
        [Test]
        public void CloneTest()
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

            BaseChain itsClone = (BaseChain) ChainBase.Clone();
            Assert.AreEqual(ChainBase, itsClone);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void EqualsPsevdoTest()
        {
            Chain empty = new Chain(10);
            Assert.AreEqual(empty, NullValue.Instance());

            empty.Add(empty.Clone(), 2);
            Assert.AreEqual(empty, NullValue.Instance());

            empty.Add(new ValueChar('1'), 5);
            Assert.AreNotEqual(empty, NullValue.Instance());
        }
    }
}