using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// ��������� ��������� ���������
    ///</summary>
    [TestFixture]
    public class ValuePhantomTest
    {
        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
        }

        ///<summary>
        /// ��������� ��������� ���������������
        ///</summary>
        [Test]
        public void EqualsTest()
        {
            ValuePhantom M1 = new ValuePhantom();
            ValuePhantom M2 = new ValuePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));

            M2.Add(new ValueChar('3'));

            // Assert.AreEqual(M1, M2);

            Assert.AreEqual(M1, new ValueChar('3'));
        }

        ///<summary>
        /// ��������� ��,�������� ���������� ����������
        ///</summary>
        [Test]
        public void AddMessagePhantomTest()
        {
            ValuePhantom M1 = new ValuePhantom();
            ValuePhantom M2 = new ValuePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));

            M2.Add(new ValueChar('4'));
            M2.Add(new ValueChar('2'));
            M2.Add(new ValueChar('5'));

            M1.Add(M2);

            Assert.AreEqual(M1, new ValueChar('1'));
            Assert.AreEqual(M1, new ValueChar('2'));
            Assert.AreEqual(M1, new ValueChar('3'));
            Assert.AreEqual(M1, new ValueChar('4'));
            Assert.AreEqual(M1, new ValueChar('5'));
        }

        ///<summary>
        /// ���������  ������������ 
        ///</summary>
        [Test]
        public void CloneTest()
        {
            ValuePhantom M1 = new ValuePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));

            ValuePhantom ItsClone = (ValuePhantom)M1.Clone();
            Assert.AreEqual(M1, ItsClone);
        }

        /*      ///<summary>
        /// ��������� ���������� ������������ � ��������������
        ///</summary>
        [Test]
        public void TestSerializeDeserialize()
        {
            ValuePhantom M1 = new ValuePhantom();
            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));

            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, M1);

            MS.Position = 0;
            SF = new SoapFormatter();
            ValuePhantom Des_Event = (ValuePhantom) SF.Deserialize(MS);
            Assert.AreEqual(M1, Des_Event);
        }*/

        ///<summary>
        ///</summary>
        public void EqualsPsevdoTest()
        {
            ValuePhantom M1 = new ValuePhantom();
            Assert.AreEqual(M1, NullValue.Instance());

            M1 = new ValuePhantom();
            M1.Add(new Chain(10));
            Assert.AreEqual(M1, NullValue.Instance());

            M1.Add(new ValueChar('1'));
            Assert.AreNotEqual(M1, NullValue.Instance());
        }
    }
}