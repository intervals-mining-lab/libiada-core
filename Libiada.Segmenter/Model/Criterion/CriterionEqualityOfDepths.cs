namespace Libiada.Segmenter.Model.Criterion;

using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// Criterion "Equality of depths". Goal to find a sequence with the same amount of information.
/// </summary>
public class CriterionEqualityOfDepths : Criterion
{
    /// <summary>
    /// The depth.
    /// </summary>
    private readonly Depth depth = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionEqualityOfDepths"/> class.
    /// </summary>
    /// <param name="threshold">
    /// A rule for handling a threshold value.
    /// </param>
    /// <param name="precision">
    /// Additional value to.
    /// </param>
    public CriterionEqualityOfDepths(ThresholdVariator threshold, double precision) : base(threshold, precision)
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
        double currentDistortion = depth.Calculate(sequence, sequence.Anchor); // - calculate(gamutDeep, sequence);
        if (Math.Abs(currentDistortion) > Value)
        {
            this.sequence = sequence.Clone();
            this.alphabet = alphabet.Clone();
            ThresholdToStop.SaveBest();
            Value = currentDistortion;
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
        return depth.Calculate(sequence.Original(), sequence.Anchor); // - gamutDeep.Calculate(sequence);
    }
}
