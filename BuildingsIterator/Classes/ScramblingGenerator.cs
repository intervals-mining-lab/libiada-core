using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;

namespace BuildingsIterator.Classes
{
    ///<summary>
    /// Генерирует все возможные сочетания
    ///</summary>
    public class ScramblingGenerator
    {
        private Alphabet alphabet;
        private int Length;
        private List<LinkedUpCharacteristic> characteristic;
        ///<summary>
        /// Генерирует хештаблицу со всеми возможными строями в качестве ключа, 
        /// и списком характеристик в качестве значения
        ///</summary>
        ///<param name="alph">Алфавит на основе которого генерируем цепочки</param>
        ///<param name="len">Длинна генерируемых цепочек</param>
        ///<param name="charact">Массив интерфейсов вычисляемых характеристик</param>
        ///<returns></returns>
        public ChainPicksWithCharacteristics Generate(Alphabet alph, int len, List<LinkedUpCharacteristic> charact)
        {
            alphabet = alph;
            Length = len;
            characteristic = charact;

            Hashtable hTable = new Hashtable();
            //По всем возможным цепочкам (Для оптимизации скорости генерируется цепочки с одинаковой первой буквой)
            for (int i = 0; i < Math.Pow(alphabet.power, Length-1); i++)
            {
                Chain chain = GenerateChain(i);
                List<double> characteristics = CalculateCharacteristics(chain);
                try
                {
                    hTable.Add(ConvertArray.ArrayToString(chain.Building), characteristics);
                }
                catch(Exception)
                {
                    ;
                }
            }
            return new ChainPicksWithCharacteristics(hTable, charact);
        }

        private List<double> CalculateCharacteristics(Chain chain)
        {
            List<double> characteristics = new List<double>(characteristic.Count);
            foreach (LinkedUpCharacteristic calculator in characteristic)
            {
                characteristics.Add(chain.GetCharacteristic(calculator.LinkUp, calculator.Calc));
            }
            return characteristics;
        }

        private Chain GenerateChain(int i)
        {
            //Очередная цепочка
            Chain chain = new Chain(Length);
            //Переменная для хранения остатка от деления на основание системы счисления (Мощность алфавита)
            int temp = i;
            //Индекс в очередной генерируемой цепи
            int index = 0;
            //По всем элементам
            for (int j = Length - 1; j >= 0; j--)
            {
                int element = (int)(temp / Math.Pow(alphabet.power, j));
                chain.Add(alphabet[element], index);
                temp = (int)(temp % Math.Pow(alphabet.power, j));
                index++;
            }
            return chain;
        }
    }
}
