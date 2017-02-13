using System.ComponentModel.DataAnnotations;

namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    public enum CongenericCharacteristic : byte
    {
        [Display(Name = "Arithmetic Mean")]
        ArithmeticMean = 1,

        [Display(Name = "Average Remoteness")]
        AverageRemoteness = 2,

        [Display(Name = "Cutting Length")]
        CuttingLength = 3,

        [Display(Name = "Cutting Length Vocabulary Entropy")]
        CuttingLengthVocabularyEntropy = 4,

        [Display(Name = "Depth")]
        Depth = 5,

        [Display(Name = "Descriptive Information")]
        DescriptiveInformation = 6,

        [Display(Name = "Elements Count")]
        ElementsCount = 7,

        [Display(Name = "Geometric Mean")]
        GeometricMean = 8,

        [Display(Name = "Identification Information")]
        IdentificationInformation = 9,

        [Display(Name = "Intervals Count")]
        IntervalsCount = 10,

        [Display(Name = "Intervals Sum")]
        IntervalsSum = 11,

        [Display(Name = "Length")]
        Length = 12,

        [Display(Name = "Periodicity")]
        Periodicity = 13,

        [Display(Name = "Probability")]
        Probability = 14,

        [Display(Name = "Regularity")]
        Regularity = 15,

        [Display(Name = "Uniformity")]
        Uniformity = 16,

        [Display(Name = "Variations Count")]
        VariationsCount = 17,

        [Display(Name = "Volume")]
        Volume = 18
    }
}