using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
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
        public void ConstructorTest()
        {
            Chain chain = new Chain(100);
            Assert.AreEqual(100, chain.Length);
        }

        ///<summary>
        /// ��������� ������� �������� ���� 0 ������
        ///</summary>
        [Test]
        [Ignore]
        public void ConstructorCreateZeroTest()
        {
            try
            {
                new Chain(0);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
            
        }

        ///<summary>
        /// ��������� ������� �������� ���� ������������� ������
        ///</summary>
        [Test]
        public void ConstructorLessZeroTest()
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
        public void GetbyThisTest()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase[0]).value, '1');
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
            Assert.AreEqual(((ValueChar) ChainBase.Get(0)).value, '1');
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
        public void RemoveTest()
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

            BaseChain ItsClone = (BaseChain) ChainBase.Clone();
            Assert.AreEqual(ChainBase, ItsClone);
        }
/*

        ///<summary>
        /// ��������� ���������� ������������ � �������������� ����
        ///</summary>
        [Test]
        public void TestSerializeDeserialize()
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


            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, ChainBase);

            MS.Position = 0;
            SF = new SoapFormatter();
            BaseChain Des_Event = (BaseChain) SF.Deserialize(MS);
            Assert.AreEqual(ChainBase, Des_Event);
        }
*/

        ///<summary>
        ///</summary>
        public void EqualsPsevdoTest()
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