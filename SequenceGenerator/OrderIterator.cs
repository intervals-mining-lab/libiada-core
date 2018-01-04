namespace SequenceGenerator
{
    using System;
    using System.Collections;

    public class OrderIterator : IEnumerable
    {
        private readonly int[] order;

        private readonly int alphabetCardinality;

        private bool hasNext = true;

        public OrderIterator(int length, int alphabetCardinality)
        {
            if (alphabetCardinality > length)
            {
                throw new ArgumentException("Alphabet cardinality can't be greater than sequence length", nameof(alphabetCardinality));
            }

            this.alphabetCardinality = alphabetCardinality;
            order = new int[length];
            for (int i = 0; i < length; i++)
            {
                order[i] = 1;
            }
        }

        public int[] Iterator => (int[])order.Clone();

        public void IterateOrderCounter()
        {
            var maximums = new int[order.Length];
            int max = 1;
            for (int i = 0; i < maximums.Length; i++)
            {
                maximums[i] = max;
                if ((max <= order[i]) && (max < alphabetCardinality))
                {
                    max++;
                }
            }

            for (int i = order.Length - 1; i >= 0; i--)
            {
                order[i]++;
                if (order[i] > maximums[i])
                {
                    order[i] = 1;
                    if (i == 1)
                    {
                        hasNext = false;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            do
            {
                yield return (int[])order.Clone();
                IterateOrderCounter();
            }
            while (hasNext);
        }
    }
}
