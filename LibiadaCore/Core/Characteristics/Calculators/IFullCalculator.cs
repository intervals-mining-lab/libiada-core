namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// »нтерфейс калькул€тора полных цепочек
    /// </summary>
    public interface IFullCalculator
    {
        /// <summary>
        /// ¬ычисл€ет и возвращает значение характеристики 
        /// дл€ полной неоднородной цеочки.
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
        double Calculate(Chain chain, Link link);
    }
}