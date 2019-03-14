namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public interface IDistanceBetweenMultiDimensionalPoints
    {
        double GetDistance(double[] firstPoint, double[] secondPoint);
    }
}