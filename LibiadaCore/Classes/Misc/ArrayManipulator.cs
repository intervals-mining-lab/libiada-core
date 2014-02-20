﻿namespace LibiadaCore.Classes.Misc
{
    using System;
    using System.Linq;

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
            var indexMap = source.Select((b, i) => b.Equals(element) ? i : -1);
            var indexes = indexMap.Where(i => i != -1);
            return indexes.ToArray();
        }
    }
}