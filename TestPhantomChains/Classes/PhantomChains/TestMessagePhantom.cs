using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;

namespace TestPhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// ��������� ��������� ���������
    ///</summary>
    [TestFixture]
    public class TestMessagePhantom
    {
        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
        }

        ///<summary>
        /// ��������� ��������� ���������������
        ///</summary>
        [Test]
        public void TestEquals()
        {
            MessagePhantom M1 = new MessagePhantom();
            MessagePhantom M2 = new MessagePhantom();

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
        public void TestAddMessagePhantom()
        {
            MessagePhantom M1 = new MessagePhantom();
            MessagePhantom M2 = new MessagePhantom();

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
        public void TestClone()
        {
            MessagePhantom M1 = new MessagePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));

            MessagePhantom ItsClone = (MessagePhantom) M1.Clone();
            Assert.AreEqual(M1, ItsClone);
        }

        /*      ///<summary>
        /// ��������� ���������� ������������ � ��������������
        ///</summary>
        [Test]
        public void TestSerializeDeserialize()
        {
            MessagePhantom M1 = new MessagePhantom();
            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));

            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, M1);

            MS.Position = 0;
            SF = new SoapFormatter();
            MessagePhantom Des_Event = (MessagePhantom) SF.Deserialize(MS);
            Assert.AreEqual(M1, Des_Event);
        }*/

        ///<summary>
        ///</summary>
        public void TestEqualsPsevdo()
        {
            MessagePhantom M1 = new MessagePhantom();
            Assert.AreEqual(M1, PsevdoValue.Instance());

            M1 = new MessagePhantom();
            M1.Add(new Chain(10));
            Assert.AreEqual(M1, PsevdoValue.Instance());

            M1.Add(new ValueChar('1'));
            Assert.AreNotEqual(M1, PsevdoValue.Instance());
        }
    }
}