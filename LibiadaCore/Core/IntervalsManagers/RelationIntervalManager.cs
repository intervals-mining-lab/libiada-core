namespace LibiadaCore.Core.IntervalsManagers
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

    public class RelationIntervalManager : IntervalsManager
    {
        private int[] building;
        private Chain sourceChain;
        private int firstElement;
        private int secondElement;
        public RelationIntervalManager(Chain chain, int firstElement, int secondElement)
        {
            this.building = chain.Building;
            this.sourceChain = chain;
            this.firstElement = firstElement;
            this.secondElement = secondElement;
            if (this.sourceChain.Alphabet.Cardinality <= firstElement || this.sourceChain.Alphabet.Cardinality <= secondElement)
            {
                throw new ArgumentException("Elements indexes are out of range.");
            }
            int count = this.GetPairsCount(firstElement, secondElement);
            this.intervals = new int[count - 1];
            this.FillIntervals();
        }

        private int GetPairsCount(int first, int second)
        {
            var elementCounter = new ElementsCount();
            var firstElementCount = (int)elementCounter.Calculate(this.sourceChain.CongenericChain(first), Link.None);
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

        private int GetBinaryInterval(int first, int second, int entry)
        {
            int firstEntry = this.Get(first, entry);
            if (firstEntry == -1)
            {
                return -1;
            }

            for (int i = firstEntry + 1; i < this.sourceChain.GetLength(); i++)
            {
                if (first.Equals(this.building[i]))
                {
                    return -1;
                }

                if (second.Equals(this.building[i]))
                {
                    return i - firstEntry;
                }
            }

            return -1;
        }

        private int Get(int element, int entry)
        {
            int entranceCount = 0;
            for (int i = 0; i < this.building.Length; i++)
            {
                if (this.building[i].Equals(element))
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

        private void FillIntervals()
        {
            int counter = 0;
            for (int i = 1; i <= this.firstElement; i++)
            {
                int binaryInterval = this.GetBinaryInterval(this.firstElement, this.secondElement, i);
                if (binaryInterval > 0)
                {
                    this.building[counter++] = binaryInterval;
                }
            }
            this.Start = this.GetAfter(this.secondElement, this.Get(this.firstElement, 1));
            //End = GetAfter()
        }

        private int GetAfter(int element, int from)
        {
            for (int i = from; i < this.sourceChain.GetLength(); i++)
            {
                if (this.sourceChain[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

    }
}
