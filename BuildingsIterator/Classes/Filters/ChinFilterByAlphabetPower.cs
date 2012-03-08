using System.Collections.Generic;

namespace BuildingsIterator.Classes.Filters
{
    ///<summary>
    /// ������ ������� �� �������� ��������
    ///</summary>
    public class ChinFilterByAlphabetPower : IChainFilter
    {
        private int min;
        private int max;

        /// <summary>
        /// ����������� ������� ������� �� ������� ��������
        /// </summary>
        /// <param name="minAlphPower">����������� �������� ��������</param>
        /// <param name="maxAlphPower">������������ �������� ��������</param>
        public ChinFilterByAlphabetPower(int minAlphPower, int maxAlphPower)
        {
            min = minAlphPower;
            max = maxAlphPower;
        }

        ///<summary>
        /// ���������� ������� �������� ���������� ���������� ����������
        ///</summary>
        ///<param name="building">�����</param>
        ///<returns></returns>
        public bool IsValid(string building)
        {
            int power = GetAlphPowerFromBuilding(building);
            return (power <= max) && (power >= min);
        }

        private int GetAlphPowerFromBuilding(string building)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < building.Length; i++)
            {
                if (!chars.Contains(building[i]))
                    chars.Add(building[i]);
            }
            return chars.Count;
        }
    }
}