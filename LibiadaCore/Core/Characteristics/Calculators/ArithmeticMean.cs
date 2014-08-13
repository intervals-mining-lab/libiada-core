namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Среднее арифметическое значение длин интервалов.
    /// </summary>
    public class ArithmeticMean : ICalculator
    {
        /// <summary>
        /// Intervals length sum calculator.
        /// </summary>
        private readonly ICalculator adder = new IntervalsSum();

        /// <summary>
        /// Intervals count calculator.
        /// </summary>
        private readonly ICalculator counter = new IntervalsCount();

        /// <summary>
        /// Для однородной цепи данная характеристика 
        /// вычисляется как сумма длин всех интервалов делёное на количество интервалов.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of average arithmetic of intervals lengths.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            double sum = adder.Calculate(chain, link);
            double intervalsCount = counter.Calculate(chain, link);
            return sum / intervalsCount;
        }

        /// <summary>
        /// Вычисляется как среднее значение от среднего интервала однородных цепей
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of average arithmetic of intervals lengths.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double sum = adder.Calculate(chain, link);
            double intervalsCount = counter.Calculate(chain, link);
            return sum / intervalsCount;
        }
    }
}