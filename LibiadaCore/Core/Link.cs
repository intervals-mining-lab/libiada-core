namespace LibiadaCore.Core
{
    /// <summary>
    /// Link of intervals.
    /// </summary>
    public enum Link
    {
        /// <summary>
        /// Link not applied in characteristic calculation.
        /// If passed to intervals manager exception will be thrown.
        /// </summary>
        NotApplied = 0,

        /// <summary>
        /// No link.
        /// Both interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are taken into account.
        /// </summary>
        None = 1,

        /// <summary>
        /// Link to start.
        /// Interval from last element to end of chain 
        /// is not taken into account.
        /// </summary>
        Start = 2,

        /// <summary>
        /// Link to end.
        /// Interval from start of chain to first element 
        /// is not taken into account.
        /// </summary>
        End = 3,

        /// <summary>
        /// Link to start and end.
        /// Both interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are taken into account.
        /// </summary>
        Both = 4,

        /// <summary>
        /// Cyclic link.
        /// Interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are summed into one interval.
        /// </summary>
        Cycle = 5,

        /// <summary>
        /// Cyclic link to start.
        /// Intervals are calculated as in cyclic link
        /// and writen to first element(position) of pair.
        /// </summary>
        CycleStart = 6,

        /// <summary>
        /// Cyclic link to end.
        /// Intervals are calculated as in cyclic link
        /// and writen to second element(position) of pair.
        /// </summary>
        CycleEnd = 7
    }
}
