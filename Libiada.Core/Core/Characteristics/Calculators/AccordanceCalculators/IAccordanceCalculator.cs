namespace Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

/// <summary>
/// The AccordanceCalculator interface.
/// </summary>
public interface IAccordanceCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="firstChain">
    /// The first chain.
    /// </param>
    /// <param name="secondChain">
    /// The second chain.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    double Calculate(CongenericChain firstChain, CongenericChain secondChain, Link link);
}
