namespace BuildingsIterator.Filters
{
    using System.Collections.Generic;

    /// <summary>
    /// Sequences filter by alphabet cardinality.
    /// </summary>
    public class ChinFilterByAlphabetCardinality : IChainFilter
    {
        /// <summary>
        /// The min.
        /// </summary>
        private readonly int min;

        /// <summary>
        /// The max.
        /// </summary>
        private readonly int max;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChinFilterByAlphabetCardinality"/> class.
        /// </summary>
        /// <param name="minAlphabetCardinality">
        /// Minimum alphabet cardinality.
        /// </param>
        /// <param name="maxAlphabetCardinality">
        /// Maximum alphabet cardinality.
        /// </param>
        public ChinFilterByAlphabetCardinality(int minAlphabetCardinality, int maxAlphabetCardinality)
        {
            min = minAlphabetCardinality;
            max = maxAlphabetCardinality;
        }

        /// <summary>
        /// Checks if buildings alphabet cardinality is between minimum and maximum.
        /// </summary>
        /// <param name="building">
        /// Building to check.
        /// </param>
        /// <returns>
        /// True if alphabet cardinality between min and max.
        /// </returns>
        public bool IsValid(string building)
        {
            int cardinality = GetAlphabetPowerFromBuilding(building);
            return (cardinality >= min) && (cardinality <= max);
        }

        /// <summary>
        /// The get alphabet power from building.
        /// </summary>
        /// <param name="building">
        /// The building.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetAlphabetPowerFromBuilding(string building)
        {
            var chars = new List<char>();
            foreach (char t in building)
            {
                if (!chars.Contains(t))
                {
                    chars.Add(t);
                }
            }

            return chars.Count;
        }
    }
}
