using System;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis
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
        public void init()
        {
            ChainBase = new BaseChain(10);
        }

        ///<summary>
        /// ��������� ����������� � ������� ������
        ///</summary>
        public void TestConstructor()
        {
            Chain Chain = new Chain(100);
            Assert.AreEqual(1, Chain.GetPlacePattern().Count);
            Assert.AreEqual(100 - 1, ((Dimension) Chain.GetPlacePattern().Dimension[0]).max);
        }

        ///<summary>
        /// ��������� ������� �������� ���� 0 ������
        ///</summary>
        [Test]
        public void TestConstructorCreateZero()
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
            Place pl = ChainBase.GetPlacePattern();
            ChainBase.AddItem(new ValueChar('1'), pl.SetValues(new long[] {0}));
            Assert.AreEqual(((ValueChar) ChainBase[0]).value, '1');
        }

        ///<summary>
        /// ��������� [] ��������� ��������
        ///</summary>
        [Test]
        public void TestSetByThis()
        {
            Place pl = ChainBase.GetPlacePattern();
            ChainBase[0] = new ValueChar('1');
            Assert.AreEqual(((ValueChar) ChainBase.GetItem(pl.SetValues(new long[] {0}))).value, '1');
        }


        ///<summary>
        /// ��������� ���������
        ///</summary>
        [Test]
        public void TestGet()
        {
            Place pl = ChainBase.GetPlacePattern();
            ChainBase.AddItem(new ValueChar('1'), pl.SetValues(new long[] {0}));
            Assert.AreEqual(((ValueChar) ChainBase.Get(0)).value, '1');
        }

        ///<summary>
        /// ��������� ����������
        ///</summary>
        [Test]
        public void TestSet()
        {
            Place pl = ChainBase.GetPlacePattern();
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase.GetItem(pl.SetValues(new long[] {0}))).value, '1');
        }

        ///<summary>
        /// ��������� ������� ��������
        ///</summary>
        public void TestRemove()
        {
            ChainBase.Add(new ValueChar('1'), 0);
            Assert.AreEqual(((ValueChar) ChainBase[0]).value, '1');

            ChainBase.RemoveAt(0);
            Assert.AreEqual(ChainBase[0], PsevdoValue.Instance());
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
        public void TestEqualsPsevdo()
        {
            Chain Empty = new Chain(10);
            Assert.AreEqual(Empty, PsevdoValue.Instance());

            Empty.Add(Empty.Clone(), 2);
            Assert.AreEqual(Empty, PsevdoValue.Instance());

            Empty.Add(new ValueChar('1'), 5);
            Assert.AreNotEqual(Empty, PsevdoValue.Instance());
        }
    }
}