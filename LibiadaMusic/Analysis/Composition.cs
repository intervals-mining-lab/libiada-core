using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaMusic.Analysis
{
    public class Composition
    {
        public double Regularity;
        public double Periodicity;
        public double AvgRemoteness;
        public double AvgDepth;
        private double entropy;
        private double IInfo;
        private double OIInfo;
        private FMArray Range = new FMArray();
        public Lexicon PLex = new Lexicon();
        public Lexicon TLex = new Lexicon();
        private Chain chain;
        private Difference FreqDiff = new Difference();
        private Difference LogNDiff = new Difference();
        public Difference VDiff = new Difference();
        private DisplayData disp = new DisplayData();

        private static object lchain = new object();

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
            var ar = new List<FMName>();
            ar = new List<FMName>(Range.Data);
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

        public Chain MakeNewChain() // сделал из void конструктор
        {
            lock (lchain)
            {
                var newChain = new Chain(Range.Length);

                for (int i = 0; i < Range.Length; i++)
                {
                    newChain[i] = new ValueInt(Range.Data[i].Id);
                }

                chain = (Chain) newChain.Clone();
                return newChain;
            }

        }

        public void CalcInfo()
        {
            IInfo = Math.Log(PLex.Capacity, 2);

            OIInfo = IInfo;
            IInfo *= Range.Length;
        } // По Шеннону

        public int Info()
        {
            return (int) IInfo;
        }

        public void CalcEntropy()
        {
            double Ent = 0;
            for (int i = 0; i < PLex.Capacity; i++)
            {
                Ent += PLex.Data[i].Frequency*Math.Log(PLex.Data[i].Frequency, 2);
            }
            entropy = Ent*(-1);
        }

        public double Entropy
        {
            get { return entropy; }
        }

        public void CalcGamut()
        {
            var G = new Characteristic(new Depth());
            AvgDepth = G.Value(MakeNewChain(), Link.End);

            int i;
            for (i = 0; i < PLex.Capacity; i++)
            {
                PLex.Data[i].Depth = new Characteristic(new Depth()).Value(
                    MakeNewChain().CongenericChain(i), Link.End);
            }
        }

        public void CalcRemoteness()
        {
            var R = new Characteristic(new AverageRemoteness());
            AvgRemoteness = R.Value(chain, Link.End);

            for (int i = 0; i < PLex.Capacity; i++)
            {
                PLex.Data[i].Remoteness =
                    new Characteristic(new AverageRemoteness()).Value(chain.CongenericChain(i), Link.End);
            }
        }

        public void CalcRegularity()
        {
            var R = new Characteristic(new Regularity());
            Regularity = R.Value(chain, Link.End);
        }

        public void CalcPeriodicity()
        {
            var P = new Characteristic(new Periodicity());
            Periodicity = P.Value(chain, Link.End);
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
                ar3.Add(TLex.Data[i].LogOccurernce);
                ar4.Add(PLex.RData()[i].LogOccurernce);
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
                        ar4.Add(PLex.RData()[i].LogOccurernce);
                    }
                }
                else
                {
                    for (int i = count; i < TLex.Capacity; i++)
                    {
                        ar1.Add(TLex.Data[i].Frequency);
                        ar2.Add(0);
                        ar3.Add(TLex.Data[i].LogOccurernce);
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
            CalcGamut();
            CalcRemoteness();
            CalcRegularity();
            CalcPeriodicity();
            CalcEntropy();
            CalcInfo();
        }

        public void FillDisplayData()
        {
            disp.GreatOccur = PLex.GreatOccur;

            disp.DiffV = VDiff.Clone();
            disp.DiffRFreq = FreqDiff.Clone();
            disp.DiffLRLN = LogNDiff.Clone();

            disp.len = Range.Length;
            disp.Regularity = Regularity;
            disp.Periodicity = Periodicity;
            disp.AvgRemoteness = AvgRemoteness;
            disp.AvgDepth = AvgDepth;
            disp.IInfo = IInfo;
            disp.Entropy = entropy;
            disp.PLCapacity = PLex.Capacity;
            disp.TLCapacity = TLex.Capacity;
            disp.GreatFrequency = PLex.GreatFrequency;
            disp.OIInfo = OIInfo;
            disp.LEntropy = entropy*Range.Length;

            for (int i = 0; i < PLex.Capacity; i++)
            {
                // на время эксперимента комментарий
                disp.Id_N.Add(new double[]
                {PLex.Data[i].Id, PLex.Data[i].Occurernce});

                disp.Rank_FreqP.Add(new double[] {PLex.RData()[i].Rank, PLex.RData()[i].Frequency});

                disp.LogRank_LogNP.Add(new double[]
                {PLex.RData()[i].LogRank, PLex.RData()[i].LogOccurernce});

                disp.LogRank_LogGamut.Add(new double[]
                {PLex.RData()[i].LogRank, PLex.RangeLexDi()[i]});

                disp.Rank_Remoteness.Add(new double[]
                {PLex.RData()[i].Rank, PLex.RangeLexRi()[i]});

            }

            for (int i = 0; i < TLex.Capacity; i++)
            {
                disp.Rank_FreqT.Add(new double[]
                {TLex.RData()[i].Rank, TLex.RData()[i].Frequency});

                disp.LogRank_LogNT.Add(new double[]
                {TLex.RData()[i].LogRank, TLex.RData()[i].LogOccurernce});
            }

            double GGamut = 0;
            double GRemote = 0;
            for (int i = 0; i < PLex.Capacity; i++)
            {
                if (GGamut < PLex.Data[i].LogDepth)
                {
                    GGamut = PLex.Data[i].LogDepth;
                }

                if (GRemote < PLex.Data[i].Remoteness)
                {
                    GRemote = PLex.Data[i].Remoteness;
                }
            }
            disp.GreatLogGamut = GGamut;
            disp.GreatRemoteness = GRemote;


        }

        public DisplayData DisplayData()
        {
            return disp;
        }
    }
}
