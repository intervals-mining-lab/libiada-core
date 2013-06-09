using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.Base.Collectors;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// Calculates actual and estimated characteristics of the subject word in the sequence
    /// </summary>
    public abstract class CriterionMethod
    {

        /// <summary>
        /// Calculates frequency for convoluted or no convoluted chain
        /// An actual characteristic of occurrence of the subject word in the sequence
        /// </summary>
        /// <param name="std">all positions of occurrence the word in the sequence</param>
        /// <param name="chainLength">length of whole sequence</param>
        /// <param name="windowLength">length of the scanning window</param>
        /// <returns>Frequency for convoluted or no convoluted chain</returns>
        public abstract double Frequncy(List<int> std, int chainLength, int windowLength);

        /// <summary>
        /// An estimated characteristic of occurrence of the subject word in the sequence
        /// </summary>
        /// <param name="accord">checking word</param>
        /// <param name="chainLength">length of whole sequence</param>
        /// <param name="winLen">length of the scanning window</param>
        /// <param name="minusOne">data for "minus one" subword</param>
        /// <param name="mid">data for "minus two" subword</param>
        /// <returns>disign characteristic of occurence of the word</returns>
        public double DesignExpected(List<String> accord, int chainLength, int winLen,
                                                     DataCollector minusOne, DataCollector mid)
        {
            int shortWord = 2;
            int midlLength = winLen - 2;
            int minusLength = winLen - 1;

            List<int> left = null;
            List<int> right = null;
            List<int> middle = null;
            left = minusOne.Positions(accord.GetRange(0, accord.Count - 1));
            right = minusOne.Positions(accord.GetRange(1, accord.Count - 1));
            if (midlLength != 0) middle = mid.Positions(accord.GetRange(1, accord.Count - 2));
            else middle = new List<int>();


            double criteria = -1;
            if (winLen == shortWord)
            {
                criteria = Frequncy(left, chainLength, minusLength)*Frequncy(right, chainLength, minusLength);
            }
            else if (middle != null)
                criteria = (Frequncy(left, chainLength, minusLength)*Frequncy(right, chainLength, minusLength))/
                           Frequncy(middle, chainLength, midlLength);

            return criteria;
        }

        /// <summary>
        /// Calculates frequency for convoluted or no convoluted chain by an interval estimation
        /// An actual characteristic of occurrence of the subject word in the sequence
        /// </summary>
        /// <param name="stdData">positions of word</param>
        /// <param name="chainLength">length of whole sequence</param>
        /// <param name="winLen">length of the scanning window</param>
        /// <param name="anchor">binding to the chain</param>
        /// <returns>interval characteristic of occurence of the word</returns>
        public double IntervalEstimate(List<int> stdData, int chainLength, int winLen, LinkUp anchor)
        {
            if (stdData.Count == 0) return 0;
            int minusLength = winLen - 1;
            int start = stdData[0] + 1;
            int end = chainLength - stdData[stdData.Count - 1] - minusLength;
            int pred = stdData[0];
            int j = 1;
            double multiplicate = 1;

            if (stdData.Count > 1)
            {
                for (j = 1; j < stdData.Count; j++)
                {
                    int current = stdData[j];
                    multiplicate *= (current - pred - minusLength);
                    pred = current;
                }
            }
            // System.out.println("Multipl = "+ multiplicate);
            switch (anchor)
            {
                case LinkUp.Start:
                    return (1/Math.Pow(multiplicate*start, 1/(double) j));
                case LinkUp.End:
                    return 1/Math.Pow(multiplicate*end, 1/(double) (j));
                case LinkUp.Both:
                    return 0; //1/Math.pow(multiplicate*start*end, 1/(double)(j + 1));
                default:
                    try
                    {
                        throw new Exception("WOW");
                    }
                    catch (Exception e)
                    {
                    }
                    return 0;
            }

        }

        /// <summary>
        /// Calculates a probability
        /// </summary>
        /// <param name="count">occurances</param>
        /// <param name="chainLen">all events</param>
        /// <returns>probability</returns>
        public double Probability(int count, int chainLen)
        {
            return count/(double) chainLen;
        }
    }
}