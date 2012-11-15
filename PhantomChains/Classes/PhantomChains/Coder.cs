using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace PhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// Статический класс, осуществляющй преобразование
    /// нуклеотидных последовательностей в аминокислотные
    /// и аминокислотных последовательностей в нуклеотидные.
    ///</summary>
    public static class Coder
    {
        ///<summary>
        /// Метод преобразующий нуклеотдитные цепи в аминокислотные.
        ///</summary>
        ///<param name="InputChain">Нуклеотидныя последовательность типа <see cref="BaseChain"/></param>
        ///<returns>Аминокислотная цепь типа <see cref="BaseChain"/>, в качестве элемнтов служат <see cref="ValueString"/></returns>
        ///<exception cref="Exception">Исключение возникает в случае наличия в нуклеотидной цепи значений отличных от A,C,T и G</exception>
        public static BaseChain Encode(BaseChain InputChain)
        {
            if(InputChain.Alphabet.Power>4)
            {
                throw new Exception();
            }
            int Count = (int) Math.Floor((double)InputChain.Length / 3);
            BaseChain OutChain = new BaseChain(Count);
            for(int i = 0; i < Count*3 ; i += 3)
            {
                String first = InputChain[i].ToString();
                String second = InputChain[i + 1].ToString();
                String third = InputChain[i + 2].ToString();
                switch(first)
                {
                    case "T":
                        switch(second)
                        {
                            case "T":
                                if((third=="T")||(third=="C"))
                                {
                                    OutChain[i / 3] = new ValueChar('F');
                                }
                                else
                                {
                                    if((third=="A")||(third=="G"))
                                    {
                                        OutChain[i / 3] = new ValueChar('L');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueChar('S');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueChar('Y');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueChar('X');
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
                                    OutChain[i / 3] = new ValueChar('C');
                                }
                                else
                                {
                                    if (third == "A")
                                    {
                                        OutChain[i / 3] = new ValueChar('X');
                                    }
                                    else
                                    {
                                        if (third == "G")
                                        {
                                            OutChain[i / 3] = new ValueChar('W');
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
                                OutChain[i / 3] = new ValueChar('L');
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueChar('P');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueChar('H');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueChar('Q');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "G":
                                OutChain[i / 3] = new ValueChar('R');
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
                                    OutChain[i / 3] = new ValueChar('I');
                                }
                                else
                                {
                                    if (third == "G")
                                    {
                                        OutChain[i / 3] = new ValueChar('M');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueChar('T');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueChar('N');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueChar('K');
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
                                    OutChain[i / 3] = new ValueChar('S');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueChar('R');
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
                                OutChain[i / 3] = new ValueChar('V');
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueChar('A');
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueChar('D');
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueChar('E');
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "G":
                                OutChain[i / 3] = new ValueChar('G');
                                break;
                            default:
                                throw new Exception();
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }
            return OutChain;
        }

        ///<summary>
        /// Метод преобразующий аминокислотные цепи в фантомные.
        ///</summary>
        ///<param name="InputChain">Аминокислотная цепь типа <see cref="BaseChain"/></param>
        ///<returns>Фантомная цепь типа <see cref="BaseChain"/>, в качестве элементов используются <see cref="ValuePhantom"/></returns>
        ///<exception cref="Exception">Исключение возникает в случае наличия в цепи элементов не являющихся аминокислотами</exception>
        public static BaseChain Decode(BaseChain InputChain)
        {
            BaseChain OutChain = new BaseChain(InputChain.Length);
            for (int i = 0; i < InputChain.Length; i++)
            {
                string str = InputChain[i].ToString();
                ValuePhantom m = new ValuePhantom();
                switch (str)
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
                OutChain[i] = m;
            }
            return OutChain;
        }

        ///<summary>
        /// Метод преобразующий нуклеотидное представление цепочек в триплетное
        ///</summary>
        ///<param name="InputChain">Исходная нуклеотидная цепочка</param>
        ///<returns>Цепоччка, состоящая из триплетов</returns>
        ///<exception cref="Exception">Допустимая мощность алфавита - 4</exception>
        public static BaseChain EncodeTriplets(BaseChain InputChain)
        {
            if(InputChain.Alphabet.Power>4)
            {
                throw new Exception();
            }
            int Count = (int) Math.Floor((double)InputChain.Length / 3);
            BaseChain OutChain = new BaseChain(Count);
            for (int i = 0; i < Count * 3; i += 3)
            {
                OutChain[i/3] = new ValueString(InputChain[i].ToString() + InputChain[i+1].ToString() + InputChain[i+2].ToString());
            }
            return OutChain;
        }
    }
}