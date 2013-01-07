using System;
using System.Collections.Generic;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Seekers
{
    public class SeekerSequence:Seeker
    {
        public SeekerSequence(IIterator where):base(where)
        {
        }

        public int seek(List<String> sequence)
        {
            result = new List<int>();
            while (iterator.hasNext())
            {
                if (iterator.next().Equals(sequence)) result.Add(iterator.position());
            }
            iterator.reset();
            return result.Count;
        } 
    }
}