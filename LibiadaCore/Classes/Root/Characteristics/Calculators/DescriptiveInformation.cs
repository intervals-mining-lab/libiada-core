using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Число описательных информаций.
    ///</summary>
    public class DescriptiveInformation : ICharacteristicCalculator
    {
        private readonly Probability probability = new Probability();
        private readonly ArithmeticMean arithmeticMean = new ArithmeticMean();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            
            double p = probability.Calculate(chain, linkUp);
            double result = Math.Pow(arithmeticMean.Calculate(chain, linkUp), p);
            //Если вся цепь заполнена одинаковыми сообщениями
            //то вероятность равна 1 и считать описательные информации не имеет смысла.
            if (p < 1)
            {
                double pInverse = 1 - p;
                double averageInterval = 1 / pInverse;
                result *= Math.Pow(averageInterval, pInverse);
            }
            return result;
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double temp = 1;

            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                temp *= Math.Pow(arithmeticMean.Calculate(chain.UniformChain(i), linkUp),
                    probability.Calculate(chain.UniformChain(i), linkUp)) ;
            }
            double pSum = probability.Calculate(chain, linkUp);
            if (pSum < 1)
            {
                temp *= Math.Pow(1 / (1 - pSum), 1 - pSum);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.DescriptiveInformation;
        }
    }
}