namespace LibiadaCore.Core
{
    /// <summary>
    /// Base interface for all storage classes.
    /// Requires implementation of comparison and cloning methods.
    /// </summary>
    public interface IBaseObject
    {
        /// <summary>
        /// Creates clone of this object.
        /// </summary>
        /// <returns>
        /// Copy of this object.
        /// </returns>
        IBaseObject Clone();

        /// <summary>
        /// Compare method.
        /// </summary>
        /// <param name="other">
        /// Object to compare to.
        /// </param>
        /// <returns>
        /// true of objects are equal and false otherwise.
        /// </returns>
        bool Equals(object other);
    }
}
