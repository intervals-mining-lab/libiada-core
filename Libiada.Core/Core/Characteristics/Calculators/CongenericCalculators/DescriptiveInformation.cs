namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System;

/// <summary>
/// Mazur's descriptive information.
/// </summary>
public class DescriptiveInformation : ICongenericCalculator
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
    /// Count of descriptive informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        var calculator = new ArithmeticMean();

        double arithmeticMean = calculator.Calculate(chain, link);
        return arithmeticMean == 0 ? 1 : Math.Pow(arithmeticMean, 1 / arithmeticMean);
    }
}
