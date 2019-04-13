namespace LibiadaCore.TimeSeries.OneDimensional
{
    using System;

    /// <summary>
    /// The euclidean distance between one dimensional points calculator.
    /// </summary>
    public class EuclideanDistanceBetweenOneDimensionalPointsCalculator : IOneDimensionalPointsDistance
    {
        /// <summary>
        /// The get distance.
        /// </summary>
        /// <param name="firstPoint">
        /// The first point.
        /// </param>
        /// <param name="secondPoint">
        /// The second point.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetDistance(double firstPoint, double secondPoint)
        {
            return Math.Abs(firstPoint - secondPoint);
        }
    }
}