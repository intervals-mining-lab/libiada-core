using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public class Count : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain);
        }

        private double CommonCalculate(ChainWithCharacteristic pChain)
        {
            IDataForCalculator data = pChain;
            return data.CommonIntervals.Count + data.StartInterval.Count;
        }
    }
}