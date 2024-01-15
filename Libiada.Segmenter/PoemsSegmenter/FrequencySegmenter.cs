using System;
using System.Collections.Generic;
using System.Text;

namespace Segmenter.PoemsSegmenter
{
    class FrequencySegmenter
    {
        public string textData;
        public string text;
        public int maxLength;
        public double threshold;

        public FrequencySegmenter(string textData, int maxLength, double threshold)
        {
            this.textData = textData;
            this.maxLength = maxLength;
            this.threshold = threshold;
        }

        public Dictionary<string, int> Segmentation()
        {
            List<string> consonanceList = new List<string>();
            Dictionary<string, int> consonancesDictionary = new Dictionary<string, int>();

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < textData.Length; i++)
            {
                try
                {
                    if (textData[i] == 'ь')
                    {
                        continue;
                    }
                    else if (textData[i + 1] == 'ь')
                    {
                        stringBuilder.Append(char.ToUpper(textData[i]));
                    }
                    else
                    {
                        stringBuilder.Append(textData[i]);
                    }
                }
                catch
                {
                    break;
                }
            }

            text = stringBuilder.ToString();


            while (maxLength != 0)
            {
                string candidateConsonance = "";
                for (int i = 0; i < text.Length; i++)
                {
                    try
                    {
                        for (int j = i; j < maxLength + i; j++)
                        {
                            if (text[j] == ' ' || text[j] == '.')
                            {
                                candidateConsonance = "";
                                break;
                            }
                            else
                            {
                                candidateConsonance += text[j];
                            }
                        }

                        if (candidateConsonance == "")
                        {
                            continue;
                        }
                        else
                        {

                            bool isConsonance = CheckCandidateConsonance(candidateConsonance);
                            if (isConsonance)
                            {
                                consonanceList.Add(candidateConsonance);
                                int entriesNumber = CalculateEntriesNumber(candidateConsonance);
                                consonancesDictionary.Add(candidateConsonance, entriesNumber);
                                text = text.Replace(candidateConsonance, ".");
                            }
                            candidateConsonance = "";
                        }
                    }
                    catch
                    {
                        candidateConsonance = "";
                        continue;
                    }
                }
                maxLength--;
            }

            return consonancesDictionary;
        }


        public Boolean CheckCandidateConsonance(string candidateConsonance)
        {
            if (maxLength == 1)
            {
                return true;
            }

            double actualFreq = CalculateActualFreq(candidateConsonance);
            double estimatesFreq = calculateEstimatedFreq(candidateConsonance);
            double deviation = CalculateDeviation(actualFreq, estimatesFreq);

            if (candidateConsonance == "ue")
            {
                Console.WriteLine(candidateConsonance + " - " + deviation);
            }

            if (deviation >= threshold)
            {
                return true;
            }

            return false;
        }



        public double CalculateDeviation(double actualFreq, double esimatedFreq)
        {
            return Math.Abs(actualFreq - esimatedFreq) / Math.Sqrt(esimatedFreq);
        }

        public double CalculateActualFreq(string candidateConsonance)
        {
            string textWithoutSpaces = text.Replace(" ", "");
            double currentTextLength = textWithoutSpaces.Length;
            double entriesConsonanceNumber = text.Split(new string[] { candidateConsonance }, StringSplitOptions.None).Length - 1; // количество вхождений текущего созвучия

            return entriesConsonanceNumber / currentTextLength;
        }

        public double calculateEstimatedFreq(string candidateConsonance)
        {
            double firstActualFreq = CalculateActualFreq(candidateConsonance.Substring(0, candidateConsonance.Length - 1)); // B1...Bn-1
            double secondActualFreq = CalculateActualFreq(candidateConsonance.Substring(1, candidateConsonance.Length - 1)); // B2...Bn
            if (candidateConsonance.Length > 2)
            {
                double thirdActualFreq = CalculateActualFreq(candidateConsonance.Substring(1, candidateConsonance.Length - 2)); // B2...Bn-1
                return (firstActualFreq * secondActualFreq) / thirdActualFreq;
            }
            return firstActualFreq * secondActualFreq;
        }

        public int CalculateEntriesNumber(string candidateConsonance)
        {
            int entriesNumber = text.Split(new string[] { candidateConsonance }, StringSplitOptions.None).Length - 1;
            return entriesNumber;
        }

    }
}
