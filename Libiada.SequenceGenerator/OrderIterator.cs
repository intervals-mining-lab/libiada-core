namespace Libiada.SequenceGenerator;

using System.Collections;

/// <summary>
/// The order iterator.
/// </summary>
public class OrderIterator : IEnumerable
{
    /// <summary>
    /// The order.
    /// </summary>
    private readonly int[] order;

    /// <summary>
    /// The alphabet cardinality.
    /// </summary>
    private readonly int alphabetCardinality;

    /// <summary>
    /// The has next.
    /// </summary>
    private bool hasNext = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderIterator"/> class.
    /// </summary>
    /// <param name="length">
    /// The order length.
    /// </param>
    /// <param name="alphabetCardinality">
    /// The order alphabet cardinality.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if alphabet cardinality greater than length.
    /// </exception>
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

    /// <summary>
    /// The iterator.
    /// </summary>
    public int[] Iterator => (int[])order.Clone();

    /// <summary>
    /// The iterate order counter.
    /// </summary>
    public void IterateOrderCounter()
    {
        int[] maximums = new int[order.Length];
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

    /// <summary>
    /// The get enumerator.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerator"/>.
    /// </returns>
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
