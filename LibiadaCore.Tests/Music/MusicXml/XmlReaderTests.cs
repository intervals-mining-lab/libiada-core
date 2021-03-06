namespace LibiadaCore.Tests.Music.MusicXml
{
    using LibiadaCore.Music.MusicXml;

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
            var xr = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            Assert.IsNotNull(xr.MusicXmlDocument);
        }
    }
}
