namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// Среднее арифметическое значение длин интервалов.
    /// </summary>
    public class ArithmeticMean : ICalculator
    {
        /// <summary>
        /// Для однородной цепи данная характеристика 
        /// вычисляется как сумма длин всех интервалов делёное на количество интервалов.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var adder = new IntervalsSum();
            double sum = adder.Calculate(chain, link);
            var counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain,link);
            return sum/intervalsCount;
        }

        /// <summary>
        /// Вычисляется как среднее значение от среднего интервала однородных цепей
        /// </summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            var adder = new IntervalsSum();
            double sum = adder.Calculate(chain, link);
            var counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain, link);
            return sum / intervalsCount;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}