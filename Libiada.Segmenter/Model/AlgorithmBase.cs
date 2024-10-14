namespace Libiada.Segmenter.Model;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Interfaces;
using Segmenter.Model.Criterion;
using Segmenter.Model.Seekers;
using Segmenter.Model.Threshold;

/// <summary>
/// The base algorithm has a model of segmentation
/// based on the difference between actual and expected frequency of occurrence of subwords
/// </summary>
public class AlgorithmBase : Algorithm
{
    /// <summary>
    /// The chain.
    /// </summary>
    private ComplexChain chain;

    /// <summary>
    /// The alphabet.
    /// </summary>
    private FrequencyDictionary alphabet;

    /// <summary>
    /// The threshold.
    /// </summary>
    private ThresholdVariator threshold;

    /// <summary>
    /// The extractor.
    /// </summary>
    private WordExtractor extractor;

    /// <summary>
    /// The criterion.
    /// </summary>
    private Criterion.Criterion criterion;

    /// <summary>
    /// The balance.
    /// </summary>
    private int balance;

    /// <summary>
    /// The window len.
    /// </summary>
    private int windowLen;

    /// <summary>
    /// The window dec.
    /// </summary>
    private int windowDec;

    /// <summary>
    /// Initializes a new instance of the <see cref="AlgorithmBase"/> class.
    /// </summary>
    public AlgorithmBase()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AlgorithmBase"/> class.
    /// </summary>
    /// <param name="parameters">
    /// The parameters.
    /// </param>
    public AlgorithmBase(Input parameters)
        : base(parameters)
    {
        threshold = ThresholdFactory.Make(parameters.ThresholdMethod, parameters);
        criterion = CriterionFactory.Make(parameters.StopCriterion, threshold, parameters.Precision);
        extractor = WordExtractorFactory.GetSeeker(parameters.Seeker);
        balance = parameters.Balance;
        windowLen = parameters.WindowLength;
        windowDec = parameters.WindowDecrement;
    }

    /// <summary>
    /// The slot.
    /// </summary>
    public new void Slot()
    {
        Dictionary<string, object> par = new()
        {
            { "Sequence", chain = new ComplexChain(inputs[0].Chain) },
            { "Alphabet", alphabet = new FrequencyDictionary(chain) }
        };

        while (criterion.State(chain, alphabet))
        {
            UpdateParams(par, threshold.Next(criterion));
            SimpleChainSplitter chainSplitter = new(extractor);
            chain = chainSplitter.Cut(par);
            alphabet = chainSplitter.FrequencyDictionary;
        }
    }

    /// <summary>
    /// The upload.
    /// </summary>
    /// <returns>
    /// The <see cref="List{MainOutputData}"/>.
    /// </returns>
    public new List<MainOutputData> Upload()
    {
        MainOutputData resultUpdate = new();
        resultUpdate.AddInfo((IIdentifiable)criterion, criterion.Value);
        resultUpdate.AddInfo((IIdentifiable)threshold, threshold.Value);

        results.Add(resultUpdate);
        return results;
    }

    /// <summary>
    /// The update parameters.
    /// </summary>
    /// <param name="par">
    /// The par.
    /// </param>
    /// <param name="nextThreshold">
    /// The next threshold.
    /// </param>
    private void UpdateParams(Dictionary<string, object> par, double nextThreshold)
    {
        par.Add("Sequence", chain = new ComplexChain(inputs[0].Chain));
        par.Add("Balance", balance);
        par.Add("Window", windowLen);
        par.Add("WindowDecrement", windowDec);
        par.Add("CurrentThreshold", nextThreshold);
    }
}
