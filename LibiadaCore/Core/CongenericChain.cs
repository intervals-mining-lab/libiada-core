namespace LibiadaCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using IntervalsManagers;
    using SimpleTypes;

    /// <summary>
    /// The congeneric chain.
    /// </summary>
    public class CongenericChain : AbstractChain
    {
        /// <summary>
        /// The element.
        /// </summary>
        private readonly IBaseObject element;

        /// <summary>
        /// The arrangement type.
        /// </summary>
        private readonly ArrangementType arrangementType;

        /// <summary>
        /// Positions of all occurrences of the element in congeneric sequence.
        /// </summary>
        private List<int> positions = new List<int>();

        /// <summary>
        /// The chain length.
        /// </summary>
        private int length;

        /// <summary>
        /// The intervals manager.
        /// </summary>
        private ICongenericIntervalsManager intervalsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericChain"/> class.
        /// </summary>
        /// <param name="element">
        /// Element of this congeneric sequence.
        /// </param>
        /// <param name="length">
        /// Length of this chain.
        /// </param>
        /// <param name="arrangementType">
        /// The arrangement Type.
        /// </param>
        public CongenericChain(IBaseObject element, int length, ArrangementType arrangementType = ArrangementType.Intervals)
        {
            this.element = element;
            this.length = length;
            positions = new List<int>();
            this.arrangementType = arrangementType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericChain"/> class.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="arrangementType">
        /// The arrangement Type.
        /// </param>
        public CongenericChain(IBaseObject element, ArrangementType arrangementType = ArrangementType.Intervals)
        {
            this.element = element;
            length = 0;
            positions = new List<int>();
            this.arrangementType = arrangementType;
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
        /// <param name="arrangementType">
        /// The arrangement Type.
        /// </param>
        public CongenericChain(IEnumerable<int> positions, IBaseObject element, int length, ArrangementType arrangementType = ArrangementType.Intervals)
        {
            this.length = length;
            this.element = element.Clone();
            this.positions = positions.OrderBy(b => b).ToList();
            this.arrangementType = arrangementType;
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
        /// <param name="arrangementType">
        /// The arrangement Type.
        /// </param>
        public CongenericChain(bool[] map, IBaseObject element, ArrangementType arrangementType = ArrangementType.Intervals)
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
            this.arrangementType = arrangementType;
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
        /// Gets the building.
        /// </summary>
        public int[] Building
        {
            get
            {
                var result = new int[length];
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
        /// Deletes chain (building and alphabet) and creates new empty chain with given length.
        /// Saves old element (alphabet) of chain.
        /// </summary>
        /// <param name="newLength">
        /// New chain length.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if new length is less than 0.
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
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
        /// The <see cref="T:List{int}"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public int[] GetIntervals(Link link)
        {
            if (intervalsManager == null)
            {
                switch (arrangementType)
                {
                    case ArrangementType.Intervals:
                        intervalsManager = positions.Count != 0 ? (ICongenericIntervalsManager)new CongenericIntervalsManager(this) : new NullCongenericIntervalsManager();
                        break;
                    case ArrangementType.Series:
                        intervalsManager = new CongenericSeriesManager(this);
                        break;
                    case ArrangementType.IntervalsAndSeries:
                    default: throw new InvalidEnumArgumentException(nameof(arrangementType), (byte)arrangementType, typeof(ArrangementType));
                }
                
            }

            return intervalsManager.GetIntervals(link);
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

        /// <summary>
        /// The get length.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetLength() => length;

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
                positions = positions.OrderBy(b => b).ToList();
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
        /// The delete at.
        /// </summary>
        /// <param name="index">
        /// The index of position.
        /// </param>
        public override void DeleteAt(int index)
        {
            intervalsManager = null;
            length--;
            if (positions.Contains(index))
            {
                positions.Remove(index);
            }

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
        /// <param name="manager">
        /// The manager.
        /// </param>
        public void SetIntervalManager(CongenericIntervalsManager manager) => intervalsManager = manager;

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
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
        public override IBaseObject Clone() => new CongenericChain(positions, Element, length, arrangementType);

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
                var hashCode = 325361583;
                hashCode = (hashCode * -1521134295) + element.GetHashCode();
                hashCode = (hashCode * -1521134295) + length.GetHashCode();
                foreach (int position in Positions)
                {
                    hashCode = (hashCode * 1566083941) + position.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}
