namespace Libiada.Core.Tests.Music.MusicXml;

using Libiada.Core.Music.MusicXml;

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
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        Assert.That(xmlReader.MusicXmlDocument, Is.Not.Null);
    }
}
