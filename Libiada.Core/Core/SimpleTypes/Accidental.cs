namespace LibiadaCore.Core.SimpleTypes
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The accidental.
    /// </summary>
    public enum Accidental : short
    {
        /// <summary>
        /// Double flat accidental.
        /// </summary>
        [Display(Name = "Double flat")]
        [Description("Double flat")]
        DoubleFlat = -2,

        /// <summary>
        /// Flat accidental.
        /// </summary>
        [Display(Name = "Flat")]
        [Description("Flat")]
        Flat = -1,

        /// <summary>
        /// Bekar accidental.
        /// </summary>
        [Display(Name = "Bekar")]
        [Description("Bekar")]
        Bekar = 0,

        /// <summary>
        /// Sharp accidental.
        /// </summary>
        [Display(Name = "Sharp")]
        [Description("Sharp")]
        Sharp = 1,

        /// <summary>
        /// Double sharp accidental.
        /// </summary>
        [Display(Name = "Double sharp")]
        [Description("Double sharp")]
        DoubleSharp = 2
    }
}
