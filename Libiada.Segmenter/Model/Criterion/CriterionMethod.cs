namespace Libiada.Segmenter.Model.Criterion;

using Libiada.Core.Core;

using Segmenter.Base.Collectors;

/// <summary>
/// Calculates actual and estimated characteristics of the subject word in the sequence
/// </summary>
public abstract class CriterionMethod
{
    /// <summary>
    /// Calculates frequency for convoluted or no convoluted sequence
    /// An actual characteristic of occurrence of the subject word in the sequence
    /// </summary>
    /// <param name="std">all positions of occurrence the word in the sequence</param>
    /// <param name="sequenceLength">length of whole sequence</param>
    /// <param name="windowLength">length of the scanning window</param>
    /// <returns>Frequency for convoluted or no convoluted sequence</returns>
    public abstract double Frequency(List<int> std, int sequenceLength, int windowLength);

    /// <summary>
    /// An estimated characteristic of occurrence of the subject word in the sequence
    /// </summary>
    /// <param name="accord">
    /// Checking word.
    /// </param>
    /// <param name="sequenceLength">
    /// Length of whole sequence.
    /// </param>
    /// <param name="winLen">
    /// Length of the scanning window.
    /// </param>
    /// <param name="minusOne">
    /// Data for "minus one" subword.
    /// </param>
    /// <param name="mid">
    /// Data for "minus two" subword.
    /// </param>
    /// <returns>
    /// Design characteristic of occurrence of the word.
    /// </returns>
    public double DesignExpected(List<string> accord, int sequenceLength, int winLen, DataCollector minusOne, DataCollector mid)
    {
        int shortWord = 2;
        int midlLength = winLen - 2;
        int minusLength = winLen - 1;

        List<int> left = minusOne.Positions(accord.GetRange(0, accord.Count - 1));
        List<int> right = minusOne.Positions(accord.GetRange(1, accord.Count - 1));
        List<int> middle = midlLength != 0 ? mid.Positions(accord.GetRange(1, accord.Count - 2)) : [];

        double criteria = -1;
        if (winLen == shortWord)
        {
            criteria = Frequency(left, sequenceLength, minusLength)
                       * Frequency(right, sequenceLength, minusLength);
        }
        else if (middle != null)
        {
            criteria = (Frequency(left, sequenceLength, minusLength)
                        * Frequency(right, sequenceLength, minusLength))
                       / Frequency(middle, sequenceLength, midlLength);
        }

        return criteria;
    }

    /// <summary>
    /// Calculates frequency for convoluted or no convoluted sequence by an interval estimation.
    /// An actual characteristic of occurrence of the subject word in the sequence.
    /// </summary>
    /// <param name="stdData">
    /// Positions of word.
    /// </param>
    /// <param name="sequenceLength">
    /// Length of whole sequence.
    /// </param>
    /// <param name="winLen">
    /// Length of the scanning window.
    /// </param>
    /// <param name="anchor">
    /// Binding to the sequence.
    /// </param>
    /// <returns>
    /// Interval characteristic of occurrence of the word.
    /// </returns>
    public double IntervalEstimate(List<int> stdData, int sequenceLength, int winLen, Link anchor)
    {
        if (stdData.Count == 0)
        {
            return 0;
        }

        int minusLength = winLen - 1;
        int start = stdData[0] + 1;
        int end = sequenceLength - stdData[^1] - minusLength;
        int pred = stdData[0];
        int j = 1;
        double multiplicate = 1;

        if (stdData.Count > 1)
        {
            for (j = 1; j < stdData.Count; j++)
            {
                int current = stdData[j];
                multiplicate *= current - pred - minusLength;
                pred = current;
            }
        }

        return anchor switch
        {
            Link.Start => 1 / Math.Pow(multiplicate * start, 1 / (double)j),
            Link.End => 1 / Math.Pow(multiplicate * end, 1 / (double)j),
            Link.Both => 0,
            _ => 0,
        };
    }

    /// <summary>
    /// Calculates probability.
    /// </summary>
    /// <param name="count">
    /// The occurrences count.
    /// </param>
    /// <param name="sequenceLength">
    /// The sequence len.
    /// All events.
    /// </param>
    /// <returns>
    /// Probability as <see cref="double"/>.
    /// </returns>
    protected double Probability(int count, int sequenceLength)
    {
        return count / (double)sequenceLength;
    }
}
