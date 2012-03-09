using System;
using System.Collections;
using System.Collections.Specialized;
using ChainAnalises.Classes.Root;

namespace NewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class DataTable :IBaseObject, IEnumerable
    {
        private readonly HybridDictionary vault = new HybridDictionary();

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        public DataTable(DataTableBin bin)
        {
            foreach (DictionaryEntry entry in bin.Objects)
            {
                vault.Add(entry.Key, ((DataObjectBin)entry.Value).GetInstance());
            }
        }

        ///<summary>
        ///</summary>
        public DataTable()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="s"></param>
        public DataObject this[int s]
        {
            get { return (DataObject) vault[s]; }
        }

        public int Count
        {
            get { return vault.Count; }
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return vault.GetEnumerator();
        }

        #endregion

        ///<summary>
        ///</summary>
        ///<param name="object1"></param>
        public void Add(DataObject object1)
        {
            vault.Add(object1.Id, object1);
        }

        public IBaseObject Clone()
        {
            throw new NotImplementedException();
        }

        public IBin GetBin()
        {
            DataTableBin Temp = new DataTableBin();
            foreach (DictionaryEntry entry in vault)
            {
                Temp.Objects.Add(new DictionaryEntry(entry.Key, ((IBaseObject) entry.Value).GetBin()));
            }
            return Temp;
        }
    }

    ///<summary>
    ///</summary>
    public class DataTableBin:IBin
    {
        public ArrayList Objects = new ArrayList();

        public IBaseObject GetInstance()
        {
            return new DataTable(this);
        }
    }
}
