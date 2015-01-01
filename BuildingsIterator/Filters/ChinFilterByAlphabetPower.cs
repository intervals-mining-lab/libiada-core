namespace BuildingsIterator.Filters
{
    using System.Collections.Generic;

    /// <summary>
    /// Фильтр цепочек по мощности алфавита
    /// </summary>
    public class ChinFilterByAlphabetPower : IChainFilter
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
        /// Конструктор фильтра цепочек по мщности алфавита
        /// </summary>
        /// <param name="minAlphabetCardinality">
        /// Минимальное значение мощности
        /// </param>
        /// <param name="maxAlphabetCardinality">
        /// Максимальное значение мощности
        /// </param>
        public ChinFilterByAlphabetPower(int minAlphabetCardinality, int maxAlphabetCardinality)
        {
            min = minAlphabetCardinality;
            max = maxAlphabetCardinality;
        }

        /// <summary>
        /// Возвращает булевое значение валидности результата фильтрации
        /// </summary>
        /// <param name="building">
        /// Строй
        /// </param>
        /// <returns>
        /// true if alphabet cardinality between min and max.
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
