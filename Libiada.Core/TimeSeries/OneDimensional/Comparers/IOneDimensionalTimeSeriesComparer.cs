namespace LibiadaCore.TimeSeries.OneDimensional.Comparers
{
    /// <summary>
    /// The OneDimensionalTimeSeriesComparer interface.
    /// </summary>
    public interface IOneDimensionalTimeSeriesComparer
    {
        /// <summary>
        /// The get distance.
        /// </summary>
        /// <param name="firstTimeSeries">
        /// The first time series.
        /// </param>
        /// <param name="secondTimeSeries">
        /// The second time series.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double GetDistance(double[] firstTimeSeries, double[] secondTimeSeries);
    }
}