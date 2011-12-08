using System;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class FileType : TypeBase
    {
        ///<summary>
        ///</summary>
        public static FileType Txt
        {
            get
            {
                FileType Ft = new FileType();
                Ft.Name = "txt";
                Ft.MIME = "text";
                Ft.Size = 1;
                return Ft;
            }
        }
    }
}