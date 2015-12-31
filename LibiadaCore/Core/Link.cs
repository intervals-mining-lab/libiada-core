namespace LibiadaCore.Core
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Link of intervals.
    /// </summary>
    public enum Link
    {
        /// <summary>
        /// Link not applied in characteristic calculation.
        /// If passed to intervals manager exception will be thrown.
        /// </summary>
        [Display(Name = "Not applied")]
        [Description("Link is not applied")]
        NotApplied = 0,

        /// <summary>
        /// No link.
        /// Both interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are taken into account.
        /// </summary>
        [Display(Name = "None")]
        [Description(" The first and the last intervals to boundaries of sequence are not taken into account")]
        None = 1,

        /// <summary>
        /// Link to start.
        /// Interval from last element to end of chain 
        /// is not taken into account.
        /// </summary>
        [Display(Name = "To the beginning")]
        [Description("Interval from the start of the sequence to the first occurrence of the element is taken into account")]
        Start = 2,

        /// <summary>
        /// Link to end.
        /// Interval from start of chain to first element 
        /// is not taken into account.
        /// </summary>
        [Display(Name = "To the end")]
        [Description("Interval from the last occurrence of the element to the end of the sequence is taken into account")]
        End = 3,

        /// <summary>
        /// Link to start and end.
        /// Both interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are taken into account.
        /// </summary>
        [Display(Name = "To the beginning and to the end")]
        [Description("Both intervals from the start of the sequence to the first occurrence of the element "
                     + "and from the last occurrence of the element to the end of the sequence are taken into account")]
        Both = 4,

        /// <summary>
        /// Cyclic link.
        /// Interval from start of chain to first element
        /// and interval from last element to end of chain 
        /// are summed into one interval.
        /// </summary>
        [Display(Name = "Cyclic")]
        [Description("Interval from the last occurrence of the element to the end of the sequence added "
                     + "to the interval from the start of the sequence to the first occurrence of the element (as if sequence was cyclic)")]
        Cycle = 5,

        /// <summary>
        /// Cyclic link to start.
        /// Intervals are calculated as in cyclic link
        /// and writen to first element(position) of pair.
        /// </summary>
        [Display(Name = "Cyclic to the beginning")]
        [Description("Cyclic reading from left to right (intervals are bound to the right position (element occurrence))")]
        CycleStart = 6,

        /// <summary>
        /// Cyclic link to end.
        /// Intervals are calculated as in cyclic link
        /// and writen to second element(position) of pair.
        /// </summary>
        [Display(Name = "Cyclic to the end")]
        [Description("Cyclic reading from right to left (intervals are bound to the left position (element occurrence))")]
        CycleEnd = 7
    }
}
