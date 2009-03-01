using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.IntervalAnalysis;
using NUnit.Framework;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders.Test
{
    ///<summary>
    /// Тестирует класс фабрика методов конвертирования пространства
    ///</summary>
    [TestFixture]
    public class TestSpaceRebuilderFactory
    {
        ///<summary>
        /// Тестирует создание при создании как построние алфавита по блокам
        ///</summary>
        [Test]
        public void TestCreate()
        {
            Assert.AreEqual(ElementStreamBuilderFactory.Create(FileType.Txt).GetType(),
                            ElementStreamBuilderFactory.Create(FileType.Txt).GetType());
        }

        ///<summary>
        /// Тестирует создание про null.
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestCreateFromNull()
        {
            SpaceRebuilderFactory<Chain,Chain>.Create(null);
        }
    }
}