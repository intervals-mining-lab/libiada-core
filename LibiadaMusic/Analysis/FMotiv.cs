using System;
using System.Collections;

namespace LibiadaMusic.Analysis
{
    public class FMotiv
    {
        protected int id; //ID
        protected string name; //Имя
        private int rank; //Ранг
        private double occurrence; //Сколько раз встретилось
        private double remoteness; // Удаленность
        private double depth; //Глубина
        private ArrayList probability = new ArrayList(); // Условные вероятности

        public FMotiv(int ident, string st, int occur, double freq)
        {
            id = ident;
            name = st;
            occurrence = occur;
            Frequency = freq;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public double LogRank
        {
            get { return Math.Log(rank, 2); }
        }

        public double Occurernce
        {
            get { return occurrence; }
            set { occurrence = value; }
        }

        public double LogOccurernce
        {
            get { return Math.Log(occurrence, 2); }
        }

        public double Frequency { get; set; }

        public double Remoteness
        {
            get { return remoteness; }
            set { remoteness = value; }
        }

        public double LogRemoteness
        {
            get { return Math.Log(remoteness, 2); }
        }

        public double Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public double LogDepth
        {
            get { return Math.Log(depth, 2); }
        }

        public ArrayList SetProbability
        {
            get { return probability; }
            set { probability = value; }
        }
    }
}
