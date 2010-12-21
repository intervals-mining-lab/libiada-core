using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AnswerPhantomChains:Answer
    {
        [XmlArrayItem(typeof(SoapChainOfChains))]
        public ArrayList Chains = new ArrayList();
    }
}