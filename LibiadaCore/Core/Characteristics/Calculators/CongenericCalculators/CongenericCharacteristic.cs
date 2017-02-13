namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The congeneric characteristic.
    /// </summary>
    public enum CongenericCharacteristic : byte
    {
        /// <summary>
        /// The arithmetic mean.
        /// </summary>
        [Display(Name = "Arithmetic Mean")]
        ArithmeticMean = 1,

        /// <summary>
        /// The average remoteness.
        /// </summary>
        [Display(Name = "Average Remoteness")]
        AverageRemoteness = 2,

        /// <summary>
        /// The cutting length.
        /// </summary>
        [Display(Name = "Cutting Length")]
        CuttingLength = 3,

        /// <summary>
        /// The cutting length vocabulary entropy.
        /// </summary>
        [Display(Name = "Cutting Length Vocabulary Entropy")]
        CuttingLengthVocabularyEntropy = 4,

        /// <summary>
        /// The depth.
        /// </summary>
        [Display(Name = "Depth")]
        Depth = 5,

        /// <summary>
        /// The descriptive information.
        /// </summary>
        [Display(Name = "Descriptive Information")]
        DescriptiveInformation = 6,

        /// <summary>
        /// The elements count.
        /// </summary>
        [Display(Name = "Elements Count")]
        ElementsCount = 7,

        /// <summary>
        /// The geometric mean.
        /// </summary>
        [Display(Name = "Geometric Mean")]
        GeometricMean = 8,

        /// <summary>
        /// The identification information.
        /// </summary>
        [Display(Name = "Identification Information")]
        IdentificationInformation = 9,

        /// <summary>
        /// The intervals count.
        /// </summary>
        [Display(Name = "Intervals Count")]
        IntervalsCount = 10,

        /// <summary>
        /// The intervals sum.
        /// </summary>
        [Display(Name = "Intervals Sum")]
        IntervalsSum = 11,

        /// <summary>
        /// The length.
        /// </summary>
        [Display(Name = "Length")]
        Length = 12,

        /// <summary>
        /// The periodicity.
        /// </summary>
        [Display(Name = "Periodicity")]
        Periodicity = 13,

        /// <summary>
        /// The probability.
        /// </summary>
        [Display(Name = "Probability")]
        Probability = 14,

        /// <summary>
        /// The regularity.
        /// </summary>
        [Display(Name = "Regularity")]
        Regularity = 15,

        /// <summary>
        /// The uniformity.
        /// </summary>
        [Display(Name = "Uniformity")]
        Uniformity = 16,

        /// <summary>
        /// The variations count.
        /// </summary>
        [Display(Name = "Variations Count")]
        VariationsCount = 17,

        /// <summary>
        /// The volume.
        /// </summary>
        [Display(Name = "Volume")]
        Volume = 18
    }
}
