using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Среднегеометрический интервал.
    ///</summary>
    public class GeometricMean : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            double G = pChain.GetCharacteristic(Link, CharacteristicsFactory.G);
            double n_j = pChain.GetCharacteristic(Link, CharacteristicsFactory.IntervalsCount);
            return Math.Pow(2, G/n_j);
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            double G = pChain.GetCharacteristic(Link, CharacteristicsFactory.G);
            double n_j = pChain.GetCharacteristic(Link, CharacteristicsFactory.IntervalsCount);
            return Math.Pow(2, G / n_j);

        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.GeometricMean;
        }
    }
}