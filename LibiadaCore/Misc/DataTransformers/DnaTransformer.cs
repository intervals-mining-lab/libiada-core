namespace LibiadaCore.Misc.DataTransformers
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Статический класс, осуществляющй преобразование
    /// нуклеотидных последовательностей в аминокислотные
    /// и аминокислотных последовательностей в нуклеотидные.
    /// </summary>
    public static class DnaTransformer
    {
        /// <summary>
        /// Метод преобразующий нуклеотдитные цепи в аминокислотные.
        /// </summary>
        /// <param name="inputChain">Нуклеотидная последовательность типа <see cref="BaseChain"/></param>
        /// <returns>Аминокислотная цепь типа <see cref="BaseChain"/>, в качестве элемнтов служат <see cref="ValueString"/></returns>
        /// <exception cref="Exception">Исключение возникает в случае наличия в нуклеотидной цепи значений отличных от A,C,T и G</exception>
        public static BaseChain Encode(BaseChain inputChain)
        {
            if (inputChain.Alphabet.Cardinality > 4)
            {
                throw new Exception();
            }

            int count = (int)Math.Floor((double)inputChain.Length / 3);
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
                                    outChain[i / 3] = new ValueChar('F');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueChar('L');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "C":
                                outChain[i / 3] = new ValueChar('S');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueChar('Y');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueChar('X');
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
                                    outChain[i / 3] = new ValueChar('C');
                                }
                                else
                                {
                                    if (third == "A")
                                    {
                                        outChain[i / 3] = new ValueChar('X');
                                    }
                                    else
                                    {
                                        if (third == "G")
                                        {
                                            outChain[i / 3] = new ValueChar('W');
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
                                outChain[i / 3] = new ValueChar('L');
                                break;
                            case "C":
                                outChain[i / 3] = new ValueChar('P');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueChar('H');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueChar('Q');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "G":
                                outChain[i / 3] = new ValueChar('R');
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
                                    outChain[i / 3] = new ValueChar('I');
                                }
                                else
                                {
                                    if (third == "G")
                                    {
                                        outChain[i / 3] = new ValueChar('M');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "C":
                                outChain[i / 3] = new ValueChar('T');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueChar('N');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueChar('K');
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
                                    outChain[i / 3] = new ValueChar('S');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueChar('R');
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
                                outChain[i / 3] = new ValueChar('V');
                                break;
                            case "C":
                                outChain[i / 3] = new ValueChar('A');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    outChain[i / 3] = new ValueChar('D');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        outChain[i / 3] = new ValueChar('E');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }

                                break;
                            case "G":
                                outChain[i / 3] = new ValueChar('G');
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
        /// Метод преобразующий аминокислотные цепи в фантомные.
        /// </summary>
        /// <param name="inputChain">Аминокислотная цепь типа <see cref="BaseChain"/></param>
        /// <returns>Фантомная цепь типа <see cref="BaseChain"/>, в качестве элементов используются <see cref="ValuePhantom"/></returns>
        /// <exception cref="Exception">Исключение возникает в случае наличия в цепи элементов не являющихся аминокислотами</exception>
        public static BaseChain Decode(BaseChain inputChain)
        {
            var outChain = new BaseChain(inputChain.Length);
            for (int i = 0; i < inputChain.Length; i++)
            {
                string aminoAcid = inputChain[i].ToString();
                var m = new ValuePhantom();
                switch (aminoAcid)
                {
                    case "F":
                        m.Add(new ValueString("TTT"));
                        m.Add(new ValueString("TTC"));
                        break;
                    case "L":
                        m.Add(new ValueString("TTA"));
                        m.Add(new ValueString("TTG"));
                        m.Add(new ValueString("CTT"));
                        m.Add(new ValueString("CTC"));
                        m.Add(new ValueString("CTA"));
                        m.Add(new ValueString("CTG"));
                        break;
                    case "S":
                        m.Add(new ValueString("TCT"));
                        m.Add(new ValueString("TCC"));
                        m.Add(new ValueString("TCA"));
                        m.Add(new ValueString("TCG"));
                        m.Add(new ValueString("AGT"));
                        m.Add(new ValueString("AGC"));
                        break;
                    case "Y":
                        m.Add(new ValueString("TAT"));
                        m.Add(new ValueString("TAC"));
                        break;
                    case "X":
                        m.Add(new ValueString("TAA"));
                        m.Add(new ValueString("TAG"));
                        m.Add(new ValueString("TGA"));
                        break;
                    case "C":
                        m.Add(new ValueString("TGT"));
                        m.Add(new ValueString("TGC"));
                        break;
                    case "W":
                        m.Add(new ValueString("TGG"));
                        break;
                    case "P":
                        m.Add(new ValueString("CCT"));
                        m.Add(new ValueString("CCC"));
                        m.Add(new ValueString("CCA"));
                        m.Add(new ValueString("CCG"));
                        break;
                    case "H":
                        m.Add(new ValueString("CAT"));
                        m.Add(new ValueString("CAC"));
                        break;
                    case "Q":
                        m.Add(new ValueString("CAA"));
                        m.Add(new ValueString("CAG"));
                        break;
                    case "R":
                        m.Add(new ValueString("CGT"));
                        m.Add(new ValueString("CGC"));
                        m.Add(new ValueString("CGA"));
                        m.Add(new ValueString("CGG"));
                        m.Add(new ValueString("AGA"));
                        m.Add(new ValueString("AGG"));
                        break;
                    case "I":
                        m.Add(new ValueString("ATT"));
                        m.Add(new ValueString("ATC"));
                        m.Add(new ValueString("ATA"));
                        break;
                    case "M":
                        m.Add(new ValueString("ATG"));
                        break;
                    case "T":
                        m.Add(new ValueString("ACT"));
                        m.Add(new ValueString("ACC"));
                        m.Add(new ValueString("ACA"));
                        m.Add(new ValueString("ACG"));
                        break;
                    case "N":
                        m.Add(new ValueString("AAT"));
                        m.Add(new ValueString("AAC"));
                        break;
                    case "K":
                        m.Add(new ValueString("AAA"));
                        m.Add(new ValueString("AAG"));
                        break;
                    case "V":
                        m.Add(new ValueString("GTT"));
                        m.Add(new ValueString("GTC"));
                        m.Add(new ValueString("GTA"));
                        m.Add(new ValueString("GTG"));
                        break;
                    case "A":
                        m.Add(new ValueString("GCT"));
                        m.Add(new ValueString("GCC"));
                        m.Add(new ValueString("GCA"));
                        m.Add(new ValueString("GCG"));
                        break;
                    case "D":
                        m.Add(new ValueString("GAT"));
                        m.Add(new ValueString("GAC"));
                        break;
                    case "E":
                        m.Add(new ValueString("GAA"));
                        m.Add(new ValueString("GAG"));
                        break;
                    case "G":
                        m.Add(new ValueString("GGT"));
                        m.Add(new ValueString("GGC"));
                        m.Add(new ValueString("GGA"));
                        m.Add(new ValueString("GGG"));
                        break;
                    default:
                        throw new Exception();
                }

                outChain[i] = m;
            }

            return outChain;
        }

        /// <summary>
        /// Метод преобразующий нуклеотидное представление цепочек в триплетное
        /// </summary>
        /// <param name="inputChain">Исходная нуклеотидная цепочка</param>
        /// <returns>Цепоччка, состоящая из триплетов</returns>
        /// <exception cref="Exception">Допустимая мощность алфавита - не больше 4</exception>
        public static BaseChain EncodeTriplets(BaseChain inputChain)
        {
            if (inputChain.Alphabet.Cardinality > 4)
            {
                throw new Exception("Alphabet cardinality must be 4 or less elements");
            }

            var resultLength = (int)Math.Floor((double)inputChain.Length / 3);
            var outChain = new BaseChain(resultLength);

            for (int i = 0; i < resultLength * 3; i += 3)
            {
                outChain[i / 3] = new ValueString(inputChain[i].ToString() + inputChain[i + 1] + inputChain[i + 2]);
            }

            return outChain;
        }
    }
}