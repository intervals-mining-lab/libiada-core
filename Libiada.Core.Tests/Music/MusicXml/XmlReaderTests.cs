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
        MusicXmlReader xr = new($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
        Assert.That(xr.MusicXmlDocument, Is.Not.Null);
    }
}
