using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

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