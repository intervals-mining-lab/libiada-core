using System;
using System.Xml;
using System.IO;

namespace LibiadaMusic.MusicXml
{
    public class MusicXmlReader
    {
        private XmlDocument curDoc; // Текущий прочитанный MusicXML файл
        private string filename; // путь к прочитанному MusicXML файлу

        public MusicXmlReader ()
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
                if (curDoc!=null) return ((XmlDocument) curDoc.Clone());
                throw new Exception("LibiadaMusic.XMLReader:you are trying to get empty XmlDocument!");
            }
        }
        public string FileName
        {
            get
            {
                return filename;
            }
        }

        private void LoadNotes(string path)
        {
            // Объявляем и забиваем файл в XMLдокумент  
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(path, FileMode.Open);
            xd.Load(fs);
            curDoc = null;
            curDoc = (XmlDocument)xd.Clone();
            fs.Close();
            this.filename = System.IO.Path.GetFileNameWithoutExtension(path); // сохраняем имя прочтенного файла
        }
    }
}

