namespace SequenceGenerator
{
    using System;
    using System.Collections;

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
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = 1;
            }

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
                if (sequence[index] > alphabetCardinality)
                {
                    carry = true;
                    sequence[index] = 1;
                    index++;
                }
                else
                {
                    carry = false;
                }
            }
            while (carry && index < sequence.Length);
        }

        public IEnumerator GetEnumerator()
        {
            int count = (int)Math.Pow(alphabetCardinality, sequence.Length);
            for (int i = 0; i < count; i++)
            {
                yield return (int[])sequence.Clone();
                IterateSequencesCounter();
            }
        }
    }
}
