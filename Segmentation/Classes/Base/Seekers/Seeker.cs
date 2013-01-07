using System;
using System.Collections.Generic;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Seekers
{
    /// <summary>
    /// Searching for occurrences of a sequence
    /// </summary>
    public class Seeker : ISeeker
    {
        private int first = 0;
        protected List<int> result;
        protected IIterator iterator;
        protected IIterator current;

        public Seeker(IIterator where)
        {
            this.iterator = where;
        }

        public override int seek(List<String> required)
        {
            int index = 0;
            List<String> sequence = null;
            result = new List<int>();
            while (iterator.hasNext())
            {
                sequence = iterator.next();
                for (List<String>.Enumerator iter = sequence.GetEnumerator(); iter.MoveNext(); index++)
                {
                    if ((iter.Current).Equals(required[first])) result.Add(index);
                }
            }
            iterator.reset();
            return result.Count;
        }


        public override List<int> arrangement()
        {
            return result;
        }

        public void customIterator(IIterator iterator)
        {
            this.iterator = iterator;
        }
    }
}