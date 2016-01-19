namespace BuildingsIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using LibiadaCore.Misc;

    /// <summary>
    /// Генерирует все возможные сочетания.
    /// </summary>
    public class ScramblingGenerator
    {
        /// <summary>
        /// Генерирует хештаблицу со всеми возможными строями в качестве ключа,
        /// и списком характеристик в качестве значения.
        /// </summary>
        /// <param name="alphabet">
        /// Alphabet for generated sequences.
        /// </param>
        /// <param name="length">
        /// Length of generated sequences.
        /// </param>
        /// <param name="characteristic">
        /// Calculated characteristics.
        /// </param>
        /// <returns>
        /// The <see cref="ChainPicksWithCharacteristics"/>.
        /// </returns>
        public ChainPicksWithCharacteristics Generate(Alphabet alphabet, int length, List<LinkedCharacteristic> characteristic) 
        {
            var hashTable = new Hashtable();

            // По всем возможным цепочкам (Для оптимизации скорости генерируется цепочки с одинаковой первой буквой)
            for (int i = 0; i < Math.Pow(alphabet.Cardinality, length - 1); i++)
            {
                Chain chain = GenerateChain(alphabet, i, length);
                List<double> characteristics = CalculateCharacteristics(chain, characteristic);
                try
                {
                    hashTable.Add(ArrayManipulator.ArrayToString(chain.Building), characteristics);
                }
                catch (Exception)
                {
                }
            }

            return new ChainPicksWithCharacteristics(hashTable, characteristic);
        }

        /// <summary>
        /// The calculate characteristics.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="characteristic">
        /// The characteristic for calculation.
        /// </param>
        /// <returns>
        /// The <see cref="List{Double}"/>.
        /// </returns>
        private List<double> CalculateCharacteristics(Chain chain, List<LinkedCharacteristic> characteristic)
        {
            var characteristics = new List<double>(characteristic.Count);
            foreach (LinkedCharacteristic calculator in characteristic)
            {
                characteristics.Add(calculator.Calculator.Calculate(chain, calculator.Link));
            }

            return characteristics;
        }

        /// <summary>
        /// The generate chain.
        /// </summary>
        /// <param name="alphabet">
        /// Generated sequence alphabet.
        /// </param>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <param name="length">
        /// Generated sequence length.
        /// </param>
        /// <returns>
        /// The <see cref="Chain"/>.
        /// </returns>
        private Chain GenerateChain(Alphabet alphabet, int i, int length)
        {
            // Очередная цепочка
            var chain = new Chain(length);

            // Переменная для хранения остатка от деления на основание системы счисления (Мощность алфавита)
            int temp = i;

            // Индекс в очередной генерируемой цепи
            int index = 0;

            // cycle through elements
            for (int j = length - 1; j >= 0; j--)
            {
                var element = (int)(temp / Math.Pow(alphabet.Cardinality, j));
                chain.Set(alphabet[element], index);
                temp = (int)(temp % Math.Pow(alphabet.Cardinality, j));
                index++;
            }

            return chain;
        }
    }
}
