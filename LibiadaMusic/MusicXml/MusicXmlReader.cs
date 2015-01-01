namespace LibiadaMusic.MusicXml
{
    using System;
    using System.Xml;
    using System.IO;

    public class MusicXmlReader
    {
        /// <summary>
        /// Текущий прочитанный MusicXML файл
        /// </summary>
        private XmlDocument curDoc;

        /// <summary>
        /// путь к прочитанному MusicXML файлу
        /// </summary>
        public string FileName { get; private set; }

        public MusicXmlReader()
        {
        }

        public MusicXmlReader(string xpath)
        {
            LoadNotes(xpath);
        }

        public void LoadMusicXmlDocument(string path)
        {
            LoadNotes(path);
        }

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
