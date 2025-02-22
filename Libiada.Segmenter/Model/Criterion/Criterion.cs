namespace Libiada.Segmenter.Model.Criterion;

using Base.Collectors;
using Base.Sequences;
using Interfaces;
using Threshold;

/// <summary>
/// The criterion of break. Defines the best mode of segmentation.
/// Allows you to handle how long will the process do something.
/// </summary>
public abstract class Criterion : IDefinable
{
    /// <summary>
    /// The threshold to stop.
    /// </summary>
    protected readonly ThresholdVariator ThresholdToStop;

    /// <summary>
    /// The precision of difference.
    /// </summary>
    protected double precisionOfDifference;

    /// <summary>
    /// The alphabet.
    /// </summary>
    protected FrequencyDictionary alphabet;

    /// <summary>
    /// The sequence.
    /// </summary>
    protected ComplexSequence sequence;

    /// <summary>
    /// Initializes a new instance of the <see cref="Criterion"/> class.
    /// </summary>
    /// <param name="threshold">
    /// A rule for handling a threshold value.
    /// </param>
    /// <param name="precision">
    /// Additional value to.
    /// </param>
    public Criterion(ThresholdVariator threshold, double precision)
    {
        ThresholdToStop = threshold;
        precisionOfDifference = precision;
    }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public double Value { get; protected set; }

    /// <summary>
    /// Returns the state of criterion. True, if everything is done, false - otherwise.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// Sequence alphabet.
    /// </param>
    /// <returns>
    /// The state of criterion.
    /// </returns>
    public abstract bool State(ComplexSequence sequence, FrequencyDictionary alphabet);

    /// <summary>
    /// Returns distortion between necessary and calculated value.
    /// For example between theoretical and practical values.
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
    public abstract double Distortion(ComplexSequence sequence, FrequencyDictionary alphabet);

    /// <summary>
    /// Returns distortion between necessary and calculated value inside of criterion.
    /// For example between theoretical and practical values.
    /// </summary>
    /// <returns>
    /// Distortion as <see cref="double"/>.
    /// </returns>
    public double Distortion()
    {
        return Distortion(sequence, alphabet);
    }

    /// <summary>
    ///  Updates data for computing a new value of the criterion.
    /// </summary>
    /// <param name="sequence">
    /// A new sequence.
    /// </param>
    /// <param name="alphabet">
    /// A new alphabet.
    /// </param>
    public void Renew(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        this.sequence = sequence;
        this.alphabet = alphabet;
    }

    /// <summary>
    /// The get value.
    /// </summary>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double GetValue()
    {
        throw new NotImplementedException();
    }
}
