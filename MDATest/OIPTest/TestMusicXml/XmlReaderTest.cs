using System;
using System.Xml;
using LibiadaMusic.OIP.MusicXml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.OIPTest.TestMusicXml
{
    [TestClass]
    public class XmlReaderTest
    {
        [TestMethod]
        public void TestXMLReader1 ()
        {
            MusicXmlReader xr = new MusicXmlReader("..\\..\\OIPTest\\LibiadaMusicexample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
            Assert.AreEqual("LibiadaMusicexample7Liga", xr.FileName);
        }

        [TestMethod]
        public void TestXMLReader2()
        {
            string path = "..\\..\\OIPTest\\LibiadaMusicexample7Liga.xml";
            MusicXmlReader xr = new MusicXmlReader();
            XmlDocument xdoc = new XmlDocument();

            // проверка на null object, при вы€влении XmlDocument
            try
            {
                xdoc = xr.MusicXmlDocument;
                Assert.Fail();
            }
            catch (Exception e) 
            {
                if (e.Message != "LibiadaMusic.XMLReader:you are trying to get empty XmlDocument!")
                {
                    Assert.Fail();
                }
            }
            
            xr.LoadMusicXmlDocument(path);
            xdoc = xr.MusicXmlDocument;
            Assert.IsNotNull(xdoc);
            Assert.AreEqual("LibiadaMusicexample7Liga", xr.FileName);
        }
    }
}

