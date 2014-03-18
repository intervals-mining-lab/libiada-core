namespace LibiadaCore.Core
{
    /// <summary>
    /// Интерфейс являющийся базовым для всех (наследуемый всеми) классами библиотеки
    /// Позоляет корректно сравнивать объекты и делать их копии.
    /// Любой элемент данных наследует данный интерфейс.
    /// </summary>
    public interface IBaseObject
    {
        /// <summary>
        /// Метод клонирования объекта
        /// </summary>
        /// <returns>
        /// Копию данного объекта
        /// </returns>
        IBaseObject Clone();

        /// <summary>
        /// Метод реализующий отношение эквивалентности
        /// </summary>
        /// <param name="other">
        /// Объект c которым происходит проверка на эквивалентность
        /// </param>
        /// <returns>
        /// True если объекты эквивалентны, иначе false
        /// </returns>
        bool Equals(object other);
    }
}