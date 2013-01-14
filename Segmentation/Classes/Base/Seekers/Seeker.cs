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
        protected List<int> Result;
        protected IIterator Iterator;

        public Seeker(IIterator where)
        {
            this.Iterator = where;
        }

        public override int Seek(List<String> required)
        {
            int index = 0;
            Result = new List<int>();
            while (Iterator.HasNext())
            {
                List<String> sequence = Iterator.Next();
                for (List<String>.Enumerator iter = sequence.GetEnumerator(); iter.MoveNext(); index++)
                {
                    if ((iter.Current).Equals(required[first])) Result.Add(index);
                }
            }
            Iterator.Reset();
            return Result.Count;
        }


        public List<int> Arrangement
        {
            get { return new List<int>(Result); }
        }

        public void CustomIterator(IIterator iterator)
        {
            this.Iterator = iterator;
        }
    }
}