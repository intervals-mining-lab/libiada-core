namespace LibiadaCore.TimeSeries.Comparers
{
    public interface ITimeSeriesComparer
    {
        double Compare(double[] firstSeries, double[] secondSeries);
    }
}