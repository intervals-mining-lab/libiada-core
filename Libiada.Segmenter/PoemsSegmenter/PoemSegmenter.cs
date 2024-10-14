namespace Libiada.Segmenter.PoemsSegmenter;

using System.Text;

public class PoemSegmenter
{
    public string textData;
    public string text;
    public int maxLength;
    public double threshold;
    public double balance;
    public string startText;
    public string segmentedText = "";
    public List<string> consonanceOrderedList = [];

    public PoemSegmenter(string textData, int maxLength, double threshold, double balance)
    {
        this.textData = textData.ToLower();
        this.maxLength = maxLength;
        this.threshold = threshold;
        this.balance = balance;
        this.startText = textData.ToLower();
    }

    public (Dictionary<string, int>, string, string) StartSegmentation()
    {
        Dictionary<string, int> consonancesDictionary = [];
        textData = textData.Replace("/n", "");
        while (true)
        {
            consonancesDictionary.Clear();
            consonanceOrderedList.Clear();
            consonancesDictionary = Segmentation();

            bool checkedDictionary = CheckSegmentationByCriteria(consonancesDictionary);

            if (checkedDictionary)
            {
                break;
            }

            threshold -= 0.001;
            if (threshold <= 0)
            {
                consonancesDictionary.Clear();
                consonanceOrderedList.Clear();
                consonancesDictionary.Add("null", 0);
                break;
            }
        }
        string poemChain = GetPoemChain();
        return (consonancesDictionary, poemChain, segmentedText);
    }

    public Dictionary<string, int> Segmentation()
    {
        Dictionary<string, int> consonancesDictionary = [];
        StringBuilder stringBuilder = new();
        int n = maxLength;
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
        startText = text;


        while (n != 0)
        {
            string candidateConsonance = "";
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    for (int j = i; j < n + i; j++)
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

                        bool isConsonance = CheckCandidateConsonance(candidateConsonance, n);
                        if (isConsonance)
                        {
                            //string candidateConsonanceString = "";
                            //for(int j = 0; j < candidateConsonance.Length; j++)
                            //{
                            //    if (Char.IsUpper(candidateConsonance[j]))
                            //    {
                            //        candidateConsonanceString += candidateConsonance[j].ToString().ToLower() + "ь";
                            //    } else
                            //    {
                            //        candidateConsonanceString += candidateConsonance[j];
                            //    }
                            //}
                            


                            int entriesNumber = CalculateEntriesNumber(candidateConsonance);
                            consonancesDictionary.Add(candidateConsonance, entriesNumber);
                            consonanceOrderedList.Add(candidateConsonance);
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
            n--;
        }

        return consonancesDictionary;
    }

    public Boolean CheckSegmentationByCriteria(Dictionary<string, int> consonancesDictionary)
    {
        PartialOrlovCriterion criterionPartialOrlov = new(consonancesDictionary, text);
        double theoreticVolumeDictionary = criterionPartialOrlov.TheoreticalDictionaryVolume();
        double actualVolumeDictionary = consonancesDictionary.Keys.Count;
        double difference = Math.Abs(actualVolumeDictionary - theoreticVolumeDictionary);

        difference = Math.Round(difference);
        if (difference <= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Boolean CheckCandidateConsonance(string candidateConsonance, int n)
    {
        if (n == 1)
        {
            return true;
        }

        double actualFreq = CalculateActualFreq(candidateConsonance);
        double intervalFreq = CalculateIntervalFreq(candidateConsonance);
        double compositedFreq = balance * intervalFreq + (1 - balance) * actualFreq;
        double estimatesFreq = calculateEstimatedFreq(candidateConsonance);

        double deviation = CalculateDeviation(compositedFreq, estimatesFreq);

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

    public double CalculateIntervalFreq(string candidateConsonance)
    {
        double geometricMeanSpacing;
        string[] textSplited = text.Split(new string[] { candidateConsonance }, StringSplitOptions.None);
        double intervalsProduct = 1;
        double powerCounter = 0;
        for (int i = 1; i < textSplited.Length; i++)
        {
            intervalsProduct *= (textSplited[i].Length + candidateConsonance.Length);
            powerCounter++;
        }

        geometricMeanSpacing = Math.Pow(intervalsProduct, 1 / powerCounter);
        return 1 / geometricMeanSpacing;
    }

    public double calculateEstimatedFreq(string candidateConsonance)
    {
        double firstIntervalFreq = CalculateIntervalFreq(candidateConsonance.Substring(0, candidateConsonance.Length - 1)); // B1...Bn-1
        double firstActualFreq = CalculateActualFreq(candidateConsonance.Substring(0, candidateConsonance.Length - 1)); // B1...Bn-1
        double compositedFirstFreq = balance * firstIntervalFreq + (1 - balance) * firstActualFreq;

        double secondIntervalFreq = CalculateIntervalFreq(candidateConsonance.Substring(1, candidateConsonance.Length - 1)); // B2...Bn
        double secondActualFreq = CalculateActualFreq(candidateConsonance.Substring(1, candidateConsonance.Length - 1)); // B2...Bn
        double compositedSecondFreq = balance * secondIntervalFreq + (1 - balance) * secondActualFreq;

        if (candidateConsonance.Length > 2)
        {
            double thirdIntervalFreq = CalculateIntervalFreq(candidateConsonance.Substring(1, candidateConsonance.Length - 2)); // B2...Bn-1
            double thirdActualFreq = CalculateActualFreq(candidateConsonance.Substring(1, candidateConsonance.Length - 2)); // B2...Bn-1
            double compositedThirdFreq = balance * thirdIntervalFreq + (1 - balance) * thirdActualFreq;
            return (compositedFirstFreq * compositedSecondFreq) / compositedThirdFreq;
        }
        return compositedFirstFreq * compositedSecondFreq;
        
    }

    public int CalculateEntriesNumber(string candidateConsonance)
    {
        int entriesNumber = text.Split(new string[] { candidateConsonance }, StringSplitOptions.None).Length - 1;
        return entriesNumber;
    }

    public string GetPoemChain()
    {
        string poemChain = startText;
        //string segmentedString = text;
        //var consonanceArray = consonanceDictionary.Select(kv => kv.Key).OrderByDescending(k => k.Length).ToArray();

        for (int i = 0; i < consonanceOrderedList.Count;  i++)
        {
             poemChain = poemChain.Replace(consonanceOrderedList[i], (i + 1).ToString() + "-");
        }

        return poemChain;
    }
}
