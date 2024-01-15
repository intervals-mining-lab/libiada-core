namespace Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

/// <summary>
/// The mutual compliance degree.
/// </summary>
public class MutualComplianceDegree : IAccordanceCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="firstChain">
    /// The first chain.
    /// </param>
    /// <param name="secondChain">
    /// The second chain.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain firstChain, CongenericChain secondChain, Link link)
    {
        var partialAccordanceCalculator = new PartialComplianceDegree();
        double firstResult = partialAccordanceCalculator.Calculate(firstChain, secondChain, link);
        double secondResult = partialAccordanceCalculator.Calculate(secondChain, firstChain, link);
        return Math.Sqrt(firstResult * secondResult);
    }
}
