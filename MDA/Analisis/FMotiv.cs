using System;
using System.Collections;

namespace MDA.Analisis
{
    public class FMotiv
    {
        /// <summary>
        /// ID
        /// </summary>
        protected int id;

        /// <summary>
        /// Имя
        /// </summary>
        protected string name;

        /// <summary>
        /// Ранг
        /// </summary>
        private int rank;

        /// <summary>
        /// Сколько раз встретилось
        /// </summary>
        private double occurrence;

        /// <summary>
        /// Частота
        /// </summary>
        private double frequency;

        /// <summary>
        /// Удаленность
        /// </summary>
        private double remoteness;

        /// <summary>
        /// Глубина
        /// </summary>
        private double depth;

        /// <summary>
        /// Условные вероятности
        /// </summary>
        private ArrayList probability = new ArrayList();

        public FMotiv(int ident, string st, int occur, double freq)
        {
            id = ident;
            name = st;
            occurrence = occur;
            frequency = freq;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public int Rank
        {
            set { rank = value; }
            get { return rank; }

        }

        public double LogRank
        {
            set { rank = (int) Math.Pow(2, value); }
            get { return Math.Log(2, rank); }

        }

        public double Occurernce
        {
            set { occurrence = value; }
            get { return occurrence; }
        }

        public double LogOccurernce
        {
            set { occurrence = Math.Pow(2, value); }
            get { return Math.Log(2, occurrence); }
        }

        public double Frequency
        {
            set { frequency = value; }
            get { return frequency; }
        }

        public double Remoteness
        {
            set { remoteness = value; }
            get { return remoteness; }
        }

        public double LogRemoteness
        {
            set { remoteness = Math.Pow(2, value); }
            get { return Math.Log(2, remoteness); }
        }

        public double Depth
        {
            set { depth = value; }
            get { return depth; }
        }

        public double LogDepth
        {
            set { depth = Math.Pow(2, value); }
            get { return Math.Log(2, depth); }
        }

        public ArrayList Probability
        {
            set { probability = value; }
            get { return probability; }
        }
    }
}
