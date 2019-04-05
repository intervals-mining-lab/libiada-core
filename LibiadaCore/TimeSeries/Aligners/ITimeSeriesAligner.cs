namespace LibiadaCore.TimeSeries.Aligners
{
    public interface ITimeSeriesAligner
    {
        (double[][] first, double[][] second) AlignSeries(double[] firstSeries, double[] secondSeries);
    }
}