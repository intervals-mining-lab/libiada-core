using LibiadaCore.TimeSeries.Aggregators;
using LibiadaCore.TimeSeries.Aligners;

namespace LibiadaCore.Tests.TimeSeries.OneDimensional
{
    using LibiadaCore.TimeSeries.OneDimensional;
    using NUnit.Framework;

    [TestFixture]
    public class OneDimensionalTimeSeriesComparerTests
    {
        private static object[][] combination_tests = {
            new object[] {new double[]{1,2,3,4,5}, new double[]{1,2,3,4,5}, 0}
        };

        [TestCaseSource("combination_tests")]

        public void CompareTest(double[] firstSeries, double[] secondSeries, double expected)
        {
            var aligner = new ByShortestAligner();
            var calculator = new EuclideanDistanceBetweenOneDimensionalPointsCalculator();
            var aggregator = new Average();
            var comparer = new OneDimensionalTimeSeriesComparer(aligner, calculator, aggregator);
            double result = comparer.GetDistance(firstSeries, secondSeries);
            Assert.AreEqual(result, expected);
        }
    }
}