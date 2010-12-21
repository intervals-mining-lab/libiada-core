using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional
{
    ///<summary>
    ///</summary>
    [Serializable]
    public abstract class Request //: IXmlSerializable
    {
        /*public ActionType Action;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsRequest(obj as Request);
        }

        private bool EqualsAsRequest(Request request)
        {
            return Action.Equals(request.Action);
        }*/

      /*  public virtual XmlSchema GetSchema()
        {
            //throw new NotImplementedException();
            
        }*/

        /*public virtual void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement(GetType().Name);
            reader.ReadStartElement("ActionType", "");
            Action = new ActionType();
            //Action.ReadXml(reader);
            reader.ReadEndElement();
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ActionType", "");
           // Action.WriteXml(writer);
            writer.WriteEndElement();
        }*/
    }
}