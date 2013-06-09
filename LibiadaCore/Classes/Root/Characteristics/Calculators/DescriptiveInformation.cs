using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Число описательных информаций.
    ///</summary>
    public class DescriptiveInformation : ICharacteristicCalculator
    {
        private Probability probability = new Probability();
        private ArithmeticMean arithmeticMean = new ArithmeticMean();

        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            
            double P = probability.Calculate(pChain, Link);
            double Result = Math.Pow(arithmeticMean.Calculate(pChain, Link), P);
            //Если вся цепь заполнена одинаковыми сообщениями
            //то вероятность равна 1 и считать описательные информации не имеет смысла.
            if (P < 1)
            {
                double P_1 = 1 - P;
                double A_1 = 1 / P_1;
                Result *= Math.Pow(A_1, P_1);
            }
            return Result;
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            double temp = 1;

            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                temp *= Math.Pow(arithmeticMean.Calculate(pChain.GetUniformChain(i), Link),
                    probability.Calculate(pChain.GetUniformChain(i), Link)) ;
            }
            double P_sum = probability.Calculate(pChain, Link);
            if (P_sum < 1)
            {
                temp *= Math.Pow(1 / (1 - P_sum), 1 - P_sum);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.DescriptiveInformation;
        }
    }
}