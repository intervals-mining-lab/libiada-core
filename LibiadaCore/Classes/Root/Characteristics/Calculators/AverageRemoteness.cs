using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// —редн€€ удалЄнность,
    /// логарифм по основанию 2 от среднегеометрического интервала.
    ///</summary>
    public class AverageRemoteness : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            GeometricMean geometricMean = new GeometricMean();
            return Math.Log(geometricMean.Calculate(pChain, Link), 2);
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            IntervalsCount intervalsCount = new IntervalsCount();
            GeometricMean geometricMean = new GeometricMean();
            double temp = 0;
            double n = intervalsCount.Calculate(pChain, Link);
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                double uniformDg = geometricMean.Calculate(pChain.UniformChain(i), Link);
                double n_j = intervalsCount.Calculate(pChain.UniformChain(i), Link);
                temp += n_j/n*Math.Log(uniformDg, 2);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverangeRemoteness;
        }
    }
}