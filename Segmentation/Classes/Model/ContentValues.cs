using System;
using System.Collections.Generic;
using System.Text;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Model
{
    /// <summary>
    /// Contains any params for segmentation
    /// </summary>
    public class ContentValues : Dictionary<String, Object>
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
        private ContentValues(Dictionary<String, Object> values)
            : base(values)
        {
        }


        public override bool Equals(Object obj)
        {
            if (!(obj is ContentValues))
            {
                return false;
            }
            return this.Values.Equals(((ContentValues) obj).Values);
        }

        public override int GetHashCode()
        {
            return Values.GetHashCode();
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, String value)
        {
            Add(key, value);
        }


        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the parameter to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(Formalism key, FrequencyDictionary value)
        {
            Add(key.ToString(), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the parameter to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(Formalism key, Chain value)
        {
            Add(key.ToString(), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the characteristic to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(Parameter key, int value)
        {
            Add(Enum.GetName(typeof(Parameter), key), value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the characteristic to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(Parameter key, double value)
        {
            Add(Enum.GetName(typeof(Parameter), key), value);
        }

        /// <summary>
        /// Adds all values from the passed in ContentValues.
        /// </summary>
        /// <param name="other"> the ContentValues from which to copy</param>
        public void putAll(ContentValues other)
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
        public void put(String key, Byte value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, short value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, int value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, long value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, float value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, Double value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, Boolean value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a value to the set.
        /// </summary>
        /// <param name="key">the name of the value to put</param>
        /// <param name="value">the data for the value to put</param>
        public void put(String key, byte[] value)
        {
            Add(key, value);
        }

        /// <summary>
        /// Adds a null value to the set.
        /// </summary>
        /// <param name="key">the name of the value to make null</param>
        public void putNull(String key)
        {
            Add(key, null);
        }

        /// <summary>
        /// Returns the number of values.
        /// </summary>
        /// <returns>the number of values</returns>
        public int size()
        {
            return Count;
        }

        /// <summary>
        /// Remove a single value.
        /// </summary>
        /// <param name="key">the name of the value to remove</param>
        public void remove(String key)
        {
            Remove(key);
        }

        /// <summary>
        /// Removes all values.
        /// </summary>
        public void clear()
        {
            Clear();
        }

        /// <summary>
        /// Returns true if this object has the named value.
        /// </summary>
        /// <param name="key">the value to check for</param>
        /// <returns>true if the value is present, false otherwise</returns>
        public bool containsKey(String key)
        {
            return ContainsKey(key);
        }

        /// <summary>
        /// Gets a value. Valid value types are String, Boolean, and
        /// int implementations.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the data for the value</returns>
        public Object get(String key)
        {
            return this[key];
        }

        public Object get(IIdentifiable param)
        {
            return this[param.GetName()];
        }

        /// <summary>
        /// Gets a value and converts it to a String.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the String for the value</returns>
        public String getAsString(String key)
        {
            Object value = this[key];
            return value != null ? this[key].ToString() : null;
        }

        /// <summary>
        /// Gets a value and converts it to a Long.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Long value, or null if the value is missing or cannot be converted</returns>
        public long getAsLong(String key)
        {
            Object value = this[key];
            try
            {
                return (long) value;
            }
            catch (Exception e)
            {
                if (value is String)
                {
                    return long.Parse(value.ToString());
                }
                throw e;
            }
        }

        /// <summary>
        /// Gets a value and converts it to an Integer.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Integer value, or null if the value is missing or cannot be converted</returns>
        public int getAsInteger(String key)
        {
            Object value = this[key];
            try
            {
                return (int) value;
            }
            catch (Exception e)
            {
                if (value is String)
                {
                    if (value is String)
                    {
                        return int.Parse(value.ToString());
                    }
                }
                throw e;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a Short.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Short value, or null if the value is missing or cannot be converted</returns>
        public short getAsShort(String key)
        {
            Object value = this[key];
            try
            {
                return (short) value;
            }
            catch (Exception e)
            {
                if (value is String)
                {
                    if (value is String)
                    {
                        return short.Parse(value.ToString());
                    }
                }
                throw e;
            }
        }

        /// <summary>
        ///  Gets a value and converts it to a Byte.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Byte value, or null if the value is missing or cannot be converted</returns>
        public Byte getAsByte(String key)
        {
            Object value = this[key];
            try
            {
                return (byte) value;
            }
            catch (Exception e)
            {
                if (value is String)
                {
                    if (value is String)
                    {
                        return byte.Parse(value.ToString());
                    }
                }
                throw e;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a Double.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Double value, or null if the value is missing or cannot be converted</returns>
        public Double getAsDouble(String key)
        {
            Object value = this[key];
            try
            {
                return (double) value;
            }
            catch (Exception e)
            {
                if (value is String)
                {
                    if (value is String)
                    {
                        return double.Parse(value.ToString());
                    }
                }
                throw e;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a Float.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Float value, or null if the value is missing or cannot be converted</returns>
        public float getAsFloat(String key)
        {
            Object value = this[key];
            try
            {
                return (float) value;
            }
            catch (Exception e)
            {
                if (value is String)
                {
                    if (value is String)
                    {
                        return float.Parse(value.ToString());
                    }
                }
                throw e;
            }
        }

        /// <summary>
        /// Gets a value and converts it to a Boolean.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the Boolean value, or null if the value is missing or cannot be converted</returns>
        public Boolean getAsBoolean(String key)
        {
            Object value = this[key];
            try
            {
                return (bool) value;
            }
            catch (Exception e)
            {
                if (value is String)
                {
                    if (value is String)
                    {
                        return bool.Parse(value.ToString());
                    }
                }
                throw e;
            }
        }

        /// <summary>
        /// Gets a value that is a byte array. Note that this method will not convert
        ///  any other types to byte arrays.
        /// </summary>
        /// <param name="key">the value to get</param>
        /// <returns>the byte[] value, or null is the value is missing or not a byte[]</returns>
        public byte[] getAsByteArray(String key)
        {
            Object value = this[key];
            if (value is byte[])
            {
                return (byte[]) value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a set of all of the keys and values
        /// </summary>
        /// <returns>a set of all of the keys and values</returns>
        public Dictionary<String, Object> valueSet()
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> keyValuePair in this)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return result;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String name in this.Keys)
            {
                String value = getAsString(name);
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(name + "=" + value);
            }
            return sb.ToString();
        }
    }
}