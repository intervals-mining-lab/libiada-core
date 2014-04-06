namespace Segmentator.Base.Seekers
{
    using System.Collections.Generic;

    using Segmentator.Interfaces;

    /// <summary>
    /// Searching for occurrences of a sequence
    /// </summary>
    public class Seeker : Interfaces.Seeker
    {
        protected List<int> result;
        protected IIterator iterator;
        private int first = 0;

        public Seeker(IIterator where)
        {
            this.iterator = where;
        }

        public List<int> Arrangement
        {
            get { return new List<int>(this.result); }
        }

        public override int Seek(List<string> required)
        {
            int index = 0;
            this.result = new List<int>();
            while (this.iterator.HasNext())
            {
                List<string> sequence = this.iterator.Next();
                for (List<string>.Enumerator iter = sequence.GetEnumerator(); iter.MoveNext(); index++)
                {
                    if (iter.Current.Equals(required[this.first]))
                    {
                        this.result.Add(index);
                    }
                }
            }

            this.iterator.Reset();
            return this.result.Count;
        }

        public void CustomIterator(IIterator iterator)
        {
            this.iterator = iterator;
        }
    }
}