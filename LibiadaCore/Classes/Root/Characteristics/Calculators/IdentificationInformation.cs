using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
    /// Энтропия, количество информации.
    ///</summary>
    public class IdentificationInformation : ICharacteristicCalculator
    {
        private ArithmeticMean arithmeticMean = new ArithmeticMean();
        private Probability probability = new Probability();

        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return Math.Log(arithmeticMean.Calculate(pChain, Link), 2);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            double temp = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                double P = probability.Calculate(pChain.GetUniformChain(i), Link);
                double da = arithmeticMean.Calculate(pChain.GetUniformChain(i), Link);
                temp += P*Math.Log(da, 2);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Entropy;
        }
    }
}