namespace LibiadaCore.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of ordered set - alphabet of elements.
    /// Alphabet is list of all unique elements in particular sequence.
    /// </summary>
    public class Alphabet : IBaseObject, IEnumerable
    {
        /// <summary>
        /// The elements within alphabet.
        /// </summary>
        protected readonly List<IBaseObject> Elements = new List<IBaseObject>();

        /// <summary>
        /// Gets count of elements in alphabet.
        /// </summary>
        public int Cardinality
        {
            get { return Elements.Count; }
        }

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
            get
            {
                return Elements[index].Clone();
            }

            set
            {
                if (!Elements.Contains(value))
                {
                    Elements[index] = value.Clone();
                }
            }
        }

        /// <summary>
        /// Adds element to the end of alphabet.
        /// </summary>
        /// <param name="baseObject">
        /// Added element.
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
        public virtual int Add(IBaseObject baseObject)
        {
            if (baseObject == null)
            {
                throw new NullReferenceException();
            }

            if (Elements.Contains(baseObject))
            {
                throw new Exception("Element '" + baseObject + "' is already in alphabet.");
            }

            Elements.Add(baseObject.Clone());
            return Elements.IndexOf(baseObject);
        }

        /// <summary>
        /// Deletes element from alphabet by index.
        /// </summary>
        /// <param name="index">
        /// Index of deleted element.
        /// </param>
        public virtual void Remove(int index)
        {
            Elements.RemoveAt(index);
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
            for (int i = 0; i < Elements.Count; i++)
            {
                clone.Add(Elements[i]);
            }

            return clone;
        }

        /// <summary>
        /// Compares alphabet with another alphabet.
        /// If another object is not alphabet returns false.
        /// In comparison order is not taken into account.
        /// </summary>
        /// <param name="other"> 
        /// Some object.
        /// </param>
        /// <returns>
        /// true if alphabets are equal and false otherwise.
        /// </returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return EqualsAsAlphabet(other as Alphabet);
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
            return Elements.IndexOf(obj);
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
            return Elements.Contains(element);
        }

        /// <summary>
        /// Returns enumerator of this alphabet..
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
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

            foreach (var vault in Elements)
            {
                result.Add(vault.Clone());
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

            foreach (var vault in Elements)
            {
                result.Add(vault.Clone());
            }

            return result;
        }

        /// <summary>
        /// Gets hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int temp = 0;
            foreach (IBaseObject o in Elements)
            {
                temp += 29 * o.GetHashCode();
            }

            return temp;
        }

        /// <summary>
        /// Compares two alphabets.
        /// </summary>
        /// <param name="other">
        /// Second alphabet for comparison.
        /// </param>
        /// <returns>
        /// true if both alphabet contains equal elements and false otherwise.
        /// </returns>
        private bool EqualsAsAlphabet(Alphabet other)
        {
            if (other == null || Cardinality != other.Cardinality)
            {
                return false;
            }

            for (int i = 0; i < Cardinality; i++)
            {
                if (!Elements.Contains(other.Elements[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
