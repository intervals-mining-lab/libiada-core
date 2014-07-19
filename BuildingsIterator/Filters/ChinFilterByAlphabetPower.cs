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
        /// <param name="minAlphPower">
        /// ����������� �������� ��������
        /// </param>
        /// <param name="maxAlphPower">
        /// ������������ �������� ��������
        /// </param>
        public ChinFilterByAlphabetPower(int minAlphPower, int maxAlphPower)
        {
            this.min = minAlphPower;
            this.max = maxAlphPower;
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ���������� ����������
        /// </summary>
        /// <param name="building">
        /// �����
        /// </param>
        /// <returns>
        /// true if alphabet power between min and max.
        /// </returns>
        public bool IsValid(string building)
        {
            int power = this.GetAlphabetPowerFromBuilding(building);
            return (power >= this.min) && (power <= this.max);
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