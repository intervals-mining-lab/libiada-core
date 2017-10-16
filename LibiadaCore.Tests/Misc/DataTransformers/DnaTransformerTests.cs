namespace LibiadaCore.Tests.Misc.DataTransformers
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

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
            BaseChain result = DnaTransformer.EncodeAmino(input);
            Assert.AreEqual("F", result[0].ToString());
        }

        /// <summary>
        /// The encode test.
        /// </summary>
        /// <param name="triplet">
        /// The triplet.
        /// </param>
        /// <param name="amino">
        /// The amino acid.
        /// </param>
        [TestCase("TTT", "F")]
        [TestCase("TTC", "F")]
        [TestCase("TTA", "L")]
        [TestCase("TTG", "L")]
        [TestCase("TCT", "S")]
        [TestCase("TCC", "S")]
        [TestCase("TCA", "S")]
        [TestCase("TCG", "S")]
        [TestCase("TAT", "Y")]
        [TestCase("TAC", "Y")]
        [TestCase("TAA", "X")]
        [TestCase("TAG", "X")]
        [TestCase("TGT", "C")]
        [TestCase("TGC", "C")]
        [TestCase("TGA", "X")]
        [TestCase("TGG", "W")]
        [TestCase("CTT", "L")]
        [TestCase("CTC", "L")]
        [TestCase("CTA", "L")]
        [TestCase("CTG", "L")]
        [TestCase("CCT", "P")]
        [TestCase("CCC", "P")]
        [TestCase("CCA", "P")]
        [TestCase("CCG", "P")]
        [TestCase("CAT", "H")]
        [TestCase("CAC", "H")]
        [TestCase("CAA", "Q")]
        [TestCase("CAG", "Q")]
        [TestCase("CGT", "R")]
        [TestCase("CGC", "R")]
        [TestCase("CGA", "R")]
        [TestCase("CGG", "R")]
        [TestCase("ATT", "I")]
        [TestCase("ATC", "I")]
        [TestCase("ATA", "I")]
        [TestCase("ATG", "M")]
        [TestCase("ACT", "T")]
        [TestCase("ACC", "T")]
        [TestCase("ACA", "T")]
        [TestCase("ACG", "T")]
        [TestCase("AAT", "N")]
        [TestCase("AAC", "N")]
        [TestCase("AAA", "K")]
        [TestCase("AAG", "K")]
        [TestCase("AGT", "S")]
        [TestCase("AGC", "S")]
        [TestCase("AGA", "R")]
        [TestCase("AGG", "R")]
        [TestCase("GTT", "V")]
        [TestCase("GTC", "V")]
        [TestCase("GTA", "V")]
        [TestCase("GTG", "V")]
        [TestCase("GCT", "A")]
        [TestCase("GCC", "A")]
        [TestCase("GCA", "A")]
        [TestCase("GCG", "A")]
        [TestCase("GAT", "D")]
        [TestCase("GAC", "D")]
        [TestCase("GAA", "E")]
        [TestCase("GAG", "E")]
        [TestCase("GGT", "G")]
        [TestCase("GGC", "G")]
        [TestCase("GGA", "G")]
        [TestCase("GGG", "G")]
        public void EncodeAminoTest(string triplet, string amino)
        {
            var input = new BaseChain(triplet);
            BaseChain result = DnaTransformer.EncodeAmino(input);

            for (int i = 0; i < result.GetLength(); i++)
            {
                Assert.AreEqual(new ValueString(amino[i]), result[i]);
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
        /// <param name="triplet">
        /// The triplet.
        /// </param>
        [TestCase("TTT")]
        [TestCase("TTC")]
        [TestCase("TTA")]
        [TestCase("TTG")]
        [TestCase("TCT")]
        [TestCase("TCC")]
        [TestCase("TCA")]
        [TestCase("TCG")]
        [TestCase("TAT")]
        [TestCase("TAC")]
        [TestCase("TAA")]
        [TestCase("TAG")]
        [TestCase("TGT")]
        [TestCase("TGC")]
        [TestCase("TGA")]
        [TestCase("TGG")]
        [TestCase("CTT")]
        [TestCase("CTC")]
        [TestCase("CTA")]
        [TestCase("CTG")]
        [TestCase("CCT")]
        [TestCase("CCC")]
        [TestCase("CCA")]
        [TestCase("CCG")]
        [TestCase("CAT")]
        [TestCase("CAC")]
        [TestCase("CAA")]
        [TestCase("CAG")]
        [TestCase("CGT")]
        [TestCase("CGC")]
        [TestCase("CGA")]
        [TestCase("CGG")]
        [TestCase("ATT")]
        [TestCase("ATC")]
        [TestCase("ATA")]
        [TestCase("ATG")]
        [TestCase("ACT")]
        [TestCase("ACC")]
        [TestCase("ACA")]
        [TestCase("ACG")]
        [TestCase("AAT")]
        [TestCase("AAC")]
        [TestCase("AAA")]
        [TestCase("AAG")]
        [TestCase("AGT")]
        [TestCase("AGC")]
        [TestCase("AGA")]
        [TestCase("AGG")]
        [TestCase("GTT")]
        [TestCase("GTC")]
        [TestCase("GTA")]
        [TestCase("GTG")]
        [TestCase("GCT")]
        [TestCase("GCC")]
        [TestCase("GCA")]
        [TestCase("GCG")]
        [TestCase("GAT")]
        [TestCase("GAC")]
        [TestCase("GAA")]
        [TestCase("GAG")]
        [TestCase("GGT")]
        [TestCase("GGC")]
        [TestCase("GGA")]
        [TestCase("GGG")]
        public void EncodeTripletsTest(string triplet)
        {
            var input = new BaseChain(triplet.Length);
            for (int i = 0; i < triplet.Length; i++)
            {
                input[i] = new ValueString(triplet[i]);
            }

            BaseChain result = DnaTransformer.EncodeTriplets(input);

            for (int i = 0; i < result.GetLength(); i++)
            {
                Assert.AreEqual(new ValueString(triplet.Substring(i * 3, 3)), result[i]);
            }
        }
    }
}
