using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators
{

    ///<summary>
    /// Интерфейс итератора позволяющего писать занчение в позицию цепи.
    /// Длинна возварщаемого фрамгмента цепи и шаг должны быть равны 1. 
    ///</summary>
    ///<typeparam name="ChainReturn">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    public interface IWritableIterator<ChainReturn, ChainToIterate> : IIterator<ChainReturn, ChainToIterate> where ChainReturn : BaseChain, new() where ChainToIterate : BaseChain, new()
    {

        ///<summary>
        /// Устанавливает значение в ячейку на которую указывает итератор
        ///</summary>
        ///<param name="value">Заначение которое присваеваем ячейке</param>
        void SetCurrent(IBaseObject value);
    }
}