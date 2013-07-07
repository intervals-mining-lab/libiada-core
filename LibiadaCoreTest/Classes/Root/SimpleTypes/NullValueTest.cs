using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    ///<summary>
    /// �������� ����� ��� ������ PsevdoValue
    ///</summary>
    [TestFixture]
    public class NullValueTest
    {
        ///<summary>
        /// ��������� Instance 
        ///</summary>
        [Test]
        public void IncstanceNotNullTest()
        {
            Assert.IsNotNull(NullValue.Instance());
        }

        ///<summary>
        /// ���� ����������� ������ �������� SingleTone
        ///</summary>
        [Test]
        public void InstanceSingleToneTest()
        {
            Assert.AreSame(NullValue.Instance(), NullValue.Instance());
        }
    }
}