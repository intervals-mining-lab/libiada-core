using System.ComponentModel.DataAnnotations;

namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    public enum BinaryCharacteristic : byte
    {
        [Display(Name = "Geometric mean")]
        GeometricMean = 1,

        [Display(Name = "Involved Partial Dependence Coefficient")]
        InvolvedPartialDependenceCoefficient = 2,

        [Display(Name = "Mutual Dependence Coefficient")]
        MutualDependenceCoefficient = 3,

        [Display(Name = "Normalized Partial Dependence Coefficient")]
        NormalizedPartialDependenceCoefficient = 4,

        [Display(Name = "Partial Dependence Coefficient")]
        PartialDependenceCoefficient = 5,

        [Display(Name = "Redundancy")]
        Redundancy = 6
    }
}