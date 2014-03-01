namespace LibiadaCore.Tests.Classes.Misc.DataTransformers
{
    using System.Collections.Generic;
    using System.Globalization;

    using LibiadaCore.Classes.Misc.DataTransformers;
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The DNA transformer test.
    /// </summary>
    [TestFixture]
    public class DnaTransformerTests
    {
        /// <summary>
        /// The simple encode test.
        /// </summary>
        [Test]
        public void SimpleEncodeTest()
        {
            var input = new BaseChain("TTT");
            BaseChain result = DnaTransformer.Encode(input);
            Assert.AreEqual("F", result[0].ToString());
        }

        /// <summary>
        /// The encode test.
        /// </summary>
        [Test]
        public void EncodeTest()
        {
            var input =
                new BaseChain(
                    "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGG");
            BaseChain result = DnaTransformer.Encode(input);
            string expected = "FFLLSSSSYYXXCCXWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG";
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].ToString(CultureInfo.InvariantCulture), result[i].ToString());
            }
        }

        /// <summary>
        /// The simple decode test.
        /// </summary>
        [Test]
        public void SimpleDecodeTest()
        {
            var input = new BaseChain("F");
            BaseChain result = DnaTransformer.Decode(input);
            var mes = new ValuePhantom { new ValueString("TTT"), new ValueString("TTC") };
            Assert.IsTrue(mes.Equals(result[0]));
        }

        /// <summary>
        /// The decode test.
        /// </summary>
        [Test]
        public void DecodeTest()
        {
            var input = new BaseChain("FLSYXCWPHQRIMTNKVADEG");

            var message = new List<ValuePhantom>
                              {
                                  new ValuePhantom { new ValueString("TTT"), new ValueString("TTC") },
                                  new ValuePhantom
                                      {
                                          new ValueString("TTA"),
                                          new ValueString("TTG"),
                                          new ValueString("CTT"),
                                          new ValueString("CTC"),
                                          new ValueString("CTA"),
                                          new ValueString("CTG")
                                      },
                                  new ValuePhantom
                                      {
                                          new ValueString("TCT"),
                                          new ValueString("TCC"),
                                          new ValueString("TCA"),
                                          new ValueString("TCG"),
                                          new ValueString("AGT"),
                                          new ValueString("AGC")
                                      },
                                  new ValuePhantom { new ValueString("TAT"), new ValueString("TAC") },
                                  new ValuePhantom
                                      {
                                          new ValueString("TAA"),
                                          new ValueString("TAG"),
                                          new ValueString("TGA")
                                      },
                                  new ValuePhantom { new ValueString("TGT"), new ValueString("TGC") },
                                  new ValuePhantom { new ValueString("TGG") },
                                  new ValuePhantom
                                      {
                                          new ValueString("CCT"),
                                          new ValueString("CCC"),
                                          new ValueString("CCA"),
                                          new ValueString("CCG")
                                      },
                                  new ValuePhantom { new ValueString("CAT"), new ValueString("CAC") },
                                  new ValuePhantom { new ValueString("CAA"), new ValueString("CAG") },
                                  new ValuePhantom
                                      {
                                          new ValueString("CGT"),
                                          new ValueString("CGC"),
                                          new ValueString("CGA"),
                                          new ValueString("CGG"),
                                          new ValueString("AGA"),
                                          new ValueString("AGG")
                                      },
                                  new ValuePhantom
                                      {
                                          new ValueString("ATT"),
                                          new ValueString("ATC"),
                                          new ValueString("ATA")
                                      },
                                  new ValuePhantom { new ValueString("ATG") },
                                  new ValuePhantom
                                      {
                                          new ValueString("ACT"),
                                          new ValueString("ACC"),
                                          new ValueString("ACA"),
                                          new ValueString("ACG")
                                      },
                                  new ValuePhantom { new ValueString("AAT"), new ValueString("AAC") },
                                  new ValuePhantom { new ValueString("AAA"), new ValueString("AAG") },
                                  new ValuePhantom
                                      {
                                          new ValueString("GTT"),
                                          new ValueString("GTC"),
                                          new ValueString("GTA"),
                                          new ValueString("GTG")
                                      },
                                  new ValuePhantom
                                      {
                                          new ValueString("GCT"),
                                          new ValueString("GCC"),
                                          new ValueString("GCA"),
                                          new ValueString("GCG")
                                      },
                                  new ValuePhantom { new ValueString("GAT"), new ValueString("GAC") },
                                  new ValuePhantom { new ValueString("GAA"), new ValueString("GAG") },
                                  new ValuePhantom
                                      {
                                          new ValueString("GGT"),
                                          new ValueString("GGC"),
                                          new ValueString("GGA"),
                                          new ValueString("GGG")
                                      }
                              };

            BaseChain result = DnaTransformer.Decode(input);
            for (int i = 0; i < message.Count; i++)
            {
                Assert.IsTrue(result[i].Equals(message[i]));
            }
        }

        /// <summary>
        /// The encode triplets test.
        /// </summary>
        [Test]
        public void EncodeTripletsTest()
        {
            var input =
                new BaseChain(
                    "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGG");

            BaseChain result = DnaTransformer.EncodeTriplets(input);

            Assert.AreEqual(new ValueString("TTT"), result[0]);
            Assert.AreEqual(new ValueString("TTC"), result[1]);
            Assert.AreEqual(new ValueString("TTA"), result[2]);
            Assert.AreEqual(new ValueString("TTG"), result[3]);
            Assert.AreEqual(new ValueString("TCT"), result[4]);
            Assert.AreEqual(new ValueString("TCC"), result[5]);
            Assert.AreEqual(new ValueString("TCA"), result[6]);
            Assert.AreEqual(new ValueString("TCG"), result[7]);
            Assert.AreEqual(new ValueString("TAT"), result[8]);
            Assert.AreEqual(new ValueString("TAC"), result[9]);
            Assert.AreEqual(new ValueString("TAA"), result[10]);
            Assert.AreEqual(new ValueString("TAG"), result[11]);
            Assert.AreEqual(new ValueString("TGT"), result[12]);
            Assert.AreEqual(new ValueString("TGC"), result[13]);
            Assert.AreEqual(new ValueString("TGA"), result[14]);
            Assert.AreEqual(new ValueString("TGG"), result[15]);
            Assert.AreEqual(new ValueString("CTT"), result[16]);
            Assert.AreEqual(new ValueString("CTC"), result[17]);
            Assert.AreEqual(new ValueString("CTA"), result[18]);
            Assert.AreEqual(new ValueString("CTG"), result[19]);
            Assert.AreEqual(new ValueString("CCT"), result[20]);
            Assert.AreEqual(new ValueString("CCC"), result[21]);
            Assert.AreEqual(new ValueString("CCA"), result[22]);
            Assert.AreEqual(new ValueString("CCG"), result[23]);
            Assert.AreEqual(new ValueString("CAT"), result[24]);
            Assert.AreEqual(new ValueString("CAC"), result[25]);
            Assert.AreEqual(new ValueString("CAA"), result[26]);
            Assert.AreEqual(new ValueString("CAG"), result[27]);
            Assert.AreEqual(new ValueString("CGT"), result[28]);
            Assert.AreEqual(new ValueString("CGC"), result[29]);
            Assert.AreEqual(new ValueString("CGA"), result[30]);
            Assert.AreEqual(new ValueString("CGG"), result[31]);
            Assert.AreEqual(new ValueString("ATT"), result[32]);
            Assert.AreEqual(new ValueString("ATC"), result[33]);
            Assert.AreEqual(new ValueString("ATA"), result[34]);
            Assert.AreEqual(new ValueString("ATG"), result[35]);
            Assert.AreEqual(new ValueString("ACT"), result[36]);
            Assert.AreEqual(new ValueString("ACC"), result[37]);
            Assert.AreEqual(new ValueString("ACA"), result[38]);
            Assert.AreEqual(new ValueString("ACG"), result[39]);
            Assert.AreEqual(new ValueString("AAT"), result[40]);
            Assert.AreEqual(new ValueString("AAC"), result[41]);
            Assert.AreEqual(new ValueString("AAA"), result[42]);
            Assert.AreEqual(new ValueString("AAG"), result[43]);
            Assert.AreEqual(new ValueString("AGT"), result[44]);
            Assert.AreEqual(new ValueString("AGC"), result[45]);
            Assert.AreEqual(new ValueString("AGA"), result[46]);
            Assert.AreEqual(new ValueString("AGG"), result[47]);
            Assert.AreEqual(new ValueString("GTT"), result[48]);
            Assert.AreEqual(new ValueString("GTC"), result[49]);
            Assert.AreEqual(new ValueString("GTA"), result[50]);
            Assert.AreEqual(new ValueString("GTG"), result[51]);
            Assert.AreEqual(new ValueString("GCT"), result[52]);
            Assert.AreEqual(new ValueString("GCC"), result[53]);
            Assert.AreEqual(new ValueString("GCA"), result[54]);
            Assert.AreEqual(new ValueString("GCG"), result[55]);
            Assert.AreEqual(new ValueString("GAT"), result[56]);
            Assert.AreEqual(new ValueString("GAC"), result[57]);
            Assert.AreEqual(new ValueString("GAA"), result[58]);
            Assert.AreEqual(new ValueString("GAG"), result[59]);
            Assert.AreEqual(new ValueString("GGT"), result[60]);
            Assert.AreEqual(new ValueString("GGC"), result[61]);
            Assert.AreEqual(new ValueString("GGA"), result[62]);
            Assert.AreEqual(new ValueString("GGG"), result[63]);
        }
    }
}