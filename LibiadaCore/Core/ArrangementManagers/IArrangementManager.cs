namespace LibiadaCore.Core.ArrangementManagers
{
    /// <summary>
    /// The intervals manager.
    /// </summary>
    public interface IArrangementManager
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
        int[] GetArrangement(Link link);

        /// <summary>
        /// Initializes arrangement manager.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        void Initialize(CongenericChain chain);
    }
}
