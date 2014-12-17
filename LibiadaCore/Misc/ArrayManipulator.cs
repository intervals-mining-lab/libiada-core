using System.Collections;

namespace LibiadaCore.Misc
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Static class with methods for array manipulation.
    /// </summary>
    public static class ArrayManipulator
    {
        /// <summary>
        /// Method for deleting one element with its cell from array.
        /// </summary>
        /// <typeparam name="T">
        /// Array type.
        /// </typeparam>
        /// <param name="source">
        /// Source array.
        /// </param>
        /// <param name="index">
        /// Index of element to be deleted.
        /// </param>
        /// <returns>
        /// Array that shorter than source by one element.
        /// </returns>
        public static T[] DeleteAt<T>(T[] source, int index)
        {
            var result = new T[source.Length - 1];
            if (index > 0)
            {
                Array.Copy(source, 0, result, 0, index);
            }

            if (index < source.Length - 1)
            {
                Array.Copy(source, index + 1, result, index, source.Length - index - 1);
            }
                
            return result;
        }

        /// <summary>
        /// Method that finds all occurrences of provided element in array.
        /// </summary>
        /// <param name="source">
        /// Array for search.
        /// </param>
        /// <param name="element">
        /// Element to be located.
        /// </param>
        /// <typeparam name="T">
        /// Type of source array and element.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Array.int"/>.
        /// </returns>
        public static int[] AllIndexesOf<T>(T[] source, T element)
        {
            var result = new List<int>();

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Equals(element))
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Method that finds all occurrences of provided element in array.
        /// </summary>
        /// <param name="source">
        /// Array for search.
        /// </param>
        /// <param name="element">
        /// Element to be located.
        /// </param>
        /// <returns>
        /// The <see cref="Array.int"/>.
        /// </returns>
        public static int[] AllIndexesOf(int[] source, int element)
        {
            var result = new List<int>();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == element)
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }

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