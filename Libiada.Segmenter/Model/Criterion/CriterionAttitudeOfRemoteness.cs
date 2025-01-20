namespace Libiada.Segmenter.Model.Criterion;

using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// Provides search for a criterion of integrity the following rule
/// Average word length is no more than the ratio of log2(Interval(M))/log2(Interval(m))
/// </summary>
public class CriterionAttitudeOfRemoteness : Criterion
{
    /// <summary>
    /// The word average length.
    /// </summary>
    private readonly AverageWordLength wordAverageLength = new();

    /// <summary>
    /// The remoteness.
    /// </summary>
    private readonly AverageRemoteness remoteness = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionAttitudeOfRemoteness"/> class.
    /// </summary>
    /// <param name="threshold">
    /// A rule for handling a threshold value.
    /// </param>
    /// <param name="precision">
    /// Additional value to.
    /// </param>
    public CriterionAttitudeOfRemoteness(ThresholdVariator threshold, double precision) : base(threshold, precision)
    {
        Value = double.MinValue;
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
        double distortion = Distortion(sequence, alphabet);
        if (Math.Abs(Value) < Math.Abs(distortion))
        {
            this.sequence = sequence.Clone();
            this.alphabet = alphabet.Clone();
            Value = distortion;
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
        return (remoteness.Calculate(sequence, sequence.Anchor) / remoteness.Calculate(sequence.Original(), sequence.Anchor)) - wordAverageLength.Calculate(sequence);
    }
}
