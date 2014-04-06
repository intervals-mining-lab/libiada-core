namespace Segmenter.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LibiadaCore.Core;

    using Segmenter.Base;
    using Segmenter.Base.Collectors;
    using Segmenter.Interfaces;

    /// <summary>
    /// Contains any params for segmentation
    /// </summary>
    public class ContentValues : Dictionary<string, object>
    {
        /// <summary>
        /// Creates an empty set of values using the default initial size
        /// </summary>
        public ContentValues()
            : base(8)
        {
        }

        /// <summary>
        /// Creates an empty set of values using the given initial size
        /// </summary>
        /// <param name="size">the initial size of the set of values</param>
        public ContentValues(int size)
            : base(size)
        {
        }

        /// <summary>
        /// Creates a set of values copied from the given set
        /// </summary>
        /// <param name="from">the values to copy</param>
        public ContentValues(ContentValues from)
            : base(from)
        {
        }

        /// <summary>
        /// Creates a set of values copied from the given HashMap. This is used
        /// by the Parcel unmarshalling code.
        /// </summary>
        /// <param name="values">the values to start with</param>
        private ContentValues(Dictionary<string, object> values)
            : base(values)
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ContentValues))
            {
                return false;
            }

            return this.Values.Equals(((ContentValues)obj).Values);
        }

        public override int GetHashCode()
        {
            return this.Values.GetHashCode();
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, string value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the parameter to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Formalism key, FrequencyDictionary value)
        {
            this.Add(key.ToString(), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the parameter to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Formalism key, Chain value)
        {
            this.Add(key.ToString(), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the characteristic to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Parameter key, int value)
        {
            this.Add(Enum.GetName(typeof(Parameter), key), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the characteristic to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Parameter key, double value)
        {
            this.Add(Enum.GetName(typeof(Parameter), key), value);
        }

        /// <summary>
        /// Adds all values from the passed in ContentValues.
        /// </summary>
        /// <param name="other"> the ContentValues from which to copy</param>
        public void PutAll(ContentValues other)
        {
            foreach (var contentValue in other)
            {
                this.Add(contentValue.Key, contentValue.Value);
            }
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, byte value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, short value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, int value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, long value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, float value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, double value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, bool value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, byte[] value)
        {
            this.Add(key, value);
        }

        /// <summary>
        /// Adds a null value to the set.
        /// </summary>
        /// <param name="key">the name of the value to make null</param>
        public void PutNull(string key)
        {
            this.Add(key, null);
        }

        /// <summary>
        /// Remove a single value.
        /// </summary>
        /// <param name="key">the name of the value to remove</param>
        public new void Remove(string key)
        {
            this.Remove(key);
        }

        /// <summary>
        /// Removes all values.
        /// </summary>
        public new void Clear()
        {
            this.Clear();
        }

        /// <summary>
        /// Returns true if this object has the named value.
        /// </summary>
        /// <param name="key">the value to check for</param>
        /// <returns>true if the value is present, false otherwise</returns>
        public new bool ContainsKey(string key)
        {
            return this.ContainsKey(key);
        }

        /// <summary>
        /// Gets a value. Valid value types are string, Boolean, and
        /// int implementations.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the data for the value</returns>
        public object Get(string key)
        {
            return this[key];
        }

        public object Get(IIdentifiable param)
        {
            return this[param.GetName()];
        }

        /// <summary>
        /// Gets a value and converts it to a string.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the string for the value</returns>
        public string GetAsstring(string key)
        {
            object value = this[key];
            return value != null ? this[key].ToString() : null;
        }

        /// <summary>
        /// Gets a value and converts it to a Long.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Long value, or null if the value is missing or cannot be converted</returns>
        public long GetAsLong(string key)
        {
            object value = this[key];
            try
            {
                return (long)value;
            }
            catch (Exception)
            {
                if (value is string)
                {
                    return long.Parse(value.ToString());
                }

                throw;
            }
        }

        /// <summary>
        /// Gets a value and converts it to an Integer.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Integer value, or null if the value is missing or cannot be converted</returns>
        public int GetAsInteger(string key)
        {
            object value = this[key];
            try
            {
                return (int)value;
            }
            catch (Exception)
            {
                if (value is string)
                {
                    return int.Parse(value.ToString());
                }

                throw;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a Short.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Short value, or null if the value is missing or cannot be converted</returns>
        public short GetAsShort(string key)
        {
            object value = this[key];
            try
            {
                return (short)value;
            }
            catch (Exception)
            {
                if (value is string)
                {
                    return short.Parse(value.ToString());
                }

                throw;
            }
        }

        /// <summary>
        ///  Gets a value and converts it to a Byte.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Byte value, or null if the value is missing or cannot be converted</returns>
        public byte GetAsByte(string key)
        {
            object value = this[key];
            try
            {
                return (byte)value;
            }
            catch (Exception)
            {
                if (value is string)
                {
                    return byte.Parse(value.ToString());
                }

                throw;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a double.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the double value, or null if the value is missing or cannot be converted</returns>
        public double GetAsdouble(string key)
        {
            object value = this[key];
            try
            {
                return (double)value;
            }
            catch (Exception)
            {
                if (value is string)
                {
                    return double.Parse(value.ToString());
                }

                throw;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a Float.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Float value, or null if the value is missing or cannot be converted</returns>
        public float GetAsFloat(string key)
        {
            object value = this[key];
            try
            {
                return (float)value;
            }
            catch (Exception)
            {
                if (value is string)
                {
                    return float.Parse(value.ToString());
                }

                throw;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a Boolean.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Boolean value, or null if the value is missing or cannot be converted</returns>
        public bool GetAsBoolean(string key)
        {
            object value = this[key];
            try
            {
                return (bool)value;
            }
            catch (Exception)
            {
                if (value is string)
                {
                    return bool.Parse(value.ToString());
                }

                throw;
            }
        }

        /// <summary>
        /// Gets a value that is a byte array. Note that this method will not convert
        ///  any other types to byte arrays.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the byte[] value, or null is the value is missing or not a byte[]</returns>
        public byte[] GetAsByteArray(string key)
        {
            object value = this[key];
            if (value is byte[])
            {
                return (byte[])value;
            }

            return null;
        }

        /// <summary>
        /// Returns a set of all of the keys and values
        /// </summary>
        /// <returns>a set of all of the keys and values</returns>
        public Dictionary<string, object> ValueSet()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> keyValuePair in this)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string name in this.Keys)
            {
                string value = this.GetAsstring(name);
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(name + "=" + value);
            }

            return sb.ToString();
        }
    }
}