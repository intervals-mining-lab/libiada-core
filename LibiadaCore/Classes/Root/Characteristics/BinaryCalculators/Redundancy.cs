namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    using System;

    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    /// <summary>
    /// Redundancy of binary chain.
    /// </summary>
    public class Redundancy : BinaryCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="firstElement">
        /// Первый элемент
        /// </param>
        /// <param name="secondElement">
        /// Второй элемент
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of redundancy.
        /// </returns>
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            var count = new Count();
            CongenericChain firstElementChain = chain.CongenericChain(firstElement);
            int firstElementCount = (int)count.Calculate(firstElementChain, link);
            double avG = 0;
            int currentEntrance = 0;
            
            for (int i = 1; i <= firstElementCount; i++)
            {
                if (chain.GetBinaryInterval(firstElement, secondElement, i) > 0)
                {
                    if (currentEntrance == 0)
                    {
                        currentEntrance = chain.GetAfter(secondElement, chain.Get(firstElement, i));
                        if (link == Link.Start || link == Link.Both)
                        {
                            avG += Math.Log(currentEntrance, 2);
                        }
                    }
                    else
                    {
                        int nextEntrance = chain.GetAfter(secondElement, chain.Get(firstElement, i));
                        avG += Math.Log(nextEntrance - currentEntrance, 2);
                        currentEntrance = nextEntrance;
                    }
                }
            }
            if (link == Link.End || link == Link.Both)
            {
                avG += Math.Log(chain.Length - currentEntrance, 2);
            }
            
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            avG = pairs == 0 ? 0 : avG / pairs;
            var geometricMeanCalculator = new BinaryGeometricMean();
            double binaryGeometricMean = geometricMeanCalculator.Calculate(chain, firstElement, secondElement, link);
            return 1 - (binaryGeometricMean / Math.Pow(2, avG));
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.Redundancy;
        }
    }
}