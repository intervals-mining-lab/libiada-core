using System.ComponentModel.DataAnnotations;

namespace LibiadaCore.Core.Characteristics.Calculators.AccordanceCalculators
{
    public enum AccordanceCharacteristic : byte
    {
        [Display(Name = "Mutual Compliance Degree")]
        MutualComplianceDegree = 1,

        [Display(Name = "Partial Compliance Degree")]
        PartialComplianceDegree = 2
    }
}