namespace LibiadaCore.Classes.Root
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Misc;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using LibiadaCore.Classes.Root.IntervalsManagers;

    /// <summary>
    /// </summary>
    public class CongenericChain : BaseChain, IBaseObject
    {
        //protected List<int> intervals = new List<int>();
        protected CongenericIntervalsManager intervalsManager = null;
        protected int MaxFilledPosition;

        /// <summary>
        /// Создаёт однородную цепочку для заданного элемента и заданной длины.
        /// </summary>
        ///<param name="length">Длина цепочки</param>
        ///<param name="element">Элемент цепочки</param>
        public CongenericChain(int length, IBaseObject element) : base(length)
        {
            alphabet.Add(element);
        }

        /// <summary>
        /// </summary>
        public CongenericChain()
        {
        }

        /// <summary>
        /// </summary>
        public CongenericChain(bool[] map, IBaseObject element)
        {
            alphabet.Add(element);
            for (int i = 0; i < map.Length; i++)
            {
                building[i] = map[i] ? 1 : 0;
            }
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
        }

        /// <summary>
        /// Элемент цепочки
        /// </summary>
        public IBaseObject Element
        {
            get { return alphabet[1]; }
        }

        /// <summary>
        /// Возвращает копию массива интервалов, 
        /// включая привязку к началу и к концу
        /// </summary>
        public List<int> GetIntervals (Link link)
        {
            if (intervalsManager == null)
            {
                intervalsManager = new CongenericIntervalsManager(this);
            }
            return intervalsManager.GetIntervals(link);
        }
        
        public override void Add(IBaseObject item, int index)
        {
            intervalsManager = null;
            if (Element.Equals(item))
            {
                base.Add(item, index);
            }
        }

        /// <summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        /// </summary>
        ///<param name="index">номер элемента</param>
        public override IBaseObject this[int index]
        {
            get { return building[index] == 1 ? Element.Clone() : NullValue.Instance(); }

            set { Add(value, index); }
        }
        
        public IBaseObject DeleteAt(int index)
        {
            intervalsManager = null;
            IBaseObject element = alphabet[building[index]];
            building = ArrayManipulator.DeleteAt(building, index);
            return element;
        }
    }
}