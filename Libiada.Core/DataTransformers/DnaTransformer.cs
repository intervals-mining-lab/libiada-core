namespace Libiada.Core.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Iterators;

using System.Collections.ObjectModel;

using static DnaCodingTables;

/// <summary>
/// Static class for transformation of DNA sequences
/// into amino acid and triplet sequences and vice versa.
/// </summary>
public static class DnaTransformer
{
    /// <summary>
    /// Translates DNA sequence into amino-acids.
    /// </summary>
    /// <param name="inputSequence">
    /// DNA sequence.
    /// </param>
    /// <param name="translationTable">
    /// Number of the codon to amino-acid translation table.
    /// 1 by default.
    /// </param>
    /// <returns>
    /// Amino-acid sequence of type <see cref="Sequence"/>.
    /// Elements are of <see cref="ValueString"/> type.
    /// </returns>
    public static Sequence EncodeAmino(Sequence inputSequence, byte translationTable = 1)
    {
        if (!codingTables.ContainsKey(translationTable))
        {
            throw new ArgumentException($"Translation table number is not supported, but was {translationTable}", nameof(translationTable));
        }

        DnaProcessor.CheckDnaAlphabet(inputSequence.Alphabet);

        ReadOnlyDictionary<string, IBaseObject> aminoMap = codingTables[translationTable];

        List<IBaseObject> result = new(inputSequence.Length / 3);
        List<string> codons = DiffCutter.Cut(inputSequence.ToString(), new SimpleCutRule(inputSequence.Length, 3, 3));

        for (int i = 0; i < codons.Count; i++)
        {
            IBaseObject aminoAcid = aminoMap[codons[i]];

            if (aminoAcid is ValuePhantom phantom && phantom.Count(p => !p.Equals((ValueString)"*")) != 1)
            {
                throw new Exception($"Ambiguous amino code:{aminoAcid}");
            }

            if (i != codons.Count - 1)
            {
                if (((ValueString)"*").Equals(aminoAcid)) throw new Exception("Unexpected stop-codon inside coding sequence");

                ValueString value = aminoAcid as ValueString ?? (ValueString)(aminoAcid as ValuePhantom).Single(p => !p.Equals((ValueString)"*"));
                result.Add(value);
            }
            else if (aminoAcid.Equals((ValueString)"*")) return new Sequence(result);
            else throw new Exception("No stop-codon at the end of coding sequence");
        }

        throw new Exception("Unreachable code is reached");
    }

    /// <summary>
    /// Translates amino acid sequences into phantom sequences.
    /// </summary>
    /// <param name="inputSequence">
    /// Amino acid sequence.
    /// </param>
    /// <returns>
    /// Phantom sequence of <see cref="Sequence"/> type.
    /// Elements are <see cref="ValuePhantom"/>.
    /// </returns>
    public static Sequence Decode(Sequence inputSequence)
    {
        // TODO: add coding table param
        List<IBaseObject> result = [];
        for (int i = 0; i < inputSequence.Length; i++)
        {
            string aminoAcid = inputSequence[i].ToString();
            ValuePhantom element = [];
            switch (aminoAcid)
            {
                case "F":
                    element.Add(new ValueString("TTT"));
                    element.Add(new ValueString("TTC"));
                    break;
                case "L":
                    element.Add(new ValueString("TTA"));
                    element.Add(new ValueString("TTG"));
                    element.Add(new ValueString("CTT"));
                    element.Add(new ValueString("CTC"));
                    element.Add(new ValueString("CTA"));
                    element.Add(new ValueString("CTG"));
                    break;
                case "S":
                    element.Add(new ValueString("TCT"));
                    element.Add(new ValueString("TCC"));
                    element.Add(new ValueString("TCA"));
                    element.Add(new ValueString("TCG"));
                    element.Add(new ValueString("AGT"));
                    element.Add(new ValueString("AGC"));
                    break;
                case "Y":
                    element.Add(new ValueString("TAT"));
                    element.Add(new ValueString("TAC"));
                    break;
                case "X":
                    element.Add(new ValueString("TAA"));
                    element.Add(new ValueString("TAG"));
                    element.Add(new ValueString("TGA"));
                    break;
                case "C":
                    element.Add(new ValueString("TGT"));
                    element.Add(new ValueString("TGC"));
                    break;
                case "W":
                    element.Add(new ValueString("TGG"));
                    break;
                case "P":
                    element.Add(new ValueString("CCT"));
                    element.Add(new ValueString("CCC"));
                    element.Add(new ValueString("CCA"));
                    element.Add(new ValueString("CCG"));
                    break;
                case "H":
                    element.Add(new ValueString("CAT"));
                    element.Add(new ValueString("CAC"));
                    break;
                case "Q":
                    element.Add(new ValueString("CAA"));
                    element.Add(new ValueString("CAG"));
                    break;
                case "R":
                    element.Add(new ValueString("CGT"));
                    element.Add(new ValueString("CGC"));
                    element.Add(new ValueString("CGA"));
                    element.Add(new ValueString("CGG"));
                    element.Add(new ValueString("AGA"));
                    element.Add(new ValueString("AGG"));
                    break;
                case "I":
                    element.Add(new ValueString("ATT"));
                    element.Add(new ValueString("ATC"));
                    element.Add(new ValueString("ATA"));
                    break;
                case "M":
                    element.Add(new ValueString("ATG"));
                    break;
                case "T":
                    element.Add(new ValueString("ACT"));
                    element.Add(new ValueString("ACC"));
                    element.Add(new ValueString("ACA"));
                    element.Add(new ValueString("ACG"));
                    break;
                case "N":
                    element.Add(new ValueString("AAT"));
                    element.Add(new ValueString("AAC"));
                    break;
                case "K":
                    element.Add(new ValueString("AAA"));
                    element.Add(new ValueString("AAG"));
                    break;
                case "V":
                    element.Add(new ValueString("GTT"));
                    element.Add(new ValueString("GTC"));
                    element.Add(new ValueString("GTA"));
                    element.Add(new ValueString("GTG"));
                    break;
                case "A":
                    element.Add(new ValueString("GCT"));
                    element.Add(new ValueString("GCC"));
                    element.Add(new ValueString("GCA"));
                    element.Add(new ValueString("GCG"));
                    break;
                case "D":
                    element.Add(new ValueString("GAT"));
                    element.Add(new ValueString("GAC"));
                    break;
                case "E":
                    element.Add(new ValueString("GAA"));
                    element.Add(new ValueString("GAG"));
                    break;
                case "G":
                    element.Add(new ValueString("GGT"));
                    element.Add(new ValueString("GGC"));
                    element.Add(new ValueString("GGA"));
                    element.Add(new ValueString("GGG"));
                    break;
                default:
                    throw new InvalidOperationException($"Unknown amino acid {aminoAcid}");
            }

            result.Add(element);
        }

        return new Sequence(result);
    }

    /// <summary>
    /// Translates dna sequence into triplet sequence.
    /// </summary>
    /// <param name="inputSequence">
    /// Nucleotide sequence.
    /// </param>
    /// <returns>
    /// Triplet sequence of <see cref="Sequence"/> type.
    /// Elements are of <see cref="ValueString"/> type.
    /// </returns>
    public static Sequence EncodeTriplets(Sequence inputSequence)
    {
        DnaProcessor.CheckDnaAlphabet(inputSequence.Alphabet);
        List<IBaseObject> result = [];
        List<string> codons = DiffCutter.Cut(inputSequence.ToString(), new SimpleCutRule(inputSequence.Length, 3, 3));

        foreach (string codon in codons)
        {
            result.Add((ValueString)codon);
        }

        return new Sequence(result);
    }
}
