using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.PhantomChains
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
            Assert.AreEqual("Phe", Out[0].ToString());
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
            MessagePhantom mes = new MessagePhantom();
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
            MessagePhantom m0 = new MessagePhantom();
            m0.Add(new ValueString("TTT"));
            m0.Add(new ValueString("TTC"));
            MessagePhantom m1 = new MessagePhantom();
            m1.Add(new ValueString("TTA"));
            m1.Add(new ValueString("TTG"));
            m1.Add(new ValueString("CTT"));
            m1.Add(new ValueString("CTC"));
            m1.Add(new ValueString("CTA"));
            m1.Add(new ValueString("CTG"));
            MessagePhantom m2 = new MessagePhantom();
            m2.Add(new ValueString("TCT"));
            m2.Add(new ValueString("TCC"));
            m2.Add(new ValueString("TCA"));
            m2.Add(new ValueString("TCG"));
            m2.Add(new ValueString("AGT"));
            m2.Add(new ValueString("AGC"));
            MessagePhantom m3 = new MessagePhantom();
            m3.Add(new ValueString("TAT"));
            m3.Add(new ValueString("TAC"));
            MessagePhantom m4 = new MessagePhantom();
            m4.Add(new ValueString("TAA"));
            m4.Add(new ValueString("TAG"));
            m4.Add(new ValueString("TGA"));
            MessagePhantom m5 = new MessagePhantom();
            m5.Add(new ValueString("TGT"));
            m5.Add(new ValueString("TGC"));
            MessagePhantom m6 = new MessagePhantom();
            m6.Add(new ValueString("TGG"));
            MessagePhantom m7 = new MessagePhantom();
            m7.Add(new ValueString("CCT"));
            m7.Add(new ValueString("CCC"));
            m7.Add(new ValueString("CCA"));
            m7.Add(new ValueString("CCG"));
            MessagePhantom m8 = new MessagePhantom();
            m8.Add(new ValueString("CAT"));
            m8.Add(new ValueString("CAC"));
            MessagePhantom m9 = new MessagePhantom();
            m9.Add(new ValueString("CAA"));
            m9.Add(new ValueString("CAG"));
            MessagePhantom m10 = new MessagePhantom();
            m10.Add(new ValueString("CGT"));
            m10.Add(new ValueString("CGC"));
            m10.Add(new ValueString("CGA"));
            m10.Add(new ValueString("CGG"));
            m10.Add(new ValueString("AGA"));
            m10.Add(new ValueString("AGG"));
            MessagePhantom m11= new MessagePhantom();
            m11.Add(new ValueString("ATT"));
            m11.Add(new ValueString("ATC"));
            m11.Add(new ValueString("ATA"));
            MessagePhantom m12 = new MessagePhantom();
            m12.Add(new ValueString("ATG"));
            MessagePhantom m13 = new MessagePhantom();
            m13.Add(new ValueString("ACT"));
            m13.Add(new ValueString("ACC"));
            m13.Add(new ValueString("ACA"));
            m13.Add(new ValueString("ACG"));
            MessagePhantom m14 = new MessagePhantom();
            m14.Add(new ValueString("AAT"));
            m14.Add(new ValueString("AAC"));
            MessagePhantom m15 = new MessagePhantom();
            m15.Add(new ValueString("AAA"));
            m15.Add(new ValueString("AAG"));
            MessagePhantom m16 = new MessagePhantom();
            m16.Add(new ValueString("GTT"));
            m16.Add(new ValueString("GTC"));
            m16.Add(new ValueString("GTA"));
            m16.Add(new ValueString("GTG"));
            MessagePhantom m17 = new MessagePhantom();
            m17.Add(new ValueString("GCT"));
            m17.Add(new ValueString("GCC"));
            m17.Add(new ValueString("GCA"));
            m17.Add(new ValueString("GCG"));
            MessagePhantom m18 = new MessagePhantom();
            m18.Add(new ValueString("GAT"));
            m18.Add(new ValueString("GAC"));
            MessagePhantom m19 = new MessagePhantom();
            m19.Add(new ValueString("GAA"));
            m19.Add(new ValueString("GAG"));
            MessagePhantom m20 = new MessagePhantom();
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
    }
}
