using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators
{

    ///<summary>
    /// Интерфейс итератор по цепочке.
    ///</summary>
    ///<typeparam name="ChainRetrun">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    public interface IIterator<ChainRetrun, ChainToIterate> where ChainRetrun : BaseChain, new() where ChainToIterate: BaseChain,new ()
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
        ChainRetrun Current();
    }
}