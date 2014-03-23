using System;
using System.Collections.Generic;

namespace LibiadaMusic.Analysis
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.SimpleTypes;

    public class Composition
    {
        public double Regularity;
        public double Periodicity;
        public double AvgRemoteness;
        public double AvgDepth;
        private double IInfo;
        private double OIInfo;
        private FmotivArray Range = new FmotivArray();
        public Lexicon PLex = new Lexicon();
        public Lexicon TLex = new Lexicon();
        private Chain chain;
        private Difference FreqDiff = new Difference();
        private Difference LogNDiff = new Difference();
        public Difference VDiff = new Difference();
        public DisplayData DisplayData { get; private set; }
        public double Entropy { get; private set; }

        /// <summary>
        /// По Шеннону
        /// </summary>
        public int Info
        {
            get { return (int)IInfo; }
        }

        public Composition()
        {
            DisplayData = new DisplayData();
        }

        public Composition Clone()
        {
            return (Composition) MemberwiseClone();
        }

        public void AddFM(string st)
        {
            Range.NewRecord(st);
        }

        public void CreatePLex()
        {
            int N = 0;
            string s;
            var ar = new List<FmotivName>();
            ar = new List<FmotivName>(Range.Data);
            while (ar.Count != 0)
            {
                for (int i = 0; i < ar.Count; i++)
                {
                    if (ar[0].Name == ar[i].Name)
                    {
                        N += 1;
                    }
                }
                double f = Range.Length;
                PLex.AddFMotiv(ar[0].Name, N, N/f);
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

        public void CreateTlex()
        {
            double K;
            double B;
            double P;
            K = 1/Math.Log(PLex.GreatOccur);
            B = (K/PLex.GreatFrequency) - 1;
            int i = 1;
            double Plow = Range.Length;
            P = K/(B + i);
            while (P >= (1/Plow))
            {
                TLex.AddFMotiv((i - 1).ToString(), (int) Math.Round(P*Range.Length), P);
                i++;
                P = K/(B + i);
            }
        }

        public void RangePlex()
        {
            PLex.RangeLex();
        }

        public void RangeTlex()
        {
            TLex.RangeLex();
        }

        public void IdentifyRange()
        {
            for (int i = 0; i < Range.Length; i++)
            {
                for (int j = 0; j < PLex.Capacity; j++)
                {
                    if (Range.Data[i].Name == PLex.Data[j].Name)
                    {
                        Range.Data[i].Id = PLex.Data[j].Id;
                    }
                }
            }
        }

        public Chain MakeNewChain()
        {
            var newChain = new Chain(Range.Length);

            for (int i = 0; i < Range.Length; i++)
            {
                newChain[i] = new ValueInt(Range.Data[i].Id);
            }

            chain = (Chain) newChain.Clone();
            return newChain;
        }

        public void CalcInfo()
        {
            IInfo = Math.Log(PLex.Capacity, 2);

            OIInfo = IInfo;
            IInfo *= Range.Length;
        }

        public void CalcEntropy()
        {
            double Ent = 0;
            for (int i = 0; i < PLex.Capacity; i++)
            {
                Ent += PLex.Data[i].Frequency*Math.Log(PLex.Data[i].Frequency, 2);
            }
            Entropy = Ent*(-1);
        }

        public void CalcDepth()
        {
            var calc = new Depth();
            AvgDepth = calc.Calculate(MakeNewChain(), Link.End);

            for (int i = 0; i < PLex.Capacity; i++)
            {
                PLex.Data[i].Depth = calc.Calculate(MakeNewChain().CongenericChain(i), Link.End);
            }
        }

        public void CalcRemoteness()
        {
            var calc = new AverageRemoteness();
            AvgRemoteness = calc.Calculate(chain, Link.End);

            for (int i = 0; i < PLex.Capacity; i++)
            {
                PLex.Data[i].Remoteness = calc.Calculate(chain.CongenericChain(i), Link.End);
            }
        }

        public void CalcRegularity()
        {
            var calc = new Regularity();
            Regularity = calc.Calculate(chain, Link.End);
        }

        public void CalcPeriodicity()
        {
            var calc = new Periodicity();
            Periodicity = calc.Calculate(chain, Link.End);
        }

        public void CalcDifference()
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

            FreqDiff.CalcDifference(ar1, ar2, Range.Length, PLex.Capacity, TLex.Capacity);
            LogNDiff.CalcDifference(ar3, ar4, Range.Length, PLex.Capacity, TLex.Capacity);
            VDiff.CalcDifferenceV(TLex.Capacity, PLex.Capacity);
        }

        public void CalcCharacteristics()
        {
            CalcDepth();
            CalcRemoteness();
            CalcRegularity();
            CalcPeriodicity();
            CalcEntropy();
            CalcInfo();
        }

        public void FillDisplayData()
        {
            DisplayData.GreatOccur = PLex.GreatOccur;

            DisplayData.DiffV = VDiff.Clone();
            DisplayData.DiffRFreq = FreqDiff.Clone();
            DisplayData.DiffLRLN = LogNDiff.Clone();

            DisplayData.len = Range.Length;
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
            DisplayData.LEntropy = Entropy*Range.Length;

            for (int i = 0; i < PLex.Capacity; i++)
            {
                // на время эксперимента комментарий
                DisplayData.Id_N.Add(new[] {PLex.Data[i].Id, PLex.Data[i].Occurrence});

                DisplayData.Rank_FreqP.Add(new[] {PLex.RData()[i].Rank, PLex.RData()[i].Frequency});

                DisplayData.LogRank_LogNP.Add(new[] {PLex.RData()[i].LogRank, PLex.RData()[i].LogOccurrence});

                DisplayData.LogRank_LogDepth.Add(new[] {PLex.RData()[i].LogRank, PLex.RangeLexDi()[i]});

                DisplayData.Rank_Remoteness.Add(new[] {PLex.RData()[i].Rank, PLex.RangeLexRi()[i]});

            }

            for (int i = 0; i < TLex.Capacity; i++)
            {
                DisplayData.Rank_FreqT.Add(new[]
                {TLex.RData()[i].Rank, TLex.RData()[i].Frequency});

                DisplayData.LogRank_LogNT.Add(new[]
                {TLex.RData()[i].LogRank, TLex.RData()[i].LogOccurrence});
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