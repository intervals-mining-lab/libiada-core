namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// The GC to AT ratio of congeneric average remotenesses.
/// </summary>
public class AverageRemotenessGCToATRatio : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// G+C Ratio value as <see cref="double"/> .
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

        CongenericCalculators.AverageRemoteness congenericRemotenessCalculator = new();

        double g = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
        double c = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
        double a = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
        double t = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);

        return a + t == 0 ? 0 : (g + c) / (a + t);
    }
}
