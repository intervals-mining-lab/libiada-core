using System.Collections.Generic;
using ChainAnalises.Classes.IntervalAnalysis;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    public class DBCalculate
    {
        public List<int> nids = new List<int>();
        private int private_length;
        private int private_uid;
        private LinkUp link;


        public int length
        {
            get { return private_length; }
            set { private_length = value; }
        }

        public int uid
        {
            get { return private_uid; }
            set { private_uid = value; }
        }

        public LinkUp Link
        {
            get { return link; }
            set { link = value; }
        }
    }
}