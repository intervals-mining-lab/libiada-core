namespace BuildingsIterator.Filters
{
    using System.Collections.Generic;

    /// <summary>
    /// ������ ������� �� �������� ��������
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
        /// ����������� ������� ������� �� ������� ��������
        /// </summary>
        /// <param name="minAlphabetCardinality">
        /// ����������� �������� ��������
        /// </param>
        /// <param name="maxAlphabetCardinality">
        /// ������������ �������� ��������
        /// </param>
        public ChinFilterByAlphabetPower(int minAlphabetCardinality, int maxAlphabetCardinality)
        {
            min = minAlphabetCardinality;
            max = maxAlphabetCardinality;
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ���������� ����������
        /// </summary>
        /// <param name="building">
        /// �����
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
