using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    public class DBMessage : Node
    {
        private string private_value;

        public virtual string value
        {
            get { return private_value; }
            set { private_value = value; }
        }
    }
}