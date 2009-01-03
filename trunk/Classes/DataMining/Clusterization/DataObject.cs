using System;
using System.Collections;
using System.Collections.Specialized;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class DataObject :IBaseObject,  IEnumerable
    {
        private int id;
        private readonly HybridDictionary vault = new HybridDictionary();

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        public DataObject(DataObjectBin bin)
        {
            id = bin.id;
            foreach (DictionaryEntry entry in bin.vault)
            {
                vault.Add(entry.Key, entry.Value);
            }
        }

        ///<summary>
        ///</summary>
        public DataObject()
        {
        }

        ///<summary>
        ///</summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        ///<summary>
        ///</summary>
        ///<param name="s"></param>
        ///<param name="d"></param>
        ///<exception cref="NotImplementedException"></exception>
        public void Add(string s, double d)
        {
            vault.Add(s, d);
        }


        ///<summary>
        ///</summary>
        ///<param name="s"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public double Get(string s)
        {
            return (double) vault[s];
        }

        public IEnumerator GetEnumerator()
        {
            return vault.GetEnumerator();
        }

        ///<summary>
        ///</summary>
        ///<param name="o"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public double Distance(DataObject o)
        {
            IEnumerator From = o.GetEnumerator();
            IEnumerator To = GetEnumerator();
            From.Reset();
            To.Reset();
            double result = 0;
            while( From.MoveNext() && To.MoveNext())
            {
                if (!((DictionaryEntry)From.Current).Key.Equals(((DictionaryEntry)To.Current).Key))
                {
                    throw new Exception("Can not calculate different parameters. First: " + ((DictionaryEntry)From.Current).Key + " Second " + ((DictionaryEntry)To.Current).Key);
                }
                result +=
                    Math.Pow(((double) ((DictionaryEntry) From.Current).Value) -
                             ((double) ((DictionaryEntry) To.Current).Value), 2);
            }

            return Math.Sqrt(result);
        }

        public IBaseObject Clone()
        {
            throw new NotImplementedException();
        }

        public IBin GetBin()
        {
            DataObjectBin Temp =new DataObjectBin();
            Temp.id = id;
            foreach (DictionaryEntry entry in vault)
            {
                Temp.vault.Add(entry);
            }
            return Temp;
        }
    }

    ///<summary>
    ///</summary>
    public class DataObjectBin: IBin
    {
        public int id;
        public ArrayList vault = new ArrayList();

        public IBaseObject GetInstance()
        {
            return new DataObject(this);
        }
    }
}