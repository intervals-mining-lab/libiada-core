using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    /// ����� ����������� ������������ ������ ������� ��� TypeBase
    ///</summary>
    [TestFixture]
    public class TestTypeBase
    {
        ///<summary>
        /// ����� ���������������� �����
        ///</summary>
        [SetUp]
        public void init()
        {
            //TypeBase TB = new TypeBase();
        }

        /// <summary> 
        /// ���� ������������ TypeBase
        /// </summary>
        [Test]
        public void TestTypeBaseChangeName()
        {
            FileType File1 = new FileType();

            File1.Name = "IntFile";
            File1.Size = 1;
            File1.MIME = "Integer value";

            File1.Name = "Integer_File";
            int hash2 = File1.HashCode;

//            Assert.AreEqual(hash1,hash2);
            Assert.AreEqual(File1.Name, "Integer_File");
            Assert.AreEqual(File1.HashCode, hash2);
        }

        /// <summary>
        /// ���� ����������� ��������� ���������������
        /// ��� ��� ������������ ���� ������������ �� Name, Size, MIME.
        /// </summary>
        [Test]
        public void TestEquals()
        {
            FileType File1 = new FileType();
            FileType File2 = new FileType();

            Assert.AreEqual(File1, File2);
            File2.Size = 4;

            Assert.AreNotEqual(File1, File2);
        }

        ///<summary>
        /// ��������� HashCode 
        ///</summary>
        public void TestHashCode()
        {
            FileType File1 = new FileType();
            FileType File2 = new FileType();

            Assert.AreEqual(File1.HashCode, File2.HashCode);

            Assert.AreEqual(File1.HashCode, File1.GetHashCode());

            File2.Size = 4;
            Assert.AreNotEqual(File1.HashCode, File2.HashCode);
        }
    }
}