using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{

    ///<summary>
    /// Базовый класс итератор по цепочке.
    ///</summary>
    ///<typeparam name="ChainReturn">Тип возвращаемой цепи (Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    ///<typeparam name="ChainToIterate">Тип цепи по которой перемещается итератор(Потомок класса BaseChain и имеет непереметризированный конструктор)</typeparam>
    public abstract class IteratorBase<ChainReturn, ChainToIterate> : IIterator<ChainReturn, ChainToIterate> where ChainReturn : BaseChain, new() where ChainToIterate : BaseChain, new()
    {
        ///<summary>
        /// Длинна возвращаемого фрагмента цепи
        ///</summary>
        protected readonly int Length;
        ///<summary>
        /// Шаг итерации
        ///</summary>
        protected readonly int Step;
        ///<summary>
        /// Цепь по которой будет перемещатся итератор
        ///</summary>
        protected readonly ChainToIterate chain;
        ///<summary>
        /// Текушая позиция итератора
        ///</summary>
        protected int Position;
        ///<summary>
        /// Максимальное кол-во смещений
        ///</summary>
        protected readonly int MaxCount;


        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="toIterate">Цепь по которой будет перемещатся итератор</param>
        ///<param name="length">Длинна возвращаемого фрагмента цепи</param>
        ///<param name="step">Шаг итерации</param>
        ///<exception cref="Exception">В случае если toIterate == null или длинна передаваемой цепи меньше или равно 0 или меньше length</exception>
        public IteratorBase(ChainToIterate toIterate, int length, int step)
        {
            if (toIterate == null || length <= 0 || toIterate.Length < length)
            {
                throw new Exception();
            }
            Length = length;
            Step = step;
            chain = toIterate;
            MaxCount = chain.Length - Length;
            Reset();
        }

        ///<summary>
        /// Максимальное кол-во смещений
        ///</summary>
        public int MaxStepCount
        {
            get { return MaxCount; }
        }


        ///<summary>
        /// Перемещает итератор на следующую позицию.
        ///</summary>
        ///<returns>Возвращает False если  при перемещении обнаруживается конец цепи. Иначе True</returns>
        public abstract bool Next();


        ///<summary>
        /// Возвращает текущее значение итератора.
        ///</summary>
        ///<returns>Текущее значение итератора.</returns>
        ///<exception cref="Exception">В случае если пытаемся считать  значение за пределами цепи</exception>
        public virtual ChainReturn Current()
        {
            if (Position < 0 || Position > MaxCount)
            {
                return null;
            }

            ChainReturn temp = new ChainReturn();
            temp.ClearAndSetNewLength(Length);

            for (int i = 0; i < Length; i++)
            {
                temp.Add(chain[Position + i], i);
            }
            return temp;
        }

        public int ActualPosition()
        {
            return Position;
        }


        ///<summary>
        /// Перемещает итератор в начальную позицию.
        /// Начальная позиция итератора -1. То есть для считывания первого значения требуется предварительно вызвать Next()
        ///</summary>
        public abstract void Reset();
    }
}