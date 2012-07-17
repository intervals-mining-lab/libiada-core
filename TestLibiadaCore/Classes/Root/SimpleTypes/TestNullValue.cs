using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// �������� ����� ��� ������ PsevdoValue
    ///</summary>
    [TestFixture]
    public class TestNullValue
    {
        ///<summary>
        /// ��������� Instance 
        ///</summary>
        [Test]
        public void TestIncstanceNotNull()
        {
            Assert.IsNotNull(NullValue.Instance());
        }

        ///<summary>
        /// ���� ����������� ������ �������� SingleTone
        ///</summary>
        [Test]
        public void TestInstanceSingleTone()
        {
            Assert.AreSame(NullValue.Instance(), NullValue.Instance());
        }
    }
}