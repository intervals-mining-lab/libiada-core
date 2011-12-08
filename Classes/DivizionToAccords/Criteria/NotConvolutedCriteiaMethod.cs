using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses;
using ChainAnalises.Classes.DivizionToAccords.Criteria;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords.Criteria
{
    internal class NotConvolutedCriteiaMethod : CriteiaMethod
    {
        public override double Frequncy(IDataForStd std, int chain_length, int window_length)
        {
            return std.Probability(chain_length);
        }
    }
}