namespace Libiada.Core.TimeSeries.OneDimensional.DistanceCalculators;

using System.ComponentModel;

public class DistanceCalculatorsFactory
{
    public IOneDimensionalPointsDistance GetDistanceCalculator(DistanceCalculator calculator)
    {
        return calculator switch
        {
            DistanceCalculator.EuclideanDistanceBetweenOneDimensionalPointsCalculator => new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            DistanceCalculator.HammingDistanceBetweenOneDimensionalPointsCalculator => new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            _ => throw new InvalidEnumArgumentException(nameof(calculator), (int)calculator, typeof(DistanceCalculator)),
        };
    }
}
