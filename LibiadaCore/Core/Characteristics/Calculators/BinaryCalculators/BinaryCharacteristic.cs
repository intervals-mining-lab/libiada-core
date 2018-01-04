namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    using System.ComponentModel;
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
        [Description("Average geometric value of binary intervals lengthes")]
        GeometricMean = 1,

        /// <summary>
        /// The involved partial dependence coefficient.
        /// </summary>
        [Display(Name = "Involved partial dependence coefficient")]
        [Description("Partial dependence coefficient weighted with frequency of elements and their pairs")]
        InvolvedPartialDependenceCoefficient = 2,

        /// <summary>
        /// The mutual dependence coefficient.
        /// </summary>
        [Display(Name = "Mutual dependence coefficient")]
        [Description("Geometric mean of involved partial dependence coefficients")]
        MutualDependenceCoefficient = 3,

        /// <summary>
        /// The normalized partial dependence coefficient.
        /// </summary>
        [Display(Name = "Normalized partial dependence coefficient")]
        [Description("Partial dependence coefficient weighted with sequence length")]
        NormalizedPartialDependenceCoefficient = 4,

        /// <summary>
        /// The partial dependence coefficient.
        /// </summary>
        [Display(Name = "Partial dependence coefficient")]
        [Description("Asymmetric measure of dependence in binary-congeneric sequence")]
        PartialDependenceCoefficient = 5,

        /// <summary>
        /// The redundancy.
        /// </summary>
        [Display(Name = "Redundancy")]
        [Description("Redundancy of coding second element with intervals between itself compared to coding with intervals from first element occurrences")]
        Redundancy = 6
    }
}
