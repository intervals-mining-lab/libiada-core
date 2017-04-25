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
            var xr = new MusicXmlReader(TestContext.CurrentContext.TestDirectory + "/../../LibiadaMusicExample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
            Assert.AreEqual("LibiadaMusicExample7Liga", xr.FileName);
        }

        /// <summary>
        /// The xml reader second test.
        /// </summary>
        [Test]
        public void XmlReaderSecondTest()
        {
            var xr = new MusicXmlReader();
            XmlDocument xmlDocument;

            var exception = Assert.Throws<Exception>(() => xmlDocument = xr.MusicXmlDocument);
            Assert.AreEqual("LibiadaMusic.XMLReader:you are trying to get empty XmlDocument!", exception.Message);

            xr.LoadMusicXmlDocument(TestContext.CurrentContext.TestDirectory + "/../../LibiadaMusicExample7Liga.xml");
            xmlDocument = xr.MusicXmlDocument;
            Assert.IsNotNull(xmlDocument);
            Assert.AreEqual("LibiadaMusicExample7Liga", xr.FileName);
        }
    }
}
