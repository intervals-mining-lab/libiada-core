namespace LibiadaCore.DataTransformers
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

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

            var completeAlphabet = new Alphabet
            {
                new ValueString("A"),
                new ValueString("C"),
                new ValueString("T"),
                new ValueString("G")
            };

            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                if (!completeAlphabet.Contains(alphabet[i]))
                {
                    throw new Exception("Alphabet contains at least 1 wrong element: " + alphabet[i]);
                }
            }
        }
    }
}
