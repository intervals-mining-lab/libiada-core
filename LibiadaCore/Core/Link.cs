namespace LibiadaCore.Core
{
    /// <summary>
    /// Link of intervals.
    /// </summary>
    public enum Link
    {
        /// <summary>
        /// Link to start.
        /// Interval from last element to end of chain 
        /// is not taken into account.
        /// </summary>
        Start = 1,

        /// <summary>
        /// Link to end.
        /// Interval from start of chain to first element 
        /// is not taken into account.
        /// </summary>
        End = 2,

        /// <summary>
        /// Link to start and end.
        /// Both interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are taken into account.
        /// </summary>
        Both = 3,

        /// <summary>
        /// Cyclic link.
        /// Interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are summed into one interval.
        /// </summary>
        Cycle = 4,

        /// <summary>
        /// No link.
        /// Both interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are taken into account.
        /// </summary>
        None = 5
    }
}
