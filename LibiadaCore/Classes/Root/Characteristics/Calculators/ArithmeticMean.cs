namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Среднее арифметическое значение длин интервалов.
    ///</summary>
    public class ArithmeticMean : ICharacteristicCalculator
    {
        /// <summary>
        /// Для однородной цепи данная характеристика 
        /// вычисляется как 1/вероятность или чеастоту её элемента.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(UniformChain chain, LinkUp Link)
        {
            Probability probability = new Probability();
            return 1 / probability.Calculate(chain, Link);
        }

        ///<summary>
        /// Вычисляется как среднее значение от среднего интервала однородных цепей
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            double sum = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                sum += Calculate(pChain.UniformChain(i), Link);
            }
            return sum/pChain.Alphabet.Power;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}