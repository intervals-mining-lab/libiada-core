namespace LibiadaCore.Core.ArrangementManagers
{
    using System;

    /// <summary>
    /// Congeneric arrangement manager implementation for empty sequences.
    /// </summary>
    public class NullArrangementManager : IArrangementManager
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
        public int[] GetArrangement(Link link)
        {
            return Array.Empty<int>();
        }
    }
}
