namespace Segmentator.Model.Criterion
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Base.Collectors;
    using Segmentator.Base.Sequencies;
    using Segmentator.Model.Threshold;

    /// <summary>
    /// A partial Orlov's criterion. Find the difference between
    /// the theoretical and practical power of the alphabet
    /// </summary>
    public class CriterionPartialOrlov : Criterion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value</param>
        public CriterionPartialOrlov(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            this.LastDistortion = Double.MaxValue;
            this.PrecisionOfDifference = 1;
        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            this.Update(chain, alphabet);
            return (this.ThresholdToStop.Distance() > ThresholdVariator.Precision) &&
                   (Math.Abs(this.Distortion(chain, alphabet)) > this.PrecisionOfDifference);
        }

        private void Update(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double dist = this.TheoryVolume(chain, alphabet) - alphabet.Count;
            if (Math.Abs(this.LastDistortion) > Math.Abs(dist))
            {
                this.Alphabet = alphabet.Clone();
                this.Chain = chain.Clone();
                this.LastDistortion = dist;
                this.ThresholdToStop.SaveBest();
            }
        }

        public override sealed double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return this.TheoryVolume(chain, alphabet) - alphabet.Count;
        }

        /// <summary>
        /// Calculates the theoretical volume the alphabet for a chain
        /// </summary>
        /// <param name="chain">an estimated chain</param>
        /// <param name="alphabet">current alphabet</param>
        /// <returns>the theoretical volume the alphabet</returns>
        public double TheoryVolume(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double f = 0;
            List<String> wordsList = alphabet.GetWords();
            foreach (String word in wordsList)
            {
                double freq = this.Frequency(chain, word);
                if (freq > f) f = freq;
            }
            double z = chain.Length;
            double k = 1/(Math.Log(f*z));
            double b = k/f - 1;
            double v = k*z - b;
            return v;
        }

        public double TheoryFrequency(int rang, double b, double k)
        {
            return k/(b + rang);
        }

        public double CalcB(double k, double f1)
        {
            return ((k/f1) - 1.0);
        }

        public double CalcK(int factFrequency, int length)
        {
            return 1.0/Math.Log(factFrequency*length);
        }


        public double Frequency(ComplexChain chain, String word)
        {
            List<object> temp = new List<object>(chain.Substring(0, chain.Length));
            return this.Frequency(temp, word) / (double)chain.Length;
        }

        public int Frequency(List<Object> c, Object o)
        {
            int result = 0;
            if (o == null)
            {
                foreach (Object e in c)
                    if (e == null)
                        result++;
            }
            else
            {
                foreach (Object e in c)
                    if (o.Equals(e))
                        result++;
            }
            return result;
        }
    }
}