using System.Collections.Generic;

namespace LibiadaCore.Core.IntervalsManagers
{
    using Characteristics.Calculators;

    public class AccordanceIntervalManager : IntervalsManager
    {
        public AccordanceIntervalManager(CongenericChain firstchain, CongenericChain secondchain)
        {
            var firstChainIntervals=new List<int>();
            var secondChainIntervals = new List<int>();
            ICalculator count = new ElementsCount();
            double elementsCount = count.Calculate(firstchain, Link.None);
            for (int i = 0; i <= elementsCount; i++)
            {
                
            }

        }
    }
}
