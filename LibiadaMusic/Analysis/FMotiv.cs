namespace LibiadaMusic.Analysis
{
    using System;
    using System.Collections;

    /// <summary>
    /// The f motiv.
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
        /// <param name="freq">
        /// The freq.
        /// </param>
        public FMotiv(int id, string st, int occur, double freq)
        {
            Id = id;
            Name = st;
            Occurrence = occur;
            Frequency = freq;
            Probability = new ArrayList();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Ранг
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Сколько раз встретилось
        /// </summary>
        public double Occurrence { get; private set; }

        /// <summary>
        /// Частота
        /// </summary>
        public double Frequency { get; private set; }

        /// <summary>
        /// Удаленность
        /// </summary>
        public double Remoteness { get; set; }

        /// <summary>
        /// Глубина
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
