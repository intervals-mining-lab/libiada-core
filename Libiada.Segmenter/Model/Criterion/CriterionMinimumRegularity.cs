﻿namespace Libiada.Segmenter.Model.Criterion;

using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// The criterion of minimum regularity.
/// Allows you to identify the most irregular chain.
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
        double distortion = Distortion(chain, alphabet);
        if (Math.Abs(Value) > Math.Abs(distortion))
        {
            this.chain = chain.Clone();
            this.alphabet = alphabet.Clone();
            Value = distortion;
            ThresholdToStop.SaveBest();
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
        return regularity.Calculate(chain, chain.Anchor);
    }
}
