namespace Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The duration type.
/// </summary>
public static class DurationType
{
    /// <summary>
    /// The parse type.
    /// </summary>
    /// <param name="type">
    /// The type.
    /// </param>
    /// <returns>
    /// The <see cref="T:int[]"/>.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown if type is unknown.
    /// </exception>
    public static (int, int) ParseType(string type)
    {
        int numerator;
        int denominator;
        switch (type)
        {
            case "whole":
                numerator = 1;
                denominator = 1;
                break;
            case "half":
                numerator = 1;
                denominator = 2;
                break;
            case "quarter":
                numerator = 1;
                denominator = 4;
                break;
            case "eighth":
                numerator = 1;
                denominator = 8;
                break;
            case "16th":
                numerator = 1;
                denominator = 16;
                break;
            case "32nd": 
            case "32th": // in Guitar Pro marked as 32th
                numerator = 1;
                denominator = 32;
                break;
            case "64th":
                numerator = 1;
                denominator = 64;
                break;
            case "128th":
                numerator = 1;
                denominator = 128;
                break;
            case "256th":
                numerator = 1;
                denominator = 256;
                break;
            default:
                throw new InvalidOperationException($"Unknown duration type {type}");
        }

        return (numerator, denominator);
    }
}
