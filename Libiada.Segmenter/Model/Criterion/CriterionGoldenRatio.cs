namespace Libiada.Segmenter.Model.Criterion;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// The criterion of "golden ratio". The basis is the standard law of the golden ratio,
/// where most of the - power of the alphabet and less - the maximum frequency of the word.
/// </summary>
public class CriterionGoldenRatio : Criterion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionGoldenRatio"/> class.
    /// </summary>
    /// <param name="threshold">
    /// A rule for handling a threshold value.
    /// </param>
    /// <param name="precision">
    /// Additional value to.
    /// </param>
    public CriterionGoldenRatio(ThresholdVariator threshold, double precision) : base(threshold, precision)
    {
        Value = double.MaxValue;
    }

    /// <summary>
    /// The state.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool State(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        double current = Distortion(sequence, alphabet);
        if (Value > current)
        {
            Value = current;
            this.sequence = sequence.Clone();
            this.alphabet = alphabet.Clone();
            ThresholdToStop.SaveBest();
        }

        return ThresholdToStop.Distance > ThresholdVariator.Precision;
    }

    /// <summary>
    /// The distortion.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override double Distortion(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        double maxFrequency = MaxFrequency(alphabet);
        double power = alphabet.Count;

        double greaterToSmaller = power / maxFrequency;
        double sumToGreater = (power + maxFrequency) / power;

        return Math.Abs(greaterToSmaller - sumToGreater);
    }

    /// <summary>
    /// The max frequency.
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    private int MaxFrequency(FrequencyDictionary alphabet)
    {
        return alphabet.GetWordsPositions().Max(p => p.Count);
    }
}
