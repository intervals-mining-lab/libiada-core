using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes.Criteria
{
    public class ConvolutedCriteiaMethod : CriteiaMethod
    {
        public override double Frequncy(IDataForStd std, int chain_length, int window_length)
        {
            return  std.Probability((chain_length - (std.n*(window_length - 1))));
        }
    }
}