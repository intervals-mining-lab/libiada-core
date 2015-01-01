namespace LibiadaMusic.Analysis
{
    using System;
    using System.IO;
    using System.Xml;

    public class Reader
    {
        public void SetData(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            var br = new BinaryReader(fs);

            char[] chars = br.ReadChars((int)fs.Length);
            string str = string.Empty;
            for (int i = 0; i < fs.Length; i++)
            {
                str = str + chars[i];
            }

            char[] sep = { '\r', '\n' };
            Data = str.Split(sep, (int)fs.Length, StringSplitOptions.RemoveEmptyEntries);
            fs.Close();
        }

        public void SetXmlData(string path)
        {
            // Объявляем и забиваем файл в документ 
            var xd = new XmlDocument();
            var fs = new FileStream(path, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("element"); // Создаем и заполняем лист по тегу "element" 
            string str = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                str += list.Item(i).InnerText + '\r' + '\n'; // вносим в строку следующий ф-мотив + разделитель
            }

            char[] sep = { '\r', '\n' };
            Data = str.Split(sep, (int)fs.Length, StringSplitOptions.RemoveEmptyEntries);
            fs.Close(); // Закрываем поток
        }

        public string[] Data { get; private set; }
    }
}
