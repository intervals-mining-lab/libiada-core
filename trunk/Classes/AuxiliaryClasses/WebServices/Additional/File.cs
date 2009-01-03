using System;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class File : IBaseObject
    {
        protected string pData = "";
        protected FileType pFileType = new FileType();

        ///<summary>
        ///</summary>
        public FileType FileType
        {
            get { return pFileType; }
            set { pFileType = value; }
        }

        /// <summary>
        /// Чтение даных из файла
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadFromFile(String fileName)
        {
            pData = System.IO.File.ReadAllText(fileName);
        }

        ///<summary>
        ///</summary>
        public string Data
        {
            get { return pData; }
            set { pData = value; }
        }

        #region IBaseObject Members

        public IBaseObject Clone()
        {
            File temp = new File();
            temp.pFileType = (FileType) pFileType.Clone();
            temp.pData = pData;
            return temp;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsFile(obj as File);
        }

        public IBin GetBin()
        {
            throw new NotImplementedException();
        }

        public string Type
        {
            get { return GetType().ToString(); }
            set { }
        }

        #endregion

        private bool EqualsAsFile(File file)
        {
            return (FileType.Equals(file.FileType) && pData.Equals(file.pData));
        }
    }
}