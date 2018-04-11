namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The full characteristic.
    /// </summary>
    public enum FullCharacteristic : byte
    {
        /// <summary>
        /// The alphabet cardinality.
        /// </summary>
        [Display(Name = "Alphabet cardinality")]
        [Description("Count of elements in alphabet of sequence")]
        AlphabetCardinality = 1,

        /// <summary>
        /// The alphabetic average remoteness.
        /// </summary>
        [Display(Name = "Alphabetic average remoteness")]
        [Description("Average remoteness calculated with logarithm base equals to alphabet cardinality")]
        AlphabeticAverageRemoteness = 2,

        /// <summary>
        /// The alphabetic depth.
        /// </summary>
        [Display(Name = "Alphabetic depth")]
        [Description("Depth calculated with logarithm base equals to alphabet cardinality")]
        AlphabeticDepth = 3,

        /// <summary>
        /// The arithmetic mean.
        /// </summary>
        [Display(Name = "Intervals arithmetic mean")]
        [Description("Average arithmetical value of intervals lengthes")]
        ArithmeticMean = 4,

        /// <summary>
        /// The at skew.
        /// </summary>
        [Display(Name = "AT skew")]
        [Description("(A - T) / (A + T)")]
        ATSkew = 5,

        /// <summary>
        /// The average remoteness.
        /// </summary>
        [Display(Name = "Average remoteness")]
        [Description("Remoteness mean of congeneric sequences")]
        AverageRemoteness = 6,

        /// <summary>
        /// The average remoteness at skew.
        /// </summary>
        [Display(Name = "Average remoteness AT skew")]
        [Description("(A - T) / (A + T) calculated for remotenesses")]
        AverageRemotenessATSkew = 7,

        /// <summary>
        /// The average remoteness dispersion.
        /// </summary>
        [Display(Name = "Average remoteness dispersion")]
        [Description("Dispersion of remotenesses of congeneric sequences around average remoteness")]
        AverageRemotenessDispersion = 8,

        /// <summary>
        /// The average remoteness gc ratio.
        /// </summary>
        [Display(Name = "Average remoteness GC ratio")]
        [Description("(G + C) / All * 100% calculated for remotenesses")]
        AverageRemotenessGCRatio = 9,

        /// <summary>
        /// The average remoteness gc skew.
        /// </summary>
        [Display(Name = "Average remoteness GC skew")]
        [Description("(G - C) / (G + C) calculated for remotenesses")]
        AverageRemotenessGCSkew = 10,

        /// <summary>
        /// The average remoteness gc to at ratio.
        /// </summary>
        [Display(Name = "Average remoteness GC/AT ratio")]
        [Description("(G + C) / (A + T) calculated for remotenesses")]
        AverageRemotenessGCToATRatio = 11,

        /// <summary>
        /// The average remoteness kurtosis.
        /// </summary>
        [Display(Name = "Average remoteness kurtosis")]
        [Description("Average remoteness excess")]
        AverageRemotenessKurtosis = 12,

        /// <summary>
        /// The average remoteness kurtosis coefficient.
        /// </summary>
        [Display(Name = "Average remoteness kurtosis coefficient")]
        [Description("Average remoteness excess coefficient")]
        AverageRemotenessKurtosisCoefficient = 13,

        /// <summary>
        /// The average remoteness mk skew.
        /// </summary>
        [Display(Name = "Average remoteness MK skew")]
        [Description("((C + A) - (G + T)) / All calculated for remotenesses")]
        AverageRemotenessMKSkew = 14,

        /// <summary>
        /// The average remoteness ry skew.
        /// </summary>
        [Display(Name = "Average remoteness RY skew")]
        [Description("((G + A) - (C + T)) / All calculated for remotenesses")]
        AverageRemotenessRYSkew = 15,

        /// <summary>
        /// The average remoteness skewness.
        /// </summary>
        [Display(Name = "Average remoteness skewness")]
        [Description("Asymmetry of remotenesses of congeneric sequences compared to average remoteness")]
        AverageRemotenessSkewness = 16,

        /// <summary>
        /// The average remoteness skewness coefficient.
        /// </summary>
        [Display(Name = "Average remoteness skewness coefficient")]
        [Description("Average remoteness assymetry coefficient")]
        AverageRemotenessSkewnessCoefficient = 17,

        /// <summary>
        /// The average remoteness standard deviation.
        /// </summary>
        [Display(Name = "Average remoteness standard deviation")]
        [Description("Scatter of remotenesses of congeneric sequences around average remoteness")]
        AverageRemotenessStandardDeviation = 18,

        /// <summary>
        /// The average remoteness sw skew.
        /// </summary>
        [Display(Name = "Average remoteness SW skew")]
        [Description("((G + C) - (A + T)) / All calculated for remotenesses")]
        AverageRemotenessSWSkew = 19,

        /// <summary>
        /// The average word length.
        /// </summary>
        [Display(Name = "Average word length")]
        [Description("Arithmetic mean of length of words in sequence")]
        AverageWordLength = 20,

        /// <summary>
        /// The cutting length.
        /// </summary>
        [Display(Name = "Cutting length")]
        [Description("Sadovsky's cutting length of l-gramms for unambiguous recovery of source sequence")]
        CuttingLength = 21,

        /// <summary>
        /// The cutting length vocabulary entropy.
        /// </summary>
        [Display(Name = "Cutting length vocabulary entropy")]
        [Description("Vocabulary entropy for sadovsky cutting length")]
        CuttingLengthVocabularyEntropy = 22,

        /// <summary>
        /// The depth.
        /// </summary>
        [Display(Name = "Depth")]
        [Description("Base 2 logarithm of Volume characteristic")]
        Depth = 23,

        /// <summary>
        /// The descriptive information.
        /// </summary>
        [Display(Name = "Descriptive information")]
        [Description("Mazur's descriptive informations count")]
        DescriptiveInformation = 24,

        /// <summary>
        /// The elements count.
        /// </summary>
        [Display(Name = "Elements count")]
        [Description("Count of elements in sequence (equals to length if sequence is full)")]
        ElementsCount = 25,

        /// <summary>
        /// The entropy dispersion.
        /// </summary>
        [Display(Name = "Entropy dispersion")]
        [Description("Dispersion of entropy of congeneric sequences around entropy of complete sequence")]
        EntropyDispersion = 26,

        /// <summary>
        /// The entropy kurtosis.
        /// </summary>
        [Display(Name = "Entropy kurtosis")]
        [Description("Entropy excess")]
        EntropyKurtosis = 27,

        /// <summary>
        /// The entropy kurtosis coefficient.
        /// </summary>
        [Display(Name = "Entropy kurtosis coefficient")]
        [Description("Entropy excess coefficient")]
        EntropyKurtosisCoefficient = 28,

        /// <summary>
        /// The entropy skewness.
        /// </summary>
        [Display(Name = "Entropy skewness")]
        [Description("Entropy assymetry")]
        EntropySkewness = 29,

        /// <summary>
        /// The entropy skewness coefficient.
        /// </summary>
        [Display(Name = "Entropy skewness coefficient")]
        [Description("Entropy assymetry coefficient")]
        EntropySkewnessCoefficient = 30,

        /// <summary>
        /// The entropy standard deviation.
        /// </summary>
        [Display(Name = "Entropy standard deviation")]
        [Description("Scatter of congeneric sequences' entropy around complete sequence entropy")]
        EntropyStandardDeviation = 31,

        /// <summary>
        /// The gc ratio.
        /// </summary>
        [Display(Name = "GC ratio")]
        [Description("(G + C) / All * 100%")]
        GCRatio = 32,

        /// <summary>
        /// The gc skew.
        /// </summary>
        [Display(Name = "GC skew")]
        [Description("(G - C) / (G + C)")]
        GCSkew = 33,

        /// <summary>
        /// The gc to at ratio.
        /// </summary>
        [Display(Name = "GC/AT ratio")]
        [Description("(G + C) / (A + T)")]
        GCToATRatio = 34,

        /// <summary>
        /// The geometric mean.
        /// </summary>
        [Display(Name = "Geometric mean")]
        [Description("Average geometric value of intervals lengthes")]
        GeometricMean = 35,

        /// <summary>
        /// The identification information.
        /// </summary>
        [Display(Name = "Entropy")]
        [Description("Shannon's information or amount of information or count of identification informations")]
        IdentificationInformation = 36,

        /// <summary>
        /// The intervals count.
        /// </summary>
        [Display(Name = "Intervals count")]
        [Description("Count of intervals in sequence")]
        IntervalsCount = 37,

        /// <summary>
        /// The intervals sum.
        /// </summary>
        [Display(Name = "Intervals sum")]
        [Description("Sum of intervals lengthes")]
        IntervalsSum = 38,

        /// <summary>
        /// The length.
        /// </summary>
        [Display(Name = "Sequence length")]
        [Description("Length of sequence measured in elements")]
        Length = 39,

        /// <summary>
        /// The mk skew.
        /// </summary>
        [Display(Name = "MK skew")]
        [Description("((C + A) - (G + T)) / All")]
        MKSkew = 40,

        /// <summary>
        /// The periodicity.
        /// </summary>
        [Display(Name = "Periodicity")]
        [Description("Calculated as geometric mean divided by arithmetic mean")]
        Periodicity = 41,

        /// <summary>
        /// The probability.
        /// </summary>
        [Display(Name = "Frequency")]
        [Description("Frequency or probability")]
        Probability = 42,

        /// <summary>
        /// The regularity.
        /// </summary>
        [Display(Name = "Regularity")]
        [Description("Calculated as geometric mean divided by descriptive informations count")]
        Regularity = 43,

        /// <summary>
        /// The remoteness dispersion.
        /// </summary>
        [Display(Name = "Remoteness dispersion")]
        [Description("Dispersion of lengthes of individual intervals around average remoteness")]
        RemotenessDispersion = 44,

        /// <summary>
        /// The remoteness kurtosis.
        /// </summary>
        [Display(Name = "Remoteness kurtosis")]
        [Description("Remoteness excess")]
        RemotenessKurtosis = 45,

        /// <summary>
        /// The remoteness kurtosis coefficient.
        /// </summary>
        [Display(Name = "Remoteness kurtosis coefficient")]
        [Description("Remoteness excess coefficient")]
        RemotenessKurtosisCoefficient = 46,

        /// <summary>
        /// The remoteness skewness.
        /// </summary>
        [Display(Name = "Remoteness skewness")]
        [Description("Remoteness assymetry")]
        RemotenessSkewness = 47,

        /// <summary>
        /// The remoteness skewness coefficient.
        /// </summary>
        [Display(Name = "Remoteness skewness coefficient")]
        [Description("Remoteness assymetry coefficient")]
        RemotenessSkewnessCoefficient = 48,

        /// <summary>
        /// The remoteness standard deviation.
        /// </summary>
        [Display(Name = "Remoteness standard deviation")]
        [Description("Scatter of individual intervals' lengthes around average remoteness")]
        RemotenessStandardDeviation = 49,

        /// <summary>
        /// The ry skew.
        /// </summary>
        [Display(Name = "RY skew")]
        [Description("((G + A) - (C + T)) / All")]
        RYSkew = 50,

        /// <summary>
        /// The sw skew.
        /// </summary>
        [Display(Name = "SW skew")]
        [Description("((G + C) - (A + T)) / All")]
        SWSkew = 51,

        /// <summary>
        /// The uniformity.
        /// </summary>
        [Display(Name = "Uniformity")]
        [Description("Normalized characteristic calculated as average remoteness substracted from entropy")]
        Uniformity = 52,

        /// <summary>
        /// The variations count.
        /// </summary>
        [Display(Name = "Variations count")]
        [Description("Number of probable sequences that can be generated from given ambiguous sequence")]
        VariationsCount = 53,

        /// <summary>
        /// The volume.
        /// </summary>
        [Display(Name = "Volume")]
        [Description("Calculated as product of all intervals in sequence")]
        Volume = 54,

        /// <summary>
        /// The remoteness standard deviation.
        /// </summary>
        [Display(Name = "Information amount")]
        [Description("The complete amount of information in sequence.")]
        InformationAmount = 55
    }
}
