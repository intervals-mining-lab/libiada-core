using System;
using System.Collections;
using System.Collections.Generic;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.Project_A;

namespace MarkovCompare
{
    ///<summary>
    /// Класс выборки цепочек с характеристиками
    ///</summary>
    public class ChainPicksWithCharacteristics
    {
        private Hashtable chains;
        private List<CharacteristicsEnum> characteristicsNames;
        private List<LinkedUpCharacteristic> charact;

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="chains">Хеш таблица с цепочками и вычисленными характеристиками</param>
        ///<param name="charact">Массив характеристик и привязок</param>
        public ChainPicksWithCharacteristics(Hashtable chains, List<LinkedUpCharacteristic> charact)
        {
            this.chains = chains;
            this.charact = charact;
            characteristicsNames = new List<CharacteristicsEnum>();
            for (int i = 0; i < charact.Count; i++)
            {
                characteristicsNames.Add(charact[i].Calc.GetCharacteristicName());
            }
        }

        /// <summary>
        /// Возвращает выборку значений конкретной характеристики
        /// </summary>
        /// <param name="charact">Характеристика</param>
        /// <returns>Выборка</returns>
        public Picks GetPicks(CharacteristicsEnum charact)
        {
            Picks picks = new Picks(GetCharacteristicName(characteristicsNames.IndexOf(charact)));
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                picks.Add(((List<double>)iter.Value)[characteristicsNames.IndexOf(charact)]);
            }
            return picks;
        }

        /// <summary>
        /// Возвращает выборку значений конкретной характеристики
        /// </summary>
        /// <returns>Выборка</returns>
        public Picks GetPicks(int i)
        {
            Picks picks = new Picks(GetCharacteristicName(i));
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                picks.Add(((List<double>)iter.Value)[i]);
            }
            return picks;
        }

        /// <summary>
        /// Число цепочек в выборке
        /// </summary>
        public int Count
        {
            get
            {
                return chains.Count;
            }
        }

        ///<summary>
        /// Возвращает вектор характеристик для конкретной цепи
        ///</summary>
        ///<param name="i">Номер цепи в массиве</param>
        ///<returns>Массив характеристик</returns>
        ///<exception cref="Exception">Элемент не найден</exception>
        public List<double> GetCharactVector(int i)
        {
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                if (i == 0)
                    return (List<double>) iter.Value;
                i--;
            }
            throw new Exception("Элемент не найден");
        }

        /// <summary>
        /// Возвращает конкретную цепочку
        /// </summary>
        /// <param name="i">Номер в массиве</param>
        /// <returns>Цепочка в виде строки</returns>
        public string GetChain(int i)
        {
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                if (i == 0)
                    return (string) iter.Key;
                i--;
            }
            throw new Exception("Цепочка не найдена");
        }

        ///<summary>
        /// Возвращает число расчитанных характеристик для каждой цепочки
        ///</summary>
        ///<returns></returns>
        public int GetCharacteristicsCount()
        {
            return characteristicsNames.Count;
        }

        ///<summary>
        /// Возвращает имя характеристики
        ///</summary>
        ///<param name="i">Номер в массиве имен</param>
        ///<returns>Строковое имя</returns>
        public string GetCharacteristicName(int i)
        {
            return characteristicsNames[i].ToString();
        }

        ///<summary>
        /// Возвращает массив всех цепочек
        ///</summary>
        ///<returns></returns>
        public List<string> GetAllChains()
        {
            List<string> result = new List<string>();
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                result.Add((string) iter.Key);
            }
            return result;
        }

        ///<summary>
        ///</summary>
        ///<param name="power"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public ChainPicksWithCharacteristics GetFilteredChainPicks(IChainFilter power)
        {
            Hashtable newChains = new Hashtable();
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                if (power.IsValid((string) iter.Key))
                    newChains.Add(iter.Key, iter.Value);
            }
            return new ChainPicksWithCharacteristics(newChains, charact);
        }

        public void FillChainList(List<string> values)
        {
            throw new NotImplementedException();
        }
    }
}