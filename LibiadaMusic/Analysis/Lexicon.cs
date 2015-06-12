namespace LibiadaMusic.Analysis
{
    using System.Collections.Generic;

    /// <summary>
    /// The lexicon.
    /// </summary>
    public class Lexicon
    {
        /// <summary>
        /// The new id.
        /// </summary>
        private int newId;

        /// <summary>
        /// The great occur.
        /// </summary>
        private double greatOccur;

        /// <summary>
        /// The capacity.
        /// </summary>
        private int capacity;

        /// <summary>
        /// The rfm variety.
        /// </summary>
        private List<FMotiv> RFMVariety = new List<FMotiv>();

        /// <summary>
        /// The ranged.
        /// </summary>
        private bool ranged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lexicon"/> class.
        /// </summary>
        public Lexicon()
        {
            Data = new List<FMotiv>();
        }

        /// <summary>
        /// Gets the great frequency.
        /// </summary>
        public double GreatFrequency { get; private set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public List<FMotiv> Data { get; private set; }

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        public int Capacity
        {
            get { return capacity; }
        }

        /// <summary>
        /// Gets the great occur.
        /// </summary>
        public double GreatOccur
        {
            get { return greatOccur; }
        }

        /// <summary>
        /// The r data.
        /// </summary>
        /// <returns>
        /// The <see cref="List{FMotiv}"/>.
        /// </returns>
        public List<FMotiv> RData()
        {
            if (!ranged)
            {
                RangeLexElem();
            }

            return RFMVariety;
        }

        /// <summary>
        /// The calculate great frequency.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double CalculateGreatFrequency()
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

        /// <summary>
        /// The add formal motiv.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="occur">
        /// The occur.
        /// </param>
        /// <param name="frequency">
        /// The frequency.
        /// </param>
        public void AddFMotiv(string name, int occur, double frequency)
        {
            Data.Add(new FMotiv(newId, name, occur, frequency));
            newId += 1;
            capacity += 1;
            if (GreatFrequency < frequency)
            {
                GreatFrequency = frequency;
                greatOccur = occur;
            }
        }

        /// <summary>
        /// The range lex.
        /// </summary>
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

        /// <summary>
        /// The range lex di.
        /// </summary>
        /// <returns>
        /// The <see cref="List{Double}"/>.
        /// </returns>
        public List<double> RangeLexDi()
        {
            var ar = new List<double>();

            foreach (FMotiv fmotiv in Data)
            {
                ar.Add(fmotiv.LogDepth);
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

        /// <summary>
        /// The range lex ri.
        /// </summary>
        /// <returns>
        /// The <see cref="List{Double}"/>.
        /// </returns>
        public List<double> RangeLexRi()
        {
            var ar = new List<double>();

            foreach (FMotiv fmotiv in Data)
            {
                ar.Add(fmotiv.Remoteness);
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

        /// <summary>
        /// The range lex elem.
        /// </summary>
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
