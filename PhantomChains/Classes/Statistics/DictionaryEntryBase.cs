using System;
using LibiadaCore.Classes.Root;

namespace PhantomChains.Classes.Statistics
{
    ///<summary>
    ///</summary>
    public class DictionaryEntryBase
    {
        private IBaseObject key;
        private IBaseObject value;

        ///<summary>
        ///</summary>
        ///<param name="pkey"></param>
        ///<param name="pvalue"></param>
        public DictionaryEntryBase(IBaseObject pkey, IBaseObject pvalue)
        {
            key = pkey;
            value = pvalue;
        }

        ///<summary>
        ///</summary>
        ///<param name="data"></param>
        public DictionaryEntryBase(DictionaryEntryBaseStruct data)
        {
            key = data.Key;
            value = data.Value;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public object GetDataStruct()
        {
            DictionaryEntryBaseStruct temp = new DictionaryEntryBaseStruct();
            temp.Key = key;
            temp.Value = value;
            return temp;
        }

        ///<summary>
        ///</summary>
        public IBaseObject Key
        {
            get { return key; }
            set { key = value; }
        }

        ///<summary>
        ///</summary>
        public IBaseObject Value
        {
            get { return value; }
            set { this.value = value; }
        }


    }

    ///<summary>
    ///</summary>
    [Serializable]
    public class DictionaryEntryBaseStruct
    {
        public IBaseObject Key;
        public IBaseObject Value;
    }
}