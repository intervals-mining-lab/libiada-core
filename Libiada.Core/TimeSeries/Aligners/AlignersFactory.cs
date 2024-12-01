namespace Libiada.Core.TimeSeries.Aligners;

using System.ComponentModel;

/// <summary>
/// The aligners factory.
/// </summary>
public class AlignersFactory
{
    /// <summary>
    /// The get aligner.
    /// </summary>
    /// <param name="aligner">
    /// The aligner.
    /// </param>
    /// <returns>
    /// The <see cref="ITimeSeriesAligner"/>.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// </exception>
    public ITimeSeriesAligner GetAligner(Aligner aligner)
    {
        return aligner switch
        {
            Aligner.ByShortestAligner => new ByShortestAligner(),
            Aligner.ByShortestFromRightAligner => new ByShortestFromRightAligner(),
            Aligner.AllOffsetsAligner => new AllOffsetsAligner(),
            Aligner.FirstElementDuplicator => new FirstElementDuplicator(),
            Aligner.LastElementDuplicator => new LastElementDuplicator(),
            _ => throw new InvalidEnumArgumentException(nameof(aligner), (int)aligner, typeof(Aligner)),
        };
    }
}
