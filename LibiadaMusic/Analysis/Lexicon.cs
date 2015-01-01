namespace LibiadaMusic.Analysis
{
    using System.Collections.Generic;

    public class Lexicon
    {
        private int newId;
        private double greatOccur;
        private int capacity;
        private List<FMotiv> RFMVariety = new List<FMotiv>();
        private bool ranged;

        public double GreatFrequency { get; private set; }

        public List<FMotiv> Data { get; private set; }

        public Lexicon()
        {
            Data = new List<FMotiv>();
        }

        public List<FMotiv> RData()
        {
            if (!ranged)
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

        public double CalcGreatFrequency()
        {
            GreatFrequency = 0;
            for (int i = 0; i < capacity; i++)
            {
                if (GreatFrequency < Data[i].Frequency)
                {
                    GreatFrequency = Data[i].Frequency;
                }
            }

            return GreatFrequency;
        }

        public void AddFMotiv(string name, int occur, double freq)
        {
            Data.Add(new FMotiv(newId, name, occur, freq));
            newId += 1;
            capacity += 1;
            if (GreatFrequency < freq)
            {
                GreatFrequency = freq;
                greatOccur = occur;
            }
        }

        public void RangeLex()
        {
            var ar = new List<FMotiv>(Data);
            for (int j = 0; j < Data.Count; j++)
            {
                double maxFreq = ar[0].Frequency;
                int curMaxFreqId = ar[0].Id;
                int curMaxFreqArId = 0;
                for (int i = 0; i < ar.Count; i++)
                {
                    if (maxFreq < ar[i].Frequency)
                    {
                        maxFreq = ar[i].Frequency;
                        curMaxFreqId = ar[i].Id;
                        curMaxFreqArId = i;
                    }
                }

                Data[curMaxFreqId].Rank = j + 1;
                ar.RemoveAt(curMaxFreqArId);
            }
        }

        public List<double> RangeLexDi()
        {
            var ar = new List<double>();

            for (int i = 0; i < Data.Count; i++)
            {
                ar.Add(Data[i].LogDepth);
            }

            bool done = false;
            while (!done)
            {
                done = true;
                for (int j = 0; j < ar.Count - 1; j++)
                {
                    if (ar[j] < ar[j + 1])
                    {
                        double tempD = ar[j];
                        ar[j] = ar[j + 1];
                        ar[j + 1] = tempD;
                        done = false;
                    }
                }
            }

            return ar;
        }

        public List<double> RangeLexRi()
        {
            var ar = new List<double>();

            for (int i = 0; i < Data.Count; i++)
            {
                ar.Add(Data[i].Remoteness);
            }

            bool done = false;
            while (!done)
            {
                done = true;
                for (int j = 0; j < ar.Count - 1; j++)
                {
                    if (ar[j] < ar[j + 1])
                    {
                        double tempD = ar[j];
                        ar[j] = ar[j + 1];
                        ar[j + 1] = tempD;
                        done = false;
                    }
                }
            }

            return ar;
        }

        public void RangeLexElem()
        {
            for (int i = 1; i < capacity + 1; i++)
            {
                for (int j = 0; j < capacity; j++)
                {
                    if (Data[j].Rank == i)
                    {
                        RFMVariety.Add(Data[j]);
                    }
                }
            }

            ranged = true;
        }
    }
}
