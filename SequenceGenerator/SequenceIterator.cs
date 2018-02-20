namespace SequenceGenerator
{
    using System;
    using System.Collections;

    /// <summary>
    /// The sequence iterator.
    /// </summary>
    public class SequenceIterator : IEnumerable
    {
        /// <summary>
        /// The sequence as int array.
        /// </summary>
        private readonly int[] sequence;

        /// <summary>
        /// Sequence alphabet cardinality.
        /// </summary>
        private readonly int alphabetCardinality;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceIterator"/> class.
        /// </summary>
        /// <param name="length">
        /// The sequence length.
        /// </param>
        /// <param name="alphabetCardinality">
        /// Sequence alphabet cardinality.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if alphabet cardinality is greater than sequence length.
        /// </exception>
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

        /// <summary>
        /// The iterator.
        /// </summary>
        public int[] Iterator => (int[])sequence.Clone();

        /// <summary>
        /// The iterate sequences counter.
        /// </summary>
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

        /// <summary>
        /// Gets sequences enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
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
