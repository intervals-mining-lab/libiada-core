using System.Collections.Generic;
using LibiadaCore.Classes.Misc;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    public class CongenericChain : BaseChain, IBaseObject
    {
        protected List<int> intervals = new List<int>();
        protected int MaxFilledPosition;

        ///<summary>
        /// Создаёт однородную цепочку для заданного элемента и заданной длины.
        ///</summary>
        ///<param name="length">Длина цепочки</param>
        ///<param name="element">Элемент цепочки</param>
        public CongenericChain(int length, IBaseObject element) : base(length)
        {
            alphabet.Add(element);
        }

        ///<summary>
        ///</summary>
        public CongenericChain()
        {
        }


        public new IBaseObject Clone()
        {
            var temp = new CongenericChain(Length, Element);
            FillClone(temp);
            return temp;
        }

        protected void FillClone(IBaseObject temp)
        {
            var tempCongenericChain = temp as CongenericChain;
            base.FillClone(tempCongenericChain);
            if (tempCongenericChain != null)
            {
                tempCongenericChain.BuildIntervals();
            }
        }

        ///<summary>
        /// Элемент цепочки
        ///</summary>
        public IBaseObject Element
        {
            get { return alphabet[1]; }
        }

        /// <summary>
        /// Возвращает копию массива интервалов, 
        /// включая привязку к началу и к концу
        /// </summary>
        public List<int> Intervals
        {
            get
            {
                return new List<int>(intervals);
            }
        }

        /// <summary>
        /// Находит позицию ближайшего слева от указанной позиции 
        /// вхождения элемента в однородную цепочки.
        /// </summary>
        /// <param name="current">Позиция для отчёта</param>
        /// <returns>Позиция бижайшего слева элемента в однородной цепи, или -1 если слева нет элементов</returns>
        protected int Left(int current)
        {
            for (int i = current - 1; i >= 0; i--)
            {
                if (building[i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// Находит позицию ближайшего справа от указанной позиции 
        /// вхождения элемента в однородную цепочки.
        /// </summary>
        /// <param name="current">Позиция для отчёта</param>
        /// <returns>Позиция бижайшего справа элемента в однородной цепи, или -длина цепочки если слева нет элементов</returns>
        protected int Right(int current)
        {
            for (int i = current + 1; i < Length; i++)
            {
                if (building[i] == 1)
                {
                    return i;
                }
            }
            return Length;
        }

        public override void Add(IBaseObject item, int index)
        {
            if (Element.Equals(item))
            {
                base.Add(item, index);
                BuildIntervals(index);
            }
        }

        ///<summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        ///</summary>
        ///<param name="index">номер элемента</param>
        public override IBaseObject this[int index]
        {
            get { return building[index] == 1 ? Element.Clone() : NullValue.Instance(); }

            set { Add(value, index); }
        }

        /// <summary>
        /// Перестраивает только последний интервал
        /// если был добавлен элемент за последним из уже имеющихся
        /// иначе вызывает метод полной перестройки интервалов.
        /// </summary>
        /// <param name="addedPosition">Позиция добавленного элемента</param>
        private void BuildIntervals(int addedPosition)
        {
            if ((intervals.Count > 0) && (addedPosition > MaxFilledPosition))
            {
                intervals[intervals.Count - 1] = addedPosition - Left(addedPosition);
                intervals.Add(Length - addedPosition);
                MaxFilledPosition = addedPosition;
            }
            else
            {
                BuildIntervals();
            }
            
        }

        /// <summary>
        /// Перестраивает массив интервалов.
        /// </summary>
        protected void BuildIntervals()
        {
            intervals = new List<int>();
            int next = -1;
            do
            {
                int current = next;
                next = Right(current);

                intervals.Add(next - current);
            } while (next != Length);
        }

        public IBaseObject DeleteAt(int index)
        {
            IBaseObject element = alphabet[building[index]];
            building = ArrayManipulator.DeleteAt(building, index);
            BuildIntervals();
            return element;
        }
    }
}