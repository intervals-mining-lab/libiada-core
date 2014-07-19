namespace BuildingsIterator.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The convert array.
    /// </summary>
    public static class ConvertArray
    {
        /// <summary>
        /// The array to string.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ArrayToString(IList array)
        {
            return ArrayToString(array, Environment.NewLine);
        }

        /// <summary>
        /// The array to string.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <param name="delimiter">
        /// The delimiter.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ArrayToString(IList array, string delimiter)
        {
            string outputString = string.Empty;

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] is IList)
                {
                    outputString += ArrayToString((IList)array[i], delimiter);
                }
                else
                {
                    outputString += array[i];
                }
            }

            return outputString;
        }

        /// <summary>
        /// The array to string generic.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <typeparam name="T">
        /// List type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ArrayToStringGeneric<T>(IList<T> array)
        {
            return ArrayToStringGeneric(array, Environment.NewLine);
        }

        /// <summary>
        /// The array to string generic.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <param name="delimiter">
        /// The delimiter.
        /// </param>
        /// <typeparam name="T">
        /// List type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ArrayToStringGeneric<T>(IList<T> array, string delimiter)
        {
            string outputString = string.Empty;

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] is IList)
                {
                    outputString += ArrayToString((IList)array[i], delimiter);
                }
                else
                {
                    outputString += array[i];
                }

                if (i != array.Count - 1)
                {
                    outputString += delimiter;
                }
            }

            return outputString;
        }
    }
}
