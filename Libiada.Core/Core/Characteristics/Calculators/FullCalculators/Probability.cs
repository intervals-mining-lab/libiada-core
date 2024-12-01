namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Probability (frequency).
/// </summary>
public class Probability : NonLinkableFullCalculator
{
    /// <summary>
    /// For complete (full) sequence always equals 1.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// if chain is full then 1, otherwise percent of filled positions as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        CongenericCalculators.Probability calculator = new();

        double result = 0;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result += calculator.Calculate(chain.CongenericChain(i));
        }

        return result > 1 ? 1 : result;
    }
}
