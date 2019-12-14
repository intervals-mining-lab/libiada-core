namespace LibiadaCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Extensions;

    /// <summary>
    /// Basic sequence class.
    /// Stores alphabet and building.
    /// </summary>
    public class BaseChain : AbstractChain
    {
        /// <summary>
        /// Sequence id (from database).
        /// </summary>
        public readonly long Id;

        /// <summary>
        /// The building of chain.
        /// </summary>
        protected int[] building;

        /// <summary>
        /// The alphabet of chain.
        /// </summary>
        protected Alphabet alphabet = new Alphabet();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class.
        /// </summary>
        /// <param name="length">
        /// The length of chain.
        /// </param>
        public BaseChain(int length) => ClearAndSetNewLength(length);

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class with 0 length.
        /// </summary>
        public BaseChain()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class from list of elements.
        /// </summary>
        /// <param name="elements">
        /// The elements.
        /// </param>
        public BaseChain(List<IBaseObject> elements) : this(elements.Count)
        {
            for (int i = 0; i < building.Length; i++)
            {
                int elementIndex = alphabet.IndexOf(elements[i]);
                if (elementIndex == -1)
                {
                    alphabet.Add(elements[i]);
                    elementIndex = alphabet.Cardinality - 1;
                }

                building[i] = elementIndex;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class from string.
        /// Each character becomes element.
        /// </summary>
        /// <param name="source">
        /// The source string.
        /// </param>
        public BaseChain(string source) : this(source.Select(e => (IBaseObject)new ValueString(e)).ToList())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class
        /// with provided building and alphabet.
        /// Only simple validation is made.
        /// </summary>
        /// <param name="building">
        /// The building of chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet of chain.
        /// </param>
        public BaseChain(int[] building, Alphabet alphabet) : this(building.Length)
        {
            if (building.Max() + 1 != alphabet.Cardinality)
            {
                throw new ArgumentException("Building max value does not corresponds with alphabet length.");
            }

            this.building = (int[])building.Clone();
            this.alphabet = (Alphabet)alphabet.Clone();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class
        /// with provided order and generates alphabet as numeric sequence.
        /// Only simple validation is made.
        /// </summary>
        /// <param name="building">
        /// The building of chain.
        /// </param>
        public BaseChain(int[] building) : this(building.Length)
        {
            var alphabetCardinality = building.Max();
            for (int i = 1; i <= alphabetCardinality; i++)
            {
                alphabet.Add((ValueInt)i);
            }
            this.building = (int[])building.Clone();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class
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
        /// Id of sequence
        /// </param>
        public BaseChain(int[] building, Alphabet alphabet, long id) : this(building, alphabet)
        {
            Id = id;
        }

        /// <summary>
        /// Gets building of chain.
        /// Returns clone of building.
        /// </summary>
        public int[] Building => (int[])building.Clone();

        /// <summary>
        /// Gets alphabet of chain.
        /// Returns clone of alphabet.
        /// Removes NullValue (Element with 0 index) from clone.
        /// </summary>
        public Alphabet Alphabet
        {
            get
            {
                var result = (Alphabet)alphabet.Clone();

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
        public override IBaseObject Get(int index) => alphabet[building[index]];

        /// <inheritdoc />
        /// <summary>
        /// As length of the sequence's order.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int Length => building.Length;

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

            RemoveAt(index);
            int position = alphabet.IndexOf(item);
            if (position == -1)
            {
                alphabet.Add(item);
                position = alphabet.Cardinality - 1;
            }

            building[index] = position;
        }

        /// <summary>
        /// Removes element from given position.
        /// </summary>
        /// <param name="index">
        /// Index of deleted element.
        /// </param>
        public override void RemoveAt(int index)
        {
            building[index] = 0;

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
            building = building.DeleteAt(index);

            // TODO: remove element from alphabet if last entry is removed.
        }

        /// <summary>
        /// Deletes chain (building and alphabet) and creates new empty chain with given length.
        /// </summary>
        /// <param name="length">
        /// New chain length.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if length of new sequence is less then zero.
        /// </exception>
        public override void ClearAndSetNewLength(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Chain length shouldn't be less than 0.");
            }

            building = new int[length];
            alphabet = new Alphabet { NullValue.Instance() };
        }

        /// <summary>
        /// Creates clone of this chain.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public override IBaseObject Clone()
        {
            var clone = new BaseChain(building.Length);
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
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is BaseChain other
                && alphabet.Equals(other.alphabet)
                && building.SequenceEqual(other.building);
        }

        /// <summary>
        /// Generates hash code using
        /// <see cref="alphabet"/> and <see cref="building"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                //TODO: try to make alphabet and/or building readonly.
                int hashCode = -1845274089 ^ alphabet.GetHashCode();
                foreach (int element in building)
                {
                    hashCode = (hashCode * -1521134295) + element.GetHashCode();
                }

                return hashCode;
            }
        }

        /// <summary>
        /// Fills the clone of chain with clones of alphabet and building.
        /// </summary>
        /// <param name="clone">
        /// The clone.
        /// </param>
        protected void FillClone(BaseChain clone)
        {
            if (clone != null)
            {
                clone.building = (int[])building.Clone();
                clone.alphabet = (Alphabet)alphabet.Clone();
            }
        }
    }
}
