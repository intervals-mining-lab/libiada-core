namespace LibiadaCore.Core.IntervalsManagers
{
    using Characteristics.Calculators;

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
            FirstElement = firstChain.Element;
            SecondElement = secondChain.Element;
            FirstChain = firstChain;
            SecondChain = secondChain;
            Length = firstChain.GetLength();

            PairsCount = FillPairsCount();
            relationIntervals = new int[PairsCount];
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
            int firstElementFirstOccurrence = FirstChain.GetOccurrence(occurrence);
            if (firstElementFirstOccurrence == -1)
            {
                return -1;
            }

            int secondElementOccurrence = SecondChain.GetFirstAfter(firstElementFirstOccurrence);

            if (secondElementOccurrence == -1)
            {
                return -1;
            }

            int firstElementSecondOccurrence = FirstChain.GetOccurrence(occurrence + 1);

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
            return FirstChain.GetOccurrence(entry);
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
            for (int i = from; i < SecondChain.GetLength(); i++)
            {
                if (SecondChain[i].Equals(SecondChain.Element))
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
        /// The <see cref="T:int[]"/>.
        /// </returns>
        public int[] GetIntervals()
        {
            return (int[])relationIntervals.Clone();
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
            var firstElementCount = (int)elementCounter.Calculate(FirstChain, Link.None);

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
            for (int i = 1; i <= FirstChain.OccurrencesCount; i++)
            {
                int binaryInterval = GetBinaryInterval(i);
                if (binaryInterval > 0)
                {
                    relationIntervals[counter++] = binaryInterval;
                }
            }

            // Start = GetAfter(1);
            
            // End = GetAfter()
        }
    }
}
