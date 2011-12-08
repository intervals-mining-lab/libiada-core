using System.Collections;
using ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses;

namespace ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses
{
    public class NullDataForStd : IDataForStd
    {
        public double Probability(int chain_length)
        {
            return 1;
        }

        public bool AddPosition(int i)
        {
            return true;
        }

        public int n
        {
            get { return 1; }
        }

        public ArrayList Positions
        {
            get { return new ArrayList();}
        }

        public void DecrimentN()
        {
            
        }
    }
}