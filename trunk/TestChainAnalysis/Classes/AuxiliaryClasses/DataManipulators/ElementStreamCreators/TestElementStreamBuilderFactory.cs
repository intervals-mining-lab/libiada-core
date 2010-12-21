using System;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators
{
    ///<summary>
    /// ��������� ������� ������������� ���������
    ///</summary>
    [TestFixture]
    public class TestElementStreamBuilderFactory
    {
        ///<summary>
        /// ��������� �������� ��� �������� ��� �����
        ///</summary>
        [Test]
        public void TestCreate()
        {
            Assert.AreEqual(new TextStreamCreator().GetType(),
                            ElementStreamBuilderFactory.Create(FileType.Txt).GetType());
        }

        ///<summary>
        /// ��������� �������� ��� null.
        ///</summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestCreateFromNull()
        {
            ElementStreamBuilderFactory.Create(null);

        }
    }
}