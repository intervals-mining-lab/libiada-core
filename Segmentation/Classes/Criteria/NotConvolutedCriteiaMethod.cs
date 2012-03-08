using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes.Criteria
{
    internal class NotConvolutedCriteiaMethod : CriteiaMethod
    {
        public override double Frequncy(IDataForStd std, int chain_length, int window_length)
        {
            return std.Probability(chain_length);
        }
    }
}