using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Segmenter.Model.Threshold
{
    public enum Threshold : byte
    {
        [Display(Name = "Threshold dichotomous")]
        [Description("")]
        ThresholdDichotomous = 1,

        [Display(Name = "Threshold linear")]
        [Description("")]
        ThresholdLinear = 2,

        [Display(Name = "Threshold random")]
        [Description("")]
        ThresholdRandom = 3
    }
}