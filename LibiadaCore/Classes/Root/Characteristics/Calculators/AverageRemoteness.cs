namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// —редн€€ удалЄнность,
    /// логарифм по основанию 2 от среднегеометрического интервала.
    /// </summary>
    public class AverageRemoteness : ICalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();

        public double Calculate(CongenericChain chain, Link link)
        {
            return Math.Log(geometricMean.Calculate(chain, link), 2);
        }

        /// <summary>
        /// </summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            return Math.Log(geometricMean.Calculate(chain, link), 2);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverageRemoteness;
        }
    }
}