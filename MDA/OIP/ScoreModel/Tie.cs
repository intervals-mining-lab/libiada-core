namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// класс для заполнения объекта класса Note данными, в зависимости от наличия лиги
    /// </summary>
    public enum Tie
    {
        /// <summary>
        /// Нет Лиги (-1)
        /// </summary>
        None=-1,

        /// <summary>
        /// Начало Лиги (0)
        /// </summary>
        Start=0,

        /// <summary>
        /// Конец Лиги (1)
        /// </summary>
        Stop=1,

        /// <summary>
        /// Конец и Начало следущей Лиги (2)
        /// </summary>
        StartStop=2
    }
}
