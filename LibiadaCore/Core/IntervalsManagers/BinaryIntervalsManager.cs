namespace LibiadaCore.Core.IntervalsManagers
{
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// The relation interval manager.
    /// </summary>
    public class BinaryIntervalsManager
    {
        private int[] intervals;

        public readonly IBaseObject firstElement;

        public readonly IBaseObject secondElement;

        public CongenericChain firstChain;

        public CongenericChain secondChain;

        public readonly int pairsCount;

        public readonly int Length;

        public List<int> filteredFirstIntervals = new List<int>();
        public List<int> filteredSecondIntervals = new List<int>();

        public readonly int firstOccurrencesCount;

        public readonly int secondOccurrencesCount;

        public BinaryIntervalsManager(CongenericChain firstChain, CongenericChain secondChain)
        {
            this.firstElement = firstChain.Element;
            this.secondElement = secondChain.Element;
            this.firstChain = firstChain;
            this.secondChain = secondChain;
            this.Length = firstChain.GetLength();

            this.firstOccurrencesCount = firstChain.OccurrencesCount;
            this.secondOccurrencesCount = secondChain.OccurrencesCount;

            int[] firstIntervals = firstChain.GetIntervals(Link.End);
            int[] secondIntervals = secondChain.GetIntervals(Link.End);

            int j = 1;

            for (int i = 1; i < firstChain.OccurrencesCount - 1; i++)
            {
                int firstPosition = firstChain.GetOccurrence(i);
                int nextFirstPosition = firstChain.GetOccurrence(i + 1) == -1 ? firstChain.GetLength() : firstChain.GetOccurrence(i + 1);
                for (; j < secondChain.OccurrencesCount - 1; j++)
                {
                    int secondOccurrence = secondChain.GetOccurrence(j);
                    if (secondOccurrence >= firstPosition && secondOccurrence < nextFirstPosition)
                    {
                        filteredFirstIntervals.Add(firstIntervals[i - 1]);
                        filteredSecondIntervals.Add(secondIntervals[j - 1]);
                        break;
                    }
                }
            }

            pairsCount = FillPairsCount();
            intervals = new int[pairsCount];
            FillIntervals();
        }

        private int FillPairsCount()
        {
            var counter = 0;

            var elementCounter = new ElementsCount();
            var firstElementCount = (int)elementCounter.Calculate(firstChain, Link.None);

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
            int firstElementFirstOccurrence = firstChain.GetOccurrence(occurrence);
            if (firstElementFirstOccurrence == -1)
            {
                return -1;
            }

            int secondElementOccurrence = secondChain.GetAfter(firstElementFirstOccurrence);

            if (secondElementOccurrence == -1)
            {
                return -1;
            }

            int firstElementSecondOccurrence = firstChain.GetOccurrence(occurrence + 1);

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

        public int GetFirst(int entry)
        {
            return firstChain.GetOccurrence(entry);
        }

        public int GetSecond(int entry)
        {
            return secondChain.GetOccurrence(entry);
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
            for (int i = from; i < secondChain.GetLength(); i++)
            {
                if (secondChain[i].Equals(secondChain.Element))
                {
                    return i;
                }
            }

            return -1;
        }

        public int[] GetIntervals()
        {
            return (int[])intervals.Clone();
        }

        private void FillIntervals()
        {
            int counter = 0;
            for (int i = 1; i <= firstChain.OccurrencesCount; i++)
            {
                int binaryInterval = GetBinaryInterval(i);
                if (binaryInterval > 0)
                {
                    intervals[counter++] = binaryInterval;
                }
            }

            // Start = GetAfter(1);
            
            // End = GetAfter()
        }
    }
}
