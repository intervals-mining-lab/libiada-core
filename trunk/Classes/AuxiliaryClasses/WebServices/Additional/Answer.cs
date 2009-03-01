using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers
{
    ///<summary>
    ///</summary>
    [Serializable]
    public abstract class Answer //: IXmlSerializable
    {
        public ErrorType Error;

        /*public virtual XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }*/

/*        public virtual void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement(GetType().Name);
            reader.ReadStartElement("ErrorType", "");
            Error = new ErrorType();
            Error.ReadXml(reader);
            reader.ReadEndElement();
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ErrorType", "");
            Error.WriteXml(writer);
            writer.WriteEndElement();
        }*/
    }
}