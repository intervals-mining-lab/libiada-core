using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes
{
    public class SimpleFilter : Filter
    {
        public IDataForStd MakeFilteration(IDataForStd std, int length, int i)
        {
            if (std.Positions.Count == 0)
            {
                return new NullDataForStd();
            }
            int pos = 1;
            int pred = (int)std.Positions[0];
            while (std.Positions.Count > pos)
            {
                if (((int)std.Positions[pos] - pred) < i)
                {
                    std.Positions.RemoveAt(pos);
                    std.DecrimentN();
                }
                else
                {
                    pred = (int)std.Positions[pos];
                }
                pos++;
            }
            return std;
        }
    }
}