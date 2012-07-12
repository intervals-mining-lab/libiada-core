using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Statistics
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class FrequencyList : Alphabet, IBaseObject
    {
        private List<int> frequency = new List<int>();

        ///<summary>
        ///</summary>
        public FrequencyList()
        {
        }

        ///<summary>
        ///</summary>
        public List<int> Frequency
        {
            get { return new List<int>((int[])frequency.ToArray().Clone()); }
        }

        /// <summary>
        /// Возвращает частоту появления объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int FrequencyFromObject(IBaseObject obj)
        {
            if (vault.Contains(obj))
                return Frequency[vault.IndexOf(obj)];
            throw new Exception("В частотном словаре нет указанного объекта");
        }

        /// <summary>
        /// Добавляем элемент в частотный словарь
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override int Add(IBaseObject o)
        {
            int result = IndexOf(o);

            if (result == -1)
            {
                result = base.Add(o);
                frequency.Add(1);
            }
            else frequency[result] = frequency[result] + 1;

            return result;
        }

        /// <summary>
        /// Удаление элемента из частотного словаря по номеру
        /// </summary>
        /// <param name="index">номер удаляемого элемента</param>
        public override void Remove(int index)
        {
            base.Remove(index);
            frequency.RemoveAt(index);
        }

        ///<summary>
        ///</summary>
        ///<param name="o"></param>
        public void Remove(IBaseObject o)
        {
            int pos = IndexOf(o);
            frequency[pos] = frequency[pos] - 1;
            if (frequency[pos] == 0)
            {
                Remove(pos);
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public new IBaseObject Clone()
        {
            FrequencyList FLNew = new FrequencyList();
            FLNew.vault = new List<IBaseObject>((IBaseObject[])vault.ToArray().Clone());
            FLNew.frequency = new List<int>((int[])frequency.ToArray().Clone());
            return FLNew;
        }

        ///<summary>
        ///</summary>
        ///<param name="index"></param>
        public new DictionaryEntryBase this[int index]
        {
            get
            {
                return
                    new DictionaryEntryBase(((IBaseObject) vault[index]).Clone(), (ValueInt) ((int) frequency[index]));
            }
        }

        ///<summary>
        ///</summary>
        public List<IBaseObject> Keys
        {
            get { return new List<IBaseObject>((IBaseObject[])vault.ToArray().Clone()); }
        }

        ///<summary>
        ///</summary>
        public List<int> Values
        {
            get { return new List<int>((int[])frequency.ToArray().Clone()); }
        }

        ///<summary>
        ///</summary>
        public int Count
        {
            get
            {
                int temp = 0;
                foreach (int value in frequency)
                {
                    temp += value;
                }
                return temp;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="intervals"></param>
        public void Sum(FrequencyList intervals)
        {
            for (int i = 0; i < intervals.Power; i++)
            {
                IBaseObject value = intervals[i].Key;
                ValueInt valueCount = (ValueInt) intervals[i].Value;
                if (!Contains(value))
                {
                    Add(value);
                    valueCount = valueCount - 1;
                }
                frequency[IndexOf(value)] = (int) frequency[IndexOf(value)] + valueCount;
            }
        }
    }
}