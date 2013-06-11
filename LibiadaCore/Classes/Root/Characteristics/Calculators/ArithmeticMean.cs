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
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            Probability probability = new Probability();
            return 1 / probability.Calculate(chain, linkUp);
        }

        ///<summary>
        /// Вычисляется как среднее значение от среднего интервала однородных цепей
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            double sum = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                sum += Calculate(chain.UniformChain(i), linkUp);
            }
            return sum/chain.Alphabet.Power;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}