namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// The AccordanceCalculator interface.
    /// </summary>
    public interface IAccordanceCalculator
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double Calculate(AccordanceIntervalsManager manager, Link link);
    }
}
