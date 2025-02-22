namespace Libiada.Core.Core;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Extensions;

/// <summary>
/// Basic sequence class.
/// Stores alphabet and order.
/// </summary>
public class Sequence : AbstractSequence
{
    /// <summary>
    /// Sequence id (from database).
    /// </summary>
    public readonly long Id;

    /// <summary>
    /// The order of the sequence.
    /// </summary>
    protected int[] order;

    /// <summary>
    /// The alphabet of the sequence.
    /// </summary>
    protected Alphabet alphabet = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Sequence"/> class.
    /// </summary>
    /// <param name="length">
    /// The length of the sequence.
    /// </param>
    public Sequence(int length) => ClearAndSetNewLength(length);

    /// <summary>
    /// Initializes a new instance of the <see cref="Sequence"/> class with 0 length.
    /// </summary>
    public Sequence()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sequence"/> class from list of elements.
    /// </summary>
    /// <param name="elements">
    /// The elements.
    /// </param>
    public Sequence(IReadOnlyList<IBaseObject> elements) : this(elements.Count)
    {
        FillAlphabetAndOrder(elements);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sequence"/> class from string.
    /// Each character becomes element.
    /// </summary>
    /// <param name="source">
    /// The source string.
    /// </param>
    public Sequence(string source) : this(source.Select(e => (IBaseObject)new ValueString(e)).ToList())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sequence"/> class
    /// with provided order and alphabet.
    /// Only simple validation is made.
    /// </summary>
    /// <param name="order">
    /// The order of sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet of sequence.
    /// </param>
    public Sequence(int[] order, Alphabet alphabet) : this(order.Length)
    {
        if (order.Max() + 1 != alphabet.Cardinality)
        {
            throw new ArgumentException("Order max value does not corresponds with alphabet length.");
        }

        this.order = (int[])order.Clone();
        this.alphabet = (Alphabet)alphabet.Clone();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sequence"/> class
    /// with provided order and generates alphabet as numeric sequence.
    /// Only simple validation is made.
    /// </summary>
    /// <param name="order">
    /// The order of the sequence.
    /// </param>
    public Sequence(int[] order) : this(order.Length)
    {
        int alphabetCardinality = order.Max();
        for (int i = 1; i <= alphabetCardinality; i++)
        {
            alphabet.Add((ValueInt)i);
        }
        this.order = (int[])order.Clone();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sequence"/> class
    /// with provided order and alphabet.
    /// Only simple validation is made.
    /// </summary>
    /// <param name="order">
    /// The order of the sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet of the sequence.
    /// </param>
    /// <param name="id">
    /// Id of the sequence.
    /// </param>
    public Sequence(int[] order, Alphabet alphabet, long id) : this(order, alphabet)
    {
        Id = id;
    }

    /// <summary>
    /// Gets order of the sequence.
    /// Returns clone of order.
    /// </summary>
    public int[] Order => (int[])order.Clone();

    /// <summary>
    /// Gets alphabet of the sequence.
    /// Returns clone of alphabet.
    /// Removes <see cref="NullValue"/> (Element with 0 index) from clone.
    /// </summary>
    public Alphabet Alphabet
    {
        get
        {
            Alphabet result = (Alphabet)alphabet.Clone();

            // Removing NullValue.
            result.Remove(0);

            return result;
        }
    }

    /// <summary>
    /// Returns element by index.
    /// </summary>
    /// <param name="index">
    /// Index of element.
    /// </param>
    /// <returns>
    /// Element from given position.
    /// </returns>
    public override IBaseObject Get(int index) => alphabet[order[index]];

    /// <inheritdoc />
    /// <summary>
    /// As length of the sequence's order.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int Length => order.Length;

    /// <summary>
    /// Sets or replaces element in specified position.
    /// </summary>
    /// <param name="item">
    /// Element to set.
    /// </param>
    /// <param name="index">
    /// Position in sequence.
    /// </param>
    public override void Set(IBaseObject item, int index)
    {
        if (item == null)
        {
            throw new NullReferenceException();
        }

        if (item.Equals(this[index]))
        {
            return;
        }

        int max = 0;
        for (int i = 0; i < index; i++)
        {
            if (max < order[i])
            {
                max = order[i];
            }
        }

        if (max + 1 == alphabet.Cardinality)
        {
            if (!alphabet.Contains(item))
            {
                alphabet.Add(item);
            }

            order[index] = alphabet.IndexOf(item);
            return;
        }

        if(!alphabet.Contains(item))
        {
            if (order.Count(el => el == order[index]) == 1)
            {
                alphabet[order[index]] = item;
                return;
            }
        }

        IBaseObject[] sequence = ToArray();
        sequence[index] = item;
        alphabet = [NullValue.Instance()];

        FillAlphabetAndOrder(sequence);
    }

    /// <summary>
    /// Removes element from given position.
    /// </summary>
    /// <param name="index">
    /// Index of deleted element.
    /// </param>
    public override void RemoveAt(int index)
    {
        order[index] = 0;

        if (VerifyOrder()) return;
        throw new NotImplementedException();
        // TODO: remove element from alphabet if last entry is removed.
    }

    /// <summary>
    /// Removes given position.
    /// </summary>
    /// <param name="index">
    /// Index of deleted position.
    /// </param>
    public override void DeleteAt(int index)
    {
        order = order.DeleteAt(index);

        if (VerifyOrder()) return;
        throw new NotImplementedException();
        // TODO: remove element from alphabet if last entry is removed.
    }

    /// <summary>
    /// Deletes sequence (order and alphabet) and creates new empty sequence with given length.
    /// </summary>
    /// <param name="length">
    /// New sequence length.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if length of new sequence is less then zero.
    /// </exception>
    public override void ClearAndSetNewLength(int length)
    {
        if (length < 0)
        {
            throw new ArgumentException("Sequence length shouldn't be less than 0.");
        }

        order = new int[length];
        alphabet = [NullValue.Instance()];
    }

    /// <summary>
    /// Creates clone of this sequence.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public override IBaseObject Clone()
    {
        Sequence clone = new(order.Length);
        FillClone(clone);
        return clone;
    }

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="obj">
    /// The other.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj is Sequence other
            && alphabet.Equals(other.alphabet)
            && order.SequenceEqual(other.order);
    }

    /// <summary>
    /// Generates hash code using
    /// <see cref="alphabet"/> and <see cref="order"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode()
    {
        unchecked
        {
            //TODO: try to make alphabet and/or order readonly.
            int hashCode = -1845274089 ^ alphabet.GetHashCode();
            foreach (int element in order)
            {
                hashCode = (hashCode * -1521134295) + element.GetHashCode();
            }

            return hashCode;
        }
    }

    /// <summary>
    /// Fills the clone of the sequence with clones of alphabet and order.
    /// </summary>
    /// <param name="clone">
    /// The clone.
    /// </param>
    protected void FillClone(Sequence clone)
    {
        if (clone != null)
        {
            clone.order = (int[])order.Clone();
            clone.alphabet = (Alphabet)alphabet.Clone();
        }
    }

    private void FillAlphabetAndOrder(IReadOnlyList<IBaseObject> elements)
    {
        for (int i = 0; i < order.Length; i++)
        {
            int elementIndex = alphabet.IndexOf(elements[i]);
            if (elementIndex == -1)
            {
                alphabet.Add(elements[i]);
                elementIndex = alphabet.Cardinality - 1;
            }

            order[i] = elementIndex;
        }
    }

    private bool VerifyOrder() 
    {
        int counter = 0;
        for(int i = 0; i < order.Length; i++)
        {
            if (counter + 1 < order[i]) return false;
            if (counter + 1 == order[i]) counter++;
        }

        return true;
    }
}
