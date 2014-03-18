namespace LibiadaCore.Core
{
    using System.Collections.Generic;

    using LibiadaCore.Core.IntervalsManagers;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc;

    /// <summary>
    /// The congeneric chain.
    /// </summary>
    public class CongenericChain : BaseChain, IBaseObject
    {
        /// <summary>
        /// The intervals manager.
        /// </summary>
        protected CongenericIntervalsManager intervalsManager;

        /// <summary>
        /// Создаёт однородную цепочку для заданного элемента и заданной длины.
        /// </summary>
        /// <param name="length">
        /// Длина цепочки
        /// </param>
        /// <param name="element">
        /// Элемент цепочки
        /// </param>
        public CongenericChain(int length, IBaseObject element) : base(length)
        {
            this.alphabet.Add(element);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericChain"/> class.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        public CongenericChain(bool[] map, IBaseObject element)
        {
            this.alphabet.Add(element);
            for (int i = 0; i < map.Length; i++)
            {
                this.building[i] = map[i] ? 1 : 0;
            }
        }

        /// <summary>
        /// Элемент цепочки
        /// </summary>
        public IBaseObject Element
        {
            get { return this.alphabet[1]; }
        }

        /// <summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        /// </summary>
        /// <param name="index">
        /// Номер элементаю.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public override IBaseObject this[int index]
        {
            get { return this.building[index] == 1 ? this.Element.Clone() : NullValue.Instance(); }

            set { this.Add(value, index); }
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public new IBaseObject Clone()
        {
            var temp = new CongenericChain(this.Length, this.Element);
            this.FillClone(temp);
            return temp;
        }

        /// <summary>
        /// Возвращает копию массива интервалов, 
        /// включая привязку к началу и к концу
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{int}"/>.
        /// </returns>
        public List<int> GetIntervals(Link link)
        {
            if (this.intervalsManager == null)
            {
                this.intervalsManager = new CongenericIntervalsManager(this);
            }

            return this.intervalsManager.GetIntervals(link);
        }

        /// <summary>
        /// Sets item in provided position.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        public override void Add(IBaseObject item, int index)
        {
            this.intervalsManager = null;
            if (this.Element.Equals(item))
            {
                base.Add(item, index);
            }
        }

        /// <summary>
        /// The delete at.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject DeleteAt(int index)
        {
            this.intervalsManager = null;
            IBaseObject element = this.alphabet[this.building[index]];
            this.building = ArrayManipulator.DeleteAt(this.building, index);
            return element;
        }

        /// <summary>
        /// The fill clone.
        /// </summary>
        /// <param name="temp">
        /// The temp.
        /// </param>
        protected void FillClone(IBaseObject temp)
        {
            var tempCongenericChain = temp as CongenericChain;
            base.FillClone(tempCongenericChain);
        }
    }
}