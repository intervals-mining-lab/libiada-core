using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;


namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AnswerClusterization:Answer
    {
        public SoapClusterizationVaraints Variant = null;
    }
}