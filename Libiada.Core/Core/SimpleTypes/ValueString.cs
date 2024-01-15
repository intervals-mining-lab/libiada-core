namespace Libiada.Core.Core.SimpleTypes;

/// <summary>
/// String-element class.
/// </summary>
public class ValueString : IBaseObject
{
    /// <summary>
    /// The value.
    /// </summary>
    public readonly string Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueString"/> class.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    public ValueString(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw value == null ?
                    new ArgumentNullException(nameof(value), "String value is null.") :
                    new ArgumentException("String value is empty.", nameof(value));
        }

        Value = (string)value.Clone();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueString"/> class.
    /// </summary>
    /// <param name="value">
    /// The <see cref="char"/> value of element.
    /// </param>
    public ValueString(char value) => Value = value.ToString();

    /// <summary>
    /// Operator of implicit casting from ValueString to string.
    /// </summary>
    /// <param name="from">
    /// The from.
    /// </param>
    /// <returns>
    /// New <see cref="string"/>.
    /// </returns>
    public static implicit operator string(ValueString from) => from.Value;

    /// <summary>
    /// Operator of implicit casting from string to ValueString.
    /// </summary>
    /// <param name="from">
    /// The from.
    /// </param>
    /// <returns>
    /// New <see cref="ValueString"/>.
    /// </returns>
    public static implicit operator ValueString(string from) => new ValueString(from);

    /// <summary>
    /// Operator of implicit casting from char to ValueString.
    /// </summary>
    /// <param name="from">
    /// The from.
    /// </param>
    /// <returns>
    /// New <see cref="ValueString"/>.
    /// </returns>
    public static implicit operator ValueString(char from) => new ValueString(from);

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone() => new ValueString(Value);

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="other">
    /// The other element.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool Equals(object other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Equals(other as ValueString);
    }

    /// <summary>
    /// The to string.
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public override string ToString() => Value;

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="other">
    /// The other.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool Equals(ValueString other)
    {
        if (other == null)
        {
            return false;
        }

        return Value == other.Value;
    }

    /// <summary>
    /// Calculates hash code using <see cref="Value"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode() => Value.GetHashCode();
}
