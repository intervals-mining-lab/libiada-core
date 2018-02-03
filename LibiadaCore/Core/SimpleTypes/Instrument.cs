namespace LibiadaCore.Core.SimpleTypes
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Instrument of the pitch.
    /// </summary>
    public enum Instrument : byte
    {
        /// <summary>
        /// Any or unknown instrument.
        /// </summary>
        [Display(Name = "Any or unknown")]
        [Description("Any or unknown instrument")]
        AnyOrUnknown = 0
    }
}