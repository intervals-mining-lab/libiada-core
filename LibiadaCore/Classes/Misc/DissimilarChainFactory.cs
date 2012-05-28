using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Misc
{
    /// <summary>
    /// Статический класс, создающий по заданной цепочке
    /// цепочку с разнородным строем.
    /// В качестве элементов используются номера вхождений элементов
    /// <example>
    /// Цепочка                  A|T|T|A|C|G|T|C|A
    /// Строй                    1|2|2|1|3|4|2|3|1
    /// Разнородный строй 1|1|2|2|1|1|3|2|3 
    /// </example>
    /// </summary>
    public static class DissimilarChainFactory
    {
        /// <summary>
        /// Метод получающий из заданной цепочки
        /// цепочку "первых встречных разных"
        /// </summary>
        /// <param name="source">Исходная цепочка</param>
        /// <returns>Разнородная цепочка</returns>
        public static Chain Create(BaseChain source)
        {
            Chain result = new Chain(source.Length);
            Alphabet sourceAlphabet = source.Alphabet;
            List<int> entries = new List<int>();
            for (int j = 0; j < sourceAlphabet.power; j++)
            {
                entries.Add(0);
            }

            for (int i = 0; i < source.Length; i++)
            {
                int entry = ++entries[sourceAlphabet.IndexOf(source[i])];
                result.Add(new ValueInt(entry), i);
            }
            return result;
        }
    }
}
