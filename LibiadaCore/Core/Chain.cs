namespace LibiadaCore.Core
{
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc;

    /// <summary>
    /// Класс цепь
    /// </summary>
    public class Chain : BaseChain, IBaseObject
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        protected CongenericChain[] CongenericChains = new CongenericChain[0];

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
        public Chain(string source) : base(source)
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
        public Chain(int[] building, Alphabet alphabet) : base(building, alphabet)
        {
            this.CreateCongenericChains();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chain"/> class from string.
        /// Each character becoms element.
        /// </summary>
        /// <param name="source">
        /// The source string.
        /// </param>
        public Chain(List<IBaseObject> source) : base(source)
        {
            this.CreateCongenericChains();
        }

        /// <summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу
        /// В случае выхода за границы цепи вызывается исключение
        /// </summary>
        /// <param name="index">
        /// Номер элемента.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public override IBaseObject this[int index]
        {
            get { return this.Get(index); }

            set { this.Add(value, index); }
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
            this.CongenericChains = new CongenericChain[0];
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public new IBaseObject Clone()
        {
            var clone = new Chain(this.Length);
            this.FillClone(clone);
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
            int pos = this.Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (CongenericChain)this.CongenericChains[pos].Clone();
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
            return (CongenericChain)this.CongenericChains[i].Clone();
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

            if (this.CongenericChains.Length != (this.alphabet.Cardinality - 1))
            {
                var temp = new CongenericChain[this.alphabet.Cardinality - 1];
                for (int i = 0; i < this.CongenericChains.Length; i++)
                {
                    temp[i] = this.CongenericChains[i];
                }

                this.CongenericChains = temp;
                this.CongenericChains[this.CongenericChains.Length - 1] = new CongenericChain(this.Length, item);
            }

            foreach (CongenericChain chain in this.CongenericChains)
            {
                chain.Add(item, index);
            }
        }

        /// <summary>
        /// The fill dissimilar chains.
        /// </summary>
        public void FillDissimilarChains()
        {
            if (this.dissimilarChains.Length > 0)
            {
                return;
            }

            var counters = new List<int>();
            for (int j = 0; j < this.Alphabet.Cardinality; j++)
            {
                counters.Add(0);
            }

            for (int i = 0; i < this.building.Length; i++)
            {
                int element = ++counters[this.building[i]];
                if (this.dissimilarChains.Length < element)
                {
                    var temp = new Chain[element];
                    for (int j = 0; j < this.dissimilarChains.Length; j++)
                    {
                        temp[j] = this.dissimilarChains[j];
                    }

                    this.dissimilarChains = temp;
                    this.dissimilarChains[this.dissimilarChains.Length - 1] = new Chain();
                }

                this.dissimilarChains[element].Add(new ValueInt(this.building[i]), i);
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
            int firstEntry = this.Get(first, entry);
            if (firstEntry == -1)
            {
                return -1;
            }

            for (int i = firstEntry + 1; i < this.Length; i++)
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
        /// Элемнет
        /// </param>
        /// <param name="entry">
        /// Номер вхождения элемента в полную цепь
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Get(IBaseObject element, int entry)
        {
            int entranceCount = 0;
            for (int i = 0; i < this.building.Length; i++)
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
        /// Элемнет
        /// </param>
        /// <param name="from">
        /// Начальная позиция для отсчёта
        /// </param>
        /// <returns>
        /// Номер позиции или -1, если элемент после указанной позиции не встречается
        /// </returns>
        public int GetAfter(IBaseObject element, int from)
        {
            for (int i = from; i < this.Length; i++)
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
            var firstElementCount = (int)elementCounter.Calculate(this.CongenericChain(first), Link.None);
            int pairs = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = this.GetBinaryInterval(first, second, i);
                if (binaryInterval > 0)
                {
                    pairs++;
                }
            }

            return pairs;
        }

        /// <summary>
        /// Deletes element in provided position.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// Deleted element.
        /// </returns>
        public IBaseObject DeleteAt(int index)
        {
            IBaseObject element = this.alphabet[this.building[index]];
            ICalculator calc = new ElementsCount();
            CongenericChain tempCongenericChain = this.CongenericChain(element);
            if ((int)calc.Calculate(tempCongenericChain, Link.None) == 1)
            {
                var temp = this.CongenericChains;
                this.CongenericChains = new CongenericChain[temp.Length - 1];
                int j = 0;
                foreach (CongenericChain congenericChain in temp)
                {
                    if (!congenericChain.Element.Equals(element))
                    {
                        this.CongenericChains[j] = congenericChain;
                        j++;
                    }
                }

                this.alphabet.Remove(this.building[index]);
                for (int k = 0; k < this.building.Length; k++)
                {
                    if (this.building[index] < this.building[k])
                    {
                        this.building[k] = this.building[k] - 1;
                    }
                }
            }

            foreach (CongenericChain congenericChain in this.CongenericChains)
            {
                congenericChain.DeleteAt(index);
            }

            this.building = ArrayManipulator.DeleteAt(this.building, index);
            return element;
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
                tempChain.CongenericChains = (CongenericChain[])this.CongenericChains.Clone();
            }
        }

        /// <summary>
        /// Выделяет из полной неоднородной цепи все однородные цепи
        /// и сохраняет их локальнов массив <see cref="CongenericChains"/>.
        /// </summary>
        private void CreateCongenericChains()
        {
            this.CongenericChains = new CongenericChain[this.alphabet.Cardinality - 1];
            for (int i = 0; i < this.alphabet.Cardinality - 1; i++)
            {
                this.CongenericChains[i] = new CongenericChain(this.building.Length, this.alphabet[i + 1]);
            }

            for (int j = 0; j < this.building.Length; j++)
            {
                this.CongenericChains[this.building[j] - 1][j] = this.alphabet[this.building[j]];
            }
        }
    }
}