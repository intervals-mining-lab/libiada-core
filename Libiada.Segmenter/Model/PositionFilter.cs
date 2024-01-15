namespace Libiada.Segmenter.Model;

/// <summary>
/// Cleaning all cross words in the sequence
/// </summary>
public class PositionFilter
{
    /// <summary>
    /// Returns non cross word's positions
    /// </summary>
    /// <param name="std">positions of words</param>
    /// <param name="winLen">length of the scanning window</param>
    /// <returns>non cross word's positions</returns>
    public static List<int> Filtrate(List<int> std, int winLen)
    {
        if (std.Count == 0)
        {
            return new List<int>();
        }

        int pos = 1;
        int pred = std[0];

        while (std.Count > pos)
        {
            if ((std[pos] - pred) < winLen)
            {
                std.Remove(pos);
            }
            else
            {
                pred = std[pos];
            }

            pos++;
        }

        return std;
    }
}
