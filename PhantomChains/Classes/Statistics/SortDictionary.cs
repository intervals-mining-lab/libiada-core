using System.Collections.Generic;

namespace PhantomChains.Classes.Statistics
{
    public class SortDictionary
    {
        private SortedList<int, IBaseObject> p_key = null;
        private SortedList<double , int> p_value = null;
        private int id = 0;

        public SortDictionary()
        {
            p_key =  new SortedList<int, IBaseObject>();
            p_value = new SortedList<double, int>();
        }

        public void Add(IBaseObject key, double value)
        {
            p_value.Add(value, id);
            p_key.Add(id, key);
            id++;
        }

        public double GetValue(IBaseObject key)
        {
            int actual_id = p_key.Keys[p_key.IndexOfValue(key)];
            return p_value.Keys[p_value.IndexOfValue(actual_id)];
        }

        public double GetValueByIndex(int i)
        {
            return p_value.Keys[i];
        }

        public int Count()
        {
            return p_value.Count;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public IBaseObject GetKeyByIndex(int i)
        {
            return p_key.Values[p_key.IndexOfKey(p_value.Values[i])];
        }
    }
}