namespace LibiadaMusic.Analysis
{
    /// <summary>
    /// The fmotiv name.
    /// </summary>
    public class FmotivName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FmotivName"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public FmotivName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
