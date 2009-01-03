using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

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