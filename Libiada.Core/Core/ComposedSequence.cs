namespace Libiada.Core.Core;

using ArrangementManagers;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Sequence class.
/// </summary>
public class ComposedSequence : Sequence, IBaseObject
{
    /// <summary>
    /// The congeneric sequences.
    /// </summary>
    private CongenericSequence[]? congenericSequences;

    /// <summary>
    /// The relation intervals managers.
    /// </summary>
    private BinaryIntervalsManager[,]? relationIntervalsManagers;

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class.
    /// </summary>
    /// <param name="length">
    /// The length of the sequence.
    /// </param>
    public ComposedSequence(int length) : base(length)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class.
    /// </summary>
    public ComposedSequence()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class from string.
    /// Each character becomes element.
    /// </summary>
    /// <param name="source">
    /// The source string.
    /// </param>
    public ComposedSequence(string source) : base(source)
    {
        FillCongenericSequences();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class
    /// with provided order and alphabet.
    /// Only simple validation is made.
    /// </summary>
    /// <param name="order">
    /// The order of the sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet of the sequence.
    /// </param>
    public ComposedSequence(int[] order, Alphabet alphabet) : base(order, alphabet)
    {
        FillCongenericSequences();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class
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
    /// Id of sequence.
    /// </param>
    public ComposedSequence(int[] order, Alphabet alphabet, long id) : base(order, alphabet, id)
    {
        FillCongenericSequences();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class
    /// with provided order and numeric sequence.
    /// Only simple validation is made.
    /// </summary>
    /// <param name="order">
    /// The order of the sequence.
    /// </param>
    public ComposedSequence(int[] order) : base(order)
    {
        FillCongenericSequences();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class from string.
    /// Each character becomes element.
    /// </summary>
    /// <param name="source">
    /// The source collection of <see cref="IBaseObject"/>.
    /// </param>
    public ComposedSequence(IReadOnlyList<IBaseObject> source) : base(source)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComposedSequence"/> class.
    /// </summary>
    /// <param name="source">
    /// The source sequence of int values.
    /// </param>
    public ComposedSequence(short[] source)
    {
        alphabet = [NullValue.Instance()];
        order = new int[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            short element = source[i];
            if (!alphabet.Contains(new ValueInt(element)))
            {
                alphabet.Add(new ValueInt(element));
            }

            order[i] = alphabet.IndexOf(new ValueInt(element));
        }

        FillCongenericSequences();
    }

    /// <summary>
    /// Deletes sequence (order and alphabet) and creates new empty sequence with given length.
    /// </summary>
    /// <param name="length">
    /// New sequence length.
    /// </param>
    public override void ClearAndSetNewLength(int length)
    {
        base.ClearAndSetNewLength(length);
        congenericSequences = null;
        relationIntervalsManagers = null;
    }

    /// <summary>
    /// Creates clone of this sequence.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public new IBaseObject Clone()
    {
        ComposedSequence clone = new(order.Length);
        FillClone(clone);
        return clone;
    }

    /// <summary>
    /// Returns clone of congeneric sequence of given element.
    /// If there is no such element in sequence returns null.
    /// </summary>
    /// <param name="baseObject">
    /// Element of congeneric sequence.
    /// </param>
    /// <returns>
    /// The <see cref="Core.CongenericSequence"/>.
    /// </returns>
    public CongenericSequence CongenericSequence(IBaseObject baseObject)
    {
        if (congenericSequences == null)
        {
            FillCongenericSequences();
        }

        CongenericSequence result = null;

        int pos = Alphabet.IndexOf(baseObject);
        if (pos != -1)
        {
            result = (CongenericSequence)congenericSequences[pos].Clone();
        }

        return result;
    }

    /// <summary>
    /// Tries to get congeneric sequence.
    /// if there is no such sequence returns null.
    /// </summary>
    /// <param name="element">
    /// The element of desired congeneric sequence.
    /// </param>
    /// <returns>
    /// The <see cref="Core.CongenericSequence"/>.
    /// </returns>
    public CongenericSequence TryGetCongenericSequence(IBaseObject element)
    {
        if (!alphabet.Contains(element))
        {
            return null;
        }

        return CongenericSequence(element);
    }

    /// <summary>
    /// Gets or creates congeneric sequence.
    /// </summary>
    /// <param name="element">
    /// The element of congeneric sequence.
    /// </param>
    /// <returns>
    /// The <see cref="Core.CongenericSequence"/>.
    /// </returns>
    public CongenericSequence GetOrCreateCongenericSequence(IBaseObject element)
    {
        return TryGetCongenericSequence(element) ?? new CongenericSequence(element);
    }

    /// <summary>
    /// Returns clone of congeneric sequence by index of its element in alphabet.
    /// </summary>
    /// <param name="index">
    /// Index of element of congeneric sequence in alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="Core.CongenericSequence"/>.
    /// </returns>
    public CongenericSequence CongenericSequence(int index)
    {
        if (congenericSequences == null)
        {
            FillCongenericSequences();
        }

        return (CongenericSequence)congenericSequences[index].Clone();
    }

    /// <summary>
    /// The get relation interval manager.
    /// </summary>
    /// <param name="first">
    /// The first.
    /// </param>
    /// <param name="second">
    /// The second.
    /// </param>
    /// <returns>
    /// The <see cref="BinaryIntervalsManager"/>.
    /// </returns>
    public BinaryIntervalsManager GetRelationIntervalsManager(int first, int second)
    {
        if (relationIntervalsManagers == null)
        {
            relationIntervalsManagers = new BinaryIntervalsManager[alphabet.Cardinality - 1, alphabet.Cardinality - 1];
        }

        BinaryIntervalsManager? intervalsManager = relationIntervalsManagers[first - 1, second - 1];

        if (intervalsManager == null)
        {
            intervalsManager = new BinaryIntervalsManager(CongenericSequence(first - 1), CongenericSequence(second - 1));
            relationIntervalsManagers[first - 1, second - 1] = intervalsManager;
        }

        return intervalsManager;
    }

    /// <summary>
    /// The get relation intervals manager.
    /// </summary>
    /// <param name="first">
    /// The first.
    /// </param>
    /// <param name="second">
    /// The second.
    /// </param>
    /// <returns>
    /// The <see cref="BinaryIntervalsManager"/>.
    /// </returns>
    public BinaryIntervalsManager GetRelationIntervalsManager(IBaseObject first, IBaseObject second)
    {
        return GetRelationIntervalsManager(alphabet.IndexOf(first), alphabet.IndexOf(second));
    }

    /// <summary>
    /// Sets item in provided position.
    /// </summary>
    /// <param name="item">
    /// The item.
    /// </param>
    /// <param name="index">
    /// The index.
    /// </param>
    public override void Set(IBaseObject item, int index)
    {
        base.Set(item, index);

        congenericSequences = null;
    }

    /// <summary>
    /// The remove at.
    /// </summary>
    /// <param name="index">
    /// Index of deleted element.
    /// </param>
    public override void RemoveAt(int index)
    {
        base.RemoveAt(index);

        congenericSequences = null;
    }

    /// <summary>
    /// Removes element from given position.
    /// </summary>
    /// <param name="index">
    /// Index of deleted position.
    /// </param>
    public override void DeleteAt(int index)
    {
        base.DeleteAt(index);

        congenericSequences = null;
    }

    /// <summary>
    /// Returns position of given occurrence of given element.
    /// </summary>
    /// <param name="element">
    /// Element to find.
    /// </param>
    /// <param name="entry">
    /// occurrence of given element.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int GetOccurrence(IBaseObject element, int entry)
    {
        if (congenericSequences == null)
        {
            FillCongenericSequences();
        }

        return congenericSequences[alphabet.IndexOf(element) - 1].GetOccurrence(entry);
    }

    /// <summary>
    /// Sets arrangement managers for congeneric sequences.
    /// </summary>
    /// <param name="arrangementType">
    /// The arrangement Type. By default set to intervals.
    /// </param>
    public void SetArrangementManagers(ArrangementType arrangementType = ArrangementType.Intervals)
    {
        foreach (CongenericSequence sequence in congenericSequences)
        {
            sequence.CurrentArrangementType = arrangementType;
            sequence.CreateArrangementManager(arrangementType);
        }

    }

    /// <summary>
    /// Fills clone of this sequence.
    /// </summary>
    /// <param name="clone">
    /// The clone of the sequence.
    /// </param>
    protected void FillClone(IBaseObject clone)
    {
        ComposedSequence? sequence = clone as ComposedSequence;
        base.FillClone(sequence);
        if (sequence != null && congenericSequences != null)
        {
            sequence.congenericSequences = (CongenericSequence[])congenericSequences.Clone();

        }
    }

    /// <summary>
    /// Fills all congeneric sequences of this sequence.
    /// All congeneric sequences stored in <see cref="congenericSequences"/> field.
    /// </summary>
    private void FillCongenericSequences()
    {
        List<int>[] occurrences = new List<int>[alphabet.Cardinality - 1];

        for (int i = 0; i < alphabet.Cardinality - 1; i++)
        {
            occurrences[i] = [];
        }

        for (int j = 0; j < order.Length; j++)
        {
            if (order[j] != 0)
            {
                occurrences[order[j] - 1].Add(j);
            }
        }

        congenericSequences = new CongenericSequence[alphabet.Cardinality - 1];
        for (int k = 0; k < alphabet.Cardinality - 1; k++)
        {
            congenericSequences[k] = new CongenericSequence(occurrences[k], alphabet[k + 1], order.Length);
        }
    }
}
