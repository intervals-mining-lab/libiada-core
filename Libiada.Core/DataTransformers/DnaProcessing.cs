namespace Libiada.Core.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Class for various actions with dna sequences.
/// </summary>
public static class DnaProcessor
{
    /// <summary>
    /// Checks if alphabet is appropriate for dna sequence,
    /// e.g. contains only nucleotide elements.
    /// </summary>
    /// <param name="alphabet">
    /// Alphabet to check.
    /// </param>
    public static void CheckDnaAlphabet(Alphabet alphabet)
    {
        if (alphabet.Cardinality > 4)
        {
            throw new Exception("DNA alphabet cardinality must be 4 or less");
        }

        Alphabet completeAlphabet =
        [
            new ValueString("A"),
            new ValueString("C"),
            new ValueString("T"),
            new ValueString("G")
        ];

        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            if (!completeAlphabet.Contains(alphabet[i]))
            {
                throw new Exception($"Alphabet contains at least 1 wrong element: {alphabet[i]}.");
            }
        }
    }
}
