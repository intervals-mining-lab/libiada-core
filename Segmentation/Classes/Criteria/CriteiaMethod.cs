using System;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.AuxiliaryClasses;
using Segmentation.Classes.DataCollectors;

namespace Segmentation.Classes.Criteria
{
    public abstract class CriteiaMethod
    {
        public abstract double Frequncy(IDataForStd std, int chain_length, int window_length);

        public double DesignExpected(Chain accord, IDataForStd std, int length, int i, IDataCollector mines_one,
                                     IDataCollector midl)
        {
            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(accord, i - 1, 1);
            it.Next();
            IDataForStd Left = mines_one[it.Current()];
            it.Next();
            IDataForStd Right = mines_one[it.Current()];
            IDataForStd Middle = null;
            if (i-2 != 0)
            {
                it = new IteratorStart<Chain, Chain>(accord, i - 2, 1);
                it.Next();
                it.Next();
                Middle = midl[it.Current()];
            }else
            {
                Middle = midl[null];
            }
            double criteria = (Frequncy(Left, length, i - 1)*Frequncy(Right, length, i - 1))/
                              Frequncy(Middle, length, i - 2);
            return criteria;
        }

        public double IntervalEstimate(Chain chain, IDataForStd std, int length, int i, LinkUp link)
        {
            if (std.Positions.Count == 0) return 0;
            int Start = (int) std.Positions[0] + 1;
            int End = length - (int) std.Positions[std.Positions.Count - 1] - (i - 1);
            int pred = (int) std.Positions[0];
            double multiplicate = 1;
            int j = 1;
            if (std.Positions.Count > 1)
            {
                for (j = 1; j < std.Positions.Count; j++)
                {
                    int current = (int) std.Positions[j];
                    multiplicate = multiplicate*(current - pred - (i - 1));
                    pred = current;
                }
            }

            switch (link)
            {
                case LinkUp.Start:
                    return 1 / Math.Pow(multiplicate * Start, 1 / (double)(j));
                case LinkUp.End:
                    return 1 / Math.Pow(multiplicate * End, 1 / (double)(j));
                case LinkUp.Both:
                    return 1/Math.Pow(multiplicate*Start*End, 1/(double)(j + 1));
                default:
                    throw  new Exception("WOW");
            }
        }
    }
}