using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// —редн€€ удалЄнность,
    /// логарифм по основанию 2 от среднегеометрического интервала.
    ///</summary>
    public class AverageRemoteness : ICharacteristicCalculator
    {
        private readonly IntervalsCount intervalsCount = new IntervalsCount();
        private readonly GeometricMean geometricMean = new GeometricMean();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return Math.Log(geometricMean.Calculate(chain, linkUp), 2);
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double temp = 0;
            double n = intervalsCount.Calculate(chain, linkUp);
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                double uniformDg = geometricMean.Calculate(chain.UniformChain(i), linkUp);
                double nj = intervalsCount.Calculate(chain.UniformChain(i), linkUp);
                temp += nj/n*Math.Log(uniformDg, 2);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverangeRemoteness;
        }
    }
}