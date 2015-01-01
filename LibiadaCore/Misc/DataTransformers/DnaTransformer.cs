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
        public static BaseChain Encode(BaseChain inputChain)
        {
            DnaProcessing.CheckDnaAlphabet(inputChain.Alphabet);

            var count = (int)Math.Floor((double)inputChain.GetLength() / 3);
            var outChain = new BaseChain(count);
            for (int i = 0; i < count * 3; i += 3)
            {
                string first = inputChain[i].ToString();
                string second = inputChain[i + 1].ToString();
                string third = inputChain[i + 2].ToString();
                switch (first)
                {
                    case "T":
                        switch (second)
                        {
                            case "T":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueString('F');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueString('L');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "C":
                                outChain[i / 3] = new ValueString('S');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueString('Y');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueString('X');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "G":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueString('C');
                                }
                                else
                                {
                                    if (third == "A")
                                    {
                                        outChain[i / 3] = new ValueString('X');
                                    }
                                    else
                                    {
                                        if (third == "G")
                                        {
                                            outChain[i / 3] = new ValueString('W');
                                        }
                                        else
                                        {
                                            throw new Exception();
                                        }
                                    }
                                }

                                break;
                            default:
                                throw new Exception();
                        }

                        break;
                    case "C":
                        switch (second)
                        {
                            case "T":
                                outChain[i / 3] = new ValueString('L');
                                break;
                            case "C":
                                outChain[i / 3] = new ValueString('P');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueString('H');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueString('Q');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "G":
                                outChain[i / 3] = new ValueString('R');
                                break;
                            default:
                                throw new Exception();
                        }

                        break;
                    case "A":
                        switch (second)
                        {
                            case "T":
                                if ((third == "T") || (third == "C") || (third == "A"))
                                {
                                    outChain[i / 3] = new ValueString('I');
                                }
                                else
                                {
                                    if (third == "G")
                                    {
                                        outChain[i / 3] = new ValueString('M');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "C":
                                outChain[i / 3] = new ValueString('T');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueString('N');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueString('K');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "G":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueString('S');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueString('R');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            default:
                                throw new Exception();
                        }

                        break;
                    case "G":
                        switch (second)
                        {
                            case "T":
                                outChain[i / 3] = new ValueString('V');
                                break;
                            case "C":
                                outChain[i / 3] = new ValueString('A');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueString('D');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueString('E');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "G":
                                outChain[i / 3] = new ValueString('G');
                                break;
                            default:
                                throw new Exception();
                        }

                        break;
                    default:
                        throw new Exception();
                }
            }

            return outChain;
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
                        throw new ArgumentException("Unknown amino acid");
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
            DnaProcessing.CheckDnaAlphabet(inputChain.Alphabet);

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
