using System;
using System.IO;
using System.Xml.Serialization;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;
using File=ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.File;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators
{
    ///<summary>
    /// Тестирует класс конструктор потока элементов
    ///</summary>
    [TestFixture]
    public class TestElementStreamCreator
    {
        private FileStream fs = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            String SimlpeXml = "FileSnapSimpleXml.xml";

            fs = new FileStream(SimlpeXml, FileMode.Open, FileAccess.ReadWrite);
        }

        ///<summary>
        ///</summary>
        [TearDown]
        public void deinit()
        {
            fs.Close();
        }


        ///<summary> 
        /// Тестирует создание потока элементов-символов
        ///</summary>
        [Test]
        [Ignore]
        public void TestTxt()
        {
            TextStreamCreator TESR = new TextStreamCreator();

            XmlSerializer SF = new XmlSerializer(typeof (File));

            File FileTest = new ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.File();
            FileTest.Data = "dsfdskhkldhg";
            FileTest.FileType.Name = FileType.Txt.Name;

            FileTest.FileType.MIME = FileType.Txt.MIME;
            FileTest.FileType.Size = FileType.Txt.Size;


            Assert.AreEqual(FileTest.Data, "dsfdskhkldhg");
            Assert.AreEqual(FileTest.FileType, FileType.Txt);


            SF.Serialize(fs, FileTest);

            fs.Position = 0;

            FileTest = (File) SF.Deserialize(fs);

            ElementStream El = TESR.Create(FileTest);
            Assert.AreEqual(El[0], new ValueChar('d'));
            Assert.AreEqual(El[1], new ValueChar('s'));
            Assert.AreEqual(El[2], new ValueChar('f'));
            Assert.AreEqual(El[3], new ValueChar('d'));
            Assert.AreEqual(El[4], new ValueChar('s'));
            Assert.AreEqual(El[5], new ValueChar('k'));
            Assert.AreEqual(El[6], new ValueChar('h'));
            Assert.AreEqual(El[7], new ValueChar('k'));
            Assert.AreEqual(El[8], new ValueChar('l'));
            Assert.AreEqual(El[9], new ValueChar('d'));
            Assert.AreEqual(El[10], new ValueChar('h'));
            Assert.AreEqual(El[11], new ValueChar('g'));
            Assert.AreEqual(12, El.Count);
        }
    }
}