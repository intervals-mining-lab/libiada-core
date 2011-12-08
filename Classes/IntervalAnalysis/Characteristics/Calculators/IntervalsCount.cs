using System;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics
{
    ///<summary>
    ///</summary>
    public class IntervalsCount : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain, Link);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain, Link);
        }

        private double CommonCalculate(ChainWithCharacteristic pChain, LinkUp Link)
        {
            IDataForCalculator data = pChain;
            switch (Link)
            {
                case LinkUp.Start:
                    return data.CommonIntervals.Count + data.StartInterval.Count;
                case LinkUp.End:
                    return data.CommonIntervals.Count + data.EndInterval.Count;
                case LinkUp.Both:
                    return data.CommonIntervals.Count + data.StartInterval.Count + data.EndInterval.Count;
                default:
                    throw new Exception("Супер странная ошибка :)");
            }
        }
    }
}