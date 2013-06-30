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

        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            return averageRemoteness.Calculate(chain, linkUp);
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double g = averageRemoteness.Calculate(chain, linkUp);
            double hMax = Math.Log(alphabetPower.Calculate(chain, linkUp), 2);
            return g - hMax;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NormalizedAverageRemoteness;
        }
    }
}