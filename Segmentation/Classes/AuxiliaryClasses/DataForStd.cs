using System.Collections;

namespace Segmentation.Classes.AuxiliaryClasses
{
    public class DataForStd: IDataForStd
    {
        private int N=0;
        private readonly ArrayList positions = new ArrayList();

        public int n
        {
            get { return N; }
        }

        public ArrayList Positions
        {
            get { return positions; }
        }

        public void DecrimentN()
        {
            N --;
        }

        public bool AddPosition(int position)
        {
            if (!positions.Contains(position))
            {
                positions.Add(position);
                N++;
                return false;
            }
            else return true;
        }

        public double Probability(int chain_length)
        {
            return (double)n/(double)chain_length;
        }
    }
}