namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// The AccordanceCalculator interface.
    /// </summary>
    public interface IAccordanceCalculator
    {
        double Calculate(CongenericChain firstChain, CongenericChain secondChain, Link link);
    }
}
