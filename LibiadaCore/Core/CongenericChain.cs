namespace LibiadaCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.IntervalsManagers;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The congeneric chain.
    /// </summary>
    public class CongenericChain : AbstractChain
    {
        /// <summary>
        /// The element.
        /// </summary>
        private readonly IBaseObject element;

        /// <summary>
        /// The building.
        /// </summary>
        private List<int> building = new List<int>();

        /// <summary>
        /// The chain length.
        /// </summary>
        private int length;

        /// <summary>
        /// The intervals manager.
        /// </summary>
        private CongenericIntervalsManager intervalsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericChain"/> class.
        /// </summary>
        /// <param name="element">
        /// ������� �������.
        /// </param>
        /// <param name="length">
        /// ����� �������.
        /// </param>
        public CongenericChain(IBaseObject element, int length)
        {
            this.element = element;
            this.length = length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericChain"/> class.
        /// </summary>
        /// <param name="building">
        /// The building.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        public CongenericChain(IEnumerable<int> building, IBaseObject element, int length)
        {
            this.length = length;
            this.element = element.Clone();
            this.building = building.OrderBy(b => b).ToList();
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
        /// <param name="length">
        /// The length.
        /// </param>
        public CongenericChain(bool[] map, IBaseObject element, int length)
        {
            this.length = length;
            this.element = element;
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i])
                {
                    Add(i);
                }
            }
        }

        /// <summary>
        /// Gets element chain filled with.
        /// </summary>
        public IBaseObject Element
        {
            get { return element.Clone(); }
        }

        /// <summary>
        /// Gets the building.
        /// </summary>
        public int[] Building
        {
            get
            {
                var result = new int[length];
                for (int i = 0; i < building.Count; i++)
                {
                    result[building[i]] = 1;
                }

                return result;
            }
        }

        /// <summary>
        /// �� ���� ���������� �������, ������ ����� �
        /// ������������ ����� �����.
        /// </summary>
        /// <param name="newLength">
        /// ����� ����� �������.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if new length is less than 0.
        /// </exception>
        public override void ClearAndSetNewLength(int newLength)
        {
            if (newLength < 0)
            {
                throw new ArgumentException("Chain length shouldn't be less than 0.");
            }

            intervalsManager = null;
            length = newLength;
            building = new List<int>();
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
        public int[] GetIntervals(Link link)
        {
            if (intervalsManager == null)
            {
                intervalsManager = new CongenericIntervalsManager(this);
            }

            return intervalsManager.GetIntervals(link);
        }

        /// <summary>
        /// The get length.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetLength()
        {
            return length;
        }

        // TODO: ������������� ����� � Set ��� ���-�� ��������.

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
            if (element.Equals(item))
            {
                Add(index);
            }
        }

        // TODO: ������������� ����� � Set ��� ���-�� ��������.

        /// <summary>
        /// Sets item in provided position.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        public void Add(int index)
        {
            if (index >= length || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index of added element is out of bounds (index = " + index + ", chain length = " + length + ").");
            }

            intervalsManager = null;

            if (!building.Contains(index))
            {
                building.Add(index);
                building = building.OrderBy(b => b).ToList();
            }
        }

        /// <summary>
        /// ����� ����������� �������� ������� �� �������.
        /// � ������ ������ �� ������� ���� ���������� ����������.
        /// </summary>
        /// <param name="index">
        /// ������ ��������
        /// </param>
        /// <returns>
        /// ���������� �������
        /// </returns>
        public override IBaseObject Get(int index)
        {
            return building.Contains(index) ? element.Clone() : NullValue.Instance();
        }

        /// <summary>
        /// The delete at.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        public void DeleteAt(int index)
        {
            intervalsManager = null;
            length--;
            if (building.Contains(index))
            {
                building.Remove(index);
            }

            for (int i = 0; i < building.Count; i++)
            {
                if (index < building[i])
                {
                    building[i]--;
                }
            }
        }

        /// <summary>
        /// ����� ��������� ������� � ������� ���� 
        /// � ������ ������ �� ������� ���� ���������� ����������
        /// </summary>
        /// <param name="index">
        /// ����� �������
        /// </param>
        public override void RemoveAt(int index)
        {
            intervalsManager = null;
            building.Remove(index);
        }

        /// <summary>
        /// The set interval manager.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public void SetIntervalManager(CongenericIntervalsManager manager)
        {
            intervalsManager = manager;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.Equals(NullValue.Instance()))
            {
                for (int i = 0; i < length; i++)
                {
                    if (!Get(i).Equals(NullValue.Instance()))
                    {
                        return false;
                    }
                }

                return true;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other as CongenericChain == null)
            {
                return false;
            }

            var chainObject = (CongenericChain)other;
            if (!element.Equals(chainObject.Element))
            {
                return false;
            }

            for (int i = 0; (i < chainObject.length) && (i < length); i++)
            {
                if (!this[i].Equals(chainObject[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public override IBaseObject Clone()
        {
            return new CongenericChain(building, Element, length);
        }
    }
}