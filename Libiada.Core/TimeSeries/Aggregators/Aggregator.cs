namespace Libiada.Core.TimeSeries.Aggregators;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The aggregator.
/// </summary>
public enum Aggregator : byte
{
    /// <summary>
    /// The average.
    /// </summary>
    [Display(Name = "Average")]
    [Description("Average aggregator")]
    Average = 1,

    /// <summary>
    /// The difference module.
    /// </summary>
    [Display(Name = "Absolute difference")]
    [Description("Absolute difference aggregator")]
    DifferenceModule = 2,

    /// <summary>
    /// The difference square root.
    /// </summary>
    [Display(Name = "Difference square root")]
    [Description("Difference square root aggregator")]
    DifferenceSquareRoot = 3,

    /// <summary>
    /// The max.
    /// </summary>
    [Display(Name = "Maximum")]
    [Description("Maximum aggregator")]
    Max = 4,

    /// <summary>
    /// The min.
    /// </summary>
    [Display(Name = "Minimum")]
    [Description("Minimum aggregator")]
    Min = 5,

    /// <summary>
    /// The sum module.
    /// </summary>
    [Display(Name = "Absolute sum")]
    [Description("Absolute sum aggregator")]
    SumModule = 6,

    /// <summary>
    /// The sum square root.
    /// </summary>
    [Display(Name = "Sum square root")]
    [Description("Square root of sum aggregator")]
    SumSquareRoot = 7,
}
