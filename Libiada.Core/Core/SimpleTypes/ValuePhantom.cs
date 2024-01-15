namespace LibiadaCore.Core.SimpleTypes
{
    /// <summary>
    /// Phantom value containing several alternative elements in one position.
    /// </summary>
    public class ValuePhantom : Alphabet, IBaseObject
    {
        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other as ValuePhantom) || EqualsAsElement(other as IBaseObject);
        }

        /// <summary>
        /// Adds phantom value by merging.
        /// All not duplicated elements from second phantom value are added to this phantom value.
        /// </summary>
        /// <param name="phantomValue">
        /// Phantom value to add.
        /// </param>
        public void Add(ValuePhantom phantomValue)
        {
            if (phantomValue != null)
            {
                for (int i = 0; i < phantomValue.Cardinality; i++)
                {
                    if (!Contains(phantomValue[i]))
                    {
                        Add(phantomValue[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Adds object to phantom elements list.
        /// </summary>
        /// <param name="baseObject">
        /// Object to add.
        /// </param>
        /// <returns>
        /// Index of new element or -1 if element not added.
        /// </returns>
        public override int Add(IBaseObject baseObject)
        {
            if (baseObject != null && !baseObject.Equals(NullValue.Instance()))
            {
                return base.Add(baseObject);
            }

            return -1;
        }

        /// <summary>
        /// Cloning method.
        /// </summary>
        /// <returns>
        /// Phantom value clone.
        /// </returns>
        public new IBaseObject Clone()
        {
            var clone = new ValuePhantom();
            foreach (IBaseObject element in Elements)
            {
                clone.Add(element);
            }

            return clone;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="nullValue">
        /// The null value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Equals(NullValue nullValue)
        {
            if (nullValue == null)
            {
                return false;
            }

            return Cardinality == 0;
        }

        /// <summary>
        /// The equals as element.
        /// </summary>
        /// <param name="baseObject">
        /// The base object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool EqualsAsElement(IBaseObject baseObject)
        {
            for (int i = 0; i < Cardinality; i++)
            {
                if (IndexOf(baseObject) != -1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
