namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Involved partial dependence coefficient of binary chain.
    /// </summary>
    public class InvolvedPartialDependenceCoefficient : BinaryCalculator
    {
        /// <summary>
        /// Коэффициент частичной зависимоти.
        /// </summary>
        /// <param name="manager">
        /// Intervals manager.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Среднегеометрический интервал
        /// </returns>
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            if (manager.FirstElement.Equals(manager.SecondElement))
            {
                return 0;
            }

            var redundancyCalculator = new Redundancy();

            double redundancy = redundancyCalculator.Calculate(manager, link);
            int pairs = manager.PairsCount;
            return redundancy * (2 * pairs) / (manager.FirstChain.OccurrencesCount + manager.SecondChain.OccurrencesCount);
        }
    }
}