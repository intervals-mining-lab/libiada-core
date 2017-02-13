namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The full characteristic.
    /// </summary>
    public enum FullCharacteristic : byte
    {
        /// <summary>
        /// The alphabet cardinality.
        /// </summary>
        [Display(Name = "Alphabet Cardinality")]
        AlphabetCardinality = 1,

        /// <summary>
        /// The alphabetic average remoteness.
        /// </summary>
        [Display(Name = "Alphabetic Average Remoteness")]
        AlphabeticAverageRemoteness = 2,

        /// <summary>
        /// The alphabetic depth.
        /// </summary>
        [Display(Name = "Alphabetic Depth")]
        AlphabeticDepth = 3,

        /// <summary>
        /// The arithmetic mean.
        /// </summary>
        [Display(Name = "Arithmetic Mean")]
        ArithmeticMean = 4,

        /// <summary>
        /// The at skew.
        /// </summary>
        [Display(Name = "ATS kew")]
        ATSkew = 5,

        /// <summary>
        /// The average remoteness.
        /// </summary>
        [Display(Name = "Average Remoteness")]
        AverageRemoteness = 6,

        /// <summary>
        /// The average remoteness at skew.
        /// </summary>
        [Display(Name = "Average Remoteness ATS kew")]
        AverageRemotenessATSkew = 7,

        /// <summary>
        /// The average remoteness dispersion.
        /// </summary>
        [Display(Name = "Average Remoteness Dispersion")]
        AverageRemotenessDispersion = 8,

        /// <summary>
        /// The average remoteness gc ratio.
        /// </summary>
        [Display(Name = "Average Remoteness GC Ratio")]
        AverageRemotenessGCRatio = 9,

        /// <summary>
        /// The average remoteness gc skew.
        /// </summary>
        [Display(Name = "Average Remoteness GCS kew")]
        AverageRemotenessGCSkew = 10,

        /// <summary>
        /// The average remoteness gc to at ratio.
        /// </summary>
        [Display(Name = "Average Remoteness GCToAT Ratio")]
        AverageRemotenessGCToATRatio = 11,

        /// <summary>
        /// The average remoteness kurtosis.
        /// </summary>
        [Display(Name = "Average Remoteness Kurtosis")]
        AverageRemotenessKurtosis = 12,

        /// <summary>
        /// The average remoteness kurtosis coefficient.
        /// </summary>
        [Display(Name = "Average Remoteness Kurtosis Coefficient")]
        AverageRemotenessKurtosisCoefficient = 13,

        /// <summary>
        /// The average remoteness mk skew.
        /// </summary>
        [Display(Name = "Average Remoteness MKS kew")]
        AverageRemotenessMKSkew = 14,

        /// <summary>
        /// The average remoteness ry skew.
        /// </summary>
        [Display(Name = "Average Remoteness RYS kew")]
        AverageRemotenessRYSkew = 15,

        /// <summary>
        /// The average remoteness skewness.
        /// </summary>
        [Display(Name = "Average Remoteness Skewness")]
        AverageRemotenessSkewness = 16,

        /// <summary>
        /// The average remoteness skewness coefficient.
        /// </summary>
        [Display(Name = "Average Remoteness Skewness Coefficient")]
        AverageRemotenessSkewnessCoefficient = 17,

        /// <summary>
        /// The average remoteness standard deviation.
        /// </summary>
        [Display(Name = "Average Remoteness Standard Deviation")]
        AverageRemotenessStandardDeviation = 18,

        /// <summary>
        /// The average remoteness sw skew.
        /// </summary>
        [Display(Name = "Average Remoteness SWS kew")]
        AverageRemotenessSWSkew = 19,

        /// <summary>
        /// The average word length.
        /// </summary>
        [Display(Name = "Average Word Length")]
        AverageWordLength = 20,

        /// <summary>
        /// The cutting length.
        /// </summary>
        [Display(Name = "Cutting Length")]
        CuttingLength = 21,

        /// <summary>
        /// The cutting length vocabulary entropy.
        /// </summary>
        [Display(Name = "Cutting Length Vocabulary Entropy")]
        CuttingLengthVocabularyEntropy = 22,

        /// <summary>
        /// The depth.
        /// </summary>
        [Display(Name = "Depth")]
        Depth = 23,

        /// <summary>
        /// The descriptive information.
        /// </summary>
        [Display(Name = "Descriptive Information")]
        DescriptiveInformation = 24,

        /// <summary>
        /// The elements count.
        /// </summary>
        [Display(Name = "Elements Count")]
        ElementsCount = 25,

        /// <summary>
        /// The entropy dispersion.
        /// </summary>
        [Display(Name = "Entropy Dispersion")]
        EntropyDispersion = 26,

        /// <summary>
        /// The entropy kurtosis.
        /// </summary>
        [Display(Name = "Entropy Kurtosis")]
        EntropyKurtosis = 27,

        /// <summary>
        /// The entropy kurtosis coefficient.
        /// </summary>
        [Display(Name = "Entropy Kurtosis Coefficient")]
        EntropyKurtosisCoefficient = 28,

        /// <summary>
        /// The entropy skewness.
        /// </summary>
        [Display(Name = "Entropy Skewness")]
        EntropySkewness = 29,

        /// <summary>
        /// The entropy skewness coefficient.
        /// </summary>
        [Display(Name = "Entropy Skewness Coefficient")]
        EntropySkewnessCoefficient = 30,

        /// <summary>
        /// The entropy standard deviation.
        /// </summary>
        [Display(Name = "Entropy Standard Deviation")]
        EntropyStandardDeviation = 31,

        /// <summary>
        /// The gc ratio.
        /// </summary>
        [Display(Name = "GC Ratio")]
        GCRatio = 32,

        /// <summary>
        /// The gc skew.
        /// </summary>
        [Display(Name = "GC S kew")]
        GCSkew = 33,

        /// <summary>
        /// The gc to at ratio.
        /// </summary>
        [Display(Name = "GCToAT Ratio")]
        GCToATRatio = 34,

        /// <summary>
        /// The geometric mean.
        /// </summary>
        [Display(Name = "Geometric Mean")]
        GeometricMean = 35,

        /// <summary>
        /// The identification information.
        /// </summary>
        [Display(Name = "Identification Information")]
        IdentificationInformation = 36,

        /// <summary>
        /// The intervals count.
        /// </summary>
        [Display(Name = "Intervals Count")]
        IntervalsCount = 37,

        /// <summary>
        /// The intervals sum.
        /// </summary>
        [Display(Name = "Intervals Sum")]
        IntervalsSum = 38,

        /// <summary>
        /// The length.
        /// </summary>
        [Display(Name = "Length")]
        Length = 39,

        /// <summary>
        /// The mk skew.
        /// </summary>
        [Display(Name = "MK S kew")]
        MKSkew = 40,

        /// <summary>
        /// The periodicity.
        /// </summary>
        [Display(Name = "Periodicity")]
        Periodicity = 41,

        /// <summary>
        /// The probability.
        /// </summary>
        [Display(Name = "Probability")]
        Probability = 42,

        /// <summary>
        /// The regularity.
        /// </summary>
        [Display(Name = "Regularity")]
        Regularity = 43,

        /// <summary>
        /// The remoteness dispersion.
        /// </summary>
        [Display(Name = "Remoteness Dispersion")]
        RemotenessDispersion = 44,

        /// <summary>
        /// The remoteness kurtosis.
        /// </summary>
        [Display(Name = "Remoteness Kurtosis")]
        RemotenessKurtosis = 45,

        /// <summary>
        /// The remoteness kurtosis coefficient.
        /// </summary>
        [Display(Name = "Remoteness Kurtosis Coefficient")]
        RemotenessKurtosisCoefficient = 46,

        /// <summary>
        /// The remoteness skewness.
        /// </summary>
        [Display(Name = "Remoteness Skewness")]
        RemotenessSkewness = 47,

        /// <summary>
        /// The remoteness skewness coefficient.
        /// </summary>
        [Display(Name = "Remoteness Skewness Coefficient")]
        RemotenessSkewnessCoefficient = 48,

        /// <summary>
        /// The remoteness standard deviation.
        /// </summary>
        [Display(Name = "Remoteness Standard Deviation")]
        RemotenessStandardDeviation = 49,

        /// <summary>
        /// The ry skew.
        /// </summary>
        [Display(Name = "RYS kew")]
        RYSkew = 50,

        /// <summary>
        /// The sw skew.
        /// </summary>
        [Display(Name = "SWS kew")]
        SWSkew = 51,

        /// <summary>
        /// The uniformity.
        /// </summary>
        [Display(Name = "Uniformity")]
        Uniformity = 52,

        /// <summary>
        /// The variations count.
        /// </summary>
        [Display(Name = "Variations Count")]
        VariationsCount = 53,

        /// <summary>
        /// The volume.
        /// </summary>
        [Display(Name = "Volume")]
        Volume = 54
    }
}
