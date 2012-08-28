using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;

namespace TestPhantomChains.Classes.PhantomChains
{
    [TestFixture]
    public class TestCoder
    {
        [Test]
        public void TestSimpleEncode()
        {
            string str;
            str = "TTT";
            BaseChain Input = new BaseChain(3);
            for (int i = 0; i < Input.Length; i++)
            {
                Input[i] = new ValueChar(str[i]);
            }
            BaseChain Out = Coder.Encode(Input);
            Assert.AreEqual("F", Out[0].ToString());
        }

        [Test]
        public void TestEncode()
        {
            string str ;
            str = "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGG";
            BaseChain Input = new BaseChain(64*3);
            for(int i=0;i<Input.Length;i++)
            {
                Input[i] = new ValueChar(str[i]);
            }
            BaseChain Out = Coder.Encode(Input);
            Assert.AreEqual("Phe", Out[0].ToString());
            Assert.AreEqual("Phe", Out[1].ToString());
            Assert.AreEqual("Leu", Out[2].ToString());
            Assert.AreEqual("Leu", Out[3].ToString());
            Assert.AreEqual("Ser", Out[4].ToString());
            Assert.AreEqual("Ser", Out[5].ToString());
            Assert.AreEqual("Ser", Out[6].ToString());
            Assert.AreEqual("Ser", Out[7].ToString());
            Assert.AreEqual("Tyr", Out[8].ToString());
            Assert.AreEqual("Tyr", Out[9].ToString());
            Assert.AreEqual("St", Out[10].ToString());
            Assert.AreEqual("St", Out[11].ToString());
            Assert.AreEqual("Cys", Out[12].ToString());
            Assert.AreEqual("Cys", Out[13].ToString());
            Assert.AreEqual("St", Out[14].ToString());
            Assert.AreEqual("Trp", Out[15].ToString());
            Assert.AreEqual("Leu", Out[16].ToString());
            Assert.AreEqual("Leu", Out[17].ToString());
            Assert.AreEqual("Leu", Out[18].ToString());
            Assert.AreEqual("Leu", Out[19].ToString());
            Assert.AreEqual("Pro", Out[20].ToString());
            Assert.AreEqual("Pro", Out[21].ToString());
            Assert.AreEqual("Pro", Out[22].ToString());
            Assert.AreEqual("Pro", Out[23].ToString());
            Assert.AreEqual("His", Out[24].ToString());
            Assert.AreEqual("His", Out[25].ToString());
            Assert.AreEqual("Gln", Out[26].ToString());
            Assert.AreEqual("Gln", Out[27].ToString());
            Assert.AreEqual("Arg", Out[28].ToString());
            Assert.AreEqual("Arg", Out[29].ToString());
            Assert.AreEqual("Arg", Out[30].ToString());
            Assert.AreEqual("Arg", Out[31].ToString());
            Assert.AreEqual("Ile", Out[32].ToString());
            Assert.AreEqual("Ile", Out[33].ToString());
            Assert.AreEqual("Ile", Out[34].ToString());
            Assert.AreEqual("Met", Out[35].ToString());
            Assert.AreEqual("Thr", Out[36].ToString());
            Assert.AreEqual("Thr", Out[37].ToString());
            Assert.AreEqual("Thr", Out[38].ToString());
            Assert.AreEqual("Thr", Out[39].ToString());
            Assert.AreEqual("Asn", Out[40].ToString());
            Assert.AreEqual("Asn", Out[41].ToString());
            Assert.AreEqual("Lys", Out[42].ToString());
            Assert.AreEqual("Lys", Out[43].ToString());
            Assert.AreEqual("Ser", Out[44].ToString());
            Assert.AreEqual("Ser", Out[45].ToString());
            Assert.AreEqual("Arg", Out[46].ToString());
            Assert.AreEqual("Arg", Out[47].ToString());
            Assert.AreEqual("Val", Out[48].ToString());
            Assert.AreEqual("Val", Out[49].ToString());
            Assert.AreEqual("Val", Out[50].ToString());
            Assert.AreEqual("Val", Out[51].ToString());
            Assert.AreEqual("Ala", Out[52].ToString());
            Assert.AreEqual("Ala", Out[53].ToString());
            Assert.AreEqual("Ala", Out[54].ToString());
            Assert.AreEqual("Ala", Out[55].ToString());
            Assert.AreEqual("Asp", Out[56].ToString());
            Assert.AreEqual("Asp", Out[57].ToString());
            Assert.AreEqual("Glu", Out[58].ToString());
            Assert.AreEqual("Glu", Out[59].ToString());
            Assert.AreEqual("Gly", Out[60].ToString());
            Assert.AreEqual("Gly", Out[61].ToString());
            Assert.AreEqual("Gly", Out[62].ToString());
            Assert.AreEqual("Gly", Out[63].ToString());
        }

        [Test]
        public void TestSimpleDecode()
        {
            BaseChain Input = new BaseChain(1);
            Input[0] = new ValueString("Phe");
            BaseChain Out = Coder.Decode(Input);
            ValuePhantom mes = new ValuePhantom();
            mes.Add(new ValueString("TTT"));
            mes.Add(new ValueString("TTC"));
            Assert.IsTrue(mes.Equals(Out[0]));
        }

        [Test]
        public void TestDecode()
        {
            BaseChain Input = new BaseChain(21);
            Input[0] = new ValueString("Phe");
            Input[1] = new ValueString("Leu");
            Input[2] = new ValueString("Ser");
            Input[3] = new ValueString("Tyr");
            Input[4] = new ValueString("St");
            Input[5] = new ValueString("Cys");
            Input[6] = new ValueString("Trp");
            Input[7] = new ValueString("Pro");
            Input[8] = new ValueString("His");
            Input[9] = new ValueString("Gln");
            Input[10] = new ValueString("Arg");
            Input[11] = new ValueString("Ile");
            Input[12] = new ValueString("Met");
            Input[13] = new ValueString("Thr");
            Input[14] = new ValueString("Asn");
            Input[15] = new ValueString("Lys");
            Input[16] = new ValueString("Val");
            Input[17] = new ValueString("Ala");
            Input[18] = new ValueString("Asp");
            Input[19] = new ValueString("Glu");
            Input[20] = new ValueString("Gly");
            ValuePhantom m0 = new ValuePhantom();
            m0.Add(new ValueString("TTT"));
            m0.Add(new ValueString("TTC"));
            ValuePhantom m1 = new ValuePhantom();
            m1.Add(new ValueString("TTA"));
            m1.Add(new ValueString("TTG"));
            m1.Add(new ValueString("CTT"));
            m1.Add(new ValueString("CTC"));
            m1.Add(new ValueString("CTA"));
            m1.Add(new ValueString("CTG"));
            ValuePhantom m2 = new ValuePhantom();
            m2.Add(new ValueString("TCT"));
            m2.Add(new ValueString("TCC"));
            m2.Add(new ValueString("TCA"));
            m2.Add(new ValueString("TCG"));
            m2.Add(new ValueString("AGT"));
            m2.Add(new ValueString("AGC"));
            ValuePhantom m3 = new ValuePhantom();
            m3.Add(new ValueString("TAT"));
            m3.Add(new ValueString("TAC"));
            ValuePhantom m4 = new ValuePhantom();
            m4.Add(new ValueString("TAA"));
            m4.Add(new ValueString("TAG"));
            m4.Add(new ValueString("TGA"));
            ValuePhantom m5 = new ValuePhantom();
            m5.Add(new ValueString("TGT"));
            m5.Add(new ValueString("TGC"));
            ValuePhantom m6 = new ValuePhantom();
            m6.Add(new ValueString("TGG"));
            ValuePhantom m7 = new ValuePhantom();
            m7.Add(new ValueString("CCT"));
            m7.Add(new ValueString("CCC"));
            m7.Add(new ValueString("CCA"));
            m7.Add(new ValueString("CCG"));
            ValuePhantom m8 = new ValuePhantom();
            m8.Add(new ValueString("CAT"));
            m8.Add(new ValueString("CAC"));
            ValuePhantom m9 = new ValuePhantom();
            m9.Add(new ValueString("CAA"));
            m9.Add(new ValueString("CAG"));
            ValuePhantom m10 = new ValuePhantom();
            m10.Add(new ValueString("CGT"));
            m10.Add(new ValueString("CGC"));
            m10.Add(new ValueString("CGA"));
            m10.Add(new ValueString("CGG"));
            m10.Add(new ValueString("AGA"));
            m10.Add(new ValueString("AGG"));
            ValuePhantom m11= new ValuePhantom();
            m11.Add(new ValueString("ATT"));
            m11.Add(new ValueString("ATC"));
            m11.Add(new ValueString("ATA"));
            ValuePhantom m12 = new ValuePhantom();
            m12.Add(new ValueString("ATG"));
            ValuePhantom m13 = new ValuePhantom();
            m13.Add(new ValueString("ACT"));
            m13.Add(new ValueString("ACC"));
            m13.Add(new ValueString("ACA"));
            m13.Add(new ValueString("ACG"));
            ValuePhantom m14 = new ValuePhantom();
            m14.Add(new ValueString("AAT"));
            m14.Add(new ValueString("AAC"));
            ValuePhantom m15 = new ValuePhantom();
            m15.Add(new ValueString("AAA"));
            m15.Add(new ValueString("AAG"));
            ValuePhantom m16 = new ValuePhantom();
            m16.Add(new ValueString("GTT"));
            m16.Add(new ValueString("GTC"));
            m16.Add(new ValueString("GTA"));
            m16.Add(new ValueString("GTG"));
            ValuePhantom m17 = new ValuePhantom();
            m17.Add(new ValueString("GCT"));
            m17.Add(new ValueString("GCC"));
            m17.Add(new ValueString("GCA"));
            m17.Add(new ValueString("GCG"));
            ValuePhantom m18 = new ValuePhantom();
            m18.Add(new ValueString("GAT"));
            m18.Add(new ValueString("GAC"));
            ValuePhantom m19 = new ValuePhantom();
            m19.Add(new ValueString("GAA"));
            m19.Add(new ValueString("GAG"));
            ValuePhantom m20 = new ValuePhantom();
            m20.Add(new ValueString("GGT"));
            m20.Add(new ValueString("GGC"));
            m20.Add(new ValueString("GGA"));
            m20.Add(new ValueString("GGG"));
            BaseChain Out = Coder.Decode(Input);
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
        public void TestEncodeTriplets()
        {
            string str;
            str = "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGG";
            BaseChain Input = new BaseChain(64 * 3);
            for (int i = 0; i < Input.Length; i++)
            {
                Input[i] = new ValueChar(str[i]);
            }
            BaseChain Out = Coder.EncodeTriplets(Input);
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
