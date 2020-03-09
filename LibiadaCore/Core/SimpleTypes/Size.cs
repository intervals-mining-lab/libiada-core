namespace LibiadaCore.Core.SimpleTypes
{
    /// <summary>
    /// The size of measure is beats / beatbase (ex size = 3/4; beats=3; beatbase=4;)
    /// </summary>
    public class Size : IBaseObject
    {
        /// <summary>
        /// Gets the beats.
        /// </summary>
        public readonly int Beats;

        /// <summary>
        /// Gets the beat base.
        /// </summary>
        public readonly int BeatBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="beats">
        /// The beats.
        /// </param>
        /// <param name="beatBase">
        /// The beat base.
        /// </param>
        public Size(int beats, int beatBase)
        {
            Beats = beats;
            BeatBase = beatBase;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone() => new Size(Beats, BeatBase);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj) => obj is Size size
                                                && Beats == size.Beats
                                                && BeatBase == size.BeatBase;

        /// <summary>
        /// Calculates hash code using
        /// <see cref="Beats"/>, <see cref="BeatBase"/> .
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -1918903070;
                hashCode = (hashCode * -1521134295) + Beats.GetHashCode();
                hashCode = (hashCode * -1521134295) + BeatBase.GetHashCode();
                return hashCode;
            }
        }
    }
}
