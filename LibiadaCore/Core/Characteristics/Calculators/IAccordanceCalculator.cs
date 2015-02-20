using LibiadaCore.Core.IntervalsManagers;

namespace LibiadaCore.Core.Characteristics.Calculators
{
    public interface IAccordanceCalculator
    {
        double Calculate(AccordanceIntervalsManager manager, Link link);
    }
}