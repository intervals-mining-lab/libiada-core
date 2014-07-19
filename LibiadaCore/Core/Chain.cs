namespace LibiadaCore.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.IntervalsManagers;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Класс цепь
    /// </summary>
    public class Chain : BaseChain, IBaseObject
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        protected CongenericChain[] congenericChains = new CongenericChain[0];

        /// <summary>
        /// The dissimilar chains.
        /// </summary>
        protected Chain[] dissimilarChains;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class.
        /// </summary>
        /// <param name="length">
        /// The length of chain.
        /// </param>
        public Chain(int length) : base(length)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class.
        /// </summary>
        public Chain()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class from string.
        /// Each character becoms element.
        /// </summary>
        /// <param name="source">
        /// The source string.
        /// </param>
        public Chain(string source)
            : base(source)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class 
        /// with provided building and alphabet.
        /// Only simple validation is made.
        /// </summary>
        /// <param name="building">
        /// The building of chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet of chain.
        /// </param>
        public Chain(int[] building, Alphabet alphabet)
            : base(building, alphabet)
        {
            CreateCongenericChains();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class from string.
        /// Each character becoms element.
        /// </summary>
        /// <param name="source">
        /// The source string.
        /// </param>
        public Chain(List<IBaseObject> source)
            : base(source)
        {
            CreateCongenericChains();
        }

        /// <summary>
        /// The clear and set new length.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        public override void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            this.congenericChains = new CongenericChain[0];
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public new IBaseObject Clone()
        {
            var clone = new Chain(building.Length);
            FillClone(clone);
            return clone;
        }

        /// <summary>
        /// Возвращает копию однородной цепочки с указанным элементом.
        /// Если такого элемента нет, то возврашщает null.
        /// </summary>
        /// <param name="baseObject">
        /// элемент однородной цепочки
        /// </param>
        /// <returns>
        /// The <see cref="CongenericChain"/>.
        /// </returns>
        public CongenericChain CongenericChain(IBaseObject baseObject)
        {
            CongenericChain result = null;
            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (CongenericChain)this.congenericChains[pos].Clone();
            }

            return result;
        }

        /// <summary>
        /// Возвращает копию однородной цепочки 
        /// с указанным индексом в алфавите полной цепи.
        /// </summary>
        /// <param name="i">
        /// Индекс элемента однородной цепочки в алфавите полной цепи
        /// </param>
        /// <returns>
        /// The <see cref="CongenericChain"/>.
        /// </returns>
        public CongenericChain CongenericChain(int i)
        {
            return (CongenericChain)this.congenericChains[i].Clone();
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
            base.Add(item, index);

            if (this.congenericChains.Length != (alphabet.Cardinality - 1))
            {
                var temp = new CongenericChain[alphabet.Cardinality - 1];
                for (int i = 0; i < this.congenericChains.Length; i++)
                {
                    temp[i] = this.congenericChains[i];
                }

                this.congenericChains = temp;
                this.congenericChains[this.congenericChains.Length - 1] = new CongenericChain(item, building.Length);
            }

            foreach (CongenericChain chain in this.congenericChains)
            {
                chain.Add(item, index);
            }
        }

        /// <summary>
        /// The fill dissimilar chains.
        /// </summary>
        public void FillDissimilarChains()
        {
            if (dissimilarChains.Length > 0)
            {
                return;
            }

            var counters = new List<int>();
            for (int j = 0; j < Alphabet.Cardinality; j++)
            {
                counters.Add(0);
            }

            for (int i = 0; i < building.Length; i++)
            {
                int element = ++counters[building[i]];
                if (dissimilarChains.Length < element)
                {
                    var temp = new Chain[element];
                    for (int j = 0; j < dissimilarChains.Length; j++)
                    {
                        temp[j] = dissimilarChains[j];
                    }

                    dissimilarChains = temp;
                    dissimilarChains[dissimilarChains.Length - 1] = new Chain();
                }

                dissimilarChains[element].Add(new ValueInt(building[i]), i);
            }
        }

        /// <summary>
        /// Возвращает i-ый интервал 
        /// между указанными элементами 
        /// в бинарно-однродной цепи
        /// </summary>
        /// <param name="first">
        /// первый элементы пары
        /// </param>
        /// <param name="second">
        /// второй элемент пары
        /// </param>
        /// <param name="entry">
        /// номер вхождения начиная с 1
        /// </param>
        /// <returns>Длина интервала</returns>
        public int GetBinaryInterval(IBaseObject first, IBaseObject second, int entry)
        {
            int firstEntry = Get(first, entry);
            if (firstEntry == -1)
            {
                return -1;
            }

            for (int i = firstEntry + 1; i < building.Length; i++)
            {
                if (first.Equals(this[i]))
                {
                    return -1;
                }

                if (second.Equals(this[i]))
                {
                    return i - firstEntry;
                }
            }

            return -1;
        }

        /// <summary>
        /// Возвращает позицию указанного по счёту вхождения указанного элемента.
        /// </summary>
        /// <param name="element">
        /// Искомый элемент.
        /// </param>
        /// <param name="entry">
        /// Номер вхождения элемента в полную цепь.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Get(IBaseObject element, int entry)
        {
            int entranceCount = 0;
            for (int i = 0; i < building.Length; i++)
            {
                if (this[i].Equals(element))
                {
                    entranceCount++;
                    if (entranceCount == entry)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Возвращает позицию первого вхождения указанного элемента 
        /// после указанной позиции.
        /// </summary>
        /// <param name="element">
        /// Искомый элемент.
        /// </param>
        /// <param name="from">
        /// Начальная позиция для отсчёта.
        /// </param>
        /// <returns>
        /// Номер позиции или -1, если элемент после указанной позиции не встречается.
        /// </returns>
        public int GetAfter(IBaseObject element, int from)
        {
            for (int i = from; i < building.Length; i++)
            {
                if (this[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// The get pairs count.
        /// </summary>
        /// <param name="first">
        /// The j.
        /// </param>
        /// <param name="second">
        /// The l.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetPairsCount(IBaseObject first, IBaseObject second)
        {
            var elementCounter = new ElementsCount();
            var firstElementCount = (int)elementCounter.Calculate(CongenericChain(first), Link.None);
            int pairs = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(first, second, i);
                if (binaryInterval > 0)
                {
                    pairs++;
                }
            }

            return pairs;
        }

        /// <summary>
        /// The fill interval managers.
        /// </summary>
        public void FillIntervalManagers()
        {
            var occurrences = new int[alphabet.Cardinality - 1];
            for (int i = 0; i < occurrences.Length; i++)
            {
                occurrences[i] = -1;
            }

            var intervals = new List<int>[alphabet.Cardinality - 1];

            for (int i = 0; i < intervals.Length; i++)
            {
                intervals[i] = new List<int>();
            }

            for (int j = 0; j < building.Length; j++)
            {
                int value = building[j] - 1;
                intervals[value].Add(j - occurrences[value]);
                occurrences[value] = j;
            }

            for (int k = 0; k < intervals.Length; k++)
            {
                int start = intervals[k][0];
                int end = building.Length - intervals[k].Last();
                intervals[k].RemoveAt(0);

                this.congenericChains[k].SetIntervalManager(new CongenericIntervalsManager(this, intervals[k].ToArray(), start, end));
            }
        }

        /// <summary>
        /// The fill clone.
        /// </summary>
        /// <param name="clone">
        /// The clone.
        /// </param>
        protected void FillClone(IBaseObject clone)
        {
            var tempChain = clone as Chain;
            base.FillClone(tempChain);
            if (tempChain != null)
            {
                tempChain.congenericChains = (CongenericChain[])this.congenericChains.Clone();
            }
        }

        /// <summary>
        /// Выделяет из полной неоднородной цепи все однородные цепи
        /// и сохраняет их локальнов массив <see cref="congenericChains"/>.
        /// </summary>
        private void CreateCongenericChains()
        {
            var occerrences = new List<int>[alphabet.Cardinality - 1];

            for (int i = 0; i < alphabet.Cardinality - 1; i++)
            {
                occerrences[i] = new List<int>();
            }

            for (int j = 0; j < building.Length; j++)
            {
                occerrences[building[j] - 1].Add(j);
            }

            this.congenericChains = new CongenericChain[alphabet.Cardinality - 1];
            for (int k = 0; k < alphabet.Cardinality - 1; k++)
            {
                this.congenericChains[k] = new CongenericChain(occerrences[k], alphabet[k + 1], building.Length);
            }
        }
    }
}