using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP;


namespace TestMDA.OIPTest
{
	[TestClass]
	public class TestXmlReader
	{
		[TestMethod]
		public void TestXMLReader1 ()
        {
            MusicXmlReader xr = new MusicXmlReader("C:\\Users\\Антошка\\Documents\\Visual Studio 2010\\Projects\\MDA\\MDATest\\OIPTest\\MDAexample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
            Assert.AreEqual("MDAexample7Liga", xr.FileName);
		}

        [TestMethod]
        public void TestXMLReader2()
        {
            string path = "C:\\Users\\Антошка\\Documents\\Visual Studio 2010\\Projects\\MDA\\MDATest\\OIPTest\\MDAexample7Liga.xml";
            MusicXmlReader xr = new MusicXmlReader();
            XmlDocument xdoc = new XmlDocument();

            // проверка на null object, при выявлении XmlDocument
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

