using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    public class AlphabeticAverageRemoteness : ICalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();

        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            throw new InvalidOperationException("Алфавитная удалённость вычисляется только для полных цепей.");
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            int alphabetPower = chain.Alphabet.Power;
            return Math.Log(geometricMean.Calculate(chain, linkUp), alphabetPower);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverangeRemoteness;
        }
    }
}