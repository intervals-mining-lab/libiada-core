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
        protected readonly int pLength;
        ///<summary>
        /// Шаг итерации
        ///</summary>
        protected readonly int pStep;
        ///<summary>
        /// Цепь по которой будет перемещатся итератор
        ///</summary>
        protected readonly ChainToIterate ptoIterate;
        ///<summary>
        /// Текушая позиция итератора
        ///</summary>
        protected int pos;
        ///<summary>
        /// Максимальное кол-во смещений
        ///</summary>
        protected readonly int maxcount;


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
            pLength = length;
            pStep = step;
            ptoIterate = toIterate;
            maxcount = ptoIterate.Length - pLength;
            Reset();
        }

        ///<summary>
        /// Максимальное кол-во смещений
        ///</summary>
        public int MaxStepCount
        {
            get { return maxcount; }
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
            if (pos < 0 || pos > maxcount)
            {
                return null;
            }

            ChainReturn temp = new ChainReturn();
            temp.ClearAndSetNewLength(pLength);

            for (int i = 0; i < pLength; i++)
            {
                temp.Add(ptoIterate[pos + i], i);
            }
            return temp;
        }

        public int ActualPosition()
        {
            return pos;
        }


        ///<summary>
        /// Перемещает итератор в начальную позицию.
        /// Начальная позиция итератора -1. То есть для считывания первого значения требуется предварительно вызвать Next()
        ///</summary>
        public abstract void Reset();
    }
}