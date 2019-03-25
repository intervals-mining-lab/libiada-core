namespace LibiadaCore.TimeSeries.OneDimensional
{
    public interface IOneDimensionalTimeSeriesComparer
    {
        double GetDistance(double[] firstTimeSeries, double[] secondTimeSeries);
    }
}