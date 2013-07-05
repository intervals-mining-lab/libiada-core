using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{
    ///<summary>
    ///</summary>
    ///<typeparam name="ChainToIterate"></typeparam>
    public class IteratorSimpleStart<ChainToIterate> where ChainToIterate : BaseChain, new() 
    {
        ///<summary>
        /// Длинна возвращаемого фрагмента цепи
        ///</summary>
        protected int Length;
        ///<summary>
        /// Шаг итерации
        ///</summary>
        protected int Step;
        ///<summary>
        /// Цепь по которой будет перемещатся итератор
        ///</summary>
        protected ChainToIterate chain;
        ///<summary>
        /// Текушая позиция итератора
        ///</summary>
        protected int Position;
        ///<summary>
        /// Максимальное кол-во смещений
        ///</summary>
        protected int MaxCount;


        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="toIterate">Цепь по которой будет перемещатся итератор</param>
        ///<param name="step">Шаг итерации</param>
        ///<exception cref="Exception">В случае если toIterate == null или длинна передаваемой цепи меньше или равно 0 или меньше length</exception>
        public IteratorSimpleStart(ChainToIterate toIterate, int step)
        {
            if (toIterate == null || toIterate.Length < 1)
            {
                throw new Exception();
            }
            Length = 1;
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
        public  bool Next()
        {
            Position = Position + Step;
            return Position <= MaxStepCount;
        }


        ///<summary>
        /// Возвращает текущее значение итератора.
        ///</summary>
        ///<returns>Текущее значение итератора.</returns>
        ///<exception cref="Exception">В случае если пытаемся считать  значение за пределами цепи</exception>
        public virtual IBaseObject Current()
        {
            if (Position < 0 || Position > MaxCount)
            {
                return null;
            }
            return (chain[Position]).Clone();
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public int ActualPosition()
        {
            return Position;
        }


        ///<summary>
        /// Перемещает итератор в начальную позицию.
        /// Начальная позиция итератора -шаг. То есть для считывания первого значения требуется предварительно вызвать Next()
        ///</summary>
        public void Reset()
        {
            Position = -Step;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public bool Move(int i)
        {
            Position = Position + i * Step;
            return Position <= MaxStepCount;
        }
    }
}