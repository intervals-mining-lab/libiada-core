using System.Collections.Generic;

namespace BuildingsIterator.Classes.Filters
{
    ///<summary>
    /// Фильтр цепочек по мощности алфавита
    ///</summary>
    public class ChinFilterByAlphabetPower : IChainFilter
    {
        private int min;
        private int max;

        /// <summary>
        /// Конструктор фильтра цепочек по мщности алфавита
        /// </summary>
        /// <param name="minAlphPower">Минимальное значение мощности</param>
        /// <param name="maxAlphPower">Максимальное значение мощности</param>
        public ChinFilterByAlphabetPower(int minAlphPower, int maxAlphPower)
        {
            min = minAlphPower;
            max = maxAlphPower;
        }

        ///<summary>
        /// Возвращает булевое значение валидности результата фильтрации
        ///</summary>
        ///<param name="building">Строй</param>
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