namespace LibiadaCore.Core.SimpleTypes
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Symbol of the note.
    /// </summary>
    public enum NoteSymbol : byte
    {
        /// <summary>
        /// C note.
        /// </summary>
        [Display(Name = "C")]
        [Description("Do")]
        C = 0,

        /// <summary>
        /// D note.
        /// </summary>
        [Display(Name = "D")]
        [Description("Re")]
        D = 2,

        /// <summary>
        /// E note.
        /// </summary>
        [Display(Name = "E")]
        [Description("Mi")]
        E = 4,

        /// <summary>
        /// F note.
        /// </summary>
        [Display(Name = "F")]
        [Description("Fa")]
        F = 5,

        /// <summary>
        /// G note.
        /// </summary>
        [Display(Name = "G")]
        [Description("Sol")]
        G = 7,

        /// <summary>
        /// A note.
        /// </summary>
        [Display(Name = "A")]
        [Description("La")]
        A = 9,

        /// <summary>
        /// B note.
        /// </summary>
        [Display(Name = "B")]
        [Description("Si")]
        B = 11
    }
}
