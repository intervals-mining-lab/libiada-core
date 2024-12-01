namespace Libiada.Segmenter.Model;

/// <summary>
/// The algorithm factory.
/// </summary>
public static class AlgorithmFactory
{
    /// <summary>
    /// The make.
    /// </summary>
    /// <param name="index">
    /// The index.
    /// </param>
    /// <param name="input">
    /// The input.
    /// </param>
    /// <returns>
    /// The <see cref="Algorithm"/>.
    /// </returns>
    public static Algorithm Make(int index, Input input)
    {
        return index switch
        {
            0 => new AlgorithmBase(input),
            1 => null,
            _ => throw new ArgumentException("Unknown index", "index"),
        };
    }
}
