using System.ComponentModel;
using Segmenter.Model.Threshold;

namespace Segmenter.Model.Criterion
{
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
            switch (criterion)
            {
                case SegmentationCriterion.CriterionPartialOrlov:
                    return new CriterionPartialOrlov(threshold, precision);
                case SegmentationCriterion.CriterionMinSymmetryByShrader:
                    return new CriterionMinSymmetryByShrader(threshold, precision);
                case SegmentationCriterion.CriterionMinSymmetryByIntervals:
                    return new CriterionMinSymmetryByIntervals(threshold, precision);
                case SegmentationCriterion.CriterionEqualityOfDepths:
                    return new CriterionEqualityOfDepths(threshold, precision);
                case SegmentationCriterion.CriterionAttitudeOfRemoteness:
                    return new CriterionAttitudeOfRemoteness(threshold, precision);
                case SegmentationCriterion.CriterionMinimumRegularity:
                    return new CriterionMinimumRegularity(threshold, precision);
                case SegmentationCriterion.CriterionGoldenRatio:
                    return new CriterionGoldenRatio(threshold, precision);
                default:
                    throw new InvalidEnumArgumentException(nameof(criterion), (int)criterion, typeof(SegmentationCriterion));
            }
        }
    }
}
