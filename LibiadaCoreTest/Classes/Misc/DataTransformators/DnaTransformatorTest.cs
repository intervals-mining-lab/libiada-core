﻿using LibiadaCore.Classes.Misc.DataTransformators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.DataTransformators
{
    [TestFixture]
    public class DnaTransformatorTest
    {
        [Test]
        public void SimpleEncodeTest()
        {
            string str;
            str = "TTT";
            BaseChain input = new BaseChain(3);
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = new ValueChar(str[i]);
            }
            BaseChain Out = DnaTransformator.Encode(input);
            Assert.AreEqual("F", Out[0].ToString());
        }

        [Test]
        public void EncodeTest()
        {
            string str;
            str = "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGG";
            BaseChain input = new BaseChain(64 * 3);
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = new ValueChar(str[i]);
            }
            BaseChain Out = DnaTransformator.Encode(input);
            string temp = "FFLLSSSSYYXXCCXWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG";
            for (int i = 0; i < temp.Length; i++)
            {
                Assert.AreEqual(temp[i].ToString(), Out[i].ToString());
            }
        }

        [Test]
        public void SimpleDecodeTest()
        {
            BaseChain input = new BaseChain(1);
            input[0] = new ValueString("F");
            BaseChain Out = DnaTransformator.Decode(input);
            ValuePhantom mes = new ValuePhantom {new ValueString("TTT"), new ValueString("TTC")};
            Assert.IsTrue(mes.Equals(Out[0]));
        }

        [Test]
        public void DecodeTest()
        {
            BaseChain input = new BaseChain(21);
            string temp = "FLSYXCWPHQRIMTNKVADEG";
            for (int i = 0; i < temp.Length; i++)
            {
                input[i] = new ValueString(temp[i].ToString());
            }
            ValuePhantom m0 = new ValuePhantom {new ValueString("TTT"), new ValueString("TTC")};
            ValuePhantom m1 = new ValuePhantom
                {
                    new ValueString("TTA"),
                    new ValueString("TTG"),
                    new ValueString("CTT"),
                    new ValueString("CTC"),
                    new ValueString("CTA"),
                    new ValueString("CTG")
                };
            ValuePhantom m2 = new ValuePhantom
                {
                    new ValueString("TCT"),
                    new ValueString("TCC"),
                    new ValueString("TCA"),
                    new ValueString("TCG"),
                    new ValueString("AGT"),
                    new ValueString("AGC")
                };
            ValuePhantom m3 = new ValuePhantom {new ValueString("TAT"), new ValueString("TAC")};
            ValuePhantom m4 = new ValuePhantom {new ValueString("TAA"), new ValueString("TAG"), new ValueString("TGA")};
            ValuePhantom m5 = new ValuePhantom {new ValueString("TGT"), new ValueString("TGC")};
            ValuePhantom m6 = new ValuePhantom {new ValueString("TGG")};
            ValuePhantom m7 = new ValuePhantom
                {
                    new ValueString("CCT"),
                    new ValueString("CCC"),
                    new ValueString("CCA"),
                    new ValueString("CCG")
                };
            ValuePhantom m8 = new ValuePhantom {new ValueString("CAT"), new ValueString("CAC")};
            ValuePhantom m9 = new ValuePhantom {new ValueString("CAA"), new ValueString("CAG")};
            ValuePhantom m10 = new ValuePhantom
                {
                    new ValueString("CGT"),
                    new ValueString("CGC"),
                    new ValueString("CGA"),
                    new ValueString("CGG"),
                    new ValueString("AGA"),
                    new ValueString("AGG")
                };
            ValuePhantom m11 = new ValuePhantom {new ValueString("ATT"), new ValueString("ATC"), new ValueString("ATA")};
            ValuePhantom m12 = new ValuePhantom {new ValueString("ATG")};
            ValuePhantom m13 = new ValuePhantom
                {
                    new ValueString("ACT"),
                    new ValueString("ACC"),
                    new ValueString("ACA"),
                    new ValueString("ACG")
                };
            ValuePhantom m14 = new ValuePhantom {new ValueString("AAT"), new ValueString("AAC")};
            ValuePhantom m15 = new ValuePhantom {new ValueString("AAA"), new ValueString("AAG")};
            ValuePhantom m16 = new ValuePhantom
                {
                    new ValueString("GTT"),
                    new ValueString("GTC"),
                    new ValueString("GTA"),
                    new ValueString("GTG")
                };
            ValuePhantom m17 = new ValuePhantom
                {
                    new ValueString("GCT"),
                    new ValueString("GCC"),
                    new ValueString("GCA"),
                    new ValueString("GCG")
                };
            ValuePhantom m18 = new ValuePhantom {new ValueString("GAT"), new ValueString("GAC")};
            ValuePhantom m19 = new ValuePhantom {new ValueString("GAA"), new ValueString("GAG")};
            ValuePhantom m20 = new ValuePhantom
                {
                    new ValueString("GGT"),
                    new ValueString("GGC"),
                    new ValueString("GGA"),
                    new ValueString("GGG")
                };
            BaseChain Out = DnaTransformator.Decode(input);
            Assert.IsTrue(Out[0].Equals(m0));
            Assert.IsTrue(Out[1].Equals(m1));
            Assert.IsTrue(Out[2].Equals(m2));
            Assert.IsTrue(Out[3].Equals(m3));
            Assert.IsTrue(Out[4].Equals(m4));
            Assert.IsTrue(Out[5].Equals(m5));
            Assert.IsTrue(Out[6].Equals(m6));
            Assert.IsTrue(Out[7].Equals(m7));
            Assert.IsTrue(Out[8].Equals(m8));
            Assert.IsTrue(Out[9].Equals(m9));
            Assert.IsTrue(Out[10].Equals(m10));
            Assert.IsTrue(Out[11].Equals(m11));
            Assert.IsTrue(Out[12].Equals(m12));
            Assert.IsTrue(Out[13].Equals(m13));
            Assert.IsTrue(Out[14].Equals(m14));
            Assert.IsTrue(Out[15].Equals(m15));
            Assert.IsTrue(Out[16].Equals(m16));
            Assert.IsTrue(Out[17].Equals(m17));
            Assert.IsTrue(Out[18].Equals(m18));
            Assert.IsTrue(Out[19].Equals(m19));
            Assert.IsTrue(Out[20].Equals(m20));
        }

        [Test]
        public void EncodeTripletsTest()
        {
            string str = "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGG";
            BaseChain input = new BaseChain(64 * 3);
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = new ValueChar(str[i]);
            }
            BaseChain Out = DnaTransformator.EncodeTriplets(input);
            Assert.AreEqual(new ValueString("TTT"), Out[0]);
            Assert.AreEqual(new ValueString("TTC"), Out[1]);
            Assert.AreEqual(new ValueString("TTA"), Out[2]);
            Assert.AreEqual(new ValueString("TTG"), Out[3]);
            Assert.AreEqual(new ValueString("TCT"), Out[4]);
            Assert.AreEqual(new ValueString("TCC"), Out[5]);
            Assert.AreEqual(new ValueString("TCA"), Out[6]);
            Assert.AreEqual(new ValueString("TCG"), Out[7]);
            Assert.AreEqual(new ValueString("TAT"), Out[8]);
            Assert.AreEqual(new ValueString("TAC"), Out[9]);
            Assert.AreEqual(new ValueString("TAA"), Out[10]);
            Assert.AreEqual(new ValueString("TAG"), Out[11]);
            Assert.AreEqual(new ValueString("TGT"), Out[12]);
            Assert.AreEqual(new ValueString("TGC"), Out[13]);
            Assert.AreEqual(new ValueString("TGA"), Out[14]);
            Assert.AreEqual(new ValueString("TGG"), Out[15]);
            Assert.AreEqual(new ValueString("CTT"), Out[16]);
            Assert.AreEqual(new ValueString("CTC"), Out[17]);
            Assert.AreEqual(new ValueString("CTA"), Out[18]);
            Assert.AreEqual(new ValueString("CTG"), Out[19]);
            Assert.AreEqual(new ValueString("CCT"), Out[20]);
            Assert.AreEqual(new ValueString("CCC"), Out[21]);
            Assert.AreEqual(new ValueString("CCA"), Out[22]);
            Assert.AreEqual(new ValueString("CCG"), Out[23]);
            Assert.AreEqual(new ValueString("CAT"), Out[24]);
            Assert.AreEqual(new ValueString("CAC"), Out[25]);
            Assert.AreEqual(new ValueString("CAA"), Out[26]);
            Assert.AreEqual(new ValueString("CAG"), Out[27]);
            Assert.AreEqual(new ValueString("CGT"), Out[28]);
            Assert.AreEqual(new ValueString("CGC"), Out[29]);
            Assert.AreEqual(new ValueString("CGA"), Out[30]);
            Assert.AreEqual(new ValueString("CGG"), Out[31]);
            Assert.AreEqual(new ValueString("ATT"), Out[32]);
            Assert.AreEqual(new ValueString("ATC"), Out[33]);
            Assert.AreEqual(new ValueString("ATA"), Out[34]);
            Assert.AreEqual(new ValueString("ATG"), Out[35]);
            Assert.AreEqual(new ValueString("ACT"), Out[36]);
            Assert.AreEqual(new ValueString("ACC"), Out[37]);
            Assert.AreEqual(new ValueString("ACA"), Out[38]);
            Assert.AreEqual(new ValueString("ACG"), Out[39]);
            Assert.AreEqual(new ValueString("AAT"), Out[40]);
            Assert.AreEqual(new ValueString("AAC"), Out[41]);
            Assert.AreEqual(new ValueString("AAA"), Out[42]);
            Assert.AreEqual(new ValueString("AAG"), Out[43]);
            Assert.AreEqual(new ValueString("AGT"), Out[44]);
            Assert.AreEqual(new ValueString("AGC"), Out[45]);
            Assert.AreEqual(new ValueString("AGA"), Out[46]);
            Assert.AreEqual(new ValueString("AGG"), Out[47]);
            Assert.AreEqual(new ValueString("GTT"), Out[48]);
            Assert.AreEqual(new ValueString("GTC"), Out[49]);
            Assert.AreEqual(new ValueString("GTA"), Out[50]);
            Assert.AreEqual(new ValueString("GTG"), Out[51]);
            Assert.AreEqual(new ValueString("GCT"), Out[52]);
            Assert.AreEqual(new ValueString("GCC"), Out[53]);
            Assert.AreEqual(new ValueString("GCA"), Out[54]);
            Assert.AreEqual(new ValueString("GCG"), Out[55]);
            Assert.AreEqual(new ValueString("GAT"), Out[56]);
            Assert.AreEqual(new ValueString("GAC"), Out[57]);
            Assert.AreEqual(new ValueString("GAA"), Out[58]);
            Assert.AreEqual(new ValueString("GAG"), Out[59]);
            Assert.AreEqual(new ValueString("GGT"), Out[60]);
            Assert.AreEqual(new ValueString("GGC"), Out[61]);
            Assert.AreEqual(new ValueString("GGA"), Out[62]);
            Assert.AreEqual(new ValueString("GGG"), Out[63]);
        } 
    }
}