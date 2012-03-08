using System.Collections.Generic;

namespace BuildingsIterator.Classes.Statistics.Calculators
{
    public interface IOnePicksCalculator
    {
        double Calculate(List<double> values);
    }
}