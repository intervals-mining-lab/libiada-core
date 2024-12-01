namespace Libiada.Core.TimeSeries.OneDimensional.DistanceCalculators;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The distance calculator.
/// </summary>
public enum DistanceCalculator : byte
{
    /// <summary>
    /// The euclidean distance between one dimensional points calculator.
    /// </summary>
    [Display(Name = "Euclidean")]
    [Description("Euclidean distance between one dimensional points calculator")]
    EuclideanDistanceBetweenOneDimensionalPointsCalculator = 1,

    [Display(Name = "Hamming")]
    [Description("Hamming distance between one dimensional points calculator")]
    HammingDistanceBetweenOneDimensionalPointsCalculator = 2
}
