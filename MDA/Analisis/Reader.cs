using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MDA.Analisis
{
    public class Reader
    {
        private string[] Data1;

        public void SetData(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            /*if (fs.Length == 0)
            {
                throw new Exception("Error! Input file is empty");
            }*/
            char[] data = br.ReadChars((int)fs.Length);
            string str = "";
            for (int i = 0; i < fs.Length; i++)
            {
                str = str + data[i];
            }
            char[] sep = new char[] { '\r', '\n' };
            Data1 = str.Split(sep, (int)fs.Length, StringSplitOptions.RemoveEmptyEntries);
            fs.Close();
        }
        public void SetXmlData(string path)
        {
            // Объявляем и забиваем файл в документ  
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(path, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("element"); // Создаем и заполняем лист по тегу "element"  
            string str = "";            
            for (int i = 0; i < list.Count; i++)
            {
                str = str + list.Item(i).InnerText + '\r' + '\n'; // вносим в строку следующий ф-мотив + разделитель
            }
            char[] sep = new char[] { '\r', '\n' };
            Data1 = str.Split(sep, (int)fs.Length, StringSplitOptions.RemoveEmptyEntries);
            fs.Close();                          // Закрываем поток
        }

        public string[] GetData()
        {
            return Data1;
        }

    }
}
