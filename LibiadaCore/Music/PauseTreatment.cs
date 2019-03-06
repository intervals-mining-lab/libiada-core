using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibiadaCore.Music
{
    /// <summary>
    /// класс для выбора отношения к паузам
    /// (игнорировать, длительность добавлять к предыдущему звуку, рассматривать как ноту "тишины")
    /// </summary>
    public enum PauseTreatment
    {
        /// <summary>
        /// Обработка пауз не применяется (для нот и тактов)
        /// </summary>
        [Display(Name = "Not applicable")]
        [Description("Pause treatment doesn't apply")]
        NotApplicable = 0,

        /// <summary>
        /// Игнорировать паузы (но не удалять) - однако они имеют значение при выделении приоритетов нот (1)
        /// </summary>
        [Display(Name = "Ignore")]
        [Description("Pauses are ignored")]
        Ignore = 1,

        /// <summary>
        /// Пауза - звуковой след ноты, длительность паузы прибавляется к предыдущей ноте,
        /// а она сама удаляется из текста (2)
        /// </summary>
        [Display(Name = "Note Trace")]
        [Description("Pause's duration adds to previous note")]
        NoteTrace = 2,

        /// <summary>
        /// Пауза - звук тишины, рассматривается как нота без высоты звучания (3)
        /// </summary>
        [Display(Name = "Silence Note")]
        [Description("Pauses is a notes without pitch")]
        SilenceNote = 3
    }
}
