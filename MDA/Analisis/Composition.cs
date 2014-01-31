using System;
using System.Collections;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;


namespace MDA.Analisis
{
    public class Composition
    {
        public double Regularity;
        public double Periodicity;
        public double AvgRemoteness;
        public double AvgDepth;
        public double Entropy;
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
            ar = (ArrayList) Range.GetData().Clone();
            while(ar.Count!=0)
            {
                for(int i=0;i<ar.Count;i++)
                {
                    if (((FMName)ar[0]).GetName() == ((FMName)ar[i]).GetName())
                    {
                        N += 1;
                    }
                }
                double f = 0;
                f = Range.Getlength();
                PLex.AddFMotiv(((FMName) ar[0]).GetName(),N,N/f);
                N = 0;
                s = ((FMName)ar[0]).GetName();
                for (int i = 0; i <ar.Count ; i++)
                {
                    if (s == ((FMName)ar[i]).GetName())
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
            K = 1/System.Math.Log(PLex.GetGreatOccur());
            B = (K/PLex.GetGreatFrequency()) - 1;
            int i = 1;
            double Plow = 0;
            Plow = Range.Getlength();
            P = K / (B + i);
            while(P>=(1/Plow))
            {
                TLex.AddFMotiv((i - 1).ToString(), (int)System.Math.Round(P * Range.Getlength()), P);
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
            for (int i = 0; i < Range.Getlength();i++)
            {
                for (int j=0;j<PLex.GetCapacity();j++)
                {
                    if (((FMName)Range.GetData()[i]).GetName()==((FMotiv)PLex.GetData()[j]).GetName())
                    {
                        ((FMName) Range.GetData()[i]).SetId(((FMotiv) PLex.GetData()[j]).GetId());
                    }
                }
            }
        }

		public Chain MakeNewChain() // сделал из void конструктор
        {	lock (lchain)
			{
            Chain newchain = new Chain(Range.Getlength());

            for (int i = 0; i < Range.Getlength(); i++)
            {
                newchain[i] = new ValueInt(((FMName)Range.GetData()[i]).GetId());
            }
			
			chain =(Chain) newchain.Clone();
			return newchain;
			}
						
        } 
		
        public void CalcInfo()
        {
				IInfo=System.Math.Log(PLex.GetCapacity(),2);
            	/*if (Info!=System.Math.Truncate(Info))
            	{
	                Info = System.Math.Truncate(Info)+1;
    	        }*/
        	    OIInfo = IInfo;
            	IInfo *= Range.Getlength();
        } // По Шеннону

        public int GetInfo()
        {
            return (int) this.IInfo;
        }

        public void CalcEntropy()
        {
				double Ent = 0;
            	for (int i=0;i<PLex.GetCapacity();i++)
            	{
                	Ent += ((FMotiv)PLex.GetData()[i]).GetFrequency() * Math.Log(((FMotiv)PLex.GetData()[i]).GetFrequency(),2);
            	}
            	this.Entropy = Ent*(-1);
        } 

        public double GetEntropy()
        {
            return this.Entropy;
        }

		public void CalcGamut()
        {
			Characteristic G = new Characteristic(new Depth());
            AvgDepth = G.Value(MakeNewChain(), Link.End);
			
			int i;				
            for(i=0;i<PLex.GetCapacity();i++)
            {
                ((FMotiv)PLex.GetData()[i]).SetDepth(new Characteristic(new Depth()).Value(MakeNewChain().CongenericChain(i), Link.End));
            }
        }

        public void CalcRemoteness()
        {
            Characteristic R = new Characteristic(new AverageRemoteness());
            AvgRemoteness = R.Value(chain, Link.End);

            for (int i = 0; i < PLex.GetCapacity(); i++)
            {
                ((FMotiv)PLex.GetData()[i]).SetRemoteness(new Characteristic(new AverageRemoteness()).Value(chain.CongenericChain(i), Link.End));
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

            if (PLex.GetCapacity()<=TLex.GetCapacity())
            {
                count = PLex.GetCapacity();
            }
            else
            {
                count = TLex.GetCapacity();
            }

            for (int i = 0; i < count;i++)
            {
                ar1.Add(((FMotiv) TLex.GetData()[i]).GetFrequency());
                ar2.Add(((FMotiv) PLex.GetRData()[i]).GetFrequency());
                ar3.Add(((FMotiv)TLex.GetData()[i]).GetLogOccurernce());
                ar4.Add(((FMotiv)PLex.GetRData()[i]).GetLogOccurernce());
            }

            if (PLex.GetCapacity() != TLex.GetCapacity())
            {
                if(PLex.GetCapacity() > TLex.GetCapacity())
                {
                    for(int i=count;i<PLex.GetCapacity();i++)
                    {
                        ar1.Add((double) 0);
                        ar2.Add(((FMotiv)PLex.GetRData()[i]).GetFrequency());
                        ar3.Add((double)0);
                        ar4.Add(((FMotiv)PLex.GetRData()[i]).GetLogOccurernce());
                    }
                }
                else
                {
                    for (int i = count; i < TLex.GetCapacity(); i++)
                    {
                        ar1.Add(((FMotiv)TLex.GetData()[i]).GetFrequency());
                        ar2.Add((double)0);
                        ar3.Add(((FMotiv)TLex.GetData()[i]).GetLogOccurernce());
                        ar4.Add((double)0);

                    }

                }
            }

            FreqDiff.CalcDifference(ar1,ar2,Range.Getlength(),PLex.GetCapacity(),TLex.GetCapacity());
            LogNDiff.CalcDifference(ar3, ar4, Range.Getlength(), PLex.GetCapacity(),TLex.GetCapacity());
            VDiff.CalcDifferenceV(TLex.GetCapacity(), PLex.GetCapacity());
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
            disp.GreatOccur = PLex.GetGreatOccur();

            disp.DiffV = VDiff.Clone();
            disp.DiffRFreq = FreqDiff.Clone();
            disp.DiffLRLN = LogNDiff.Clone();

            disp.len = this.Range.Getlength();
            disp.Regularity = this.Regularity;
            disp.Periodicity = this.Periodicity;
            disp.AvgRemoteness = this.AvgRemoteness;
            disp.AvgDepth = this.AvgDepth;
            disp.IInfo = this.IInfo;
            disp.Entropy = this.Entropy;
            disp.PLCapacity=this.PLex.GetCapacity();
            disp.TLCapacity=this.TLex.GetCapacity();
            disp.GreatFrequency=this.PLex.GetGreatFrequency();
            disp.OIInfo = this.OIInfo;
            disp.LEntropy = this.Entropy*Range.Getlength();
  
            for(int i=0; i<PLex.GetCapacity();i++)
            {
                // на время эксперимента комментарий
                disp.Id_N.Add(new double[]
                {((FMotiv) PLex.GetData()[i]).GetId(), ((FMotiv) PLex.GetData()[i]).GetOccurernce()});
                
                //disp.Id_N.Add(new double[] { ((FMotiv)PLex.GetRData()[i]).GetRemoteness(), ((FMotiv)PLex.GetRData()[i]).GetFrequency() });
                //disp.Id_N.Add(new double[] { ((FMotiv)PLex.GetRData()[i]).GetRemoteness(), ((FMotiv)PLex.GetRData()[i]).GetFrequency() });

                disp.Rank_FreqP.Add(new double[] { ((FMotiv)PLex.GetRData()[i]).GetRank(), ((FMotiv)PLex.GetRData()[i]).GetFrequency()});

                disp.LogRank_LogNP.Add(new double[] { ((FMotiv)PLex.GetRData()[i]).GetLogRank(), ((FMotiv)PLex.GetRData()[i]).GetLogOccurernce()});


                /*disp.LogRank_LogGamut.Add(new double[] { ((FMotiv)PLex.GetRData()[i]).GetLogRank(), ((FMotiv)PLex.GetRData()[i]).GetLogDepth() });

                disp.Rank_Remoteness.Add(new double[] { ((FMotiv)PLex.GetRData()[i]).GetRank(), ((FMotiv)PLex.GetRData()[i]).GetRemoteness() });
                */
                
                disp.LogRank_LogGamut.Add(new double[] 
                { ((FMotiv)PLex.GetRData()[i]).GetLogRank(), (double)PLex.RangeLexDi()[i] });

                disp.Rank_Remoteness.Add(new double[]
                { ((FMotiv)PLex.GetRData()[i]).GetRank(),  (double)PLex.RangeLexRi()[i] });

            }

            for (int i = 0; i < TLex.GetCapacity(); i++)
            {
                disp.Rank_FreqT.Add(new double[] 
                {((FMotiv)TLex.GetRData()[i]).GetRank(), ((FMotiv)TLex.GetRData()[i]).GetFrequency() });

                disp.LogRank_LogNT.Add(new double[] 
                {((FMotiv)TLex.GetRData()[i]).GetLogRank(), ((FMotiv)TLex.GetRData()[i]).GetLogOccurernce() });
            }

            double GGamut = 0;
            double GRemote = 0;
            for (int i=0; i < PLex.GetCapacity();i++)
            {
                if (GGamut<((FMotiv) PLex.GetData()[i]).GetLogDepth())
                {
                    GGamut = ((FMotiv) PLex.GetData()[i]).GetLogDepth();
                }

                if (GRemote < ((FMotiv)PLex.GetData()[i]).GetRemoteness())
                {
                    GRemote = ((FMotiv)PLex.GetData()[i]).GetRemoteness();
                }
            }
            disp.GreatLogGamut = GGamut;
            disp.GreatRemoteness = GRemote;


        }

        public DisplayData GetDisplayData()
        {
            return disp;
        }


    }
}
