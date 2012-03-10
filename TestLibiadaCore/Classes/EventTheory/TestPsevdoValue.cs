using LibiadaCore.Classes.EventTheory;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.EventTheory
{
    ///<summary>
    /// �������� ����� ��� ������ PsevdoValue
    ///</summary>
    [TestFixture]
    public class TestPsevdoValue
    {
        ///<summary>
        /// ��������� Instance 
        ///</summary>
        [Test]
        public void TestIncstanceNotNull()
        {
            Assert.IsNotNull(PsevdoValue.Instance());
        }

        ///<summary>
        /// ���� ����������� ������ �������� SingleTone
        ///</summary>
        [Test]
        public void TestInstanceSingleTone()
        {
            Assert.AreSame(PsevdoValue.Instance(), PsevdoValue.Instance());
        }
    }
}