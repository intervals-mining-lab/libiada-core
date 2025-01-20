namespace Libiada.Segmenter.Model.Criterion;

using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// The criterion of minimum regularity.
/// Allows one to identify the most irregular sequence.
/// </summary>
public class CriterionMinimumRegularity : Criterion
{
    /// <summary>
    /// The regularity.
    /// </summary>
    private readonly DescriptiveInformation regularity = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionMinimumRegularity"/> class.
    /// </summary>
    /// <param name="threshold">
    /// A rule for handling a threshold value.
    /// </param>
    /// <param name="precision">
    /// Additional value to.
    /// </param>
    public CriterionMinimumRegularity(ThresholdVariator threshold, double precision) : base(threshold, precision)
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
        double distortion = Distortion(sequence, alphabet);
        if (Math.Abs(Value) > Math.Abs(distortion))
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
        return regularity.Calculate(sequence, sequence.Anchor);
    }
}
