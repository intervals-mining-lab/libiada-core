namespace LibiadaCore.Core.Characteristics.Calculators.AccordanceCalculators
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The accordance characteristic.
    /// </summary>
    public enum AccordanceCharacteristic : byte
    {
        /// <summary>
        /// The mutual compliance degree.
        /// </summary>
        [Display(Name = "Mutual Compliance Degree")]
        MutualComplianceDegree = 1,

        /// <summary>
        /// The partial compliance degree.
        /// </summary>
        [Display(Name = "Partial Compliance Degree")]
        PartialComplianceDegree = 2
    }
}
