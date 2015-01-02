namespace LibiadaMusic.Tests.MusicXml
{
    using System;
    using System.Xml;

    using LibiadaMusic.MusicXml;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The xml reader tests.
    /// </summary>
    [TestClass]
    public class XmlReaderTests
    {
        /// <summary>
        /// The xml reader first test.
        /// </summary>
        [TestMethod]
        public void XMLReaderFirstTest()
        {
            var xr = new MusicXmlReader("../../LibiadaMusicexample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
            Assert.AreEqual("LibiadaMusicexample7Liga", xr.FileName);
        }

        /// <summary>
        /// The xml reader second test.
        /// </summary>
        [TestMethod]
        public void XMLReaderSecondTest()
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
