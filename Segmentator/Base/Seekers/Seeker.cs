namespace Segmentator.Base.Seekers
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Interfaces;

    /// <summary>
    /// Searching for occurrences of a sequence
    /// </summary>
    public class Seeker : Interfaces.Seeker
    {
        private int first = 0;
        protected List<int> Result;
        protected IIterator Iterator;

        public Seeker(IIterator where)
        {
            this.Iterator = where;
        }

        public override int Seek(List<String> required)
        {
            int index = 0;
            this.Result = new List<int>();
            while (this.Iterator.HasNext())
            {
                List<String> sequence = this.Iterator.Next();
                for (List<String>.Enumerator iter = sequence.GetEnumerator(); iter.MoveNext(); index++)
                {
                    if ((iter.Current).Equals(required[this.first])) this.Result.Add(index);
                }
            }
            this.Iterator.Reset();
            return this.Result.Count;
        }


        public List<int> Arrangement
        {
            get { return new List<int>(this.Result); }
        }

        public void CustomIterator(IIterator iterator)
        {
            this.Iterator = iterator;
        }
    }
}