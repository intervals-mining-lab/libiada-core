namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// The partial dependence coefficient of binary chain.
    /// </summary>
    public class PartialDependenceCoefficient : BinaryCalculator
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
        /// Partial dependence coefficient.
        /// </returns>
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            if (manager.FirstElement.Equals(manager.SecondElement))
            {
                return 0;
            }

            var redundancyCalculator = new Redundancy();

            double redundancy = redundancyCalculator.Calculate(manager, link);

            return redundancy * manager.PairsCount / manager.SecondChain.OccurrencesCount;
        }
    }
}
