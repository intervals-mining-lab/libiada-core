namespace LibiadaCore.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown to indicate that an inappropriate type argument was used for
    /// a type parameter to a generic type or method.
    /// </summary>
    public class TypeArgumentException : Exception
    {
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
    }
}
