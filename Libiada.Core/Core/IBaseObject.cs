namespace Libiada.Core.Core;

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
    /// True if objects are equal and false otherwise.
    /// </returns>
    bool Equals(object? other);

    /// <summary>
    /// Calculates hash code using
    /// stored internal values.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    int GetHashCode();

    /// <summary>
    /// Converts <see cref="IBaseObject"/> to <see cref="string"/>
    /// </summary>
    /// <returns></returns>
    string ToString();
}
