namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// Интерфейс Bin классов, промежуточных между
    /// Soap классами и естественными классами библиотеки.
    ///</summary>
    public interface IBin
    {
        ///<summary>
        /// Создаёт из Bin объекта соответсвующий ему объект библиотеки.
        ///</summary>
        ///<returns></returns>
        IBaseObject GetInstance();
    }
}