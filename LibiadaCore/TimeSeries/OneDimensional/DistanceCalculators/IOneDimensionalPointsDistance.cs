namespace LibiadaCore.TimeSeries.OneDimensional.DistanceCalculators
{
    /// <summary>
    /// The OneDimensionalPointsDistance interface.
    /// </summary>
    public interface IOneDimensionalPointsDistance
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
        double GetDistance(double firstPoint, double secondPoint);
    }
}