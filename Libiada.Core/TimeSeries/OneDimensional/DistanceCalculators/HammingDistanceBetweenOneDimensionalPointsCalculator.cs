namespace Libiada.Core.TimeSeries.OneDimensional.DistanceCalculators;

using System.Globalization;

/// <summary>
/// The hamming distance between one dimensional points calculator.
/// </summary>
public class HammingDistanceBetweenOneDimensionalPointsCalculator : IOneDimensionalPointsDistance
{
    /// <summary>
    /// The get distance.
    /// </summary>
    /// <param name="firstPoint">
    /// The first point.
    /// </param>
    /// <param name="secondPoint">
    /// The second point.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double GetDistance(double firstPoint, double secondPoint)
    {
        string[] firstPointStringArray = firstPoint.ToString("0.00000000000000", CultureInfo.InvariantCulture).Split('.');
        string[] secondPointStringArray = secondPoint.ToString("0.00000000000000", CultureInfo.InvariantCulture).Split('.');

        string intPartFirst = firstPointStringArray[0];
        string intPartSecond = secondPointStringArray[0];


        while (intPartSecond.Length != intPartFirst.Length)
        {
            if (intPartFirst.Length > intPartSecond.Length)
            {
                intPartSecond = $"0{intPartSecond}";
            }
            else
            {
                intPartFirst = $"0{intPartFirst}";
            }
        }

        int distance = 0;

        for (int i = 0; i < intPartFirst.Length; i++)
        {
            if (intPartFirst[i] != intPartSecond[i])
            {
                distance++;
            }
        }

        string fracPartFirst = firstPointStringArray[1];
        string fracPartSecond = secondPointStringArray[1];

        for (int i = 0; i < fracPartFirst.Length; i++)
        {
            if (fracPartFirst[i] != fracPartSecond[i])
            {
                distance++;
            }
        }

        return distance;
    }
}
