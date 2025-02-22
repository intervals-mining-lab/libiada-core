namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Entropy.
/// Equals to Shannon's entropy when cyclic bindind is used.
/// Amount of information.
/// Amount of identifying informations (average for one element).
/// Calculated here using intervals count and arithmetic mean interval.
/// </summary>
public class IdentifyingInformation : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval and 
    /// intervals count instead of elements frequency 
    /// based on geometric mean interval formula.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Count of identifying informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double n = new IntervalsCount().Calculate(sequence, link);
        if (n == 0) return 0;

        CongenericCalculators.ArithmeticMean meanCalculator = new();
        CongenericCalculators.IntervalsCount counter = new();

        double result = 0;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            double arithmeticMean = meanCalculator.Calculate(sequence.CongenericSequence(i), link);
            if (arithmeticMean == 0) continue;

            double nj = counter.Calculate(sequence.CongenericSequence(i), link);
            
            result += (nj / n) * Math.Log2(arithmeticMean);
        }

        return result;
    }
}
