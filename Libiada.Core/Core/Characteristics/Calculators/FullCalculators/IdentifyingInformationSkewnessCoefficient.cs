namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Normalized asymmetry of the identifying informations in congeneric sequences.
/// In other words asymmetry coefficient (skewness) of identifying informations.
/// Equals to entropy skewness coefficient when cyclic bindind is used.
/// </summary>
public class IdentifyingInformationSkewnessCoefficient : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval and 
    /// intervals count instead of elements frequency 
    /// based on geometric mean interval formula.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Identifying informations (entropy) skewness coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double identifyingInformationStandardDeviation = new IdentifyingInformationStandardDeviation().Calculate(chain, link);
        if (identifyingInformationStandardDeviation == 0) return 0;

        double identifyingInformationSkewness = new IdentifyingInformationSkewness().Calculate(chain, link);

        return identifyingInformationSkewness / (identifyingInformationStandardDeviation * identifyingInformationStandardDeviation * identifyingInformationStandardDeviation);
    }
}
