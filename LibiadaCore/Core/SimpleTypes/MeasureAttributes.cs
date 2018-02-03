namespace LibiadaCore.Core.SimpleTypes
{
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
            if (size != null)
            {
                Size = (Size)size.Clone();
            }

            if (key != null)
            {
                Key = (Key)key.Clone();
            }
        }

        /// <summary>
        /// Gets size that contains Beats, beatbase, ticksperbeat.
        /// </summary>
        public Size Size { get; private set; }

        /// <summary>
        /// Gets Key that contains fifths, mode.
        /// </summary>
        public Key Key { get; private set; }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new MeasureAttributes(Size, Key);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (Key.Equals(((MeasureAttributes)obj).Key) && Size.Equals(((MeasureAttributes)obj).Size))
            {
                return true;
            }

            return false;
        }
    }
}
