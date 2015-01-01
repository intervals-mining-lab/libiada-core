

namespace BuildingsIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using LibiadaCore.Misc;

    /// <summary>
    /// Генерирует все возможные сочетания
    /// </summary>
    public class ScramblingGenerator
    {
        /// <summary>
        /// The alphabet.
        /// </summary>
        private Alphabet alphabet;

        /// <summary>
        /// The length.
        /// </summary>
        private int length;

        /// <summary>
        /// The characteristic.
        /// </summary>
        private List<LinkedCharacteristic> characteristic;

        /// <summary>
        /// Генерирует хештаблицу со всеми возможными строями в качестве ключа,
        /// и списком характеристик в качестве значения
        /// </summary>
        /// <param name="alphabet">Алфавит на основе которого генерируем цепочки</param>
        /// <param name="len">Длинна генерируемых цепочек</param>
        /// <param name="charact">Массив интерфейсов вычисляемых характеристик</param>
        /// <returns></returns>
        public ChainPicksWithCharacteristics Generate(Alphabet alphabet, int len, List<LinkedCharacteristic> charact)
        {
            this.alphabet = alphabet;
            length = len;
            characteristic = charact;

            var hashTable = new Hashtable();

            // По всем возможным цепочкам (Для оптимизации скорости генерируется цепочки с одинаковой первой буквой)
            for (int i = 0; i < Math.Pow(alphabet.Cardinality, length - 1); i++)
            {
                Chain chain = GenerateChain(i);
                List<double> characteristics = CalculateCharacteristics(chain);
                try
                {
                    hashTable.Add(ArrayManipulator.ArrayToString(chain.Building), characteristics);
                }
                catch (Exception)
                {
                }
            }

            return new ChainPicksWithCharacteristics(hashTable, charact);
        }

        /// <summary>
        /// The calculate characteristics.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<double> CalculateCharacteristics(Chain chain)
        {
            var characteristics = new List<double>(characteristic.Count);
            foreach (LinkedCharacteristic calculator in characteristic)
            {
                characteristics.Add(calculator.Calc.Calculate(chain, calculator.Link));
            }

            return characteristics;
        }

        /// <summary>
        /// The generate chain.
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The <see cref="Chain"/>.
        /// </returns>
        private Chain GenerateChain(int i)
        {
            // Очередная цепочка
            var chain = new Chain(length);

            // Переменная для хранения остатка от деления на основание системы счисления (Мощность алфавита)
            int temp = i;

            // Индекс в очередной генерируемой цепи
            int index = 0;

            // По всем элементам
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
