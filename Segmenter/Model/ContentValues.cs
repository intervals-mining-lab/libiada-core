﻿namespace Segmenter.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LibiadaCore.Core;

    using Segmenter.Base;
    using Segmenter.Base.Collectors;
    using Segmenter.Interfaces;

    /// <summary>
    /// Contains any parameters for segmentation.
    /// </summary>
    public class ContentValues : Dictionary<string, object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentValues"/> class.
        /// Creates an empty set of values using the default initial size.
        /// </summary>
        public ContentValues() : base(8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentValues"/> class.
        /// Creates an empty set of values using the given initial size
        /// </summary>
        /// <param name="size">
        /// The initial size of the set of values.
        /// </param>
        public ContentValues(int size) : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentValues"/> class.
        /// Creates a set of values copied from the given set.
        /// </summary>
        /// <param name="from">
        /// The values to copy.
        /// </param>
        public ContentValues(ContentValues from) : base(from)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentValues"/> class.
        /// Creates a set of values copied from the given HashMap. This is used
        /// by the Parcel unmarshalling code.
        /// </summary>
        /// <param name="values">
        /// The values to start with.
        /// </param>
        private ContentValues(Dictionary<string, object> values) : base(values)
        {
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (!(other is ContentValues))
            {
                return false;
            }

            return Values.Equals(((ContentValues)other).Values);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Values.GetHashCode();
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, string value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the parameter to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Formalism key, FrequencyDictionary value)
        {
            Add(key.ToString(), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the parameter to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Formalism key, Chain value)
        {
            Add(key.ToString(), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the characteristic to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Parameter key, int value)
        {
            Add(Enum.GetName(typeof(Parameter), key), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the characteristic to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(Parameter key, double value)
        {
            Add(Enum.GetName(typeof(Parameter), key), value);
        }

        /// <summary>
        /// Adds all values from the passed in ContentValues.
        /// </summary>
        /// <param name="other"> the ContentValues from which to copy</param>
        public void PutAll(ContentValues other)
        {
            foreach (var contentValue in other)
            {
                Add(contentValue.Key, contentValue.Value);
            }
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, byte value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, short value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, int value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, long value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, float value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, double value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, bool value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void Put(string key, byte[] value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a null value to the set.
        /// </summary>
        /// <param name="key">the name of the value to make null</param>
        public void PutNull(string key)
        {
            Add(key, null);
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

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Get(IIdentifiable parameters)
        {
            return this[parameters.GetName()];
        }

        /// <summary>
        /// Gets a value and converts it to a string.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the string for the value</returns>
        public string GetAsString(string key)
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
        public Dictionary<string, object> GetValueSet()
        {
            var result = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> keyValuePair in this)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return result;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string name in Keys)
            {
                string value = GetAsString(name);
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
