namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Interface of binary calculators.
/// </summary>
public interface IBinaryCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="manager">
    /// Intervals manager.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of characteristic.
    /// </returns>
    double Calculate(BinaryIntervalsManager manager, Link link);

    /// <summary>
    /// Calculates relative characteristics of all pairs of elements.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// <see cref="List{List{double}}"/>.
    /// </returns>
    List<List<double>> CalculateAll(ComposedSequence sequence, Link link);
}
