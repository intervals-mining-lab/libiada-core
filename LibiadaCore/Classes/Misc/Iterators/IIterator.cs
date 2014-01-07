using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{

    ///<summary>
    /// Интерфейс итератор по цепочке.
    ///</summary>
    ///<typeparam name="ChainReturn">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непараметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непараметризированный конструктор)</typeparam>
    public interface IIterator<ChainReturn, ChainToIterate> where ChainReturn : BaseChain, new() where ChainToIterate: BaseChain,new ()
    {

        ///<summary>
        /// Перемещает итератор на следующую позицию.
        ///</summary>
        ///<returns>Возвращает False если  при перемещении обнаруживается конец цепи. Иначе True</returns>
        bool Next();


        ///<summary>
        /// Перемещает итератор в начальную позицию.
        /// Начальная позиция итератора -шаг итерации. То есть для считывания первого значения требуется предварительно вызвать Next()
        ///</summary>
        void Reset();

        ///<summary>
        /// Возвращает текущее значение итератора.
        ///</summary>
        ///<returns>Текущее значение итератора.</returns>
        ChainReturn Current();
    }
}