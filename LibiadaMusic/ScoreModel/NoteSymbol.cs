namespace LibiadaMusic.ScoreModel
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
        [Description("До")]
        C = 0,
        /// <summary>
        /// D note.
        /// </summary>
        [Display(Name = "D")]
        [Description("Ре")]
        D= 2,
        /// <summary>
        /// E note.
        /// </summary>
        [Display(Name = "E")]
        [Description("Ми")]
        E= 4,
        /// <summary>
        /// F note.
        /// </summary>
        [Display(Name = "F")]
        [Description("Фа")]
        F = 5,
        /// <summary>
        /// G note.
        /// </summary>
        [Display(Name = "G")]
        [Description("Соль")]
        G = 7,
        /// <summary>
        /// A note.
        /// </summary>
        [Display(Name = "A")]
        [Description("Ля")]
        A = 9,
        /// <summary>
        /// B note.
        /// </summary>
        [Display(Name = "B")]
        [Description("Си")]
        B = 11
    }
}