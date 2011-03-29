using System;
using System.Xml;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MDA.OIP
{
	public class MusicXmlReader
	{
        protected XmlDocument curDoc = new XmlDocument(); // Текущий MusicXML файл обработки
        
		public MusicXmlReader ()
		{
		}

        public MusicXmlReader(string xpath)
        {
          LoadNotes(xpath);
        }

		private void LoadNotes(string path)
        {
            // Объявляем и забиваем файл в документ  
            XmlDocument xd = new XmlDocument();

            try
            {
                curDoc = null;
                FileStream fs = new FileStream(path, FileMode.Open);
                xd.Load(fs);
                curDoc = (XmlDocument)xd.Clone();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("MDA: " + e.Message);
            }

        }

        public XmlDocument GetMusicXmlDocument()
        {
            if (curDoc.Equals(null)) throw new Exception("Пустой Xml Document");
            else return curDoc;
		}

        public void OpenMusicXmlDocument (string path)
        {
            LoadNotes(path);   
        }
	}
}

