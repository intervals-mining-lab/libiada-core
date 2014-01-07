using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Нормализованная средняя удалённость
    ///</summary>
    public class NormalizedAverageRemoteness : ICalculator
    {
        private readonly AverageRemoteness averageRemoteness = new AverageRemoteness();
        private readonly AlphabetPower alphabetPower = new AlphabetPower();

        public double Calculate(CongenericChain chain, Link link)
        {
            return averageRemoteness.Calculate(chain, link);
        }

        public double Calculate(Chain chain, Link link)
        {
            double g = averageRemoteness.Calculate(chain, link);
            double hMax = Math.Log(alphabetPower.Calculate(chain, link), 2);
            return g - hMax;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NormalizedAverageRemoteness;
        }
    }
}