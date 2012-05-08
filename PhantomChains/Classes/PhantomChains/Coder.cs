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
            if(InputChain.Alphabet.power>4)
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
                                    OutChain[i / 3] = new ValueString("Phe");
                                }
                                else
                                {
                                    if((third=="A")||(third=="G"))
                                    {
                                        OutChain[i / 3] = new ValueString("Leu");
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueString("Ser");
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueString("Tyr");
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueString("St");
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
                                    OutChain[i / 3] = new ValueString("Cys");
                                }
                                else
                                {
                                    if (third == "A")
                                    {
                                        OutChain[i / 3] = new ValueString("St");
                                    }
                                    else
                                    {
                                        if (third == "G")
                                        {
                                            OutChain[i / 3] = new ValueString("Trp");
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
                                OutChain[i / 3] = new ValueString("Leu");
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueString("Pro");
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueString("His");
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueString("Gln");
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "G":
                                OutChain[i / 3] = new ValueString("Arg");
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
                                    OutChain[i / 3] = new ValueString("Ile");
                                }
                                else
                                {
                                    if (third == "G")
                                    {
                                        OutChain[i / 3] = new ValueString("Met");
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueString("Thr");
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueString("Asn");
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueString("Lys");
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
                                    OutChain[i / 3] = new ValueString("Ser");
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueString("Arg");
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
                                OutChain[i / 3] = new ValueString("Val");
                                break;
                            case "C":
                                OutChain[i / 3] = new ValueString("Ala");
                                break;
                            case "A":
                                if ((third == "T") || (third == "C"))
                                {
                                    OutChain[i / 3] = new ValueString("Asp");
                                }
                                else
                                {
                                    if ((third == "A") || (third == "G"))
                                    {
                                        OutChain[i / 3] = new ValueString("Glu");
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                break;
                            case "G":
                                OutChain[i / 3] = new ValueString("Gly");
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
                    case "Phe":
                        m.Add(new ValueString("TTT"));
                        m.Add(new ValueString("TTC"));
                        break;
                    case "Leu":
                        m.Add(new ValueString("TTA"));
                        m.Add(new ValueString("TTG"));
                        m.Add(new ValueString("CTT"));
                        m.Add(new ValueString("CTC"));
                        m.Add(new ValueString("CTA"));
                        m.Add(new ValueString("CTG"));
                        break;
                    case "Ser":
                        m.Add(new ValueString("TCT"));
                        m.Add(new ValueString("TCC"));
                        m.Add(new ValueString("TCA"));
                        m.Add(new ValueString("TCG"));
                        m.Add(new ValueString("AGT"));
                        m.Add(new ValueString("AGC"));
                        break;
                    case "Tyr":
                        m.Add(new ValueString("TAT"));
                        m.Add(new ValueString("TAC"));
                        break;
                    case "St":
                        m.Add(new ValueString("TAA"));
                        m.Add(new ValueString("TAG"));
                        m.Add(new ValueString("TGA"));
                        break;
                    case "Cys":
                        m.Add(new ValueString("TGT"));
                        m.Add(new ValueString("TGC"));
                        break;
                    case "Trp":
                        m.Add(new ValueString("TGG"));
                        break;
                    case "Pro":
                        m.Add(new ValueString("CCT"));
                        m.Add(new ValueString("CCC"));
                        m.Add(new ValueString("CCA"));
                        m.Add(new ValueString("CCG"));
                        break;
                    case "His":
                        m.Add(new ValueString("CAT"));
                        m.Add(new ValueString("CAC"));
                        break;
                    case "Gln":
                        m.Add(new ValueString("CAA"));
                        m.Add(new ValueString("CAG"));
                        break;
                    case "Arg":
                        m.Add(new ValueString("CGT"));
                        m.Add(new ValueString("CGC"));
                        m.Add(new ValueString("CGA"));
                        m.Add(new ValueString("CGG"));
                        m.Add(new ValueString("AGA"));
                        m.Add(new ValueString("AGG"));
                        break;
                    case "Ile":
                        m.Add(new ValueString("ATT"));
                        m.Add(new ValueString("ATC"));
                        m.Add(new ValueString("ATA"));
                        break;
                    case "Met":
                        m.Add(new ValueString("ATG"));
                        break;
                    case "Thr":
                        m.Add(new ValueString("ACT"));
                        m.Add(new ValueString("ACC"));
                        m.Add(new ValueString("ACA"));
                        m.Add(new ValueString("ACG"));
                        break;
                    case "Asn":
                        m.Add(new ValueString("AAT"));
                        m.Add(new ValueString("AAC"));
                        break;
                    case "Lys":
                        m.Add(new ValueString("AAA"));
                        m.Add(new ValueString("AAG"));
                        break;
                    case "Val":
                        m.Add(new ValueString("GTT"));
                        m.Add(new ValueString("GTC"));
                        m.Add(new ValueString("GTA"));
                        m.Add(new ValueString("GTG"));
                        break;
                    case "Ala":
                        m.Add(new ValueString("GCT"));
                        m.Add(new ValueString("GCC"));
                        m.Add(new ValueString("GCA"));
                        m.Add(new ValueString("GCG"));
                        break;
                    case "Asp":
                        m.Add(new ValueString("GAT"));
                        m.Add(new ValueString("GAC"));
                        break;
                    case "Glu":
                        m.Add(new ValueString("GAA"));
                        m.Add(new ValueString("GAG"));
                        break;
                    case "Gly":
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
            if(InputChain.Alphabet.power>4)
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