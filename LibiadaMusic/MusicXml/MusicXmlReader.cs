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
        /// Текущий прочитанный MusicXML файл
        /// </summary>
        private XmlDocument curDoc;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicXmlReader"/> class.
        /// </summary>
        public MusicXmlReader()
        {
        }

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
        /// Gets path to MusicXML file.
        /// </summary>
        public string FileName { get; private set; }

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
                if (curDoc != null)
                {
                    return (XmlDocument)curDoc.Clone();
                }

                throw new Exception("LibiadaMusic.XMLReader:you are trying to get empty XmlDocument!");
            }
        }

        /// <summary>
        /// The load music xml document.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void LoadMusicXmlDocument(string path)
        {
            LoadNotes(path);
        }

        /// <summary>
        /// The load notes.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        private void LoadNotes(string path)
        {
            // Объявляем и забиваем файл в XMLдокумент  
            var xd = new XmlDocument();
            var fs = new FileStream(path, FileMode.Open);
            xd.Load(fs);
            curDoc = null;
            curDoc = (XmlDocument)xd.Clone();
            fs.Close();
            FileName = Path.GetFileNameWithoutExtension(path); // сохраняем имя прочтенного файла
        }
    }
}
