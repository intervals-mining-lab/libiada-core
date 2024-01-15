namespace Libiada.Core.TimeSeries.OneDimensional.DistanceCalculators;

using System.ComponentModel;

public class DistanceCalculatorsFactory
{
    public IOneDimensionalPointsDistance GetDistanceCalculator(DistanceCalculator calculator)
    {
        switch (calculator)
        {
            case DistanceCalculator.EuclideanDistanceBetweenOneDimensionalPointsCalculator:
                return new EuclideanDistanceBetweenOneDimensionalPointsCalculator();
            case DistanceCalculator.HammingDistanceBetweenOneDimensionalPointsCalculator:
                return new HammingDistanceBetweenOneDimensionalPointsCalculator();
            default:
                throw new InvalidEnumArgumentException(nameof(calculator), (int)calculator, typeof(DistanceCalculator));
        }
    }
}