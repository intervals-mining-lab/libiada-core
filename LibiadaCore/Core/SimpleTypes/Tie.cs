using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibiadaCore.Core.SimpleTypes
{
    /// <summary>
    ///  класс для заполнения объекта класса Note данными, в зависимости от наличия лиги
    /// </summary>
    public enum Tie : byte
    {
        /// <summary>
        /// Нет Лиги (0)
        /// </summary>
        [Display(Name = "None")]
        [Description("No tie on note")]
        None = 0,

        /// <summary>
        ///  Начало Лиги (1)
        /// </summary>
        [Display(Name = "Start")]
        [Description("Tie starts on the note")]
        Start = 1,

        /// <summary>
        /// Конец Лиги (2)
        /// </summary>
        [Display(Name = "End")]
        [Description("Tie ends on the note")]
        End = 2,

        /// <summary>
        /// Конец и Начало следущей Лиги (3)
        /// </summary>
        [Display(Name = "Continue")]
        [Description("The note is inside the tie")]
        Continue = 3
    }
}
