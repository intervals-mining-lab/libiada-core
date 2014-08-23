namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// The normalized partial dependence coefficient of binary chain.
    /// </summary>
    public class NormalizedPartialDependenceCoefficient : BinaryCalculator
    {
        /// <summary>
        /// Calculation method.
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
        public override double Calculate(RelationIntervalsManager manager, Link link)
        {
            if (manager.firstElement.Equals(manager.secondElement))
            {
                return 0;
            }

            var partialDependenceCoefficient = new PartialDependenceCoefficient();
            double k1 = partialDependenceCoefficient.Calculate(manager, link);
            int pairs = manager.pairsCount;
            return k1 * 2 * pairs / manager.firstChain.GetLength();
        }
    }
}