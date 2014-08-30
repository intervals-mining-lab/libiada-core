namespace LibiadaCore.Core.IntervalsManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// The relation interval manager.
    /// </summary>
    public class BinaryIntervalsManager
    {
        /// <summary>
        /// First chain element.
        /// </summary>
        public readonly IBaseObject FirstElement;

        /// <summary>
        /// Second chain element.
        /// </summary>
        public readonly IBaseObject SecondElement;

        /// <summary>
        /// The first chain.
        /// </summary>
        public readonly CongenericChain FirstChain;

        /// <summary>
        /// The second chain.
        /// </summary>
        public readonly CongenericChain SecondChain;

        /// <summary>
        /// The elements pairs count.
        /// </summary>
        public readonly int PairsCount;

        /// <summary>
        /// The chains length.
        /// </summary>
        public readonly int Length;

        /// <summary>
        /// First accordance  intervals.
        /// </summary>
        public readonly List<int> FilteredFirstIntervals = new List<int>();

        /// <summary>
        /// Second accordance intervals.
        /// </summary>
        public readonly List<int> FilteredSecondIntervals = new List<int>();

        /// <summary>
        /// First element occurrences count.
        /// </summary>
        public readonly int FirstOccurrencesCount;

        /// <summary>
        /// Second element occurrences count.
        /// </summary>
        public readonly int SecondOccurrencesCount;

        /// <summary>
        /// Relation intervals.
        /// </summary>
        private readonly int[] relationIntervals;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryIntervalsManager"/> class.
        /// </summary>
        /// <param name="firstChain">
        /// The first chain.
        /// </param>
        /// <param name="secondChain">
        /// The second chain.
        /// </param>
        public BinaryIntervalsManager(CongenericChain firstChain, CongenericChain secondChain)
        {
            this.FirstElement = firstChain.Element;
            this.SecondElement = secondChain.Element;
            this.FirstChain = firstChain;
            this.SecondChain = secondChain;
            this.Length = firstChain.GetLength();
            this.FirstOccurrencesCount = firstChain.OccurrencesCount;
            this.SecondOccurrencesCount = secondChain.OccurrencesCount;

            this.FillAccordanceIntervals();

            this.PairsCount = FillPairsCount();
            this.relationIntervals = new int[this.PairsCount];
            FillIntervals();
        }

        /// <summary>
        /// Возвращает i-ый интервал 
        /// между указанными элементами 
        /// в бинарно-однродной цепи
        /// </summary>
        /// <param name="occurrence">
        /// номер вхождения начиная с 1
        /// </param>
        /// <returns>Длина интервала</returns>
        public int GetBinaryInterval(int occurrence)
        {
            int firstElementFirstOccurrence = this.FirstChain.GetOccurrence(occurrence);
            if (firstElementFirstOccurrence == -1)
            {
                return -1;
            }

            int secondElementOccurrence = this.SecondChain.GetAfter(firstElementFirstOccurrence);

            if (secondElementOccurrence == -1)
            {
                return -1;
            }

            int firstElementSecondOccurrence = this.FirstChain.GetOccurrence(occurrence + 1);

            if (firstElementSecondOccurrence == -1)
            {
                firstElementSecondOccurrence = int.MaxValue;
            }

            if (secondElementOccurrence < firstElementSecondOccurrence)
            {
                return secondElementOccurrence - firstElementFirstOccurrence;
            }

            return -1;
        }

        /// <summary>
        /// The get first.
        /// </summary>
        /// <param name="entry">
        /// The entry.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetFirst(int entry)
        {
            return this.FirstChain.GetOccurrence(entry);
        }

        /// <summary>
        /// The get second.
        /// </summary>
        /// <param name="entry">
        /// The entry.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetSecond(int entry)
        {
            return this.SecondChain.GetOccurrence(entry);
        }

        /// <summary>
        /// Возвращает позицию первого вхождения указанного элемента 
        /// после указанной позиции.
        /// </summary>
        /// <param name="from">
        /// Начальная позиция для отсчёта.
        /// </param>
        /// <returns>
        /// Номер позиции или -1, если элемент после указанной позиции не встречается.
        /// </returns>
        public int GetAfter(int from)
        {
            for (int i = from; i < this.SecondChain.GetLength(); i++)
            {
                if (this.SecondChain[i].Equals(this.SecondChain.Element))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// The get intervals.
        /// </summary>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// </returns>
        public int[] GetIntervals()
        {
            return (int[])this.relationIntervals.Clone();
        }

        /// <summary>
        /// The fill pairs count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int FillPairsCount()
        {
            var counter = 0;

            var elementCounter = new ElementsCount();
            var firstElementCount = (int)elementCounter.Calculate(this.FirstChain, Link.None);

            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(i);
                if (binaryInterval > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// The fill intervals.
        /// </summary>
        private void FillIntervals()
        {
            int counter = 0;
            for (int i = 1; i <= this.FirstChain.OccurrencesCount; i++)
            {
                int binaryInterval = GetBinaryInterval(i);
                if (binaryInterval > 0)
                {
                    this.relationIntervals[counter++] = binaryInterval;
                }
            }

            // Start = GetAfter(1);
            
            // End = GetAfter()
        }

        /// <summary>
        /// The fill accordance intervals.
        /// </summary>
        private void FillAccordanceIntervals()
        {
            int[] firstIntervals = FirstChain.GetIntervals(Link.End);
            int[] secondIntervals = SecondChain.GetIntervals(Link.End);

            int j = 1;

            for (int i = 1; i < this.FirstOccurrencesCount - 1; i++)
            {
                int firstPosition = FirstChain.GetOccurrence(i);
                int nextFirstPosition = FirstChain.GetOccurrence(i + 1) == -1 ? this.Length : FirstChain.GetOccurrence(i + 1);
                for (; j < SecondChain.OccurrencesCount - 1; j++)
                {
                    int secondOccurrence = SecondChain.GetOccurrence(j);
                    if (secondOccurrence >= firstPosition && secondOccurrence < nextFirstPosition)
                    {
                        this.FilteredFirstIntervals.Add(firstIntervals[i - 1]);
                        this.FilteredSecondIntervals.Add(secondIntervals[j - 1]);
                        break;
                    }
                }
            }
        }
    }
}
