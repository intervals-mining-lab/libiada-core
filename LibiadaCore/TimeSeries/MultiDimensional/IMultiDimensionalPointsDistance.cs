namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public interface IMultiDimensionalPointsDistance
    {
        double GetDistance(double[] firstPoint, double[] secondPoint);
    }
}