using System;
using System.Collections;
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
        public double entropy;
        private double IInfo;
        private double OIInfo;
        private FMArray Range = new FMArray();
        public Lexicon PLex = new Lexicon();
        public Lexicon TLex = new Lexicon();
        private Chain chain =null;
        private Difference FreqDiff= new Difference();
        private Difference LogNDiff= new Difference();
        public Difference VDiff = new Difference();
        private DisplayData disp = new DisplayData();
        
        static object lchain = new object();

        public Composition() 
        {

        }
        public Composition Clone()
        {
            return (Composition) this.MemberwiseClone();
        }

        public void AddFM(string st)
        {
            Range.NewRecord(st);
        }

        public void CreatePLex()
        {
            int N=0;
            string s="";
            ArrayList ar=new ArrayList();
            ar = (ArrayList) Range.Data.Clone();
            while(ar.Count!=0)
            {
                for(int i=0;i<ar.Count;i++)
                {
                    if (((FMName)ar[0]).Name == ((FMName)ar[i]).Name)
                    {
                        N += 1;
                    }
                }
                double f = 0;
                f = Range.Length;
                PLex.AddFMotiv(((FMName) ar[0]).Name,N,N/f);
                N = 0;
                s = ((FMName)ar[0]).Name;
                for (int i = 0; i <ar.Count ; i++)
                {
                    if (s == ((FMName)ar[i]).Name)
                    {
                        ar.RemoveAt(i);
                        i--;
                    }
                }

            }
        }

        public void CreateTlex()
        {
            double K = 0;
            double B = 0;
            double P = 0;
            K = 1/System.Math.Log(PLex.GreatOccur);
            B = (K/PLex.GreatFrequency) - 1;
            int i = 1;
            double Plow = 0;
            Plow = Range.Length;
            P = K / (B + i);
            while(P>=(1/Plow))
            {
                TLex.AddFMotiv((i - 1).ToString(), (int)System.Math.Round(P * Range.Length), P);
                i++;
                P = K / (B + i);
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
                for (int j=0;j<PLex.Capacity;j++)
                {
                    if (((FMName)Range.Data[i]).Name==((FMotiv)PLex.Data[j]).Name)
                    {
                        ((FMName) Range.Data[i]).Id =((FMotiv) PLex.Data[j]).Id;
                    }
                }
            }
        }

        public Chain MakeNewChain() // сделал из void конструктор
        {	lock (lchain)
            {
                Chain newchain = new Chain(Range.Length);

                for (int i = 0; i < Range.Length; i++)
            {
                newchain[i] = new ValueInt(((FMName)Range.Data[i]).Id);
            }
            
            chain =(Chain) newchain.Clone();
            return newchain;
            }
                        
        } 
        
        public void CalcInfo()
        {
                IInfo=System.Math.Log(PLex.Capacity,2);
                /*if (Info!=System.Math.Truncate(Info))
                {
                    Info = System.Math.Truncate(Info)+1;
                }*/
                OIInfo = IInfo;
                IInfo *= Range.Length;
        } // По Шеннону

        public int Info()
        {
            return (int) this.IInfo;
        }

        public void CalcEntropy()
        {
                double Ent = 0;
                for (int i=0;i<PLex.Capacity;i++)
                {
                    Ent += ((FMotiv)PLex.Data[i]).Frequency * Math.Log(((FMotiv)PLex.Data[i]).Frequency,2);
                }
                this.entropy = Ent*(-1);
        } 

        public double Entropy()
        {
            return this.entropy;
        }

        public void CalcGamut()
        {
            Characteristic G = new Characteristic(new Depth());
            AvgDepth = G.Value(MakeNewChain(), Link.End);
            
            int i;				
            for(i=0;i<PLex.Capacity;i++)
            {
                ((FMotiv)PLex.Data[i]).Depth = new Characteristic(new Depth()).Value(MakeNewChain().CongenericChain(i), Link.End);
            }
        }

        public void CalcRemoteness()
        {
            Characteristic R = new Characteristic(new AverageRemoteness());
            AvgRemoteness = R.Value(chain, Link.End);

            for (int i = 0; i < PLex.Capacity; i++)
            {
                ((FMotiv)PLex.Data[i]).Remoteness = new Characteristic(new AverageRemoteness()).Value(chain.CongenericChain(i), Link.End);
            }
        }
        
        public void CalcRegularity()
        {
            Characteristic R = new Characteristic(new Regularity());
            Regularity = R.Value(chain, Link.End);
        }

        public void CalcPeriodicity()
        {
            Characteristic P = new Characteristic(new Periodicity());
            Periodicity = P.Value(chain, Link.End);			
        }

        public void CalcDifference()
        {
            ArrayList ar1 = new ArrayList();
            ArrayList ar2 = new ArrayList();
            ArrayList ar3 = new ArrayList();
            ArrayList ar4 = new ArrayList();
            int count = 0;

            if (PLex.Capacity<=TLex.Capacity)
            {
                count = PLex.Capacity;
            }
            else
            {
                count = TLex.Capacity;
            }

            for (int i = 0; i < count;i++)
            {
                ar1.Add(((FMotiv) TLex.Data[i]).Frequency);
                ar2.Add(((FMotiv) PLex.RData()[i]).Frequency);
                ar3.Add(((FMotiv)TLex.Data[i]).LogOccurernce);
                ar4.Add(((FMotiv)PLex.RData()[i]).LogOccurernce);
            }

            if (PLex.Capacity != TLex.Capacity)
            {
                if(PLex.Capacity > TLex.Capacity)
                {
                    for(int i=count;i<PLex.Capacity;i++)
                    {
                        ar1.Add((double) 0);
                        ar2.Add(((FMotiv)PLex.RData()[i]).Frequency);
                        ar3.Add((double)0);
                        ar4.Add(((FMotiv)PLex.RData()[i]).LogOccurernce);
                    }
                }
                else
                {
                    for (int i = count; i < TLex.Capacity; i++)
                    {
                        ar1.Add(((FMotiv)TLex.Data[i]).Frequency);
                        ar2.Add((double)0);
                        ar3.Add(((FMotiv)TLex.Data[i]).LogOccurernce);
                        ar4.Add((double)0);

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

            disp.len = this.Range.Length;
            disp.Regularity = this.Regularity;
            disp.Periodicity = this.Periodicity;
            disp.AvgRemoteness = this.AvgRemoteness;
            disp.AvgDepth = this.AvgDepth;
            disp.IInfo = this.IInfo;
            disp.Entropy = this.entropy;
            disp.PLCapacity=this.PLex.Capacity;
            disp.TLCapacity=this.TLex.Capacity;
            disp.GreatFrequency=this.PLex.GreatFrequency;
            disp.OIInfo = this.OIInfo;
            disp.LEntropy = this.entropy * Range.Length;
  
            for(int i=0; i<PLex.Capacity;i++)
            {
                // на время эксперимента комментарий
                disp.Id_N.Add(new double[]
                {((FMotiv) PLex.Data[i]).Id, ((FMotiv) PLex.Data[i]).Occurernce});
                
                //disp.Id_N.Add(new double[] { ((FMotiv)PLex.RData()[i]).Remoteness(), ((FMotiv)PLex.RData()[i]).Frequency });
                //disp.Id_N.Add(new double[] { ((FMotiv)PLex.RData()[i]).Remoteness(), ((FMotiv)PLex.RData()[i]).Frequency });

                disp.Rank_FreqP.Add(new double[] { ((FMotiv)PLex.RData()[i]).Rank, ((FMotiv)PLex.RData()[i]).Frequency});

                disp.LogRank_LogNP.Add(new double[] { ((FMotiv)PLex.RData()[i]).LogRank, ((FMotiv)PLex.RData()[i]).LogOccurernce});


                /*disp.LogRank_LogGamut.Add(new double[] { ((FMotiv)PLex.RData()[i]).LogRank(), ((FMotiv)PLex.RData()[i]).LogDepth() });

                disp.Rank_Remoteness.Add(new double[] { ((FMotiv)PLex.RData()[i]).Rank(), ((FMotiv)PLex.RData()[i]).Remoteness() });
                */
                
                disp.LogRank_LogGamut.Add(new double[] 
                { ((FMotiv)PLex.RData()[i]).LogRank, (double)PLex.RangeLexDi()[i] });

                disp.Rank_Remoteness.Add(new double[]
                { ((FMotiv)PLex.RData()[i]).Rank,  (double)PLex.RangeLexRi()[i] });

            }

            for (int i = 0; i < TLex.Capacity; i++)
            {
                disp.Rank_FreqT.Add(new double[] 
                {((FMotiv)TLex.RData()[i]).Rank, ((FMotiv)TLex.RData()[i]).Frequency });

                disp.LogRank_LogNT.Add(new double[] 
                {((FMotiv)TLex.RData()[i]).LogRank, ((FMotiv)TLex.RData()[i]).LogOccurernce });
            }

            double GGamut = 0;
            double GRemote = 0;
            for (int i=0; i < PLex.Capacity;i++)
            {
                if (GGamut<((FMotiv) PLex.Data[i]).LogDepth)
                {
                    GGamut = ((FMotiv) PLex.Data[i]).LogDepth;
                }

                if (GRemote < ((FMotiv)PLex.Data[i]).Remoteness)
                {
                    GRemote = ((FMotiv)PLex.Data[i]).Remoteness;
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
