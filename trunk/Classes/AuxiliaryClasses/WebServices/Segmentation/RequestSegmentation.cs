using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Requests;
using ChainAnalises.Classes.DivizionToAccords.Criteria;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class RequestSegmentation: Request
    {
        public double BalanceFactor;
        public File Files = null;
        public int StartLength;
        public LinkUp Link;
        public Method CalculateFrequenceMethod;
        public double RightValue;
        public double Eps;
    }
}
