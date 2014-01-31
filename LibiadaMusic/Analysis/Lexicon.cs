using System.Collections;

namespace LibiadaMusic.Analysis
{
    public class Lexicon
    {
        private int newid=0;
        private double greatFrequency = 0;
        private double greatOccur = 0;
        private int capacity=0;
        private ArrayList FMVariety= new ArrayList();
        private ArrayList RFMVariety = new ArrayList();
        private bool Ranged=false;

        public ArrayList Data
        {
            get { return FMVariety; }
        }

        public ArrayList RData()
        {
            if (!Ranged)
            {
                RangeLexElem();
            }
            return RFMVariety;
        }

        public int Capacity
        {
            get { return capacity; }
 
        }

        public double GreatOccur
        {
            get { return greatOccur; }
            
        }

        public double GreatFrequency
        {
            get { return greatFrequency; }
            set { greatFrequency = value; }
            
        }

        public double CalcGreatFrequency()
        {
            greatFrequency = 0;
            for (int i = 0; i < capacity;i++)
            {
                if (greatFrequency < ((FMotiv) FMVariety[i]).Frequency)
                {
                    greatFrequency = ((FMotiv) FMVariety[i]).Frequency;
                }
            }
            return greatFrequency;
        }

        public void AddFMotiv(string name,int occur,double freq)
        {   FMVariety.Add(new FMotiv(newid,name,occur,freq));
            newid += 1;
            capacity += 1;
            if (greatFrequency < freq)
            {
                greatFrequency = freq;
                greatOccur = occur;
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
                MaxFreq = ((FMotiv)ar[0]).Frequency;
                CurMaxFreqId = ((FMotiv)ar[0]).Id;
                CurMaxFreqArId = 0;
                for (int i = 0; i < ar.Count; i++)
                {
                    if (MaxFreq<((FMotiv)ar[i]).Frequency)
                    {
                        MaxFreq = ((FMotiv) ar[i]).Frequency;
                        CurMaxFreqId = ((FMotiv) ar[i]).Id;
                        CurMaxFreqArId = i;
                    }
                }
                ((FMotiv)FMVariety[CurMaxFreqId]).Rank = j+1;
                ar.RemoveAt(CurMaxFreqArId);
            }
        }

        public ArrayList RangeLexDi()
        {
            ArrayList ar = new ArrayList();

            for (int i = 0; i < FMVariety.Count; i++)
            {
                ar.Add(((FMotiv)FMVariety[i]).LogDepth);
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
                ar.Add(((FMotiv)FMVariety[i]).Remoteness);
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
            for (int i =1; i<capacity+1;i++)
            {
                for (int j = 0; j < capacity; j++)
                {
                    if (((FMotiv)FMVariety[j]).Rank == i)
                    {
                        RFMVariety.Add(FMVariety[j]);
                    }
                }

            }
            Ranged = true;
        }
    }
}
