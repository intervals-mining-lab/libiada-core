using System;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Количество интервалов в зависимости от привязки.
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

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsCount;
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