using System.Collections.Generic;
using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    public class DBChainMessage : Node
    {
        private Dictionary<int, DBMessage> private_elements;

        public virtual Dictionary<int, DBMessage> elements
        {
            get { return private_elements; }
            set { private_elements = value; }
        }

    }
}