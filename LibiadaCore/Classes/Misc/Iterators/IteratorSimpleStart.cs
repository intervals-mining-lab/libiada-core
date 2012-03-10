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
        protected int pLength;
        ///<summary>
        /// Шаг итерации
        ///</summary>
        protected int pStep;
        ///<summary>
        /// Цепь по которой будет перемещатся итератор
        ///</summary>
        protected ChainToIterate ptoIterate;
        ///<summary>
        /// Текушая позиция итератора
        ///</summary>
        protected int pos;
        ///<summary>
        /// Максимальное кол-во смещений
        ///</summary>
        protected int maxcount;


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
            pLength = 1;
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
        public  bool Next()
        {
            pos = pos + pStep;
            return pos <= MaxStepCount;
        }


        ///<summary>
        /// Возвращает текущее значение итератора.
        ///</summary>
        ///<returns>Текущее значение итератора.</returns>
        ///<exception cref="Exception">В случае если пытаемся считать  значение за пределами цепи</exception>
        public virtual IBaseObject Current()
        {
            if (pos < 0 || pos > maxcount)
            {
                return null;
            }
            return (ptoIterate[pos]).Clone();
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public int ActualPosition()
        {
            return pos;
        }


        ///<summary>
        /// Перемещает итератор в начальную позицию.
        /// Начальная позиция итератора -шаг. То есть для считывания первого значения требуется предварительно вызвать Next()
        ///</summary>
        public void Reset()
        {
            pos = -pStep;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public bool Move(int i)
        {
            pos = pos + i * pStep;
            return pos <= MaxStepCount;
        }
    }
}