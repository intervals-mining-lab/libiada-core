using ChainAnalises.Classes.EventTheory;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
{
    ///<summary>
    /// Содержит тесты для класса PsevdoValue
    ///</summary>
    [TestFixture]
    public class TestPsevdoValue
    {
        ///<summary>
        /// Тестирует Instance 
        ///</summary>
        [Test]
        public void TestIncstanceNotNull()
        {
            Assert.IsNotNull(PsevdoValue.Instance());
        }

        ///<summary>
        /// Тест проверяющий работу паттрена SingleTone
        ///</summary>
        [Test]
        public void TestInstanceSingleTone()
        {
            Assert.AreSame(PsevdoValue.Instance(), PsevdoValue.Instance());
        }
    }
}