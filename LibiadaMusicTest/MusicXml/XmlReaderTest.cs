using System;
using System.Xml;
using LibiadaMusic.MusicXml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.MusicXml
{
    [TestClass]
    public class XmlReaderTest
    {
        [TestMethod]
        public void TestXMLReader1 ()
        {
            var xr = new MusicXmlReader("../../LibiadaMusicexample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
            Assert.AreEqual("LibiadaMusicexample7Liga", xr.FileName);
        }

        [TestMethod]
        public void TestXMLReader2()
        {
            var path = "../../LibiadaMusicexample7Liga.xml";
            var xr = new MusicXmlReader();
            var xdoc = new XmlDocument();

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

