namespace LibiadaCore.TimeSeries.Comparers
{
    public interface ITimeSeriesAligner
    {
        (double[][] first, double[][] second) AlignSeries(double[] firstSeries, double[] secondSeries);
    }
}