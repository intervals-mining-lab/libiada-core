using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{

    ///<summary>
    /// Итератор перемещающийся с конца цепи к началу.
    /// Позваляет записывать значения в цепь.
    ///</summary>
    ///<typeparam name="ChainReturn">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    public class IteratorWritableEnd<ChainReturn, ChainToIterate> : IteratorEnd<ChainReturn, ChainToIterate>, IWritableIterator<ChainReturn, ChainToIterate>   
        where ChainToIterate : BaseChain, new() where ChainReturn : BaseChain, new()
    {
        ///<summary>
        /// Конструктор
        /// Длинна фрагмента возвращаемой цепи = 1.
        /// Шаг итерации = 1.
        ///</summary>
        ///<param name="toIterate">Цепь по которой будет перемещатся итератор</param>
        ///<exception cref="Exception">В случае если toIterate == null или длинна передаваемой цепи меньше или равно 0 или меньше length</exception>
        public IteratorWritableEnd(ChainToIterate toIterate) : base(toIterate, 1, 1)
        {
        }


        ///<summary>
        /// Устанавливает значение в ячейку на которую указывает итератор
        ///</summary>
        ///<param name="baseObject">Заначение которое присваеваем ячейке</param>
        public void SetCurrent(IBaseObject baseObject)
        {
            ptoIterate.Add(baseObject, pos);
        }
    }
}