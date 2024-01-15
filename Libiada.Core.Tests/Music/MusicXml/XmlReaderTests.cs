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
        var xr = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
        Assert.IsNotNull(xr.MusicXmlDocument);
    }
}
