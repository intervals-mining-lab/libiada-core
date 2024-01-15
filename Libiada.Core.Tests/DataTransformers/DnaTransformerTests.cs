namespace LibiadaCore.Tests.DataTransformers
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.DataTransformers;

    using NUnit.Framework;

    /// <summary>
    /// The DNA transformer test.
    /// </summary>
    [TestFixture]
    public class DnaTransformerTests
    {
        [Test]
        public void UnexpectedStopCodonTest()
        {
            var input = new BaseChain("TAGTGA");
            Assert.Throws<Exception>(() => DnaTransformer.EncodeAmino(input));
        }

        [Test]
        public void NoStopCodonTest()
        {
            var input = new BaseChain("AAAAAA");
            Assert.Throws<Exception>(() => DnaTransformer.EncodeAmino(input));
        }

        [Test]
        public void WrongCodingTableNumberTest()
        {
            var input = new BaseChain("TAGTGA");
            Assert.Throws<ArgumentException>(() => DnaTransformer.EncodeAmino(input, 58));
        }

        [TestCase(1, "FFLLSSSSYYCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(1, "", "TAG")]
        [TestCase(1, "", "TGA")]
        [TestCase(2, "FFLLSSSSYYCCWWLLLLPPPPHHQQRRRRIIMMTTTTNNKKSSVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGAGG")]
        [TestCase(2, "", "TAG")]
        [TestCase(2, "", "TAA")]
        [TestCase(2, "", "AGA")]
        [TestCase(3, "FFLLSSSSYYCCWWTTTTPPPPHHQQRRRRIIMMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(3, "", "TAG")]
        [TestCase(4, "FFLLSSSSYYCCWWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(4, "", "TAG")]
        [TestCase(5, "FFLLSSSSYYCCWWLLLLPPPPHHQQRRRRIIMMTTTTNNKKSSSSVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(5, "", "TAG")]
        [TestCase(6, "FFLLSSSSYYQQCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTGA")]
        [TestCase(9, "FFLLSSSSYYCCWWLLLLPPPPHHQQRRRRIIIMTTTTNNNKSSSSVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(9, "", "TAG")]
        [TestCase(10, "FFLLSSSSYYCCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(10, "", "TAG")]
        [TestCase(11, "FFLLSSSSYYCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(11, "", "TAG")]
        [TestCase(11, "", "TGA")]
        [TestCase(12, "FFLLSSSSYYCCWLLLSPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(12, "", "TAG")]
        [TestCase(12, "", "TGA")]
        [TestCase(13, "FFLLSSSSYYCCWWLLLLPPPPHHQQRRRRIIMMTTTTNNKKSSGGVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(13, "", "TAG")]
        [TestCase(14, "FFLLSSSSYYYCCWWLLLLPPPPHHQQRRRRIIIMTTTTNNNKSSSSVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAG")]
        [TestCase(15, "FFLLSSSSYYQCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAGTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(15, "", "TGA")]
        [TestCase(16, "FFLLSSSSYYLCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAGTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(16, "", "TGA")]
        [TestCase(21, "FFLLSSSSYYCCWWLLLLPPPPHHQQRRRRIIMMTTTTNNNKSSSSVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(21, "", "TAG")]
        [TestCase(22, "FFLLSSSYYLCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCGTATTACTAGTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTCA")]
        [TestCase(22, "", "TAA")]
        [TestCase(22, "", "TGA")]
        [TestCase(23, "FFLSSSSYYCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTGTCTTCCTCATCGTATTACTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTTA")]
        [TestCase(23, "", "TAA")]
        [TestCase(23, "", "TAG")]
        [TestCase(23, "", "TGA")]
        [TestCase(24, "FFLLSSSSYYCCWWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSSKVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(24, "", "TAG")]
        [TestCase(25, "FFLLSSSSYYCCGWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(25, "", "TAG")]
        [TestCase(26, "FFLLSSSSYYCCWLLLAPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(26, "", "TAG")]
        [TestCase(26, "", "TGA")]
        [TestCase(27, "FFLLSSSSYYQQCCWWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTGA")]
        [TestCase(28, "FFLLSSSSYYQQCCWWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(28, "", "TAG")]
        [TestCase(28, "", "TGA")]
        [TestCase(29, "FFLLSSSSYYYYCCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTGA")]
        [TestCase(30, "FFLLSSSSYYEECCWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTGA")]
        [TestCase(31, "FFLLSSSSYYEECCWWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSRRVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATAGTGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAA")]
        [TestCase(31, "", "TAG")]
        [TestCase(33, "FFLLSSSSYYYCCWWLLLLPPPPHHQQRRRRIIIMTTTTNNKKSSSKVVVVAAAADDEEGGGG", "TTTTTCTTATTGTCTTCCTCATCGTATTACTAATGTTGCTGATGGCTTCTCCTACTGCCTCCCCCACCGCATCACCAACAGCGTCGCCGACGGATTATCATAATGACTACCACAACGAATAACAAAAAGAGTAGCAGAAGGGTTGTCGTAGTGGCTGCCGCAGCGGATGACGAAGAGGGTGGCGGAGGGTAG")]
        public void EncodeWithCodingTableTest(byte codingTable, string aminoSequence, string nucleotideSequcne)
        {
            var input = new BaseChain(nucleotideSequcne);
            BaseChain result = DnaTransformer.EncodeAmino(input, codingTable);
            var expected = new BaseChain(aminoSequence);

            Assert.AreEqual(expected, result);
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

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(new ValueString(triplet.Substring(i * 3, 3)), result[i]);
            }
        }
    }
}
