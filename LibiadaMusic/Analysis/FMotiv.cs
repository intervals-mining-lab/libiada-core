using System;
using System.Collections;

namespace LibiadaMusic.Analysis
{
    public class FMotiv
    {
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
        /// Условные вероятности
        /// </summary>
        private ArrayList Probability { get; set; }

        public double LogDepth
        {
            get { return Math.Log(Depth, 2); }
        }

        public double LogRank
        {
            get { return Math.Log(Rank, 2); }
        }

        public double LogOccurrence
        {
            get { return Math.Log(Occurrence, 2); }
        }

        public double LogRemoteness
        {
            get { return Math.Log(Remoteness, 2); }
        }
    }
}