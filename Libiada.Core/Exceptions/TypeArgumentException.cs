namespace Libiada.Core.Exceptions;

using System;

/// <summary>
/// Exception thrown to indicate that an inappropriate type argument was used for
/// a type parameter to a generic type or method.
/// </summary>
public class TypeArgumentException : ArgumentException
{
    /// <summary>
    /// The actual type.
    /// </summary>
    public readonly Type ActualTypeArgument;

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeArgumentException"/> class.
    /// Constructs a new instance of TypeArgumentException with no message.
    /// </summary>
    public TypeArgumentException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeArgumentException"/> class.
    /// Constructs a new instance of TypeArgumentException with the given message.
    /// </summary>
    /// <param name="message">
    /// Message for the exception.
    /// </param>
    public TypeArgumentException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeArgumentException"/> class.
    /// </summary>
    /// <param name="message">
    /// The message.
    /// </param>
    /// <param name="actualType">
    /// The argument type.
    /// </param>
    public TypeArgumentException(string message, Type actualType) : base(message)
    {
        ActualTypeArgument = actualType;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeArgumentException"/> class.
    /// Constructs a new instance of TypeArgumentException with the given message and inner exception.
    /// </summary>
    /// <param name="message">
    /// Message for the exception.
    /// </param>
    /// <param name="inner">
    /// Inner exception.
    /// </param>
    public TypeArgumentException(string message, Exception inner) : base(message, inner)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeArgumentException"/> class.
    /// </summary>
    /// <param name="message">
    /// The message.
    /// </param>
    /// <param name="inner">
    /// The inner.
    /// </param>
    /// <param name="actualType">
    /// The argument type.
    /// </param>
    public TypeArgumentException(string message, Exception inner, Type actualType) : base(message, inner)
    {
        ActualTypeArgument = actualType;
    }
}
