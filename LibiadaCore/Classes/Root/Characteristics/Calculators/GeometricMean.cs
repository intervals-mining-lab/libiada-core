using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Среднегеометрический интервал.
    ///</summary>
    public class GeometricMean : ICharacteristicCalculator
    {
        private Depth depth = new Depth();
        private IntervalsCount intervalsCount = new IntervalsCount();

        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            
            double G = depth.Calculate(pChain, Link);
            double n_j = intervalsCount.Calculate(pChain,Link);
            return Math.Pow(2, G/n_j);
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            double G = depth.Calculate(pChain, Link);
            double n_j = intervalsCount.Calculate(pChain, Link);
            return Math.Pow(2, G / n_j);

        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.GeometricMean;
        }
    }
}