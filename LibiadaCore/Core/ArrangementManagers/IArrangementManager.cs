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
        /// Array of intervals and/or series .
        /// </returns>
        int[] GetArrangement(Link link);
    }
}
