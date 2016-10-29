namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using System.Linq;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Average geometric value of interval length.
    /// </summary>
    public class GeometricMean : BinaryCalculator, ICalculator
    {
        /// <summary>
        /// Depth characteristic calculator.
        /// </summary>
        private readonly ICalculator averageRemoteness = new AverageRemoteness();

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average geometric of intervals lengths as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            double remoteness = averageRemoteness.Calculate(chain, link);

            return Math.Pow(2, remoteness);
        }

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average geometric of intervals lengths as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double remoteness = averageRemoteness.Calculate(chain, link);

            return Math.Pow(2, remoteness);
        }

        /// <summary>
        /// Calculated as geometric mean between two congeneric sequences.
        /// </summary>
        /// <param name="manager">
        /// Intervals manager.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average geometric value.
        /// </returns>
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            // dependence of the component on itself is 0.
            if (manager.FirstElement.Equals(manager.SecondElement))
            {
                return 0;
            }

            int[] intervals = manager.GetIntervals();

            double result = intervals.Where(t => t > 0).Sum(t => Math.Log(t, 2));

            return Math.Pow(2, intervals.Length == 0 ? 0 : result / intervals.Length);
        }
    }
}
