namespace LibiadaCore.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Array extensions methods.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Method for deleting one element and its cell from array.
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
        public static T[] DeleteAt<T>(this T[] source, int index)
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
        /// Method for deleting one element with its cell from array.
        /// </summary>
        /// <param name="source">
        /// Source array.
        /// </param>
        /// <param name="index">
        /// Index of element to be deleted.
        /// </param>
        /// <returns>
        /// Array that shorter than source by one element.
        /// </returns>
        public static int[] DeleteAt(this int[] source, int index)
        {
            var result = new int[source.Length - 1];
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
        public static int[] AllIndexesOf<T>(this T[] source, T element)
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
        public static int[] AllIndexesOf(this int[] source, int element)
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
        public static string ToStringWithoutDelimiter(this IList array)
        {
            string outputString = string.Empty;

            foreach (object element in array)
            {
                outputString += element is IList ? ToStringWithoutDelimiter((IList)element) : element;
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
        public static string ToStringWithDefaultDelimiter<T>(this IList<T> array)
        {
            return ToString(array, Environment.NewLine);
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
        public static string ToString<T>(this IList<T> array, string delimiter)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < array.Count; i++)
            {
                builder.Append(array[i] is IList ? ToStringWithoutDelimiter((IList)array[i]) : array[i].ToString());
                builder.Append(delimiter);
            }

            return builder.ToString(0, builder.Length - delimiter.Length);
        }

        /// <summary>
        /// Array rotation method.
        /// </summary>
        /// <param name="array">
        /// The source array.
        /// </param>
        /// <param name="rotations">
        /// The number rotations.
        /// </param>
        /// <returns>
        /// The <see cref="T:int[]"/>.
        /// </returns>
        public static int[] Rotate(this int[] array, uint rotations)
        {
            var result = new int[array.Length];
            Array.Copy(array, rotations, result, 0, array.Length - rotations);
            Array.Copy(array, 0, result, result.Length - rotations, rotations);

            return result;
        }

        /// <summary>
        /// Checks if array is sorted.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsSorted(this int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if List is sorted.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsSorted(this List<int> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
