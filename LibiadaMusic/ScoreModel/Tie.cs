namespace LibiadaMusic.ScoreModel
{
    /// <summary>
    ///  класс для заполнения объекта класса Note данными, в зависимости от наличия лиги
    /// </summary>
    public enum Tie : byte
    {
        /// <summary>
        /// Нет Лиги (0)
        /// </summary>
        None = 0,

        /// <summary>
        ///  Начало Лиги (1)
        /// </summary>
        Start = 1,

        /// <summary>
        /// Конец Лиги (2)
        /// </summary>
        Stop = 2,

        /// <summary>
        /// Конец и Начало следущей Лиги (3)
        /// </summary>
        StartStop = 3
    }
}
