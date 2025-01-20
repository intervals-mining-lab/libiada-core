namespace Libiada.Segmenter.Model;

/// <summary>
/// The algorithm.
/// </summary>
public class Algorithm
{
    /// <summary>
    /// The results.
    /// </summary>
    protected List<MainOutputData> results = [];

    /// <summary>
    /// The inputs.
    /// </summary>
    protected List<Input> inputs = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Algorithm"/> class.
    /// </summary>
    /// <param name="parameters">
    /// The parameters.
    /// </param>
    public Algorithm(IEnumerable<Input> parameters)
    {
        inputs = new List<Input>(parameters);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Algorithm"/> class.
    /// </summary>
    /// <param name="input">
    /// The input.
    /// </param>
    public Algorithm(Input input)
    {
        inputs.Add(input);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Algorithm"/> class.
    /// </summary>
    public Algorithm()
    {
    }

    /// <summary>
    /// Executes segmentation in a separate thread with notifying all observers.
    /// </summary>
    public void Run()
    {
        Slot();
    }

    /// <summary>
    /// The add.
    /// </summary>
    /// <param name="input">
    /// The input.
    /// </param>
    public void Add(IEnumerable<Input> input)
    {
        inputs.AddRange(input);
    }

    /// <summary>
    /// Execute segmentation
    /// </summary>
    public void Slot()
    {
        foreach (Input input in inputs)
        {
            Algorithm algorithm = AlgorithmFactory.Make(input.Algorithm, input);
            algorithm.Slot();
            List<MainOutputData> res = algorithm.Upload();
            results.Add(res[0]);
            res.RemoveAt(0);
        }
    }

    /// <summary>
    /// Returns characteristics of the sequences and its
    /// </summary>
    /// <returns>list of characteristics</returns>
    public List<MainOutputData> Upload()
    {
        return results;
    }
}
