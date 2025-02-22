namespace Libiada.Core.Core;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

/// <summary>
/// Represents binding (reading direction) of the intervals in the sequence.
/// </summary>
public enum Binding : byte
{
    /// <summary>
    /// Binding is not applied in characteristic calculation (or otherwise).
    /// If passed to intervals manager exception will be thrown.
    /// </summary>
    [Display(Name = "Binding not applicable")]
    [Description("Binding can not be applied")]
    NotApplicable = 0,

    /// <summary>
    /// Binding to the start of the sequence.
    /// Interval from the beginning of the sequence 
    /// to the first element occurrence is taken into account.
    /// And Interval from the last element occurrence 
    /// to the end of the sequence is not taken into account.
    /// </summary>
    [Display(Name = "Binding to the beginning")]
    [Description("Interval from the start of the sequence to the first occurrence of the element is taken into account")]
    Beginning = 1,

    /// <summary>
    /// Binding to the end of the sequence.
    /// And Interval from the last element occurrence 
    /// to the end of the sequence is taken into account.
    /// And Interval from the beginning of the sequence 
    /// to the first element occurrence is not taken into account.
    /// </summary>
    [Display(Name = "To the end")]
    [Description("Interval from the last occurrence of the element to the end of the sequence is taken into account")]
    End = 2
}
