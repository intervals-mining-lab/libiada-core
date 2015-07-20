using System;

namespace LibiadaCore.Core.Characteristics.Calculators
{
    public class MutualComplianceDegree : IAccordanceCalculator
    {
        public double Calculate(CongenericChain firstChain, CongenericChain secondChain, Link link)
        {
            var partialAccordanceCalculator = new PartialComplianceDegree();
            var firstResult = partialAccordanceCalculator.Calculate(firstChain, secondChain, link);
            var secondResult = partialAccordanceCalculator.Calculate(secondChain, firstChain, link);
            return Math.Sqrt(firstResult * secondResult);
        }
    }
}