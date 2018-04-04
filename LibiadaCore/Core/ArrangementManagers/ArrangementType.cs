namespace LibiadaCore.Core.ArrangementManagers
{
    /// <summary>
    /// The arrangement type.
    /// </summary>
    public enum ArrangementType : byte
    {
        /// <summary>
        /// The intervals.
        /// </summary>
        Intervals = 0,

        /// <summary>
        /// The series.
        /// </summary>
        Series = 1,

        /// <summary>
        /// The intervals and series.
        /// </summary>
        IntervalsAndSeries = 2
    }
}