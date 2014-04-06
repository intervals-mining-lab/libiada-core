namespace Segmenter.Base.Seekers
{
    using System.Collections.Generic;

    using Segmenter.Interfaces;

    public class SeekerSequence : Seeker
    {
        public SeekerSequence(IIterator where)
            : base(where)
        {
        }

        public override int Seek(List<string> sequence)
        {
            this.result = new List<int>();
            while (this.iterator.HasNext())
            {
                List<string> chain = this.iterator.Next();
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
                    this.result.Add(this.iterator.Position());
                }
            }

            this.iterator.Reset();
            return this.result.Count;
        }
    }
}