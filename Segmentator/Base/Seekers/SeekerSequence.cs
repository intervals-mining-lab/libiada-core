namespace Segmentator.Base.Seekers
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Interfaces;

    public class SeekerSequence : Seeker
    {
        public SeekerSequence(IIterator where)
            : base(where)
        {
        }

        public override int Seek(List<String> sequence)
        {
            this.Result = new List<int>();
            while (this.Iterator.HasNext())
            {
                List<String> chain = this.Iterator.Next();
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
                    this.Result.Add(this.Iterator.Position());
                }
            }
            this.Iterator.Reset();
            return this.Result.Count;
        }
    }
}