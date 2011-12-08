namespace ChainAnalises.Classes.Root
{
    ///<summary>
    ///Интерфейс являющийся базовым для всех (наследуемый всеми) классами библиотеки
    ///Позоляет корректно сравнивать объекты и делать их копии.
    ///</summary>
    public interface IBaseObject /*:IXmlSerializable*/
    {
        ///<summary>
        /// Метод клонирования объекта
        ///</summary>
        ///<returns>Копию данного объекта</returns>
        IBaseObject Clone();

        ///<summary>
        /// Метод реализующий отношение эквивалентности
        ///</summary>
        ///<param name="obj">Объект c которым происходит проверка на эквивалентность</param>
        ///<returns>True если объекты эквивалентны, иначе false</returns>
        bool Equals(object obj);

        ///<summary>
        ///</summary>
        ///<returns></returns>
     //   object GetDataStruct();
        IBin GetBin();
    }
}