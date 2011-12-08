using System;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    /// Нормализованная средняя удалённость
    ///</summary>
    public class NormalizedAverageRemoteness : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return pChain.GetCharacteristic(Link, CharacteristicsFactory.g);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            double g = pChain.GetCharacteristic(Link, CharacteristicsFactory.g);
            double Hmax = Math.Log(pChain.GetCharacteristic(Link, CharacteristicsFactory.Power), 2);
            return g - Hmax;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NormalizedAverageRemoteness;
        }
    }
}