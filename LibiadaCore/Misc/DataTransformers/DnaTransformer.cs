namespace LibiadaCore.Misc.DataTransformers
{
    using System;

    using Core;
    using Core.SimpleTypes;

    /// <summary>
    /// Static class for transformation of DNA sequences
    /// into amino acid and triplet sequences and vice versa.
    /// </summary>
    public static class DnaTransformer
    {
        /// <summary>
        /// Translates DNA sequence into amino acids.
        /// </summary>
        /// <param name="inputChain">
        /// DNA sequence.
        /// </param>
        /// <returns>
        /// Amino acid sequence of type <see cref="BaseChain"/>.
        /// Elements are of <see cref="ValueString"/> type.
        /// </returns>
        public static BaseChain EncodeAmino(BaseChain inputChain)
        {
            // TODO: add translationTable param
            DnaProcessor.CheckDnaAlphabet(inputChain.Alphabet);

            throw new NotImplementedException("Old code was horrifying so it was removed");
        }

        /// <summary>
        /// Translates amino acid sequences into phantom sequences.
        /// </summary>
        /// <param name="inputChain">
        /// Amino acid sequence.
        /// </param>
        /// <returns>
        /// Phantom sequence of <see cref="BaseChain"/> type.
        /// Elements are <see cref="ValuePhantom"/>.
        /// </returns>
        public static BaseChain Decode(BaseChain inputChain)
        {
            var resultChain = new BaseChain(inputChain.GetLength());
            for (int i = 0; i < inputChain.GetLength(); i++)
            {
                string aminoAcid = inputChain[i].ToString();
                var element = new ValuePhantom();
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

                resultChain[i] = element;
            }

            return resultChain;
        }

        /// <summary>
        /// Translates dna sequence into triplet sequence.
        /// </summary>
        /// <param name="inputChain">
        /// Nucleotide sequence.
        /// </param>
        /// <returns>
        /// Triplet sequence of <see cref="BaseChain"/> type.
        /// Elements are of <see cref="ValueString"/> type.
        /// </returns>
        public static BaseChain EncodeTriplets(BaseChain inputChain)
        {
            DnaProcessor.CheckDnaAlphabet(inputChain.Alphabet);

            var resultLength = (int)Math.Floor((double)inputChain.GetLength() / 3);
            var resultChain = new BaseChain(resultLength);

            for (int i = 0; i < resultLength * 3; i += 3)
            {
                resultChain[i / 3] = new ValueString(inputChain[i].ToString() + inputChain[i + 1] + inputChain[i + 2]);
            }

            return resultChain;
        }
    }
}
