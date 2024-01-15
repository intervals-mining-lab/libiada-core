using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Segmenter.Model.Criterion
{
    public enum SegmentationCriterion : byte
    {
        [Display(Name = "Partial orlov criterion")]
        [Description("")]
        CriterionPartialOrlov = 1,

        [Display(Name = "Minimal symmetry shrader criterion")]
        [Description("")]
        CriterionMinSymmetryByShrader = 2,

        [Display(Name = "Intervals minimal symmetry criterion")]
        [Description("")]
        CriterionMinSymmetryByIntervals = 3,

        [Display(Name = "Equality of depths criterion")]
        [Description("")]
        CriterionEqualityOfDepths = 4,

        [Display(Name = "Attitude of remoteness criterion")]
        [Description("")]
        CriterionAttitudeOfRemoteness = 5,

        [Display(Name = "Minimum regularity criterion")]
        [Description("")]
        CriterionMinimumRegularity = 6,

        [Display(Name = "Golden ratio criterion")]
        [Description("")]
        CriterionGoldenRatio = 7
    }
}