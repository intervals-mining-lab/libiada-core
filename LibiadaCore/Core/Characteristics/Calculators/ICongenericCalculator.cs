namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// The Congeneric Calculator interface.
    /// </summary>
    public interface ICongenericCalculator
    {
        /// <summary>
        /// Вычисляет и возвращает значение характеристики 
        /// для однородной цеочки.
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