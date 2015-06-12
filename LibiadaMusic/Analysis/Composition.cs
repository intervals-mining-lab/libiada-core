namespace LibiadaMusic.Analysis
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The composition.
    /// </summary>
    public class Composition
    {
        /// <summary>
        /// The regularity.
        /// </summary>
        public double Regularity;

        /// <summary>
        /// The periodicity.
        /// </summary>
        public double Periodicity;

        /// <summary>
        /// The average remoteness.
        /// </summary>
        public double AvgRemoteness;

        /// <summary>
        /// The average depth.
        /// </summary>
        public double AvgDepth;

        /// <summary>
        /// The p lex.
        /// </summary>
        public Lexicon PLex = new Lexicon();

        /// <summary>
        /// The t lex.
        /// </summary>
        public Lexicon TLex = new Lexicon();

        /// <summary>
        /// The v diff.
        /// </summary>
        public Difference VDiff = new Difference();

        /// <summary>
        /// The i info.
        /// </summary>
        private double IInfo;

        /// <summary>
        /// The oi info.
        /// </summary>
        private double OIInfo;

        /// <summary>
        /// The range.
        /// </summary>
        private FmotivArray range = new FmotivArray();

        /// <summary>
        /// The chain.
        /// </summary>
        private Chain chain;

        /// <summary>
        /// The frequency difference.
        /// </summary>
        private Difference FreqDiff = new Difference();

        /// <summary>
        /// The log n difference.
        /// </summary>
        private Difference LogNDiff = new Difference();

        /// <summary>
        /// Initializes a new instance of the <see cref="Composition"/> class.
        /// </summary>
        public Composition()
        {
            DisplayData = new DisplayData();
        }

        /// <summary>
        /// Gets the display data.
        /// </summary>
        public DisplayData DisplayData { get; private set; }

        /// <summary>
        /// Gets the entropy.
        /// </summary>
        public double Entropy { get; private set; }

        /// <summary>
        /// По Шеннону
        /// </summary>
        public int Info
        {
            get { return (int)IInfo; }
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="Composition"/>.
        /// </returns>
        public Composition Clone()
        {
            return (Composition)MemberwiseClone();
        }

        /// <summary>
        /// The add fm.
        /// </summary>
        /// <param name="st">
        /// The st.
        /// </param>
        public void AddFM(string st)
        {
            range.NewRecord(st);
        }

        /// <summary>
        /// The create p lex.
        /// </summary>
        public void CreatePLex()
        {
            int N = 0;
            string s;
            var ar = new List<FmotivName>(range.Data);
            while (ar.Count != 0)
            {
                for (int i = 0; i < ar.Count; i++)
                {
                    if (ar[0].Name == ar[i].Name)
                    {
                        N += 1;
                    }
                }

                double f = range.Length;
                PLex.AddFMotiv(ar[0].Name, N, N / f);
                N = 0;
                s = ar[0].Name;
                for (int i = 0; i < ar.Count; i++)
                {
                    if (s == ar[i].Name)
                    {
                        ar.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        /// <summary>
        /// The create tlex.
        /// </summary>
        public void CreateTlex()
        {
            double K;
            double B;
            double P;
            K = 1 / Math.Log(PLex.GreatOccur);
            B = (K / PLex.GreatFrequency) - 1;
            int i = 1;
            double Plow = range.Length;
            P = K / (B + i);
            while (P >= (1 / Plow))
            {
                TLex.AddFMotiv((i - 1).ToString(), (int)Math.Round(P * range.Length), P);
                i++;
                P = K / (B + i);
            }
        }

        /// <summary>
        /// The range plex.
        /// </summary>
        public void RangePlex()
        {
            PLex.RangeLex();
        }

        /// <summary>
        /// The range tlex.
        /// </summary>
        public void RangeTlex()
        {
            TLex.RangeLex();
        }

        /// <summary>
        /// The identify range.
        /// </summary>
        public void IdentifyRange()
        {
            for (int i = 0; i < range.Length; i++)
            {
                for (int j = 0; j < PLex.Capacity; j++)
                {
                    if (range.Data[i].Name == PLex.Data[j].Name)
                    {
                        range.Data[i].Id = PLex.Data[j].Id;
                    }
                }
            }
        }

        /// <summary>
        /// The make new chain.
        /// </summary>
        /// <returns>
        /// The <see cref="Chain"/>.
        /// </returns>
        public Chain MakeNewChain()
        {
            var newChain = new Chain(range.Length);

            for (int i = 0; i < range.Length; i++)
            {
                newChain[i] = new ValueInt(range.Data[i].Id);
            }

            chain = (Chain)newChain.Clone();
            return newChain;
        }

        /// <summary>
        /// The calculate info.
        /// </summary>
        public void CalculateInfo()
        {
            IInfo = Math.Log(PLex.Capacity, 2);

            OIInfo = IInfo;
            IInfo *= range.Length;
        }

        /// <summary>
        /// The calculate entropy.
        /// </summary>
        public void CalculateEntropy()
        {
            double entropy = 0;
            for (int i = 0; i < PLex.Capacity; i++)
            {
                entropy += PLex.Data[i].Frequency * Math.Log(PLex.Data[i].Frequency, 2);
            }

            Entropy = entropy * (-1);
        }

        /// <summary>
        /// The calculate depth.
        /// </summary>
        public void CalculateDepth()
        {
            var calculator = new Depth();
            AvgDepth = calculator.Calculate(MakeNewChain(), Link.End);

            for (int i = 0; i < PLex.Capacity; i++)
            {
                PLex.Data[i].Depth = calculator.Calculate(MakeNewChain().CongenericChain(i), Link.End);
            }
        }

        /// <summary>
        /// The calculate remoteness.
        /// </summary>
        public void CalculateRemoteness()
        {
            var calculator = new AverageRemoteness();
            AvgRemoteness = calculator.Calculate(chain, Link.End);

            for (int i = 0; i < PLex.Capacity; i++)
            {
                PLex.Data[i].Remoteness = calculator.Calculate(chain.CongenericChain(i), Link.End);
            }
        }

        /// <summary>
        /// The calculate regularity.
        /// </summary>
        public void CalculateRegularity()
        {
            var calculator = new Regularity();
            Regularity = calculator.Calculate(chain, Link.End);
        }

        /// <summary>
        /// The calculate periodicity.
        /// </summary>
        public void CalculatePeriodicity()
        {
            var calculator = new Periodicity();
            Periodicity = calculator.Calculate(chain, Link.End);
        }

        /// <summary>
        /// The calculate difference.
        /// </summary>
        public void CalculateDifference()
        {
            var ar1 = new List<double>();
            var ar2 = new List<double>();
            var ar3 = new List<double>();
            var ar4 = new List<double>();

            int count = PLex.Capacity <= TLex.Capacity ? PLex.Capacity : TLex.Capacity;

            for (int i = 0; i < count; i++)
            {
                ar1.Add(TLex.Data[i].Frequency);
                ar2.Add(PLex.RData()[i].Frequency);
                ar3.Add(TLex.Data[i].LogOccurrence);
                ar4.Add(PLex.RData()[i].LogOccurrence);
            }

            if (PLex.Capacity != TLex.Capacity)
            {
                if (PLex.Capacity > TLex.Capacity)
                {
                    for (int i = count; i < PLex.Capacity; i++)
                    {
                        ar1.Add(0);
                        ar2.Add(PLex.RData()[i].Frequency);
                        ar3.Add(0);
                        ar4.Add(PLex.RData()[i].LogOccurrence);
                    }
                }
                else
                {
                    for (int i = count; i < TLex.Capacity; i++)
                    {
                        ar1.Add(TLex.Data[i].Frequency);
                        ar2.Add(0);
                        ar3.Add(TLex.Data[i].LogOccurrence);
                        ar4.Add(0);
                    }
                }
            }

            FreqDiff.CalculateDifference(ar1, ar2, range.Length, PLex.Capacity, TLex.Capacity);
            LogNDiff.CalculateDifference(ar3, ar4, range.Length, PLex.Capacity, TLex.Capacity);
            VDiff.CalculateDifferenceV(TLex.Capacity, PLex.Capacity);
        }

        /// <summary>
        /// The calculate characteristics.
        /// </summary>
        public void CalculateCharacteristics()
        {
            CalculateDepth();
            CalculateRemoteness();
            CalculateRegularity();
            CalculatePeriodicity();
            CalculateEntropy();
            CalculateInfo();
        }

        /// <summary>
        /// The fill display data.
        /// </summary>
        public void FillDisplayData()
        {
            DisplayData.GreatOccur = PLex.GreatOccur;

            DisplayData.DiffV = VDiff.Clone();
            DisplayData.DiffRFreq = FreqDiff.Clone();
            DisplayData.DiffLRLN = LogNDiff.Clone();

            DisplayData.Length = range.Length;
            DisplayData.Regularity = Regularity;
            DisplayData.Periodicity = Periodicity;
            DisplayData.AvgRemoteness = AvgRemoteness;
            DisplayData.AvgDepth = AvgDepth;
            DisplayData.IInfo = IInfo;
            DisplayData.Entropy = Entropy;
            DisplayData.PLCapacity = PLex.Capacity;
            DisplayData.TLCapacity = TLex.Capacity;
            DisplayData.GreatFrequency = PLex.GreatFrequency;
            DisplayData.OIInfo = OIInfo;
            DisplayData.LEntropy = Entropy * range.Length;

            for (int i = 0; i < PLex.Capacity; i++)
            {
                // на время эксперимента комментарий
                DisplayData.IdN.Add(new[] { PLex.Data[i].Id, PLex.Data[i].Occurrence });

                DisplayData.RankFreqP.Add(new[] { PLex.RData()[i].Rank, PLex.RData()[i].Frequency });

                DisplayData.LogRankLogNP.Add(new[] { PLex.RData()[i].LogRank, PLex.RData()[i].LogOccurrence });

                DisplayData.LogRankLogDepth.Add(new[] { PLex.RData()[i].LogRank, PLex.RangeLexDi()[i] });

                DisplayData.RankRemoteness.Add(new[] { PLex.RData()[i].Rank, PLex.RangeLexRi()[i] });
            }

            for (int i = 0; i < TLex.Capacity; i++)
            {
                DisplayData.RankFreqT.Add(new[] { TLex.RData()[i].Rank, TLex.RData()[i].Frequency });

                DisplayData.LogRankLogNT.Add(new[] { TLex.RData()[i].LogRank, TLex.RData()[i].LogOccurrence });
            }

            double gDepth = 0;
            double gRemote = 0;
            for (int i = 0; i < PLex.Capacity; i++)
            {
                if (gDepth < PLex.Data[i].LogDepth)
                {
                    gDepth = PLex.Data[i].LogDepth;
                }

                if (gRemote < PLex.Data[i].Remoteness)
                {
                    gRemote = PLex.Data[i].Remoteness;
                }
            }

            DisplayData.GreatLogDepth = gDepth;
            DisplayData.GreatRemoteness = gRemote;
        }
    }
}
