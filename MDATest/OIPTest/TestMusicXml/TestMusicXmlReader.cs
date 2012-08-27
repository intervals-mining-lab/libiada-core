using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.MusicXml;


namespace TestMusicXml.TestMDA.OIPTest
{
    [TestClass]
    public class TestXmlReader
    {
        [TestMethod]
        public void TestXMLReader1()
        {
            // WTF????!!!!
            MusicXmlReader xr = new MusicXmlReader("K:\\_”чеба\\MDA 2.0.3\\MDA\\MDATest\\OIPTest\\MDAexample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
            Assert.AreEqual("MDAexample7Liga", xr.FileName);
        }

        [TestMethod]
        public void TestXMLReader2()
        {
            // WTF????!!!!
            string path = "K:\\_”чеба\\MDA 2.0.3\\MDA\\MDATest\\OIPTest\\MDAexample7Liga.xml";
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
                if (e.Message != "MDA.XMLReader:you are trying to get empty XmlDocument!")
                {
                    Assert.Fail();
                }
            }

            xr.LoadMusicXmlDocument(path);
            xdoc = xr.MusicXmlDocument;
            Assert.IsNotNull(xdoc);
            Assert.AreEqual("MDAexample7Liga", xr.FileName);
        }
    }
}

