using System;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators
{
    ///<summary>
    /// Итератор перемещающийся с начала цепи к концу.
    /// Позваляет записывать значения в цепь.
    ///</summary>
    ///<typeparam name="ChainReturn">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    public class IteratorWritableStart<ChainReturn, ChainToIterate> : IteratorStart<ChainReturn, ChainToIterate>, IWritableIterator<ChainReturn, ChainToIterate>
        where ChainToIterate : BaseChain, new() where ChainReturn : BaseChain, new()
    {
        ///<summary>
        /// Конструктор
        /// Длинна фрагмента возвращаемой цепи = 1.
        /// Шаг итерации = 1.
        ///</summary>
        ///<param name="toIterate">Цепь по которой будет перемещатся итератор</param>
        ///<exception cref="Exception">В случае если toIterate == null или длинна передаваемой цепи меньше или равно 0 или меньше length</exception>
        public IteratorWritableStart(ChainToIterate toIterate) : base(toIterate, 1, 1)
        {
        }


        ///<summary>
        /// Устанавливает значение в ячейку на которую указывает итератор
        ///</summary>
        ///<param name="value">Заначение которое присваеваем ячейке</param>
        public void SetCurrent(IBaseObject value)
        {
            ptoIterate.Add(value, pos);
        }
    }
}