using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
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
            formalismType = Formalism.CRITERION_PARTIAL_ORLOV;
            lastDistortion = Double.MaxValue;
            precisionOfDifference = 1;
        }

        public override bool state(ComplexChain chain, FrequencyDictionary alphabet)
        {
            update(chain, alphabet);
            return (thresholdToStop.distance() > ThresholdVariator.PRECISION) &&
                   (Math.Abs(distortion(chain, alphabet)) > precisionOfDifference);
        }

        private void update(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double dist = theoryVolume(chain, alphabet) - alphabet.Count;
            if (Math.Abs(lastDistortion) > Math.Abs(dist))
            {
                this.alphabet = (FrequencyDictionary) alphabet.Clone();
                this.chain = (ComplexChain)chain.Clone();
                this.lastDistortion = dist;
                thresholdToStop.saveBest();
            }
        }

        public double getValue()
        {
            return lastDistortion;
        }

        public override sealed double distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return theoryVolume(chain, alphabet) - alphabet.Count;
        }

        /// <summary>
        /// Calculates the theoretical volume the alphabet for a chain
        /// </summary>
        /// <param name="chain">an estimated chain</param>
        /// <param name="alphabet">current alphabet</param>
        /// <returns>the theoretical volume the alphabet</returns>
        public double theoryVolume(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double z;
            double k;
            double b;
            double v;
            double f = 0;
            double freq;
            List<String> wordsList = alphabet.GetWords();
            foreach (String word in wordsList)
            {
                freq = frequency(chain, word);
                if (freq > f) f = freq;
            }
            z = chain.Length;
            k = 1/(Math.Log(f*z));
            b = k/f - 1;
            v = k*z - b;
            return v;
        }

        public double theoryFrequency(int rang, double b, double k)
        {
            return k/(b + (double) rang);
        }

        public double calcB(double k, double f1)
        {
            return ((k/f1) - 1.0);
        }

        public double calcK(int factFrequency, int length)
        {
            return 1.0/Math.Log(factFrequency*length);
        }


        public double frequency(ComplexChain chain, String word)
        {
            List<object> temp = new List<object>(chain.Substring(0, chain.Length));
            return frequency(temp, word) / (double)chain.Length;
        }

        public int frequency(List<Object> c, Object o)
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