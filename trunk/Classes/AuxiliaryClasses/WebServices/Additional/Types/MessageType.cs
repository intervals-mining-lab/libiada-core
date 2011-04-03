using System;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class MessageType : TypeBase
    {
        ///<summary>
        ///</summary>
        [XmlIgnore]
        public static MessageType Text
        {
            get
            {
                MessageType MesType = new MessageType();
                MesType.pname = "Char/text";
                MesType.pMIME = "text";
                return MesType;
            }
        }

        ///<summary>
        ///</summary>
        public MessageType()
        {
            pHashCode = GetHashCode();
        }
    }
}