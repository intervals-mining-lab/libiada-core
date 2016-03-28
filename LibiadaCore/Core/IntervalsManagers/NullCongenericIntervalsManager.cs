namespace LibiadaCore.Core.IntervalsManagers
{
    /// <summary>
    /// Congeneric intervals manager implementation for empty sequences.
    /// </summary>
    public class NullCongenericIntervalsManager : ICongenericIntervalsManager
    {
        /// <summary>
        /// Returns empty array.
        /// </summary>
        /// <param name="link">
        /// Link is not taken into account.
        /// </param>
        /// <returns>
        /// Returns empty array of <see cref="T:int[]"/>.
        /// </returns>
        public int[] GetIntervals(Link link)
        {
            return new int[0];
        }
    }
}
