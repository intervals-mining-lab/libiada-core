namespace LibiadaCore.TimeSeries.Aligners
{
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
            switch (aligner)
            {
                case Aligner.ByShortestAligner:
                    return new ByShortestAligner();
                case Aligner.ByShortestFromRightAligner:
                    return new ByShortestFromRightAligner();
                case Aligner.AllOffsetsAligner:
                    return new AllOffsetsAligner();
                case Aligner.FirstElementDuplicator:
                    return new FirstElementDuplicator();
                case Aligner.LastElementDuplicator:
                    return new LastElementDuplicator();
                default:
                    throw new InvalidEnumArgumentException(nameof(aligner), (int)aligner, typeof(Aligner));
            }
        }
    }
}