namespace Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Measure attributes.
/// </summary>
public class MeasureAttributes : IBaseObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MeasureAttributes"/> class.
    /// </summary>
    /// <param name="size">
    /// The size.
    /// </param>
    /// <param name="key">
    /// The key.
    /// </param>
    public MeasureAttributes(Size size, Key key)
    {
            Size = (Size)size.Clone();
            Key = (Key)key.Clone();
    }

    /// <summary>
    /// Gets size that contains beats and beatBase.
    /// </summary>
    public Size Size { get; }

    /// <summary>
    /// Gets Key that contains fifths, mode.
    /// </summary>
    public Key Key { get; }

    /// <summary>
    /// Creates copy of current MeasureAttributes.
    /// </summary>
    /// <returns>
    /// The MeasureAttributes as <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone() => new MeasureAttributes(Size, Key);

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="obj">
    /// The object.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj is MeasureAttributes other && Key.Equals(other.Key) && Size.Equals(other.Size);
    }

    /// <summary>
    /// Calculates hash code using
    /// <see cref="Key"/> and <see cref="Size"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = 1812711144;
            hashCode = (hashCode * -1521134295) + Size.GetHashCode();
            hashCode = (hashCode * -1521134295) + Key.GetHashCode();
            return hashCode;
        }
    }
}
