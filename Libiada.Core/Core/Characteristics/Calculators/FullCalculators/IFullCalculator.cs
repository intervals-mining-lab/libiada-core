namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The Full sequence calculator interface.
/// </summary>
public interface IFullCalculator
{
    /// <summary>
    /// Calculate integral value of characteristic (for complete sequence).
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// May be redundant for some characteristics.
    /// </param>
    /// <returns>
    /// Characteristic value as <see cref="double"/>.
    /// </returns>
    double Calculate(ComposedSequence sequence, Link link);
}
