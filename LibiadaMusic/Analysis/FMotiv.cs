namespace LibiadaMusic.Analysis
{
    using System;
    using System.Collections;

    /// <summary>
    /// The formal motiv.
    /// </summary>
    public class FMotiv
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FMotiv"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="st">
        /// The st.
        /// </param>
        /// <param name="occur">
        /// The occur.
        /// </param>
        /// <param name="frequency">
        /// The frequency.
        /// </param>
        public FMotiv(int id, string st, int occur, double frequency)
        {
            Id = id;
            Name = st;
            Occurrence = occur;
            Frequency = frequency;
            Probability = new ArrayList();
        }

        /// <summary>
        /// Gets the id of fmotiv.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Gets the occurrences count.
        /// </summary>
        public double Occurrence { get; private set; }

        /// <summary>
        /// Gets the frequency.
        /// </summary>
        public double Frequency { get; private set; }

        /// <summary>
        /// Gets or sets the remoteness.
        /// </summary>
        public double Remoteness { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        public double Depth { private get; set; }

        /// <summary>
        /// Gets the log depth.
        /// </summary>
        public double LogDepth
        {
            get { return Math.Log(Depth, 2); }
        }

        /// <summary>
        /// Gets the log rank.
        /// </summary>
        public double LogRank
        {
            get { return Math.Log(Rank, 2); }
        }

        /// <summary>
        /// Gets the log occurrence.
        /// </summary>
        public double LogOccurrence
        {
            get { return Math.Log(Occurrence, 2); }
        }

        /// <summary>
        /// Gets the log remoteness.
        /// </summary>
        public double LogRemoteness
        {
            get { return Math.Log(Remoteness, 2); }
        }

        /// <summary>
        /// Условные вероятности
        /// </summary>
        private ArrayList Probability { get; set; }
    }
}
