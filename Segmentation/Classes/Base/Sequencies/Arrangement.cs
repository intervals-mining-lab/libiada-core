using System;
using System.Collections.Generic;
using System.Text;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Sequencies
{
    /// <summary>
    /// The class is designed for storing and processing numeric sequences.
    /// Not tied to any notion of order a chain.
    /// </summary>
    public class Arrangement : INumberSequence
    {
        protected List<int> values;
        protected String delimiter = "-";

        public Arrangement(List<int> values)
        {
            Build(values);
        }

        public Arrangement()
        {
            this.values = new List<int>();
        }

        public Arrangement(int[] values)
        {
            this.values = new List<int>();
            for (int index = 0; index < values.Length; index++)
            {
                this.values.Add(values[index]);
            }
        }

        /// <summary>
        /// Maps taken to the value of the object
        /// </summary>
        /// <param name="values">input numeric sequence</param>
        private void Build(List<int> values)
        {
            this.values = new List<int>();
            if (values.Count == 0)
            {
                List<int> list = new List<int>();
                this.values.AddRange(list);
                return;
            }
            this.values.AddRange(values);
        }

        public bool IsEmpty()
        {

            return values.Count == 0;
        }

        public int Length()
        {
            return values.Count;
        }

        public int ElementAt(int index)
        {
            try
            {
                return values[index];
            }
            catch (Exception e)
            {

            }
            return -1;
        }

        public INumberSequence Concat(INumberSequence value)
        {
            try
            {
                if (!value.IsEmpty())
                {
                    for (int index = 0; index < value.Length(); index++)
                    {
                        values.Add(value.ElementAt(index));
                    }
                }
            }
            catch (Exception e)
            {
            }

            return this;
        }

        public INumberSequence Add(int value)
        {
            values.Add(value);
            return this;
        }

        public INumberSequence Substring(int beginIndex, int endIndex)
        {
            Arrangement arrangement = null;
            arrangement = new Arrangement(Sublist(beginIndex, endIndex));
            return arrangement;
        }

        public INumberSequence ClearAt(int index)
        {
            try
            {
                values.Remove(index);
            }
            catch (Exception e)
            {
            }
            return this;
        }

        /// <summary>
        /// Returns a new sequence that is a sublist of the current sequence. 
        /// The substring begins at the specified beginIndex and extends to the figures at index endIndex - 1. 
        /// Thus the length of the substring is endIndex-beginIndex.
        /// </summary>
        /// <param name="beginIndex">the beginning index, inclusive.</param>
        /// <param name="endIndex">the ending index, exclusive.</param>
        /// <returns>the specified numerical substring.</returns>
        protected List<int> Sublist(int beginIndex, int endIndex)
        {
            List<int> sublist = null;

            try
            {
                sublist = values.GetRange(beginIndex, endIndex - beginIndex);
            }
            catch (Exception e)
            {
            }

            return new List<int>(sublist);
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Arrangement))
            {
                return false;
            }
            Arrangement sequence = (Arrangement) obj;
            if (sequence.Length() != values.Count) return false;
            for (int index = 0; index < sequence.Length(); index++)
            {
                if (values[index] != sequence.ElementAt(index))
                    return false;
            }
            return true;
        }


        public override String ToString()
        {
            StringBuilder str = new StringBuilder();

            for (List<int>.Enumerator iter = this.values.GetEnumerator(); iter.MoveNext();)
            {
                str.Append(iter.Current + delimiter);
            }
            str.Remove(str.Length - 1, 1);
            return str.ToString();
        }

        public void Push(int value)
        {
            values.Add(value);
        }

        public void Clear()
        {
            values.Clear();
        }
    }
}