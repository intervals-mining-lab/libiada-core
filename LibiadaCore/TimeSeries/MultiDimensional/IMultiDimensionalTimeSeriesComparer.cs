namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public interface IMultiDimensionalTimeSeriesComparer
    {
        double GetDistance(double[][] firstTimeSerie, double[][] secondTimeSerie);
    }
}