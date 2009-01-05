using System.Collections.Generic;
using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    public class DBAlphabet : Node
    {
        private Dictionary<int, DBChainMessage> private_elements;

        public virtual Dictionary<int, DBChainMessage> elements
        {
            get { return private_elements; }
            set { private_elements = value; }
        }
    }
}