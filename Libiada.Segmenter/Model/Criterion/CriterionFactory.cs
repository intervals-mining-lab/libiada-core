namespace Libiada.Segmenter.Model.Criterion;

using System.ComponentModel;
using Segmenter.Model.Threshold;

/// <summary>
/// Creates one of available criterion
/// </summary>
public static class CriterionFactory
{
    /// <summary>
    /// The make.
    /// </summary>
    /// <param name="criterion">
    /// The segmentation criterion.
    /// </param>
    /// <param name="threshold">
    /// The threshold.
    /// </param>
    /// <param name="precision">
    /// The precision.
    /// </param>
    /// <returns>
    /// The <see cref="Criterion"/>.
    /// </returns>
    public static Criterion Make(SegmentationCriterion criterion, ThresholdVariator threshold, double precision)
    {
        return criterion switch
        {
            SegmentationCriterion.CriterionPartialOrlov => new CriterionPartialOrlov(threshold, precision),
            SegmentationCriterion.CriterionMinSymmetryByShrader => new CriterionMinSymmetryByShrader(threshold, precision),
            SegmentationCriterion.CriterionMinSymmetryByIntervals => new CriterionMinSymmetryByIntervals(threshold, precision),
            SegmentationCriterion.CriterionEqualityOfDepths => new CriterionEqualityOfDepths(threshold, precision),
            SegmentationCriterion.CriterionAttitudeOfRemoteness => new CriterionAttitudeOfRemoteness(threshold, precision),
            SegmentationCriterion.CriterionMinimumRegularity => new CriterionMinimumRegularity(threshold, precision),
            SegmentationCriterion.CriterionGoldenRatio => new CriterionGoldenRatio(threshold, precision),
            _ => throw new InvalidEnumArgumentException(nameof(criterion), (int)criterion, typeof(SegmentationCriterion)),
        };
    }
}
