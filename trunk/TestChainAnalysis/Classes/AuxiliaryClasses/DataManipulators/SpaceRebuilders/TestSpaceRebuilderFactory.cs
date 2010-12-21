using System;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.IntervalAnalysis;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
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
        public void TestCreateFromNull()
        {
            try
            {
                SpaceRebuilderFactory<Chain,Chain>.Create(null);
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }
    }
}