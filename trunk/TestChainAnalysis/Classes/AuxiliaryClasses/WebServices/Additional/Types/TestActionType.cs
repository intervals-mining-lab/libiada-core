using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    /// Класс тестирующий ActionType
    ///</summary>
    [TestFixture]
    public class TestActionType
    {
        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestCalcaulateFull()
        {
            ActionType Act = ActionType.Calculate;
            Assert.AreEqual("Calculate",Act.Name);
            Assert.AreEqual("Calculate", Act.MIME);
            Assert.AreEqual(-772858697, Act.GetHashCode());
        }

    }
}