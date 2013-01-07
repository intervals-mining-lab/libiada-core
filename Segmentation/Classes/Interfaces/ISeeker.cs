using System;
using System.Collections.Generic;

namespace Segmentation.Classes.Interfaces
{
    /// <summary>
    /// Provides search an entry one object to other
    /// </summary>
    public abstract class ISeeker
    {
        public static readonly int step = 1;

        /// <summary>
        /// Returns number of hits required word from a sequence
        /// </summary>
        /// <param name="required">searchable word</param>
        /// <returns>number of hits</returns>
        public abstract int seek(List<String> required);

        /// <summary>
        /// Finds the cursorPosition of the location of the element
        /// </summary>
        /// <returns>Numbers places where the word</returns>
        public abstract List<int> arrangement();
    }
}