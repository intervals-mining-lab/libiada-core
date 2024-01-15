namespace Libiada.Segmenter.Model.Threshold;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public enum Threshold : byte
{
    [Display(Name = "Dichotomous threshold")]
    [Description("")]
    Dichotomous = 1,

    [Display(Name = "Linear threshold")]
    [Description("")]
    Linear = 2,

    [Display(Name = "Random threshold")]
    [Description("")]
    Random = 3,

    [Display(Name = "Logarithmic threshold")]
    [Description("")]
    Log = 4
}