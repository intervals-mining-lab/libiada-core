namespace Libiada.Segmenter.Model.Criterion;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// A partial Orlov's criterion. Find the difference between
/// the theoretical and practical power of the alphabet
/// </summary>
public class CriterionPartialOrlov : Criterion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionPartialOrlov"/> class.
    /// </summary>
    /// <param name="threshold">
    /// The rule for handle a threshold value.
    /// </param>
    /// <param name="precision">
    /// The additional value.
    /// </param>
    public CriterionPartialOrlov(ThresholdVariator threshold, double precision)
        : base(threshold, precision)
    {
        Value = double.MaxValue;
        precisionOfDifference = 1;
    }

    /// <summary>
    /// The state.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool State(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        Update(sequence, alphabet);
        return (ThresholdToStop.Distance > ThresholdVariator.Precision)
               && (Math.Abs(Distortion(sequence, alphabet)) > precisionOfDifference);
    }

    /// <summary>
    /// The distortion.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override sealed double Distortion(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        return TheoryVolume(sequence, alphabet) - alphabet.Count;
    }

    /// <summary>
    /// Calculates the theoretical volume the alphabet for a sequence.
    /// </summary>
    /// <param name="sequence">
    /// An estimated sequence.
    /// </param>
    /// <param name="alphabet">
    /// Current alphabet.
    /// </param>
    /// <returns>
    /// The theoretical volume the alphabet.
    /// </returns>
    public double TheoryVolume(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        double f = 0;
        List<string> wordsList = alphabet.GetWords();
        foreach (string word in wordsList)
        {
            double freq = Frequency(sequence, word);
            if (freq > f)
            {
                f = freq;
            }
        }

        double z = sequence.Length;
        // TODO: check if this should be Log2
        double k = 1 / Math.Log(f * z);
        double b = (k / f) - 1;
        double v = (k * z) - b;
        return v;
    }

    /// <summary>
    /// The theory frequency.
    /// </summary>
    /// <param name="rank">
    /// The rank.
    /// </param>
    /// <param name="b">
    /// The b.
    /// </param>
    /// <param name="k">
    /// The k.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double TheoryFrequency(int rank, double b, double k)
    {
        return k / (b + rank);
    }

    /// <summary>
    /// B calculation method.
    /// </summary>
    /// <param name="k">
    /// The k.
    /// </param>
    /// <param name="f1">
    /// The f 1.
    /// </param>
    /// <returns>
    /// B value as <see cref="double"/>.
    /// </returns>
    public double CalculateB(double k, double f1)
    {
        return (k / f1) - 1.0;
    }

    /// <summary>
    /// K calculation method.
    /// </summary>
    /// <param name="factFrequency">
    /// The fact frequency.
    /// </param>
    /// <param name="length">
    /// The length.
    /// </param>
    /// <returns>
    /// K value as <see cref="double"/>.
    /// </returns>
    public double CalculateK(int factFrequency, int length)
    {
        // TODO: check if this should be Log2
        return 1.0 / Math.Log(factFrequency * length);
    }

    /// <summary>
    /// The frequency.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="word">
    /// The word.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Frequency(ComplexSequence sequence, string word)
    {
        List<string> temp = new(sequence.Substring(0, sequence.Length));
        return Frequency(temp, word) / (double)sequence.Length;
    }

    /// <summary>
    /// The frequency.
    /// </summary>
    /// <param name="c">
    /// The c.
    /// </param>
    /// <param name="o">
    /// The o.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int Frequency(IEnumerable<string> c, object o)
    {
        int result = 0;
        if (o == null)
        {
            result += c.Count(e => e == null);
        }
        else
        {
            result += c.Count(e => o.Equals(e));
        }

        return result;
    }

    /// <summary>
    /// The update method.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    private void Update(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        double dist = TheoryVolume(sequence, alphabet) - alphabet.Count;
        if (Math.Abs(Value) > Math.Abs(dist))
        {
            this.alphabet = alphabet.Clone();
            this.sequence = sequence.Clone();
            Value = dist;
            ThresholdToStop.SaveBest();
        }
    }
}
