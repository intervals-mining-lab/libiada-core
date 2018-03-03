namespace LibiadaCore.Core.IntervalsManagers
{
    /// <summary>
    /// The intervals manager.
    /// </summary>
    public interface ICongenericArrangementManager
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

        /// <summary>
        /// Initializes arrangement manager.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        void Initialize(CongenericChain chain);
    }
}
