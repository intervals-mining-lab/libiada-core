﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibiadaCore.Classes.Misc;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.IntervalsManagers
{
    public class RelationIntervalManager : IntervalsManager
    {
        private int[] building;
        private Chain sourceChain;
        private int firstElement;
        private int secondElement;
        public RelationIntervalManager(Chain chain, int firstElement, int secondElement)
        {
            building = chain.Building;
            sourceChain = chain;
            this.firstElement = firstElement;
            this.secondElement = secondElement;
            if (sourceChain.Alphabet.Cardinality <= firstElement || sourceChain.Alphabet.Cardinality <= secondElement)
            {
                throw new ArgumentException("Elements indexes are out of range.");
            }
            int count = GetPairsCount(firstElement, secondElement);
            Intervals = new int[count - 1];
            FillIntervals();
        }

        private int GetPairsCount(int first, int second)
        {
            var elementCounter = new ElementsCount();
            var firstElementCount = (int)elementCounter.Calculate(sourceChain.CongenericChain(first), Link.None);
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

        private int GetBinaryInterval(int first, int second, int entry)
        {
            int firstEntry = Get(first, entry);
            if (firstEntry == -1)
            {
                return -1;
            }

            for (int i = firstEntry + 1; i < sourceChain.Length; i++)
            {
                if (first.Equals(building[i]))
                {
                    return -1;
                }

                if (second.Equals(building[i]))
                {
                    return i - firstEntry;
                }
            }

            return -1;
        }

        private int Get(int element, int entry)
        {
            int entranceCount = 0;
            for (int i = 0; i < building.Length; i++)
            {
                if (building[i].Equals(element))
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
            for (int i = 1; i <= firstElement; i++)
            {
                int binaryInterval = GetBinaryInterval(firstElement, secondElement, i);
                if (binaryInterval > 0)
                {
                    building[counter++] = binaryInterval;
                }
            }
        }

    }
}