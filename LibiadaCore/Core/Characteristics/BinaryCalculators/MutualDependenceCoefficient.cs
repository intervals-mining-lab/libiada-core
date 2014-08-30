namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Mutual dependence coefficient of binary chain.
    /// </summary>
    public class MutualDependenceCoefficient : BinaryCalculator
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
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            if (manager.FirstElement.Equals(manager.SecondElement))
            {
                return 0;
            }

            var involvedCoefficientCalculator = new InvolvedPartialDependenceCoefficient();
            double firstInvolvedCoefficient = involvedCoefficientCalculator.Calculate(manager, link);
            double secondInvolvedCoefficient = involvedCoefficientCalculator.Calculate(new BinaryIntervalsManager(manager.SecondChain, manager.FirstChain), link);
            return firstInvolvedCoefficient < 0 || secondInvolvedCoefficient < 0 ? 0 : Math.Sqrt(firstInvolvedCoefficient * secondInvolvedCoefficient);
        }
    }
}