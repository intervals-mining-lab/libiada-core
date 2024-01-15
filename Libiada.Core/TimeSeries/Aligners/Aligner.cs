namespace Libiada.Core.TimeSeries.Aligners;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The aligner.
/// </summary>
public enum Aligner : Byte
{
    /// <summary>
    /// The by shortest aligner.
    /// </summary>
    [Display(Name = "By shortest from left")]
    [Description("By shortest from left aligner")]
    ByShortestAligner = 1,

    /// <summary>
    /// The by shortest from right aligner.
    /// </summary>
    [Display(Name = "By shortest from right")]
    [Description("By shortest from right aligner")]
    ByShortestFromRightAligner = 2,

    /// <summary>
    /// The all offsets aligner.
    /// </summary>
    [Display(Name = "All offsets")]
    [Description("All offsets aligner")]
    AllOffsetsAligner = 3,

    /// <summary>
    /// The first element duplicator.
    /// </summary>
    [Display(Name = "First element duplicate")]
    [Description("First element duplicator")]
    FirstElementDuplicator = 4,

    /// <summary>
    /// The last element duplicator.
    /// </summary>
    [Display(Name = "Last element duplicate")]
    [Description("Last element duplicator")]
    LastElementDuplicator = 5
}