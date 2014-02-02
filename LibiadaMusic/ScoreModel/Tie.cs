using System;

namespace LibiadaMusic.ScoreModel
{
    /// <summary>
    ///  класс для заполнения объекта класса Note данными, в зависимости от наличия лиги
    /// </summary>
    public enum Tie : byte
    {
        /// <summary>
        /// Нет Лиги (-1)
        /// </summary>
        None = 0,
        /// <summary>
        ///  Начало Лиги (0)
        /// </summary>
        Start = 1,
        /// <summary>
        /// Конец Лиги (1)
        /// </summary>
        Stop = 2,
        /// <summary>
        /// Конец и Начало следущей Лиги (2)
        /// </summary>
        StartStop = 3
    }
}
