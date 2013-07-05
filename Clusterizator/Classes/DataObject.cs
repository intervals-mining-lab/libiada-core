using System;
using System.Collections;
using System.Collections.Specialized;
using LibiadaCore.Classes.Root;

namespace Clusterizator.Classes
{
    ///<summary>
    ///</summary>
    public class DataObject :IBaseObject,  IEnumerable
    {
        public readonly HybridDictionary Vault = new HybridDictionary();

        ///<summary>
        ///</summary>
        public long Id { get; set; }

        ///<summary>
        ///</summary>
        ///<param name="s"></param>
        ///<param name="d"></param>
        ///<exception cref="NotImplementedException"></exception>
        public void Add(string s, double d)
        {
            Vault.Add(s, d);
        }


        ///<summary>
        ///</summary>
        ///<param name="s"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public double Get(string s)
        {
            return (double) Vault[s];
        }

        public IEnumerator GetEnumerator()
        {
            return Vault.GetEnumerator();
        }

        ///<summary>
        ///</summary>
        ///<param name="o"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public double Distance(DataObject o)
        {
            IEnumerator from = o.GetEnumerator();
            IEnumerator to = GetEnumerator();
            from.Reset();
            to.Reset();
            double result = 0;
            while( from.MoveNext() && to.MoveNext())
            {
                if (!((DictionaryEntry)from.Current).Key.Equals(((DictionaryEntry)to.Current).Key))
                {
                    throw new Exception("Can not calculate different parameters. First: " + ((DictionaryEntry)from.Current).Key + " Second " + ((DictionaryEntry)to.Current).Key);
                }
                result +=
                    Math.Pow(((double) ((DictionaryEntry) from.Current).Value) -
                             ((double) ((DictionaryEntry) to.Current).Value), 2);
            }

            return Math.Sqrt(result);
        }

        public IBaseObject Clone()
        {
            throw new NotImplementedException();
        }
    }
}