using System.Collections;

namespace Segmentation.Classes.AuxiliaryClasses
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