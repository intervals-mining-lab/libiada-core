using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Среднегеометрический интервал.
    ///</summary>
    public class GeometricMean : ICharacteristicCalculator
    {
        private readonly Depth depthCalc = new Depth();
        private readonly IntervalsCount intervalsCount = new IntervalsCount();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            
            double depth = depthCalc.Calculate(chain, linkUp);
            double nj = intervalsCount.Calculate(chain,linkUp);
            return Math.Pow(2, depth/nj);
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double depth = depthCalc.Calculate(chain, linkUp);
            double nj = intervalsCount.Calculate(chain, linkUp);
            return Math.Pow(2, depth / nj);

        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.GeometricMean;
        }
    }
}