using System;
using System.Collections;
using ChainAnalises.Classes.TheoryOfGraphs;

namespace ChainAnalises.Classes.DataMining
{
    ///<summary>
    ///</summary>
    public class Dictionary : IEnumerable
    {
        private  ArrayList pKeys = new ArrayList();
        private ArrayList pValues = new ArrayList();

        ///<summary>
        ///</summary>
        public ArrayList Keys
        {
            get { return new ArrayList(pKeys); }
        }

        ///<summary>
        ///</summary>
        public int Count
        {
            get { return pKeys.Count; }
        }

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        ///<param name="value"></param>
        ///<exception cref="Exception"></exception>
        public void Add(Branch branch, double value)
        {
            if (pKeys.Contains(branch))
            {
                throw new Exception();
            }
            pKeys.Add(branch);
            pValues.Add(value);
        }

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        public double this[Branch branch]
        {
            get { return pKeys.Contains(branch) ? (double) pValues[pKeys.IndexOf(branch)] : double.NaN; }
            set
            {
                if (pKeys.Contains(branch))
                {
                    pValues[pKeys.IndexOf(branch)] = value;
                }else
                {
                    Add(branch, value);
                }
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public object Clone()
        {
            
            Dictionary Temp = new Dictionary();
            Temp.pKeys = (ArrayList) pKeys.Clone();
            Temp.pValues = (ArrayList) pValues.Clone();
            return Temp;
        }

        public IEnumerator GetEnumerator()
        {
            ArrayList Temp = new ArrayList();
            for (int i = 0; i < pKeys.Count; i++)
            {
                Temp.Add(new DictionaryEntry(pKeys[i], pValues[i]));
            }
            return Temp.GetEnumerator();
        }

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        public void Remove(Branch branch)
        {
            pValues.Remove(pKeys.IndexOf(branch));
            pKeys.Remove(branch);
        }
    }
}