using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MDA.Analisis
{
    public class Lexicon
    {
        private int newid=0;
        private double GreatFrequency = 0;
        private double GreatOccur = 0;
        private int Capacity=0;
        private ArrayList FMVariety= new ArrayList();
        private ArrayList RFMVariety = new ArrayList();
        private bool Ranged=false;

        public ArrayList GetData()
        {lock (this)
			{
            return FMVariety;
			}
        }

        public ArrayList GetRData()
        {
            if (!this.Ranged)
            {
                this.RangeLexElem();
            }
            return RFMVariety;
        }

        public int GetCapacity()
        { lock(this)
			{
            return this.Capacity;
			}
        }

        public double GetGreatOccur()
        {
            return this.GreatOccur;
        }

        public void SetGreatFrequency(double n)
        {
            this.GreatFrequency = n;
        }

        public double GetGreatFrequency()
        {
            return this.GreatFrequency;
        }

        public double CalcGreatFrequency()
        {
            GreatFrequency = 0;
            for (int i = 0; i < this.Capacity;i++)
            {
                if (GreatFrequency < ((FMotiv) FMVariety[i]).GetFrequency())
                {
                    GreatFrequency = ((FMotiv) FMVariety[i]).GetFrequency();
                }
            }
            return this.GreatFrequency;
        }

        public void AddFMotiv(string name,int occur,double freq)
        {   this.FMVariety.Add(new FMotiv(newid,name,occur,freq));
            newid += 1;
            Capacity += 1;
            if (GreatFrequency < freq)
            {
                GreatFrequency = freq;
                GreatOccur = occur;
            }

        }

        public void RangeLex()
        {
            ArrayList ar = new ArrayList();
            ar = (ArrayList) FMVariety.Clone();
            double MaxFreq = 0;
            int CurMaxFreqId = 0;
            int CurMaxFreqArId = 0;
            for (int j = 0; j < FMVariety.Count; j++)
            {
                MaxFreq = ((FMotiv)ar[0]).GetFrequency();
                CurMaxFreqId = ((FMotiv)ar[0]).GetId();
                CurMaxFreqArId = 0;
                for (int i = 0; i < ar.Count; i++)
                {
                    if (MaxFreq<((FMotiv)ar[i]).GetFrequency())
                    {
                        MaxFreq = ((FMotiv) ar[i]).GetFrequency();
                        CurMaxFreqId = ((FMotiv) ar[i]).GetId();
                        CurMaxFreqArId = i;
                    }
                }
                ((FMotiv)FMVariety[CurMaxFreqId]).SetRank(j+1);
                ar.RemoveAt(CurMaxFreqArId);
            }
        }

        public ArrayList RangeLexDi()
        {
            ArrayList ar = new ArrayList();

            for (int i = 0; i < FMVariety.Count; i++)
            {
                ar.Add(((FMotiv)FMVariety[i]).GetLogDepth());
            }

            bool done = false;
            while (!done)
            {
                done = true;
                for (int j = 0; j < ar.Count - 1; j++)
                {
                    if (((double)ar[j]) < ((double)ar[j + 1]))
                    {
                        double tempD = (double)ar[j];
                        ar[j] = (double)ar[j + 1];
                        ar[j + 1] = tempD;
                        done = false;
                    }

                }

            }
            return ar;
        }

        public ArrayList RangeLexRi()
        {
            ArrayList ar = new ArrayList();

            for (int i = 0; i < FMVariety.Count; i++ )
            {
                ar.Add(((FMotiv)FMVariety[i]).GetRemoteness());
            }

            bool done = false;
        while(!done)
        {
            done = true;
            for (int j = 0; j < ar.Count-1; j++)
            {
                if (((double)ar[j]) < ((double)ar[j + 1]))
                    {
                        double tempD = (double)ar[j];
                        ar[j] = (double)ar[j + 1];
                        ar[j+1] = tempD;
                        done = false;
                    }
                
            }
            
        }
            return ar;
        }

        public void RangeLexElem()
        {
            for (int i =1; i<this.GetCapacity()+1;i++)
            {
                for (int j = 0; j < this.GetCapacity(); j++)
                {
                    if (((FMotiv)this.FMVariety[j]).GetRank() == i)
                    {
                        RFMVariety.Add(FMVariety[j]);
                    }
                }

            }
            Ranged = true;
        }
    }
}
