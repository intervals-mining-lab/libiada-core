namespace Libiada.Core.Core;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

/// <summary>
/// Represents binding mode of the intervals in the sequence.
/// In other words which of the intervals on the ends 
/// of the sequence are taken into account and in what manner.
/// </summary>
public enum BindingMode : byte
{
    /// <summary>
    /// Binding mode is not applied in characteristic calculation (or otherwise).
    /// If passed to intervals manager exception will be thrown.
    /// </summary>
    [Display(Name = "Binding mode not applicable")]
    [Description("Binding mode can not be applied")]
    NotApplicable = 0,

    /// <summary>
    /// With normal binding mode each element gets one corresponding interval.
    /// </summary>
    [Display(Name = "Normal binding mode")]
    [Description("Each element gets one corresponding interval")]
    Normal = 1,

    /// <summary>
    /// Cyclic binding mode closes sequence into a loop 
    /// and each element gets one corresponding interval.
    /// </summary>
    [Display(Name = "Cyclic binding mode")]
    [Description("Сloses sequence into a loop and each element gets one corresponding interval")]
    Cyclic = 2,

    /// <summary>
    /// With lossy binding mode only intervals between elements are taken into account.
    /// And no interval to the either end of the sequence is considered.
    /// </summary>
    [Display(Name = "Lossy binding mode")]
    [Description("Only intervals between elements are taken into account")]
    Lossy = 3,

    /// <summary>
    /// With redundant binding mode intervals to the both ends of the sequence are taken into account.
    /// And nubber of intervals is greater than number of elements.
    /// </summary>
    [Display(Name = "Redundant binding mode")]
    [Description("Intervals to the both ends of the sequence are taken into account")]
    Redundant = 4
}
