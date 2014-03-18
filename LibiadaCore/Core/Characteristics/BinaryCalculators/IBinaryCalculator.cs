namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface of binary calculators.
    /// </summary>
    public interface IBinaryCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="firstElement">
        /// Первый элемент
        /// </param>
        /// <param name="secondElement">
        /// Второй элемент
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of characteristic.
        /// </returns>
        double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link);

        /// <summary>
        /// Calculates relative characteristics of all pairs of elements.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// <see cref="List{List{double}}"/>.
        /// </returns>
        List<List<double>> Calculate(Chain chain, Link link);

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        BinaryCharacteristicsEnum GetCharacteristicName();
    }
}