namespace LibiadaCore.Core.SimpleTypes
{
    using SixLabors.ImageSharp;

    /// <summary>
    /// The value pixel.
    /// </summary>
    public class ValuePixel : IBaseObject
    {
        /// <summary>
        /// The value as <see cref="Rgba32"/>.
        /// </summary>
        private readonly Rgba32 value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuePixel"/> class.
        /// </summary>
        /// <param name="value">
        /// The value as <see cref="Rgba32"/>.
        /// </param>
        public ValuePixel(Rgba32 value) => this.value = value;

        /// <summary>
        /// Creates a copy of the element.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone() => new ValuePixel(value);

        /// <summary>
        /// Compares pixel to another object.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other) => other is ValuePixel pixel && value.Equals(pixel.value);

        /// <summary>
        /// Calculates hash code using <see cref="value"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => value.GetHashCode();
    }
}
