using System;
using System.Collections;

namespace SequenceGenerator
{
    public class OrderIterator : IEnumerable
    {
        private readonly int[] order;
        private readonly int alphabetCardinality;

        public OrderIterator(int length, int alphabetCardinality)
        {
            if (alphabetCardinality > length)
            {
                throw new ArgumentException("Alphabet cardinality can't be greater than sequence length", nameof(alphabetCardinality));
            }

            order = new int[length];
            for (int i = 0; i < length; i++)
            {
                order[i] = 1;
            }

            this.alphabetCardinality = alphabetCardinality;
        }

        public int[] Iterator => (int[])order.Clone();

        public void IterateOrderCounter()
        {
            bool carry;
            int index = 0;
            int max = 1;
            do
            {
                order[index]++;
                if (order[index] > max)
                {
                    carry = true;
                    order[index] = 1;
                    index++;
                    if (max < alphabetCardinality)
                    {
                        max++;
                    }
                }
                else
                {
                    carry = false;
                }
            } while (carry && index < order.Length);
        }

        public IEnumerator GetEnumerator()
        {
            int[] checkArr = new int[order.Length];
            bool check = false;
            int max = 1;
            for (int i = 0; i < checkArr.Length; i++)
            {
                checkArr[i] = max;
                if (max < alphabetCardinality)
                {
                    max++;
                }
            }
            while (true)
            {
                for (int i = 0; i < checkArr.Length; i++)
                {
                    if (checkArr[i] == order[i])
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                yield return (int[])order.Clone();
                if (check)
                {
                    break;
                }
                IterateOrderCounter();
            }
        }
    }
}

