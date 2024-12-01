namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// The AT skew of congeneric average remotenesses.
/// </summary>
public class AverageRemotenessATSkew : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// AT skew value as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

        CongenericCalculators.AverageRemoteness congenericRemotenessCalculator = new();

        double a = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
        double t = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);

        return a + t == 0 ? 0 : (a - t) / (a + t);
    }
}
