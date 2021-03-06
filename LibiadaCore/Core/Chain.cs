namespace LibiadaCore.Core
{
    using System.Collections.Generic;

    using ArrangementManagers;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Sequence class.
    /// </summary>
    public class Chain : BaseChain, IBaseObject
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        private CongenericChain[] congenericChains;

        /// <summary>
        /// The relation intervals managers.
        /// </summary>
        private BinaryIntervalsManager[,] relationIntervalsManagers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class.
        /// </summary>
        /// <param name="length">
        /// The length of chain.
        /// </param>
        public Chain(int length) : base(length)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class.
        /// </summary>
        public Chain()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class from string.
        /// Each character becomes element.
        /// </summary>
        /// <param name="source">
        /// The source string.
        /// </param>
        public Chain(string source) : base(source)
        {
            FillCongenericChains();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class
        /// with provided building and alphabet.
        /// Only simple validation is made.
        /// </summary>
        /// <param name="building">
        /// The building of chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet of chain.
        /// </param>
        public Chain(int[] building, Alphabet alphabet) : base(building, alphabet)
        {
            FillCongenericChains();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class
        /// with provided building and alphabet.
        /// Only simple validation is made.
        /// </summary>
        /// <param name="building">
        /// The building of chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet of chain.
        /// </param>
        /// <param name="id">
        /// Id of sequence.
        /// </param>
        public Chain(int[] building, Alphabet alphabet, long id) : base(building, alphabet, id)
        {
            FillCongenericChains();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class
        /// with provided order and numeric sequence.
        /// Only simple validation is made.
        /// </summary>
        /// <param name="building">
        /// The building of chain.
        /// </param>
        public Chain(int[] building) : base(building)
        {
            FillCongenericChains();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class from string.
        /// Each character becomes element.
        /// </summary>
        /// <param name="source">
        /// The source collection of <see cref="IBaseObject"/>.
        /// </param>
        public Chain(IReadOnlyList<IBaseObject> source) : base(source)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class.
        /// </summary>
        /// <param name="source">
        /// The source sequence of int values.
        /// </param>
        public Chain(short[] source)
        {
            alphabet = new Alphabet() { NullValue.Instance() };
            building = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                if (!alphabet.Contains(new ValueInt(source[i])))
                {
                    alphabet.Add(new ValueInt(source[i]));
                }

                building[i] = alphabet.IndexOf(new ValueInt(source[i]));
            }

            FillCongenericChains();
        }

        /// <summary>
        /// Deletes chain (building and alphabet) and creates new empty chain with given length.
        /// </summary>
        /// <param name="length">
        /// New chain length.
        /// </param>
        public override void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            congenericChains = null;
            relationIntervalsManagers = null;
        }

        /// <summary>
        /// Creates clone of this chain.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public new IBaseObject Clone()
        {
            var clone = new Chain(building.Length);
            FillClone(clone);
            return clone;
        }

        /// <summary>
        /// Returns clone of congeneric sequence of given element.
        /// If there is no such element in chain returns null.
        /// </summary>
        /// <param name="baseObject">
        /// Element of congeneric chain.
        /// </param>
        /// <returns>
        /// The <see cref="T:CongenericChain"/>.
        /// </returns>
        public CongenericChain CongenericChain(IBaseObject baseObject)
        {
            if (congenericChains == null)
            {
                FillCongenericChains();
            }

            CongenericChain result = null;

            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (CongenericChain)congenericChains[pos].Clone();
            }

            return result;
        }

        /// <summary>
        /// Tries to get congeneric chain.
        /// if there is no such chain returns null.
        /// </summary>
        /// <param name="element">
        /// The element of desired congeneric chain.
        /// </param>
        /// <returns>
        /// The <see cref="T:CongenericChain"/>.
        /// </returns>
        public CongenericChain TryGetCongenericChain(IBaseObject element)
        {
            if (!alphabet.Contains(element))
            {
                return null;
            }

            return CongenericChain(element);
        }

        /// <summary>
        /// Gets or creates congeneric chain.
        /// </summary>
        /// <param name="element">
        /// The element of congeneric chain.
        /// </param>
        /// <returns>
        /// The <see cref="T:CongenericChain"/>.
        /// </returns>
        public CongenericChain GetOrCreateCongenericChain(IBaseObject element)
        {
            return TryGetCongenericChain(element) ?? new CongenericChain(element);
        }

        /// <summary>
        /// Returns clone of congeneric sequence by index of its element in alphabet.
        /// </summary>
        /// <param name="index">
        /// Index of element of congeneric chain in alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="T:CongenericChain"/>.
        /// </returns>
        public CongenericChain CongenericChain(int index)
        {
            if (congenericChains == null)
            {
                FillCongenericChains();
            }

            return (CongenericChain)congenericChains[index].Clone();
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

            var intervalsManager = relationIntervalsManagers[first - 1, second - 1];

            if (intervalsManager == null)
            {
                intervalsManager = new BinaryIntervalsManager(CongenericChain(first - 1), CongenericChain(second - 1));
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

            congenericChains = null;
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

            congenericChains = null;
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

            congenericChains = null;
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
            if (congenericChains == null)
            {
                FillCongenericChains();
            }

            return congenericChains[alphabet.IndexOf(element) - 1].GetOccurrence(entry);
        }

        /// <summary>
        /// Sets arrangement managers for congeneric chains.
        /// </summary>
        /// <param name="arrangementType">
        /// The arrangement Type. By default set to intervals.
        /// </param>
        public void SetArrangementManagers(ArrangementType arrangementType = ArrangementType.Intervals)
        {
            foreach (var chain in congenericChains)
            {
                chain.CurrentArrangementType = arrangementType;
                chain.CreateArrangementManager(arrangementType);
            }

        }

        /// <summary>
        /// Fills clone of this chain.
        /// </summary>
        /// <param name="clone">
        /// The clone of chain.
        /// </param>
        protected void FillClone(IBaseObject clone)
        {
            var tempChain = clone as Chain;
            base.FillClone(tempChain);
            if (tempChain != null)
            {
                if (congenericChains != null)
                {
                    tempChain.congenericChains = (CongenericChain[])congenericChains.Clone();
                }
            }
        }

        /// <summary>
        /// Fills all congeneric chains of this chain.
        /// All congeneric sequences stored in <see cref="congenericChains"/> field.
        /// </summary>
        private void FillCongenericChains()
        {
            var occurrences = new List<int>[alphabet.Cardinality - 1];

            for (int i = 0; i < alphabet.Cardinality - 1; i++)
            {
                occurrences[i] = new List<int>();
            }

            for (int j = 0; j < building.Length; j++)
            {
                if (building[j] != 0)
                {
                    occurrences[building[j] - 1].Add(j);
                }
            }

            congenericChains = new CongenericChain[alphabet.Cardinality - 1];
            for (int k = 0; k < alphabet.Cardinality - 1; k++)
            {
                congenericChains[k] = new CongenericChain(occurrences[k], alphabet[k + 1], building.Length);
            }
        }
    }
}
