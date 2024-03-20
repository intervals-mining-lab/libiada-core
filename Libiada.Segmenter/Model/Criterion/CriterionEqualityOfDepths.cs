namespace Libiada.Segmenter.Model.Criterion;

using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// Criterion "Equality of depths". Goal to find a chain with the same amount of information
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
        double currentDistortion = depth.Calculate(chain, chain.Anchor); // - calculate(gamutDeep, chain);
        if (Math.Abs(currentDistortion) > Value)
        {
            this.chain = chain.Clone();
            this.alphabet = alphabet.Clone();
            ThresholdToStop.SaveBest();
            Value = currentDistortion;
        }

        return ThresholdToStop.Distance > ThresholdVariator.Precision;
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
        return depth.Calculate(chain.Original(), chain.Anchor); // - gamutDeep.Calculate(chain);
    }
}
