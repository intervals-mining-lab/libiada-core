using System;
using System.Collections;

namespace SequenceGenerator
{
    public class SequenceIterator : IEnumerable
    {
        private readonly int[] sequence;
        private readonly int alphabetCardinality;

        public SequenceIterator(int length, int alphabetCardinality)
        {
            if (alphabetCardinality > length)
            {
                throw new ArgumentException("Alphabet cardinality can't be greater than sequence length", nameof(alphabetCardinality));
            }
            sequence = new int[length];
            this.alphabetCardinality = alphabetCardinality;
        }

        public int[] Iterator => (int[])sequence.Clone();

        public void IterateSequencesCounter()
        {
            bool carry;
            int index = 0;
            do
            {
                sequence[index]++;
                if (sequence[index] >= alphabetCardinality)
                {
                    carry = true;
                    sequence[index] = 0;
                    index++;
                }
                else
                {
                    carry = false;
                }
            } while (carry && index < sequence.Length);
        }

        public IEnumerator GetEnumerator()
        {
            bool carry;
            int index = 0;
            do
            {
                yield return (int[])sequence.Clone();
                sequence[index]++;
                if (sequence[index] >= alphabetCardinality)
                {
                    carry = true;
                    sequence[index] = 0;
                    index++;
                }
                else
                {
                    carry = false;
                }
            } while (carry && index < sequence.Length);
        }
    }
}
