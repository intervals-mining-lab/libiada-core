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
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
    {
        Update(chain, alphabet);
        return (ThresholdToStop.Distance > ThresholdVariator.Precision)
               && (Math.Abs(Distortion(chain, alphabet)) > precisionOfDifference);
    }

    /// <summary>
    /// The distortion.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override sealed double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
    {
        return TheoryVolume(chain, alphabet) - alphabet.Count;
    }

    /// <summary>
    /// Calculates the theoretical volume the alphabet for a chain.
    /// </summary>
    /// <param name="chain">
    /// An estimated chain.
    /// </param>
    /// <param name="alphabet">
    /// Current alphabet.
    /// </param>
    /// <returns>
    /// The theoretical volume the alphabet.
    /// </returns>
    public double TheoryVolume(ComplexChain chain, FrequencyDictionary alphabet)
    {
        double f = 0;
        List<string> wordsList = alphabet.GetWords();
        foreach (string word in wordsList)
        {
            double freq = Frequency(chain, word);
            if (freq > f)
            {
                f = freq;
            }
        }

        double z = chain.Length;
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
    /// The calculate b.
    /// </summary>
    /// <param name="k">
    /// The k.
    /// </param>
    /// <param name="f1">
    /// The f 1.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double CalculateB(double k, double f1)
    {
        return (k / f1) - 1.0;
    }

    /// <summary>
    /// The calculate k.
    /// </summary>
    /// <param name="factFrequency">
    /// The fact frequency.
    /// </param>
    /// <param name="length">
    /// The length.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double CalculateK(int factFrequency, int length)
    {
        return 1.0 / Math.Log(factFrequency * length);
    }

    /// <summary>
    /// The frequency.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="word">
    /// The word.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Frequency(ComplexChain chain, string word)
    {
        List<string> temp = new(chain.Substring(0, chain.Length));
        return Frequency(temp, word) / (double)chain.Length;
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
    /// The update.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    private void Update(ComplexChain chain, FrequencyDictionary alphabet)
    {
        double dist = TheoryVolume(chain, alphabet) - alphabet.Count;
        if (Math.Abs(Value) > Math.Abs(dist))
        {
            this.alphabet = alphabet.Clone();
            this.chain = chain.Clone();
            Value = dist;
            ThresholdToStop.SaveBest();
        }
    }
}
