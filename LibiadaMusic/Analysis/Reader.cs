namespace LibiadaMusic.Analysis
{
    using System;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// The reader.
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        public string[] Data { get; private set; }

        /// <summary>
        /// The set data.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void SetData(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var br = new BinaryReader(fs);

                char[] chars = br.ReadChars((int)fs.Length);
                string str = string.Empty;
                for (int i = 0; i < fs.Length; i++)
                {
                    str = str + chars[i];
                }

                char[] sep = { '\r', '\n' };
                Data = str.Split(sep, (int)fs.Length, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// The set xml data.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void SetXmlData(string path)
        {
            // Объявляем и забиваем файл в документ
            var xd = new XmlDocument();
            using (var fs = new FileStream(path, FileMode.Open))
            {
                xd.Load(fs);

                // Создаем и заполняем лист по тегу "element"
                XmlNodeList list = xd.GetElementsByTagName("element");
                string str = string.Empty;
                for (int i = 0; i < list.Count; i++)
                {
                    // вносим в строку следующий ф-мотив + разделитель
                    str += list.Item(i).InnerText + '\r' + '\n';
                }

                char[] sep = { '\r', '\n' };
                Data = str.Split(sep, (int)fs.Length, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
