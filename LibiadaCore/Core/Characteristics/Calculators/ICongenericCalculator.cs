namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// The congeneric chain calculator interface.
    /// </summary>
    public interface ICongenericCalculator
    {
        /// <summary>
        /// Calculates value of characteristic of congeneric sequence.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// May be redundant for some characteristics.
        /// </param>
        /// <returns>
        /// Characteristic value as <see cref="double"/>.
        /// </returns>
        double Calculate(CongenericChain chain, Link link);
    }
}
