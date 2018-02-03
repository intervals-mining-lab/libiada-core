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
        [Description("Дубль-бемоль")]
        DoubleFlat = -2,

        /// <summary>
        /// Flat accidental.
        /// </summary>
        [Display(Name = "Flat")]
        [Description("Бемоль")]
        Flat = -1,

        /// <summary>
        /// Bekar accidental.
        /// </summary>
        [Display(Name = "Bekar")]
        [Description("Бекар")]
        Bekar = 0,

        /// <summary>
        /// Sharp accidental.
        /// </summary>
        [Display(Name = "Sharp")]
        [Description("Диез")]
        Sharp = 1,

        /// <summary>
        /// Double sharp accidental.
        /// </summary>
        [Display(Name = "Double sharp")]
        [Description("Дубль-диез")]
        DoubleSharp = 2
    }
}
