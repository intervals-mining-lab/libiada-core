namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Sequence length.
    /// Link is not used in calculation.
    /// </summary>
    public class Length : NonLinkableCongenericCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// Chain length as <see cref="double"/>.
        /// </returns>
        public override double Calculate(CongenericChain chain)
        {
            return chain.GetLength();
        }
    }
}
