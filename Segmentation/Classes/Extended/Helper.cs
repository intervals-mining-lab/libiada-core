using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentation.Classes.Extended
{
    /// <summary>
    /// Contains methods that will facilitate your work
    /// </summary>
    public static class Helper
    {  
        /// <summary>
        /// Designed for fast conversion a collection to the String object without delimiters
        /// </summary>
        /// <param name="list">list convertible sequence of words</param>
        /// <returns>string composed of items in the collection</returns>
        public static String ToString(List<String> list)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < list.Count; i++) result.Append(list[i]);
            return result.ToString();
        }

        public static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }
    }
}