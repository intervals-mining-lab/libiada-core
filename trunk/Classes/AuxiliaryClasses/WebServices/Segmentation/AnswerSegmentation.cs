using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AnswerSegmentation:Answer
    {   
        public SoapChainOfChains Chain;
        public double BestLevel;
        public double BestDelta;
        public double TheoryVolume;
    }
}