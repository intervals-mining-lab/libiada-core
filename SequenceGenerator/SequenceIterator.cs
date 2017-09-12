using System.Collections;

namespace SequenceGenerator
{
    class SequenceIterator : IEnumerable
    {
        private readonly int[] iterator;
        private readonly int alphabetCardinality;

        public SequenceIterator(int length, int alphabetCardinality)
        {
            iterator = new int[length];
            this.alphabetCardinality = alphabetCardinality;
        }

        public int[] Iterator
        {
            get { return (int[])iterator.Clone(); }
        }

        public void IterateSequencesCounter()
        {
            bool carry = false;
            int index = 0;
            do
            {
                iterator[index]++;
                if (iterator[index] >= alphabetCardinality)
                {
                    carry = true;
                    iterator[index] = 0;
                    index++;
                }
                else
                {
                    carry = false;
                }
            } while (carry && index < iterator.Length);
        }

        public IEnumerator GetEnumerator()
        {
            bool carry = false;
            int index = 0;
            do
            {
                iterator[index]++;
                if (iterator[index] >= alphabetCardinality)
                {
                    carry = true;
                    iterator[index] = 0;
                    index++;
                }
                else
                {
                    carry = false;
                }
                yield return (int[])iterator.Clone();
            } while (carry && index < iterator.Length);
        }
    }
}
