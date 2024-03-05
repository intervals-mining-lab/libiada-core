namespace Libiada.Core.TimeSeries.Aligners;

/// <summary>
/// The TimeSeriesAligner interface.
/// </summary>
public interface ITimeSeriesAligner
{
    /// <summary>
    /// The align series.
    /// </summary>
    /// <param name="firstSeries">
    /// The first series.
    /// </param>
    /// <param name="secondSeries">
    /// The second series.
    /// </param>
    /// <returns>
    /// The <see T:cref="(double[][] first, double[][] second)"/>.
    /// </returns>
    (double[][] first, double[][] second) AlignSeries(double[] firstSeries, double[] secondSeries);
}