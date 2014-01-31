using System.Collections;

namespace LibiadaMusic.Analysis
{
    public class DisplayData
    {
        public double PLCapacity;
        public double TLCapacity;
        public double GreatOccur;
        public double GreatFrequency;
        public double GreatLogGamut;
        public double GreatRemoteness;
        public double Regularity;
        public double Periodicity;
        public double AvgRemoteness;
        public double AvgDepth;
        public double Entropy;
        public double IInfo;
        public double OIInfo;
        public double LEntropy;
        public double len;
        public ArrayList Id_N = new ArrayList();
        public ArrayList Rank_FreqP = new ArrayList();
        public ArrayList Rank_FreqT = new ArrayList();
        public ArrayList LogRank_LogNP = new ArrayList();
        public ArrayList LogRank_LogNT = new ArrayList();
        public ArrayList LogRank_LogGamut = new ArrayList();
        public ArrayList Rank_Remoteness = new ArrayList();
        public Difference DiffV = new Difference();
        public Difference DiffRFreq = new Difference();
        public Difference DiffLRLN = new Difference();
    }
  
}
