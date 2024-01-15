namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    using System;

    using LibiadaCore.Core.ArrangementManagers;

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
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// Mutual dependence coefficient
        /// </returns>
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            // dependence of the component on itself is 0
            if (manager.FirstElement.Equals(manager.SecondElement))
            {
                return 0;
            }

            var involvedCoefficientCalculator = new InvolvedPartialDependenceCoefficient();

            double firstInvolvedCoefficient = involvedCoefficientCalculator.Calculate(manager, link);
            double secondInvolvedCoefficient = involvedCoefficientCalculator.Calculate(new BinaryIntervalsManager(manager.SecondChain, manager.FirstChain), link);
            double multipliedInvolvedCoefficient = firstInvolvedCoefficient * secondInvolvedCoefficient;
            return (firstInvolvedCoefficient < 0 || secondInvolvedCoefficient < 0) ? 0 : Math.Sqrt(multipliedInvolvedCoefficient);
        }
    }
}
