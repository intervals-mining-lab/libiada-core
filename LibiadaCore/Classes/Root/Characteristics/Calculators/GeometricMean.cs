using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Среднегеометрический интервал.
    ///</summary>
    public class GeometricMean : ICalculator
    {
        private readonly Depth depthCalc = new Depth();
        private readonly IntervalsCount intervalsCount = new IntervalsCount();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            //Считаем в логарифмическом масштабе, чтобы избежать переполнения
            double depth = depthCalc.Calculate(chain, linkUp);
            double nj = intervalsCount.Calculate(chain,linkUp);
            //возвращаемое значение делогарифмируем
            return Math.Pow(2, depth/nj);
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            //Считаем в логарифмическом масштабе, чтобы избежать переполнения
            double depth = depthCalc.Calculate(chain, linkUp);
            double nj = intervalsCount.Calculate(chain, linkUp);
            //возвращаемое значение делогарифмируем
            return Math.Pow(2, depth / nj);

        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.GeometricMean;
        }
    }
}