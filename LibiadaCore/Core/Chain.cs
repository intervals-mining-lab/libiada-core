namespace LibiadaCore.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using IntervalsManagers;
    using SimpleTypes;

    /// <summary>
    /// Sequence class.
    /// </summary>
    public class Chain : BaseChain, IBaseObject
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        protected CongenericChain[] congenericChains = new CongenericChain[0];

        /// <summary>
        /// The dissimilar chains.
        /// </summary>
        protected Chain[] dissimilarChains;

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
        public Chain(string source)
            : base(source)
        {
            CreateCongenericChains();
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
        public Chain(int[] building, Alphabet alphabet)
            : base(building, alphabet)
        {
            CreateCongenericChains();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class from string.
        /// Each character becomes element.
        /// </summary>
        /// <param name="source">
        /// The source string.
        /// </param>
        public Chain(List<IBaseObject> source)
            : base(source)
        {
            CreateCongenericChains();
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
            congenericChains = new CongenericChain[0];
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
        /// The <see cref="CongenericChain"/>.
        /// </returns>
        public CongenericChain CongenericChain(IBaseObject baseObject)
        {
            CongenericChain result = null;
            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (CongenericChain)congenericChains[pos].Clone();
            }

            return result;
        }

        /// <summary>
        /// Returns clone of congeneric sequence by index of its element in alphabet.
        /// </summary>
        /// <param name="index">
        /// Index of element of congeneric chain in alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="CongenericChain"/>.
        /// </returns>
        public CongenericChain CongenericChain(int index)
        {
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

            if (congenericChains.Length != (alphabet.Cardinality - 1))
            {
                var temp = new CongenericChain[alphabet.Cardinality - 1];
                for (int i = 0; i < congenericChains.Length; i++)
                {
                    temp[i] = congenericChains[i];
                }

                congenericChains = temp;
                congenericChains[congenericChains.Length - 1] = new CongenericChain(item, building.Length);
            }

            foreach (CongenericChain chain in congenericChains)
            {
                chain.Set(item, index);
            }
        }

        /// <summary>
        /// Fills all dissimilar chains of this chain.
        /// </summary>
        public void FillDissimilarChains()
        {
            if (dissimilarChains.Length > 0)
            {
                return;
            }

            var counters = new List<int>();
            for (int j = 0; j < Alphabet.Cardinality; j++)
            {
                counters.Add(0);
            }

            for (int i = 0; i < building.Length; i++)
            {
                int element = ++counters[building[i]];
                if (dissimilarChains.Length < element)
                {
                    var temp = new Chain[element];
                    for (int j = 0; j < dissimilarChains.Length; j++)
                    {
                        temp[j] = dissimilarChains[j];
                    }

                    dissimilarChains = temp;
                    dissimilarChains[dissimilarChains.Length - 1] = new Chain();
                }

                dissimilarChains[element].Set(new ValueInt(building[i]), i);
            }
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
            return congenericChains[alphabet.IndexOf(element) - 1].GetOccurrence(entry);
        }

        /// <summary>
        /// Fills all interval managers.
        /// </summary>
        public void FillIntervalManagers()
        {
            var occurrences = new int[alphabet.Cardinality - 1];
            for (int i = 0; i < occurrences.Length; i++)
            {
                occurrences[i] = -1;
            }

            var intervals = new List<int>[alphabet.Cardinality - 1];

            for (int i = 0; i < intervals.Length; i++)
            {
                intervals[i] = new List<int>();
            }

            for (int j = 0; j < building.Length; j++)
            {
                int value = building[j] - 1;
                intervals[value].Add(j - occurrences[value]);
                occurrences[value] = j;
            }

            for (int k = 0; k < intervals.Length; k++)
            {
                int start = intervals[k][0];
                int end = building.Length - intervals[k].Last();
                intervals[k].RemoveAt(0);

                congenericChains[k].SetIntervalManager(new CongenericIntervalsManager(this, intervals[k].ToArray(), start, end));
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
                tempChain.congenericChains = (CongenericChain[])congenericChains.Clone();
            }
        }

        /// <summary>
        /// Fills all congeneric chains of this chain.
        /// All congeneric sequences stored in <see cref="congenericChains"/> field.
        /// </summary>
        private void CreateCongenericChains()
        {
            var occerrences = new List<int>[alphabet.Cardinality - 1];

            for (int i = 0; i < alphabet.Cardinality - 1; i++)
            {
                occerrences[i] = new List<int>();
            }

            for (int j = 0; j < building.Length; j++)
            {
                occerrences[building[j] - 1].Add(j);
            }

            congenericChains = new CongenericChain[alphabet.Cardinality - 1];
            for (int k = 0; k < alphabet.Cardinality - 1; k++)
            {
                congenericChains[k] = new CongenericChain(occerrences[k], alphabet[k + 1], building.Length);
            }
        }
    }
}
