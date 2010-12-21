using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional
{
    ///<summary>
    /// јбстрактный класс-ответ от которого наследуютс€
    /// все контейнеры с результатами вычислений сервисов
    ///</summary>
    [Serializable]
    public abstract class Answer
    {
        ///<summary>
        /// ƒанные о текущем состо€нии вычислений
        ///</summary>
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