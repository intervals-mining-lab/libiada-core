namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Abstract class common for all binary calculators.
/// </summary>
public abstract class BinaryCalculator : IBinaryCalculator
{
    /// <summary>
    /// Calculation method for two congeneric chains.
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
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Square matrix of characteristics of all pairs of elements.
    /// </returns>
    public List<List<double>> CalculateAll(Chain chain, Link link)
    {
        var result = new List<List<double>>();
        var alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result.Add(new List<double>());
            for (int j = 0; j < alphabetCardinality; j++)
            {
                result[i].Add(Calculate(chain.GetRelationIntervalsManager(i + 1, j + 1), link));
            }
        }

        return result;
    }
}
