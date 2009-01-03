using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AnswerObjects : Answer
    {
        public SoapAlphabetOfChains Alphabet = new SoapAlphabetOfChains();
    }
}