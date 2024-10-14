namespace Libiada.Core.TimeSeries.OneDimensional.Comparers;

using Libiada.Core.TimeSeries.Aggregators;
using Libiada.Core.TimeSeries.Aligners;
using Libiada.Core.TimeSeries.OneDimensional.DistanceCalculators;

/// <summary>
/// The one dimensional time series comparer.
/// </summary>
public class OneDimensionalTimeSeriesComparer : IOneDimensionalTimeSeriesComparer
{
    /// <summary>
    /// The aligner.
    /// </summary>
    private ITimeSeriesAligner aligner;

    /// <summary>
    /// The calculator.
    /// </summary>
    private IOneDimensionalPointsDistance calculator;

    /// <summary>
    /// The aggregator.
    /// </summary>
    private IDistancesAggregator aggregator;

    /// <summary>
    /// Initializes a new instance of the <see cref="OneDimensionalTimeSeriesComparer"/> class.
    /// </summary>
    /// <param name="aligner">
    /// The aligner.
    /// </param>
    /// <param name="calculator">
    /// The calculator.
    /// </param>
    /// <param name="aggregator">
    /// The aggregator.
    /// </param>
    public OneDimensionalTimeSeriesComparer(ITimeSeriesAligner aligner, IOneDimensionalPointsDistance calculator, IDistancesAggregator aggregator = null)
    {
        this.aligner = aligner;
        this.calculator = calculator;
        this.aggregator = aggregator ?? new Min();
    }

    /// <summary>
    /// The get distance between two time series.
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
    public double GetDistance(double[] firstTimeSeries, double[] secondTimeSeries)
    {
        (double[][] first, double[][] second) = this.aligner.AlignSeries(firstTimeSeries, secondTimeSeries);

        double[] aggregated = new double[first.Length];

        for (int i = 0; i < first.Length; i++)
        {
            List<double> distances = [];
            for (int j = 0; j < first[0].Length; j++)
            {
                distances.Add(this.calculator.GetDistance(first[i][j], second[i][j]));
            }

            aggregated[i] = this.aggregator.Aggregate(distances);
        }

        return aggregated.Min();
    }
}
