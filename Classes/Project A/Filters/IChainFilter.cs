namespace MarkovCompare
{
    ///<summary>
    /// Интерфес фильтра цепей
    ///</summary>
    public interface IChainFilter
    {
        ///<summary>
        /// Возвращает булевое значение валидности результата фильтрации
        ///</summary>
        ///<param name="building">Строй</param>
        ///<returns></returns>
        bool IsValid(string building);
    }
}