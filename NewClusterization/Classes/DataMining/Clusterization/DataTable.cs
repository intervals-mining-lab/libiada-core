using System;
using System.Collections;
using System.Collections.Specialized;
using LibiadaCore.Classes.Root;

namespace NewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class DataTable :IBaseObject, IEnumerable
    {
        private readonly HybridDictionary vault = new HybridDictionary();

        ///<summary>
        ///</summary>
        public DataTable()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="s"></param>
        public DataObject this[long s]
        {
            get { return (DataObject) vault[s]; }
        }

        public long Count
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
    }
}
