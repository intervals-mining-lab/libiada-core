using System;
using System.Collections;
using System.Collections.Specialized;
using ChainAnalises.Classes.MatrixCalculus;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.DataMining.Clusterization
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

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public Matrix GetDistanceMatrix()
        {
            Matrix Temp = new Matrix(this);
            int i_pos = 0;
            foreach (DictionaryEntry entry1 in vault)
            {
                int i = (int) entry1.Key;
                int j_pos = 0;
                foreach (DictionaryEntry entry2 in vault)
                {
                    int j = (int)entry2.Key;
                    Double value;
                    if (i_pos < j_pos)
                    {
                        value = ((DataObject) entry1.Value).Distance(((DataObject) entry2.Value));
                    }
                    else
                    {
                        if (i_pos > j_pos)
                        {
                            value = Temp.Get(j, i);
                        }else
                        {
                            value = Double.NaN;
                        }
                    }
                    
                    Temp.Set(i, j, value);
                    j_pos++;
                }
                i_pos++;
            }
            return Temp;
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
