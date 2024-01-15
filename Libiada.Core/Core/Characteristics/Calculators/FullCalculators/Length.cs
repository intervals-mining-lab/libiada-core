namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Sequence length.
    /// </summary>
    public class Length : NonLinkableFullCalculator
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
        public override double Calculate(Chain chain)
        {
            return chain.Length;
        }
    }
}
