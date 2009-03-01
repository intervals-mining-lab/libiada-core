using System;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators
{
    ///<summary>
    /// Тестирует фабрику конструкторов элементов
    ///</summary>
    [TestFixture]
    public class TestElementStreamBuilderFactory
    {
        ///<summary>
        /// Тестирует создание при создании как текст
        ///</summary>
        [Test]
        public void TestCreate()
        {
            Assert.AreEqual(new TextStreamCreator().GetType(),
                            ElementStreamBuilderFactory.Create(FileType.Txt).GetType());
        }

        ///<summary>
        /// Тестирует создание про null.
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestCreateFromNull()
        {
            ElementStreamBuilderFactory.Create(null);
        }
    }
}