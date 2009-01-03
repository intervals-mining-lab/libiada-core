using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.IntervalAnalysis;
using NUnit.Framework;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders.Test
{
    ///<summary>
    /// ��������� ����� ������� ������� ��������������� ������������
    ///</summary>
    [TestFixture]
    public class TestSpaceRebuilderFactory
    {
        ///<summary>
        /// ��������� �������� ��� �������� ��� ��������� �������� �� ������
        ///</summary>
        [Test]
        public void TestCreate()
        {
            Assert.AreEqual(ElementStreamBuilderFactory.Create(FileType.Txt).GetType(),
                            ElementStreamBuilderFactory.Create(FileType.Txt).GetType());
        }

        ///<summary>
        /// ��������� �������� ��� null.
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestCreateFromNull()
        {
            SpaceRebuilderFactory<Chain,Chain>.Create(null);
        }
    }
}