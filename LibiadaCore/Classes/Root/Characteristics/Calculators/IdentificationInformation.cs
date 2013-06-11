using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
    /// Энтропия, количество информации.
    ///</summary>
    public class IdentificationInformation : ICharacteristicCalculator
    {
        private readonly ArithmeticMean arithmeticMean = new ArithmeticMean();
        private readonly Probability probability = new Probability();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return Math.Log(arithmeticMean.Calculate(chain, linkUp), 2);
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double temp = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                double p = probability.Calculate(chain.UniformChain(i), linkUp);
                double da = arithmeticMean.Calculate(chain.UniformChain(i), linkUp);
                temp += p*Math.Log(da, 2);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Entropy;
        }
    }
}