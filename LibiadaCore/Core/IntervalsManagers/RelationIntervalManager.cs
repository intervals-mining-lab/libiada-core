namespace LibiadaCore.Core.IntervalsManagers
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Remoting.Channels;

    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// The relation interval manager.
    /// </summary>
    public class RelationIntervalManager : IntervalsManager
    {
        private int[] building;
        private Chain sourceChain;
        //private int firstElement;
        //private int secondElement;

        private CongenericChain firstChain;

        private CongenericChain secondChain;

        public RelationIntervalManager(Chain chain, IBaseObject firstElement, IBaseObject secondElement)
        {
            building = chain.Building;
            sourceChain = chain;
           // this.firstElement = sourceChain.Alphabet.IndexOf(firstElement);
           // this.secondElement = sourceChain.Alphabet.IndexOf(secondElement);
            firstChain = sourceChain.CongenericChain(firstElement);
            secondChain = sourceChain.CongenericChain(secondElement);
           /* if (sourceChain.Alphabet.Cardinality < firstElement || sourceChain.Alphabet.Cardinality < secondElement)
            {
                throw new ArgumentException("Elements indexes are out of range.");
            }*/

            int count = GetPairsCount();
          //  intervals = new int[count - 1];
          //  FillIntervals();
        }

        public int GetPairsCount()
        {
            var elementCounter = new ElementsCount();
            var firstElementCount = (int)elementCounter.Calculate(firstChain, Link.None);
            int pairs = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(i);
                if (binaryInterval > 0)
                {
                    pairs++;
                }
            }

            return pairs;
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

        public int Get(IBaseObject element, int entry)
        {
            return sourceChain.Get(element, entry);
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
            for (int i = from; i < sourceChain.GetLength(); i++)
            {
                if (sourceChain[i].Equals(secondChain.Element))
                {
                    return i;
                }
            }

            return -1;
        }

        private void FillIntervals()
        {
            int counter = 0;
            for (int i = 1; i <= firstChain.OccurrencesCount; i++)
            {
                int binaryInterval = GetBinaryInterval(i);
                if (binaryInterval > 0)
                {
                    building[counter++] = binaryInterval;
                }
            }

            // Start = GetAfter(1);
            
            // End = GetAfter()
        }
    }
}
