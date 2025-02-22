namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Kurtosis of the identifying informations in congeneric sequences.
/// Equals to Shannon's entropy (amount of information) kurtosis when cyclic bindind is used.
/// </summary>
public class IdentifyingInformationKurtosis : IFullCalculator
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
    /// Identifying informations (entropy) kurtosis <see cref="double"/> value.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double n = new IntervalsCount().Calculate(sequence, link);
        if (n == 0) return 0;

        CongenericCalculators.IntervalsCount congenericIntervalsCount = new();
        CongenericCalculators.IdentifyingInformation congenericIdentifyingInformation = new();

        double result = 0;
        double h = new IdentifyingInformation().Calculate(sequence, link);
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            double nj = congenericIntervalsCount.Calculate(sequence.CongenericSequence(i), link);
            double hj = congenericIdentifyingInformation.Calculate(sequence.CongenericSequence(i), link);
            double deltaH = hj - h;
            result += deltaH * deltaH * deltaH * deltaH * nj / n;
        }

        return result;
    }
}
