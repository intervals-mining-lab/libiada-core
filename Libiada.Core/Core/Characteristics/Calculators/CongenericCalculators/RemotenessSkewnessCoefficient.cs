﻿namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness skewness coefficient.
/// </summary>
public class RemotenessSkewnessCoefficient : ICongenericCalculator
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
    /// Standard Deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        double standardDeviation = new RemotenessStandardDeviation().Calculate(chain, link);
        if (standardDeviation == 0) return 0;

        double remotenessSkewness = new RemotenessSkewness().Calculate(chain, link);

        return remotenessSkewness / (standardDeviation * standardDeviation * standardDeviation);
    }
}
