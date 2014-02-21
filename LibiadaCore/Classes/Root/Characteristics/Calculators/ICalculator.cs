namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// »нтерфейс калькул€тора
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// ¬ычисл€ет и возвращает значение характеристики 
        /// дл€ однородной цеочки.
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

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}