namespace Segmenter.Extended
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains methods that will facilitate your work
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Designed for fast conversion a collection to the string object without delimiters.
        /// </summary>
        /// <param name="list">
        /// List convertible sequence of words.
        /// </param>
        /// <returns>
        /// String composed of items in the collection.
        /// </returns>
        public static string ToString(List<string> list)
        {
            var result = new StringBuilder();
            foreach (string element in list)
            {
                result.Append(element);
            }

            return result.ToString();
        }

        /// <summary>
        /// The arrays equal.
        /// </summary>
        /// <param name="a1">
        /// The a 1.
        /// </param>
        /// <param name="a2">
        /// The a 2.
        /// </param>
        /// <typeparam name="T">
        /// Type of array's elements.
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (ReferenceEquals(a1, a2))
            {
                return true;
            }

            if (a1 == null || a2 == null)
            {
                return false;
            }

            if (a1.Length != a2.Length)
            {
                return false;
            }

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
