using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{
    ///<summary>
    /// Итератор перемещающийся с начала цепи к концу.
    ///</summary>
    ///<typeparam name="ChainReturn">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    public class IteratorStart<ChainReturn, ChainToIterate> : IteratorBase<ChainReturn, ChainToIterate>
        where ChainToIterate : BaseChain, new()
        where ChainReturn : BaseChain, new()
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="toIterate">Цепь по которой будет перемещатся итератор</param>
        ///<param name="length">Длинна возвращаемого фрагмента цепи</param>
        ///<param name="step">Шаг итерации</param>
        ///<exception cref="Exception">В случае если toIterate == null или длинна передаваемой цепи меньше или равно 0 или меньше length</exception>
        public IteratorStart(ChainToIterate toIterate, int length, int step)
            : base(toIterate, length, step)
        {
        }


        ///<summary>
        /// Перемещает итератор на следующую позицию.
        ///</summary>
        ///<returns>Возвращает False если  при перемещении обнаруживается конец цепи. Иначе True</returns>
        public override bool Next()
        {
            Position = Position + Step;
            return Position <= MaxStepCount;
        }

        ///<summary>
        /// Перемещает итератор в начальную позицию.
        /// Начальная позиция итератора -шаг. То есть для считывания первого значения требуется предварительно вызвать Next()
        ///</summary>
        public override void Reset()
        {
            Position = -Step;
        }

        ///<summary>
        /// Перемещает итератор на заданную позицию
        ///</summary>
        ///<param name="i">Позиция на которую перемещаемся</param>
        ///<returns></returns>
        public bool Move(int i)
        {
            Position = Position + i*Step;
            return Position <= MaxStepCount;
        }
    }
}