namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Sequence length.
    /// Link is not used in calculation.
    /// </summary>
    public class Length : IFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Chain length as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return chain.GetLength();
        }
    }
}
