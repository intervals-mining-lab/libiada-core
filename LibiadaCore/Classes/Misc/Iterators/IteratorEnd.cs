using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{

    ///<summary>
    /// Итератор перемещающийся с конца цепи к началу.
    ///</summary>
    ///<typeparam name="ChainReturn">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    public class IteratorEnd<ChainReturn, ChainToIterate> : IteratorBase<ChainReturn, ChainToIterate> where ChainToIterate : BaseChain, new() where ChainReturn : BaseChain, new()
    {

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="toIterate">Цепь по которой будет перемещатся итератор</param>
        ///<param name="length">Длинна возвращаемого фрагмента цепи</param>
        ///<param name="step">Шаг итерации</param>
        ///<exception cref="Exception">В случае если toIterate == null или длинна передаваемой цепи меньше или равно 0 или меньше length</exception>
        public IteratorEnd(ChainToIterate toIterate, int length, int step) : base(toIterate, length, step)
        {
        }

        ///<summary>
        /// Перемещает итератор на следующую позицию.
        ///</summary>
        ///<returns>Возвращает False если  при перемещении обнаруживается начало цепи. Иначе True</returns>
        public override bool Next()
        {
            Position = Position - Step;
            return Position >= 0;
        }


        ///<summary>
        /// Перемещает итератор в начальную позицию.
        /// Для считывания первого значения требуется предварительно вызвать Next()
        ///</summary>
        public override void Reset()
        {
            Position = chain.Length - Length + Step;
        }
    }
}