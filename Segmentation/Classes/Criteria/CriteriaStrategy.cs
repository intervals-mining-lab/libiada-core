using System;

namespace Segmentation.Classes.Criteria
{
    public static class  CriteriaStrategy
    {
        public static CriteiaMethod Get(Method calc_frecuncy_method)
        {
            switch(calc_frecuncy_method) 
            {
                case Method.Convoluted: return new ConvolutedCriteiaMethod();
                case Method.NotConvoluted: return new NotConvolutedCriteiaMethod();
                default: throw new Exception("WOW");
            }
        }
    }
}