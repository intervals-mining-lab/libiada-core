namespace Libiada.Core.Music.MusicXml;

using System.IO;
using System.Xml;

/// <summary>
/// The music xml reader.
/// </summary>
public class MusicXmlReader
{
    /// <summary>
    /// MusicXml file as XmlDocument.
    /// </summary>
    private readonly XmlDocument musicXmlDocument = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="MusicXmlReader"/> class.
    /// </summary>
    /// <param name="xpath">
    /// The xpath.
    /// </param>
    public MusicXmlReader(string xpath)
    {
        using FileStream fs = new(xpath, FileMode.Open);
        LoadNotes(fs);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MusicXmlReader"/> class.
    /// </summary>
    /// <param name="stream">
    /// The stream.
    /// </param>
    public MusicXmlReader(Stream stream)
    {
        LoadNotes(stream);
    }

    /// <summary>
    /// Gets the music xml document.
    /// </summary>
    /// <exception cref="Exception">
    /// Thrown if curDoc is null.
    /// </exception>
    public XmlDocument MusicXmlDocument => (XmlDocument)musicXmlDocument.Clone();

    /// <summary>
    /// The load notes.
    /// </summary>
    /// <param name="stream">
    /// Data stream with musicXml file.
    /// </param>
    private void LoadNotes(Stream stream)
    {
        musicXmlDocument.Load(stream);
    }
}
