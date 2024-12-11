namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Kurtosis coefficient of the identifying informations in congeneric sequences.
/// Equals to entropy kurtosis coefficient when cyclic binding is used.
/// </summary>
public class IdentifyingInformationKurtosisCoefficient : IFullCalculator
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
    /// Identifying informations kurtosis coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double identifyingInformationStandardDeviation = new IdentifyingInformationStandardDeviation().Calculate(chain, link);
        if (identifyingInformationStandardDeviation == 0) return 0;

        double identifyingInformationKurtosis = new IdentifyingInformationKurtosis().Calculate(chain, link);

        return identifyingInformationKurtosis / (identifyingInformationStandardDeviation * identifyingInformationStandardDeviation * identifyingInformationStandardDeviation * identifyingInformationStandardDeviation);
    }
}
