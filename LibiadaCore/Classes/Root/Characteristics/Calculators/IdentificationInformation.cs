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

        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            double mean = arithmeticMean.Calculate(chain, linkUp);
            return -1/mean*Math.Log(1/mean, 2);
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double result = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result += Calculate(chain.CongenericChain(i), linkUp);
            }
            return result;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Entropy;
        }
    }
}