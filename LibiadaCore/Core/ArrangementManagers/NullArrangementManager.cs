﻿namespace LibiadaCore.Core.ArrangementManagers
{
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
            return new int[0];
        }

        /// <summary>
        /// Mock for initialization.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        public void Initialize(CongenericChain chain)
        {
        }
    }
}