namespace Libiada.Core.Core.SimpleTypes;

using System.Globalization;

/// <summary>
/// Double value element class.
/// </summary>
public class ValueDouble : IBaseObject
{
    /// <summary>
    /// The value.
    /// </summary>
    private readonly double value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueDouble"/> class.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    public ValueDouble(double value)
    {
        this.value = value;
    }

    /// <summary>
    /// Operator of implicit casting from ValueDouble to double.
    /// </summary>
    /// <param name="from">
    /// The from.
    /// </param>
    /// <returns>
    /// New <see cref="double"/>.
    /// </returns>
    public static implicit operator double(ValueDouble from)
    {
        return from.value;
    }

    /// <summary>
    /// Operator of implicit casting from double to ValueDouble.
    /// </summary>
    /// <param name="from">
    /// The from.
    /// </param>
    /// <returns>
    /// New <see cref="ValueDouble"/>.
    /// </returns>
    public static implicit operator ValueDouble(double from)
    {
        return new ValueDouble(from);
    }

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone()
    {
        return new ValueDouble(value);
    }

    /// <summary>
    /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.
    /// </summary>
    /// <returns>
    /// true if the specified <see cref="object"/> is equal to the current <see cref="object"/>; otherwise, false.
    /// </returns>
    /// <param name="obj">
    /// The <see cref="object"/> to compare with the current <see cref="object"/>.
    /// </param>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj is ValueDouble valueDouble && Equals(valueDouble);
    }

    /// <summary>
    /// The to string.
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public override string ToString() => value.ToString(CultureInfo.InvariantCulture);

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="other">
    /// The other.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool Equals(ValueDouble other)
    {
        if (other == null)
        {
            return false;
        }

        return value.Equals(other.value);
    }

    /// <summary>
    /// Calculates hash code using <see cref="value"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode() => value.GetHashCode();
}
