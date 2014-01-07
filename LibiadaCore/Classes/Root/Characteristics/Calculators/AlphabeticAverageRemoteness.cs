using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    public class AlphabeticAverageRemoteness : ICalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();

        public double Calculate(CongenericChain chain, Link link)
        {
            throw new InvalidOperationException("Алфавитная удалённость вычисляется только для полных цепей.");
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            int alphabetPower = chain.Alphabet.Power;
            return Math.Log(geometricMean.Calculate(chain, link), alphabetPower);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AlphabeticAverageRemoteness;
        }
    }
}