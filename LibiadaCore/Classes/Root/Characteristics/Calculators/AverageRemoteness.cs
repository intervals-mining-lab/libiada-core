using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// —редн€€ удалЄнность,
    /// логарифм по основанию 2 от среднегеометрического интервала.
    ///</summary>
    public class AverageRemoteness : ICalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();

        public double Calculate(CongenericChain chain, LinkUp linkUp)
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
            return Math.Log(geometricMean.Calculate(chain, linkUp), 2);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverangeRemoteness;
        }
    }
}