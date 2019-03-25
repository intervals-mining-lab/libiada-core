namespace LibiadaCore.TimeSeries.OneDimensional
{
    public interface ITimeSeriesDistanceCalculator
    {
        double GetDistance(double[] firstTimeSeries, double[] secondTimeSeries);
    }
}