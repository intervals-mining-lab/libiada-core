namespace Segmenter.Base.Seekers
{
    using System.Collections.Generic;

    using Segmenter.Interfaces;

    /// <summary>
    /// The seeker sequence.
    /// </summary>
    public class SeekerSequence : Seeker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeekerSequence"/> class.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        public SeekerSequence(IIterator where)
            : base(where)
        {
        }

        /// <summary>
        /// The seek.
        /// </summary>
        /// <param name="sequence">
        /// The sequence.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
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