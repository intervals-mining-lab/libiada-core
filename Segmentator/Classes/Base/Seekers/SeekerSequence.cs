using System;
using System.Collections.Generic;
using Segmentator.Classes.Interfaces;

namespace Segmentator.Classes.Base.Seekers
{
    public class SeekerSequence : Seeker
    {
        public SeekerSequence(IIterator where)
            : base(where)
        {
        }

        public override int Seek(List<String> sequence)
        {
            Result = new List<int>();
            while (Iterator.HasNext())
            {
                List<String> chain = Iterator.Next();
                bool chainsEquals = sequence.Count == chain.Count;
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (chain[i] != sequence[i])
                    {
                        chainsEquals = false;
                    }
                }
                if (chainsEquals)
                {
                    Result.Add(Iterator.Position());
                }
            }
            Iterator.Reset();
            return Result.Count;
        }
    }
}