namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    using LibiadaCore.Core.ArrangementManagers;

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
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// Normalized partial dependence coefficient.
        /// </returns>
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            // dependence of the component on itself is 0
            if (manager.FirstElement.Equals(manager.SecondElement))
            {
                return 0;
            }

            var partialDependenceCoefficient = new PartialDependenceCoefficient();

            double k1 = partialDependenceCoefficient.Calculate(manager, link);
            return k1 * 2 * manager.PairsCount / manager.FirstChain.Length;
        }
    }
}
