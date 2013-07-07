using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    ///<summary>
    /// ��������� ��������� ���������
    ///</summary>
    [TestFixture]
    public class ValuePhantomTest
    {

        ///<summary>
        /// ��������� ��������� ���������������
        ///</summary>
        [Test]
        public void EqualsTest()
        {
            ValuePhantom m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3')};

            Assert.AreEqual(m1, new ValueChar('3'));
        }

        ///<summary>
        /// ��������� ��,�������� ���������� ����������
        ///</summary>
        [Test]
        public void AddMessagePhantomTest()
        {
            ValuePhantom m2 = new ValuePhantom { new ValueChar('4'), new ValueChar('2'), new ValueChar('5') };
            ValuePhantom m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3'), m2};

            Assert.AreEqual(m1, new ValueChar('1'));
            Assert.AreEqual(m1, new ValueChar('2'));
            Assert.AreEqual(m1, new ValueChar('3'));
            Assert.AreEqual(m1, new ValueChar('4'));
            Assert.AreEqual(m1, new ValueChar('5'));
        }

        ///<summary>
        /// ���������  ������������ 
        ///</summary>
        [Test]
        public void CloneTest()
        {
            ValuePhantom m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3')};

            ValuePhantom itsClone = (ValuePhantom)m1.Clone();
            Assert.AreEqual(m1, itsClone);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void EqualsPsevdoTest()
        {
            ValuePhantom m1 = new ValuePhantom();
            Assert.AreEqual(m1, NullValue.Instance());

            m1 = new ValuePhantom {new Chain(10)};
            Assert.AreEqual(m1, NullValue.Instance());

            m1.Add(new ValueChar('1'));
            Assert.AreNotEqual(m1, NullValue.Instance());
        }
    }
}