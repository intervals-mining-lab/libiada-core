﻿namespace LibiadaMusic.Analysis
{
    using System.Collections;

    /// <summary>
    /// The display data.
    /// </summary>
    public class DisplayData
    {
        /// <summary>
        /// The pl capacity.
        /// </summary>
        public double PLCapacity;

        /// <summary>
        /// The tl capacity.
        /// </summary>
        public double TLCapacity;

        /// <summary>
        /// The great occur.
        /// </summary>
        public double GreatOccur;

        /// <summary>
        /// The great frequency.
        /// </summary>
        public double GreatFrequency;

        /// <summary>
        /// The great log depth.
        /// </summary>
        public double GreatLogDepth;

        /// <summary>
        /// The great remoteness.
        /// </summary>
        public double GreatRemoteness;

        /// <summary>
        /// The regularity.
        /// </summary>
        public double Regularity;

        /// <summary>
        /// The periodicity.
        /// </summary>
        public double Periodicity;

        /// <summary>
        /// The avg remoteness.
        /// </summary>
        public double AvgRemoteness;

        /// <summary>
        /// The avg depth.
        /// </summary>
        public double AvgDepth;

        /// <summary>
        /// The entropy.
        /// </summary>
        public double Entropy;

        /// <summary>
        /// The i info.
        /// </summary>
        public double IInfo;

        /// <summary>
        /// The oi info.
        /// </summary>
        public double OIInfo;

        /// <summary>
        /// The l entropy.
        /// </summary>
        public double LEntropy;

        /// <summary>
        /// The len.
        /// </summary>
        public double len;

        /// <summary>
        /// The id_ n.
        /// </summary>
        public ArrayList Id_N = new ArrayList();

        /// <summary>
        /// The rank_ freq p.
        /// </summary>
        public ArrayList Rank_FreqP = new ArrayList();

        /// <summary>
        /// The rank_ freq t.
        /// </summary>
        public ArrayList Rank_FreqT = new ArrayList();

        /// <summary>
        /// The log rank_ log np.
        /// </summary>
        public ArrayList LogRank_LogNP = new ArrayList();

        /// <summary>
        /// The log rank_ log nt.
        /// </summary>
        public ArrayList LogRank_LogNT = new ArrayList();

        /// <summary>
        /// The log rank_ log depth.
        /// </summary>
        public ArrayList LogRank_LogDepth = new ArrayList();

        /// <summary>
        /// The rank_ remoteness.
        /// </summary>
        public ArrayList Rank_Remoteness = new ArrayList();

        /// <summary>
        /// The diff v.
        /// </summary>
        public Difference DiffV = new Difference();

        /// <summary>
        /// The diff r freq.
        /// </summary>
        public Difference DiffRFreq = new Difference();

        /// <summary>
        /// The diff lrln.
        /// </summary>
        public Difference DiffLRLN = new Difference();
    }
}
