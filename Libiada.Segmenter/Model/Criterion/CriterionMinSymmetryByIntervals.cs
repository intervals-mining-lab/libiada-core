namespace Libiada.Segmenter.Model.Criterion;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// The criterion of "minimum symmetry by  intervals".
/// As taxons are the words of the intervals and merons - parts word intervals.
/// </summary>
public class CriterionMinSymmetryByIntervals : Criterion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionMinSymmetryByIntervals"/> class.
    /// </summary>
    /// <param name="threshold">
    /// The threshold.
    /// </param>
    /// <param name="precision">
    /// The precision.
    /// </param>
    public CriterionMinSymmetryByIntervals(ThresholdVariator threshold, double precision)
        : base(threshold, precision)
    {
    }

    /// <summary>
    /// The get taxons value.
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double GetTaxonsValue(FrequencyDictionary alphabet)
    {
        double taxons = 0;

        List<List<int>> positions = alphabet.GetWordsPositions();

        for (int index = 0; index < alphabet.Count; index++)
        {
            int countT = positions[index].Count;
            taxons += (Math.Log(countT) * countT) - countT;
        }

        return taxons;
    }

    /// <summary>
    /// The get merons value.
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double GetMeronsValue(FrequencyDictionary alphabet)
    {
        double merons = 0;

        return merons;
    }

    /// <summary>
    /// The state.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
    {
        return false;
    }

    /// <summary>
    /// The distortion.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
    {
        return -1;
    }
}
