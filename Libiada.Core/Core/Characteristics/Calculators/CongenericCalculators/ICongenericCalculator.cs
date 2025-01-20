namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The congeneric sequence calculator interface.
/// </summary>
public interface ICongenericCalculator
{
    /// <summary>
    /// Calculates value of characteristic of congeneric sequence.
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
    double Calculate(CongenericSequence sequence, Link link);
}
