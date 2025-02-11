﻿namespace Libiada.Segmenter.Model.Criterion;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// The criterion shreder by words.
/// </summary>
public class CriterionShrederByWords : Criterion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionShrederByWords"/> class.
    /// </summary>
    /// <param name="threshold">
    /// A rule for handle a threshold value.
    /// </param>
    /// <param name="precision">
    /// The precision.
    /// </param>
    public CriterionShrederByWords(ThresholdVariator threshold, double precision)
        : base(threshold, precision)
    {
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
        return false;
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
        return 0;
    }
}
