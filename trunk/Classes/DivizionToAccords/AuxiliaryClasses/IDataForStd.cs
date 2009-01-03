using System.Collections;

namespace ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses
{
    public interface IDataForStd
    {
        double Probability(int chain_length);
        bool AddPosition(int i);

        int n
        {
            get;
        }

        ArrayList Positions
        {
            get;
        }

        void DecrimentN();
    }
}