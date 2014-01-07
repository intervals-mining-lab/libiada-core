using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
    /// Энтропия, количество информации по Шеннону.
    ///</summary>
    public class IdentificationInformation : ICalculator
    {
        private readonly ArithmeticMean arithmeticMean = new ArithmeticMean();

        public double Calculate(CongenericChain chain, Link link)
        {
            double mean = arithmeticMean.Calculate(chain, link);
            return -1/mean*Math.Log(1/mean, 2);
        }

        public double Calculate(Chain chain, Link link)
        {
            double result = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result += Calculate(chain.CongenericChain(i), link);
            }
            return result;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Entropy;
        }
    }
}