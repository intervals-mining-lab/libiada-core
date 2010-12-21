using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;


namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AnswerMarkovChain:Answer
    {
        [XmlArrayItem(typeof(SoapChainOfChains))]
        public ArrayList Chains = new ArrayList();
    }
}