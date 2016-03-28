namespace LibiadaCore.Core.IntervalsManagers
{
    /// <summary>
    /// The intervals manager.
    /// </summary>
    public interface ICongenericIntervalsManager
    {
        /// <summary>
        /// Returns Intervals with given link.
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="T:int[]"/>.
        /// </returns>
        int[] GetIntervals(Link link);
    }
}
