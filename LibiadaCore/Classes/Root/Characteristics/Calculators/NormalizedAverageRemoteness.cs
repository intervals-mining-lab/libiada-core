using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Нормализованная средняя удалённость
    ///</summary>
    public class NormalizedAverageRemoteness : ICharacteristicCalculator
    {
        private AverageRemoteness averageRemoteness = new AverageRemoteness();
        private AlphabetPower alphabetPower = new AlphabetPower();

        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return averageRemoteness.Calculate(pChain, Link);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            double g = averageRemoteness.Calculate(pChain, Link);
            double Hmax = Math.Log(alphabetPower.Calculate(pChain, Link), 2);
            return g - Hmax;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NormalizedAverageRemoteness;
        }
    }
}