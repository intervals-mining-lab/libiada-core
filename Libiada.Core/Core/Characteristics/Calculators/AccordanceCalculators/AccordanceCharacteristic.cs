namespace Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The accordance characteristic.
/// </summary>
public enum AccordanceCharacteristic : byte
{
    /// <summary>
    /// The mutual compliance degree.
    /// </summary>
    [Display(Name = "Mutual compliance degree")]
    [Description("Geometric mean of two partial compliances degrees")]
    MutualComplianceDegree = 1,

    /// <summary>
    /// The partial compliance degree.
    /// </summary>
    [Display(Name = "Partial compliance degree")]
    [Description(" ")]
    PartialComplianceDegree = 2
}
