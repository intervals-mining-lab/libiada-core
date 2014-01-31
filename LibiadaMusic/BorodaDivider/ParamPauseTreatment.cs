﻿namespace LibiadaMusic.BorodaDivider
{
    /// <summary>
    /// класс для выбора отношения к паузам 
    /// (игнорировать, длительность добавлять к предыдущему звуку, рассматривать как ноту "тишины")
    /// </summary>
    public enum ParamPauseTreatment 
    {
        /// <summary>
        /// Игнорировать паузы (но не удалять) - однако они имеют значение при выделении приоритетов нот (0)
        /// </summary>
        Ignore = 0,


        /// <summary>
        /// Пауза - звуковой след ноты, длительность паузы прибавляется к предыдущей ноте, 
        /// а она сама удаляется из текста (1)
        /// </summary>
         NoteTrace = 1,

        /// <summary>
        /// Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
        /// </summary>
        SilenceNote = 2
    }
}
