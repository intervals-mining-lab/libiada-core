using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    public class DBBuilding : Node
    {
        private int private_length;
        private string private_value;

        public virtual int length
        {
            get { return private_length; }
            set { private_length = value; }
        }

        public virtual string value
        {
            get { return private_value; }
            set { private_value = value; }
        }
    }
}