namespace Libiada.Core.Core;

using System.ComponentModel;

using ArrangementManagers;
using SimpleTypes;

/// <summary>
/// The congeneric chain.
/// </summary>
public class CongenericChain : AbstractChain
{
    /// <summary>
    /// Gets or sets the current arrangement type.
    /// </summary>
    public ArrangementType CurrentArrangementType { get; set; }

    /// <summary>
    /// The element.
    /// </summary>
    private readonly IBaseObject element;

    /// <summary>
    /// Positions of all occurrences of the element in congeneric sequence.
    /// </summary>
    private readonly List<int> positions = [];

    /// <summary>
    /// The chain length.
    /// </summary>
    private int length;

    /// <summary>
    /// The intervals manager.
    /// </summary>
    private IArrangementManager intervalsManager;

    /// <summary>
    /// The series manager.
    /// </summary>
    private IArrangementManager seriesManager;

    /// <summary>
    /// The series intervals manager.
    /// </summary>
    private IArrangementManager seriesIntervalsManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="CongenericChain"/> class.
    /// </summary>
    /// <param name="element">
    /// Element of this congeneric sequence.
    /// </param>
    /// <param name="length">
    /// Length of this chain.
    /// </param>
    public CongenericChain(IBaseObject element, int length)
    {
        this.element = element;
        this.length = length;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CongenericChain"/> class.
    /// </summary>
    /// <param name="element">
    /// The element.
    /// </param>
    public CongenericChain(IBaseObject element)
    {
        this.element = element;
        length = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CongenericChain"/> class.
    /// </summary>
    /// <param name="positions">
    /// The positions of all elements in congeneric sequence.
    /// </param>
    /// <param name="element">
    /// Element of this congeneric sequence.
    /// </param>
    /// <param name="length">
    /// Length of this chain.
    /// </param>
    public CongenericChain(List<int> positions, IBaseObject element, int length)
    {
        this.length = length;
        this.element = element.Clone();
        this.positions = positions.OrderBy(b => b).ToList();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CongenericChain"/> class.
    /// </summary>
    /// <param name="map">
    /// The map of elements.
    /// </param>
    /// <param name="element">
    /// Element of this congeneric sequence.
    /// </param>
    public CongenericChain(bool[] map, IBaseObject element)
    {
        length = map.Length;
        this.element = element;
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i])
            {
                Set(i);
            }
        }
    }

    /// <summary>
    /// Gets the occurrences count.
    /// </summary>
    public int OccurrencesCount => positions.Count;

    /// <summary>
    /// Gets element chain filled with.
    /// </summary>
    public IBaseObject Element => element.Clone();

    /// <summary>
    /// Gets the order.
    /// </summary>
    public int[] Order
    {
        get
        {
            int[] result = new int[length];
            for (int i = 0; i < positions.Count; i++)
            {
                result[positions[i]] = 1;
            }

            return result;
        }
    }

    /// <summary>
    /// Gets positions of all elements in congeneric sequence.
    /// </summary>
    public int[] Positions
    {
        get
        {
            return positions.ToArray();
        }
    }

    /// <summary>
    /// Deletes chain (order and alphabet) and creates new empty chain with given length.
    /// Saves old element (alphabet) of chain.
    /// </summary>
    /// <param name="newLength">
    /// New chain length.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if new length is less than 0.
    /// </exception>
    public override void ClearAndSetNewLength(int newLength)
    {
        if (newLength < 0)
        {
            throw new ArgumentException("Chain length shouldn't be less than 0.");
        }

        intervalsManager = null;
        length = newLength;
        positions.Clear();
    }

    /// <summary>
    /// Returns clone of intervals array including interval of given link.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="int[]"/>.
    /// </returns>
    public int[] GetArrangement(Link link)
    {
        return CurrentArrangementType switch
        {
            ArrangementType.Intervals => GetIntervals(link),
            ArrangementType.Series => GetSeries(link),
            ArrangementType.IntervalsAndSeries => GetSeriesAndIntervals(link),
            _ => throw new InvalidEnumArgumentException(nameof(CurrentArrangementType), (int)CurrentArrangementType, typeof(ArrangementType)),
        };
    }

    /// <summary>
    /// Returns clone of intervals array including interval for given link.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="T:List{int}"/>.
    /// </returns>
    public int[] GetIntervals(Link link)
    {
        if (intervalsManager == null)
        {
            CreateIntervalsManager();
        }

        return intervalsManager.GetArrangement(link);
    }

    /// <summary>
    /// Returns clone of series array including series for given link.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="int[]"/>.
    /// </returns>
    public int[] GetSeries(Link link)
    {
        if (seriesManager == null)
        {
            CreateSeriesManager();
        }

        return seriesManager.GetArrangement(link);
    }

    /// <summary>
    /// Returns clone of series and intervals arrays.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="int[]"/>.
    /// </returns>
    public int[] GetSeriesAndIntervals(Link link)
    {
        if (seriesIntervalsManager == null)
        {
            CreateSeriesIntervalsManager();
        }

        return seriesIntervalsManager.GetArrangement(link);
    }


    /// <summary>
    /// Returns position of given occurrence of element of this chain.
    /// If occurrence not found returns -1.
    /// </summary>
    /// <param name="occurrence">
    /// Occurrence to find.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int GetOccurrence(int occurrence)
    {
        if (occurrence - 1 >= positions.Count)
        {
            return -1;
        }

        return positions[occurrence - 1];
    }

    /// <summary>
    /// Returns position of first occurrence of element after given position.
    /// </summary>
    /// <param name="index">
    /// Starting position for search.
    /// </param>
    /// <returns>
    /// Position of occurrence or -1 if occurrence after given not found.
    /// </returns>
    public int GetFirstAfter(int index)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            if (positions[i] > index)
            {
                return positions[i];
            }
        }

        return -1;
    }

    /// <inheritdoc />
    public override int Length => length;

    /// <summary>
    /// Sets item in provided position.
    /// Clears position if element not from this chain.
    /// Does nothing if position is empty and element not from this chain.
    /// </summary>
    /// <param name="item">
    /// The item.
    /// </param>
    /// <param name="index">
    /// The index of position.
    /// </param>
    public override void Set(IBaseObject item, int index)
    {
        if (element.Equals(item))
        {
            Set(index);
        }
    }

    /// <summary>
    /// Sets item in provided position.
    /// </summary>
    /// <param name="index">
    /// The index.
    /// </param>
    public void Set(int index)
    {
        if (index >= length || index < 0)
        {
            throw new ArgumentOutOfRangeException($"Index of added element is out of bounds (index = {index}, sequence length = {length}).");
        }

        intervalsManager = null;

        if (!positions.Contains(index))
        {
            positions.Add(index);
            positions.Sort();
        }
    }

    /// <summary>
    /// Gets element by position index.
    /// If position is empty returns <see cref="NullValue"/>.
    /// </summary>
    /// <param name="index">
    /// Index of position.
    /// </param>
    /// <returns>
    /// Element or <see cref="NullValue"/>.
    /// </returns>
    public override IBaseObject Get(int index) => positions.Contains(index) ? element.Clone() : NullValue.Instance();

    /// <summary>
    /// Deletes given position.
    /// Clears element from position if any.
    /// Reduces chain length by 1.
    /// </summary>
    /// <param name="index">
    /// The index of position.
    /// </param>
    public override void DeleteAt(int index)
    {
        intervalsManager = null;
        length--;
        positions.Remove(index);

        for (int i = 0; i < positions.Count; i++)
        {
            if (index < positions[i])
            {
                positions[i]--;
            }
        }
    }

    /// <summary>
    /// Removes element from given position.
    /// Also clears interval manager of chain.
    /// </summary>
    /// <param name="index">
    /// Index of position.
    /// </param>
    public override void RemoveAt(int index)
    {
        intervalsManager = null;
        positions.Remove(index);
    }

    /// <summary>
    /// Sets interval manager of chain.
    /// </summary>
    /// <param name="intervals">
    /// The intervals.
    /// </param>
    /// <param name="start">
    /// The start.
    /// </param>
    /// <param name="end">
    /// The end.
    /// </param>
    public void FillIntervalManager()
    {
        if (positions.Count == 0)
        {
            intervalsManager = new NullArrangementManager();
            return;
        }

        intervalsManager = new IntervalsManager(this);
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

        return obj is CongenericChain other
            && element.Equals(other.Element)
            && length == other.length
            && positions.SequenceEqual(other.positions);
    }

    /// <summary>
    /// Creates clone of this chain.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public override IBaseObject Clone() => new CongenericChain(positions, Element, length)
    {
        CurrentArrangementType = CurrentArrangementType
    };

    /// <summary>
    /// Calculates hash code using
    /// <see cref="element"/>, <see cref="positions"/> and <see cref="length"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = 325361583;
            hashCode = (hashCode * -1521134295) + element.GetHashCode();
            hashCode = (hashCode * -1521134295) + length.GetHashCode();
            foreach (int position in Positions)
            {
                hashCode = (hashCode * 1566083941) + position.GetHashCode();
            }

            return hashCode;
        }
    }

    /// <summary>
    /// Creates arrangement manager of given type.
    /// </summary>
    /// <param name="arrangementType">
    /// The arrangement type.
    /// </param>
    /// <exception cref="InvalidEnumArgumentException">
    /// Thrown if arrangement type is unknown.
    /// </exception>
    public void CreateArrangementManager(ArrangementType arrangementType = ArrangementType.Intervals)
    {
        switch (arrangementType)
        {
            case ArrangementType.Intervals:
                CreateIntervalsManager();
                break;
            case ArrangementType.Series:
                CreateSeriesManager();
                break;
            case ArrangementType.IntervalsAndSeries:
                CreateSeriesIntervalsManager();
                break;
            default:
                throw new InvalidEnumArgumentException(nameof(arrangementType), (int)arrangementType, typeof(ArrangementType));
        }
    }

    /// <summary>
    /// Creates intervals manager.
    /// </summary>
    public void CreateIntervalsManager()
    {
        if (intervalsManager == null)
        {
            intervalsManager = positions.Count == 0
                                   ? new NullArrangementManager()
                                   : new IntervalsManager(this);
        }
    }

    /// <summary>
    /// Creates series manager.
    /// </summary>
    public void CreateSeriesManager()
    {
        if (seriesManager == null)
        {
            seriesManager = positions.Count == 0
                                   ? new NullArrangementManager()
                                   : new SeriesManager(this);
        }
    }

    /// <summary>
    /// Creates complex series and intervals manager.
    /// </summary>
    public void CreateSeriesIntervalsManager()
    {
        if (seriesIntervalsManager == null)
        {
            seriesIntervalsManager = positions.Count == 0
                                   ? new NullArrangementManager()
                                   : new SeriesIntervalsManager(this);
        }
    }
}
