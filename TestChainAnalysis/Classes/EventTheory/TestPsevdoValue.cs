using ChainAnalises.Classes.EventTheory;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
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