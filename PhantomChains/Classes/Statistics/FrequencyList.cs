using System;
using System.Collections;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace PhantomChains.Classes.Statistics
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class FrequencyList : Alphabet, IBaseObject
    {
        private ArrayList pFrequency = new ArrayList();

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        public FrequencyList(FrequencyListBin bin)
        {
            foreach (FrequencyListItemBin element in bin.Elements)
            {
                vault.Add(element.Key.GetInstance());
                pFrequency.Add((int) (ValueInt) element.Value.GetInstance());
            }
        }

        ///<summary>
        ///</summary>
        public FrequencyList()
        {
        }

        public new IBin GetBin()
        {
            FrequencyListBin Temp = new FrequencyListBin();
            FillBin(Temp);
            return Temp;
        }

        protected virtual void FillBin(FrequencyListBin temp)
        {
            for (int i = 0; i < vault.Count; i++)
            {
                FrequencyListItemBin item = new FrequencyListItemBin();
                item.Key = ((IBaseObject)vault[i]).GetBin();
                item.Value = (ValueIntBin) ((ValueInt) (int) pFrequency[i]).GetBin();
                temp.Elements.Add(item);
            }
        }

        ///<summary>
        ///</summary>
        public ArrayList Frequency
        {
            get { return (ArrayList) pFrequency.Clone(); }
        }

        /// <summary>
        /// Возвращает частоту появления объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int FrequencyFromObject(IBaseObject obj)
        {
            if (vault.Contains(obj))
                return (int) Frequency[vault.IndexOf(obj)];
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
                pFrequency.Add(1);
            }
            else pFrequency[result] = (int) pFrequency[result] + 1;

            return result;
        }

        /// <summary>
        /// Удаление элемента из частотного словаря по номеру
        /// </summary>
        /// <param name="index">номер удаляемого элемента</param>
        public override void Remove(int index)
        {
            base.Remove(index);
            pFrequency.RemoveAt(index);
        }

        ///<summary>
        ///</summary>
        ///<param name="o"></param>
        public void Remove(IBaseObject o)
        {
            int pos = IndexOf(o);
            pFrequency[pos] = (int) pFrequency[pos] - 1;
            if ((int) pFrequency[pos] == 0)
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
            FLNew.vault = (ArrayList) vault.Clone();
            FLNew.pFrequency = (ArrayList) pFrequency.Clone();
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
                    new DictionaryEntryBase(((IBaseObject) vault[index]).Clone(), (ValueInt) ((int) pFrequency[index]));
            }
        }

        ///<summary>
        ///</summary>
        public ArrayList Keys
        {
            get { return (ArrayList) vault.Clone(); }
        }

        ///<summary>
        ///</summary>
        public ArrayList Values
        {
            get { return (ArrayList) pFrequency.Clone(); }
        }

        ///<summary>
        ///</summary>
        public int Count
        {
            get
            {
                int temp = 0;
                foreach (int value in pFrequency)
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
            for (int i = 0; i < intervals.power; i++)
            {
                IBaseObject value = intervals[i].Key;
                ValueInt valueCount = (ValueInt) intervals[i].Value;
                if (!Contains(value))
                {
                    Add(value);
                    valueCount = valueCount - 1;
                }
                pFrequency[IndexOf(value)] = (int) pFrequency[IndexOf(value)] + valueCount;
            }
        }
    }

    ///<summary>
    ///</summary>
    public class FrequencyListBin:IBin
    {
        public ArrayList Elements = new ArrayList();

        public IBaseObject GetInstance()
        {
            return new FrequencyList(this);
        }
    }

    ///<summary>
    ///</summary>
    public class FrequencyListItemBin
    {
        public IBin Key;
        public ValueIntBin Value;
    }
}