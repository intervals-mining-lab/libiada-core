namespace Libiada.Segmenter.Model.Seekers;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public enum DeviationCalculationMethod : byte
{
    [Display(Name = "Average interval difference")]
    [Description("")]
    AverageIntervalDifference = 1,

    [Display(Name = "Probability method")]
    [Description("")]
    ProbabilityMethod = 2,

    [Display(Name = "Null")]
    [Description("")]
    Null = 3
}