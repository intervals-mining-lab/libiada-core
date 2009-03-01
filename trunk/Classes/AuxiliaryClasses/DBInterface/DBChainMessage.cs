using System.Collections;
using System.Collections.Generic;
using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;
using ChainAnalises.Classes.DataMining;

namespace ChainAnalises.Classes.AuxiliaryClasses.DBInterface
{
    public class DBChainMessage : Node
    {
        private IDictionary private_elements = new Hashtable();

        public DBChainMessage()
        {
            Type = "message";
            Title = "Cool";
        }
        

        public virtual IDictionary elements
        {
            get { return private_elements; }
            set { private_elements = value; }
        }

    }
}