namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Abstract class common for all binary calculators.
/// </summary>
public abstract class BinaryCalculator : IBinaryCalculator
{
    /// <summary>
    /// Calculation method for two congeneric sequences.
    /// </summary>
    /// <param name="manager">
    /// Intervals manager.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Characteristic value.
    /// </returns>
    public abstract double Calculate(BinaryIntervalsManager manager, Link link);

    /// <summary>
    /// Calculation method for complete matrix of all pairs of elements.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Square matrix of characteristics of all pairs of elements.
    /// </returns>
    public List<List<double>> CalculateAll(ComposedSequence sequence, Link link)
    {
        List<List<double>> result = [];
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result.Add([]);
            for (int j = 0; j < alphabetCardinality; j++)
            {
                result[i].Add(Calculate(sequence.GetRelationIntervalsManager(i + 1, j + 1), link));
            }
        }

        return result;
    }
}
