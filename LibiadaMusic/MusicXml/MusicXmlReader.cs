namespace LibiadaMusic.MusicXml
{
    using System;
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
        private XmlDocument musicXmlDocument;


        /// <summary>
        /// Initializes a new instance of the <see cref="MusicXmlReader"/> class.
        /// </summary>
        /// <param name="xpath">
        /// The xpath.
        /// </param>
        public MusicXmlReader(string xpath)
        {
            LoadNotes(xpath);
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
        public XmlDocument MusicXmlDocument
        {
            get
            {
                if (musicXmlDocument != null)
                {
                    return (XmlDocument)musicXmlDocument.Clone();
                }

                throw new Exception("LibiadaMusic.XMLReader:you are trying to get empty XmlDocument!");
            }
        }

        /// <summary>
        /// The load notes.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        private void LoadNotes(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                LoadNotes(fs);
            }
        }

        /// <summary>
        /// The load notes.
        /// </summary>
        /// <param name="stream">
        /// Data stream with musicXml file.
        /// </param>
        private void LoadNotes(Stream stream)
        {
            var xd = new XmlDocument();
            xd.Load(stream);
            musicXmlDocument = (XmlDocument)xd.Clone();
        }
    }
}
