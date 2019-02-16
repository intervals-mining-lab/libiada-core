namespace LibiadaCore.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of ordered set - alphabet of elements.
    /// Alphabet is list of all unique elements in particular sequence.
    /// </summary>
    public class Alphabet : IBaseObject, IEnumerable<IBaseObject>
    {
        /// <summary>
        /// The elements within alphabet.
        /// </summary>
        protected readonly List<IBaseObject> Elements = new List<IBaseObject>();

        /// <summary>
        /// The elements indexes.
        /// </summary>
        protected readonly Dictionary<IBaseObject, int> ElementsIndexes = new Dictionary<IBaseObject, int>();

        /// <summary>
        /// Gets count of elements in alphabet.
        /// </summary>
        public int Cardinality => Elements.Count;

        /// <summary>
        /// Indexer. Allows to get or set element by index.
        /// Only element not presented in alphabet can be added.
        /// </summary>
        /// <param name="index">
        /// Index of element in alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject this[int index]
        {
            get => Elements[index].Clone();

            set
            {
                if (!ElementsIndexes.ContainsKey(value))
                {
                    Elements[index] = value.Clone();
                }
            }
        }

        /// <summary>
        /// Adds element to the end of alphabet.
        /// </summary>
        /// <param name="element">
        /// Element to add.
        /// </param>
        /// <returns>
        /// Index of new element in alphabet.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if alphabet already contains given element.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Thrown if added element is null.
        /// </exception>
        public virtual int Add(IBaseObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "Cannot add null into alphabet");
            }

            if (ElementsIndexes.ContainsKey(element))
            {
                throw new ArgumentException($"Element '{element}' is already in alphabet.", nameof(element));
            }

            Elements.Add(element.Clone());
            ElementsIndexes.Add(Elements.Last(), Elements.Count - 1);

            return ElementsIndexes[Elements.Last()];
        }

        /// <summary>
        /// Deletes element from alphabet by index.
        /// </summary>
        /// <param name="index">
        /// Index of deleted element.
        /// </param>
        public virtual void Remove(int index)
        {
            ElementsIndexes.Remove(Elements[index]);
            Elements.RemoveAt(index);

            for (int i = index; i < Elements.Count; i++)
            {
                ElementsIndexes[Elements[i]]--;
            }
        }

        /// <summary>
        /// Creates clone of this alphabet
        /// </summary>
        /// <returns>
        /// Clone of alphabet containing clones of all elements.
        /// </returns>
        public IBaseObject Clone()
        {
            var clone = new Alphabet();
            foreach (IBaseObject element in Elements)
            {
                clone.Add(element);
            }

            return clone;
        }

        /// <summary>
        /// Compares alphabet with another alphabet.
        /// If another object is not alphabet returns false.
        /// </summary>
        /// <param name="obj">
        /// Some object.
        /// </param>
        /// <returns>
        /// true if alphabets are equal and false otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return obj is Alphabet other && Elements.SequenceEqual(other.Elements);
        }

        /// <summary>
        /// Compares alphabet with another alphabet as sets.
        /// Order of elements is not taken into account.
        /// </summary>
        /// <param name="other">
        /// Another alphabet.
        /// </param>
        /// <returns>
        /// true if alphabets are equal as sets and false otherwise.
        /// </returns>
        public bool SetEquals(Alphabet other)
        {
            if (Equals(other))
            {
                return true;
            }

            return new HashSet<IBaseObject>(Elements).SetEquals(new HashSet<IBaseObject>(other.Elements));
        }

        /// <summary>
        /// Searches position of element in alphabet.
        /// </summary>
        /// <param name="obj">
        /// Searched element.
        /// </param>
        /// <returns>
        /// Index of element in alphabet.
        /// Or -1 if element not found in alphabet.
        /// </returns>
        public int IndexOf(IBaseObject obj)
        {
            return ElementsIndexes.ContainsKey(obj) ? ElementsIndexes[obj] : -1;
        }

        /// <summary>
        /// Checks if alphabet contains given element.
        /// </summary>
        /// <param name="element">
        /// Element to check.
        /// </param>
        /// <returns>
        /// true if element found in alphabet and false otherwise.
        /// </returns>
        public bool Contains(IBaseObject element)
        {
            return ElementsIndexes.ContainsKey(element);
        }

        /// <summary>
        /// Returns enumerator of this alphabet.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        IEnumerator<IBaseObject> IEnumerable<IBaseObject>.GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        /// <summary>
        /// Casts alphabet to array containing clones of all elements.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IBaseObject[]"/>.
        /// </returns>
        public IBaseObject[] ToArray()
        {
            var result = new List<IBaseObject>();

            foreach (IBaseObject element in Elements)
            {
                result.Add(element.Clone());
            }

            return result.ToArray();
        }

        /// <summary>
        /// Casts alphabet to list containing clones of all elements.
        /// </summary>
        /// <returns>
        /// The <see cref="List{IBaseObject}"/>.
        /// </returns>
        public List<IBaseObject> ToList()
        {
            var result = new List<IBaseObject>();

            foreach (IBaseObject element in Elements)
            {
                result.Add(element.Clone());
            }

            return result;
        }

        /// <summary>
        /// Calculates hash code using
        /// <see cref="Elements"/> hash codes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -1573927371;
                foreach (IBaseObject element in Elements)
                {
                    hashCode = (hashCode * 1573927372) + element.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}
