using System.Collections.Generic;

namespace MarkovCompare
{
    public interface IOnePicksCalculator
    {
        double Calculate(List<double> values);
    }
}