namespace LibiadaCore.Classes.Root
{
    using System.Collections.Generic;

    using Misc;
    using IntervalsManagers;
    using SimpleTypes;

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
        /// ������ ���������� ������� ��� ��������� �������� � �������� �����.
        /// </summary>
        /// <param name="length">
        /// ����� �������
        /// </param>
        /// <param name="element">
        /// ������� �������
        /// </param>
        public CongenericChain(int length, IBaseObject element) : base(length)
        {
            alphabet.Add(element);
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
            alphabet.Add(element);
            for (int i = 0; i < map.Length; i++)
            {
                building[i] = map[i] ? 1 : 0;
            }
        }

        /// <summary>
        /// ������� �������
        /// </summary>
        public IBaseObject Element
        {
            get { return alphabet[1]; }
        }

        /// <summary>
        /// ��������� ��������� �������� ������ � �������� ���� �� �������.
        /// � ������ ������ �� ������� ���� ���������� ����������.
        /// </summary>
        /// <param name="index">
        /// ����� ���������.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public override IBaseObject this[int index]
        {
            get { return building[index] == 1 ? Element.Clone() : NullValue.Instance(); }

            set { Add(value, index); }
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public new IBaseObject Clone()
        {
            var temp = new CongenericChain(Length, Element);
            FillClone(temp);
            return temp;
        }

        /// <summary>
        /// ���������� ����� ������� ����������, 
        /// ������� �������� � ������ � � �����
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{int}"/>.
        /// </returns>
        public List<int> GetIntervals(Link link)
        {
            if (intervalsManager == null)
            {
                intervalsManager = new CongenericIntervalsManager(this);
            }

            return intervalsManager.GetIntervals(link);
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
            intervalsManager = null;
            if (Element.Equals(item))
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
            intervalsManager = null;
            IBaseObject element = alphabet[building[index]];
            building = ArrayManipulator.DeleteAt(building, index);
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