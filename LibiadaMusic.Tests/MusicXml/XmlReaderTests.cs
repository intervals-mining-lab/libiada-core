namespace LibiadaMusic.Tests.MusicXml
{
    using System;
    using System.Xml;

    using LibiadaMusic.MusicXml;

    using NUnit.Framework;

    /// <summary>
    /// The xml reader tests.
    /// </summary>
    [TestFixture]
    public class XmlReaderTests
    {
        /// <summary>
        /// The xml reader first test.
        /// </summary>
        [Test]
        public void XmlReaderFirstTest()
        {
            var xr = new MusicXmlReader("../../LibiadaMusicexample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
            Assert.AreEqual("LibiadaMusicexample7Liga", xr.FileName);
        }

        /// <summary>
        /// The xml reader second test.
        /// </summary>
        [Test]
        public void XmlReaderSecondTest()
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
