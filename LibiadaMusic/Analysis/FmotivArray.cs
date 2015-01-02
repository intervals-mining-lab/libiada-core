namespace LibiadaMusic.Analysis
{
    using System.Collections.Generic;

    /// <summary>
    /// The fmotiv array.
    /// </summary>
    public class FmotivArray
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FmotivArray"/> class.
        /// </summary>
        public FmotivArray()
        {
            Data = new List<FmotivName>();
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public List<FmotivName> Data { get; private set; }

        /// <summary>
        /// Gets the length.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// The new record.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public void NewRecord(string name)
        {
            Data.Add(new FmotivName(name));
            Length += 1;
        }
    }
}
