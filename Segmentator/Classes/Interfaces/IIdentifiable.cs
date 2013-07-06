using System;

namespace Segmentator.Classes.Interfaces
{
    /// <summary>
    /// Defines an object name
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Returns an object name
        /// </summary>
        /// <returns>an object name</returns>
        String GetName();
    }
}