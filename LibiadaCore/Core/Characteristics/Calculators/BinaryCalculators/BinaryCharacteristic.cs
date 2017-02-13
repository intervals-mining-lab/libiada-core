namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The binary characteristic.
    /// </summary>
    public enum BinaryCharacteristic : byte
    {
        /// <summary>
        /// The geometric mean.
        /// </summary>
        [Display(Name = "Geometric mean")]
        GeometricMean = 1,

        /// <summary>
        /// The involved partial dependence coefficient.
        /// </summary>
        [Display(Name = "Involved Partial Dependence Coefficient")]
        InvolvedPartialDependenceCoefficient = 2,

        /// <summary>
        /// The mutual dependence coefficient.
        /// </summary>
        [Display(Name = "Mutual Dependence Coefficient")]
        MutualDependenceCoefficient = 3,

        /// <summary>
        /// The normalized partial dependence coefficient.
        /// </summary>
        [Display(Name = "Normalized Partial Dependence Coefficient")]
        NormalizedPartialDependenceCoefficient = 4,

        /// <summary>
        /// The partial dependence coefficient.
        /// </summary>
        [Display(Name = "Partial Dependence Coefficient")]
        PartialDependenceCoefficient = 5,

        /// <summary>
        /// The redundancy.
        /// </summary>
        [Display(Name = "Redundancy")]
        Redundancy = 6
    }
}
