namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The congeneric characteristic.
/// </summary>
public enum CongenericCharacteristic : byte
{
    /// <summary>
    /// The arithmetic mean.
    /// </summary>
    [Display(Name = "Intervals arithmetic mean")]
    [Description("Average arithmetical value of intervals lengthes")]
    ArithmeticMean = 1,

    /// <summary>
    /// The average remoteness.
    /// </summary>
    [Display(Name = "Average remoteness")]
    [Description("Depth divided by sequence length")]
    AverageRemoteness = 2,

    /// <summary>
    /// The cutting length.
    /// </summary>
    [Display(Name = "Cutting length")]
    [Description("Sadovsky's cutting length of l-gramms for unambiguous recovery of source sequence")]
    CuttingLength = 3,

    /// <summary>
    /// The cutting length vocabulary entropy.
    /// </summary>
    [Display(Name = "Cutting length vocabulary entropy")]
    [Description("Vocabulary entropy for sadovsky cutting length")]
    CuttingLengthVocabularyEntropy = 4,

    /// <summary>
    /// The depth.
    /// </summary>
    [Display(Name = "Depth")]
    [Description("Base 2 logarithm of Volume characteristic")]
    Depth = 5,

    /// <summary>
    /// The elements count.
    /// </summary>
    [Display(Name = "Elements count")]
    [Description("Count of elements in sequence (equals to length if sequence is full)")]
    ElementsCount = 7,

    /// <summary>
    /// The geometric mean.
    /// </summary>
    [Display(Name = "Geometric mean")]
    [Description("Average geometric value of intervals lengthes")]
    GeometricMean = 8,

    /// <summary>
    /// The identifying informations.
    /// </summary>
    [Display(Name = "Identifying information")]
    [Description("Equals to Shannon's entropy (amount of information) when cyclic binding is used")]
    IdentifyingInformation = 9,

    /// <summary>
    /// The intervals count.
    /// </summary>
    [Display(Name = "Intervals count")]
    [Description("Count of intervals in sequence taking link into account")]
    IntervalsCount = 10,

    /// <summary>
    /// The intervals sum.
    /// </summary>
    [Display(Name = "Intervals sum")]
    [Description("Sum of intervals lengthes")]
    IntervalsSum = 11,

    /// <summary>
    /// The length.
    /// </summary>
    [Display(Name = "Sequence length")]
    [Description("Length of sequence measured in elements")]
    Length = 12,

    /// <summary>
    /// The periodicity.
    /// </summary>
    [Display(Name = "Periodicity")]
    [Description("Calculated as geometric mean divided by arithmetic mean")]
    Periodicity = 13,

    /// <summary>
    /// The probability.
    /// </summary>
    [Display(Name = "Frequency")]
    [Description("Frequency or probability of the element in sequence")]
    Probability = 14,

    /// <summary>
    /// The uniformity.
    /// </summary>
    [Display(Name = "Uniformity")]
    [Description("Normalized characteristic calculated as average remoteness substracted from identifying informations (entropy)")]
    Uniformity = 16,

    /// <summary>
    /// The variations count.
    /// </summary>
    [Display(Name = "Variations count")]
    [Description("Number of probable sequences that can be generated from given ambiguous sequence")]
    VariationsCount = 17,

    /// <summary>
    /// The volume.
    /// </summary>
    [Display(Name = "Volume")]
    [Description("Calculated as product of all intervals in sequence")]
    Volume = 18,

    /// <summary>
    /// The remoteness variance.
    /// </summary>
    [Display(Name = "Remoteness variance")]
    [Description("")]
    RemotenessVariance = 19,

    /// <summary>
    /// The remoteness kurtosis.
    /// </summary>
    [Display(Name = "Remoteness kurtosis")]
    [Description("")]
    RemotenessKurtosis = 20,

    /// <summary>
    /// The remoteness kurtosis coefficient.
    /// </summary>
    [Display(Name = "Remoteness kurtosis coefficient")]
    [Description("")]
    RemotenessKurtosisCoefficient = 21,

    /// <summary>
    /// The remoteness skewness.
    /// </summary>
    [Display(Name = "Remoteness skewness")]
    [Description("")]
    RemotenessSkewness = 22,

    /// <summary>
    /// The remoteness skewness coefficient.
    /// </summary>
    [Display(Name = "Remoteness skewness coefficient")]
    [Description("")]
    RemotenessSkewnessCoefficient = 23,

    /// <summary>
    /// The remoteness standard deviation.
    /// </summary>
    [Display(Name = "Remoteness standard deviation")]
    [Description("")]
    RemotenessStandardDeviation = 24,

    /// <summary>
    /// The remoteness standard deviation.
    /// </summary>
    [Display(Name = "Information amount")]
    [Description("The complete amount of information in sequence.")]
    InformationAmount = 25
}
