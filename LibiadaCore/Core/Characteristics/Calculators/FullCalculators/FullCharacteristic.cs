using System.ComponentModel.DataAnnotations;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    public enum FullCharacteristic : byte
    {
        [Display(Name = "Alphabet Cardinality")]
        AlphabetCardinality = 1,

        [Display(Name = "Alphabetic Average Remoteness")]
        AlphabeticAverageRemoteness = 2,

        [Display(Name = "Alphabetic Depth")]
        AlphabeticDepth = 3,

        [Display(Name = "Arithmetic Mean")]
        ArithmeticMean = 4,

        [Display(Name = "ATS kew")]
        ATSkew = 5,

        [Display(Name = "Average Remoteness")]
        AverageRemoteness = 6,

        [Display(Name = "Average Remoteness ATS kew")]
        AverageRemotenessATSkew = 7,

        [Display(Name = "Average Remoteness Dispersion")]
        AverageRemotenessDispersion = 8,

        [Display(Name = "Average Remoteness GC Ratio")]
        AverageRemotenessGCRatio = 9,

        [Display(Name = "Average Remoteness GCS kew")]
        AverageRemotenessGCSkew = 10,

        [Display(Name = "Average Remoteness GCToAT Ratio")]
        AverageRemotenessGCToATRatio = 11,

        [Display(Name = "Average Remoteness Kurtosis")]
        AverageRemotenessKurtosis = 12,

        [Display(Name = "Average Remoteness Kurtosis Coefficient")]
        AverageRemotenessKurtosisCoefficient = 13,

        [Display(Name = "Average Remoteness MKS kew")]
        AverageRemotenessMKSkew = 14,

        [Display(Name = "Average Remoteness RYS kew")]
        AverageRemotenessRYSkew = 15,

        [Display(Name = "Average Remoteness S kewness")]
        AverageRemotenessSkewness = 16,

        [Display(Name = "Average Remoteness S kewness Coefficient")]
        AverageRemotenessSkewnessCoefficient = 17,

        [Display(Name = "Average Remoteness Standard Deviation")]
        AverageRemotenessStandardDeviation = 18,

        [Display(Name = "Average Remoteness SWS kew")]
        AverageRemotenessSWSkew = 19,

        [Display(Name = "Average Word Length")]
        AverageWordLength = 20,

        [Display(Name = "Cutting Length")]
        CuttingLength = 21,

        [Display(Name = "Cutting Length Vocabulary Entropy")]
        CuttingLengthVocabularyEntropy = 22,

        [Display(Name = "Depth")]
        Depth = 23,

        [Display(Name = "Descriptive Information")]
        DescriptiveInformation = 24,

        [Display(Name = "Elements Count")]
        ElementsCount = 25,

        [Display(Name = "Entropy Dispersion")]
        EntropyDispersion = 26,

        [Display(Name = "Entropy Kurtosis")]
        EntropyKurtosis = 27,

        [Display(Name = "Entropy Kurtosis Coefficient")]
        EntropyKurtosisCoefficient = 28,

        [Display(Name = "Entropy S kewness")]
        EntropySkewness = 29,

        [Display(Name = "Entropy S kewness Coefficient")]
        EntropySkewnessCoefficient = 30,

        [Display(Name = "Entropy Standard Deviation")]
        EntropyStandardDeviation = 31,

        [Display(Name = "GC Ratio")]
        GCRatio = 32,

        [Display(Name = "GC S kew")]
        GCSkew = 33,

        [Display(Name = "GCToAT Ratio")]
        GCToATRatio = 34,

        [Display(Name = "Geometric Mean")]
        GeometricMean = 35,

        [Display(Name = "Identification Information")]
        IdentificationInformation = 36,

        [Display(Name = "Intervals Count")]
        IntervalsCount = 37,

        [Display(Name = "Intervals Sum")]
        IntervalsSum = 38,

        [Display(Name = "Length")]
        Length = 39,

        [Display(Name = "MK S kew")]
        MKSkew = 40,

        [Display(Name = "Periodicity")]
        Periodicity = 41,

        [Display(Name = "Probability")]
        Probability = 42,

        [Display(Name = "Regularity")]
        Regularity = 43,

        [Display(Name = "Remoteness Dispersion")]
        RemotenessDispersion = 44,

        [Display(Name = "Remoteness Kurtosis")]
        RemotenessKurtosis = 45,

        [Display(Name = "Remoteness Kurtosis Coefficient")]
        RemotenessKurtosisCoefficient = 46,

        [Display(Name = "Remoteness S kewness")]
        RemotenessSkewness = 47,

        [Display(Name = "Remoteness S kewness Coefficient")]
        RemotenessSkewnessCoefficient = 48,

        [Display(Name = "Remoteness Standard Deviation")]
        RemotenessStandardDeviation = 49,

        [Display(Name = "RYS kew")]
        RYSkew = 50,

        [Display(Name = "SWS kew")]
        SWSkew = 51,

        [Display(Name = "Uniformity")]
        Uniformity = 52,

        [Display(Name = "Variations Count")]
        VariationsCount = 53,

        [Display(Name = "Volume")]
        Volume = 54
    }
}