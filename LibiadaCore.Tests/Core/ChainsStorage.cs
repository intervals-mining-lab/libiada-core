namespace LibiadaCore.Tests.Core
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The chains storage.
    /// </summary>
    public static class ChainsStorage
    {
        /// <summary>
        /// Gets dictionary of elements.
        /// </summary>
        public static Dictionary<string, IBaseObject> Elements =>
            new Dictionary<string, IBaseObject>
                {
                    { "A", new ValueString("A") },
                    { "B", new ValueString("B") },
                    { "C", new ValueString("C") },
                    { "G", new ValueString("G") },
                    { "T", new ValueString("T") }
                };

        /// <summary>
        /// Gets the chains.
        /// </summary>
        public static List<Chain> Chains =>
            new List<Chain>
                {
                    // B B A A C B A C C B
                    // _ _ A A _ _ A _ _ _
                    // B B _ _ _ B _ _ _ B
                    // _ _ _ _ C _ _ C C _
                    new Chain("BBAACBACCB"),

                    // A C T T G A T A C G
                    // A _ _ _ _ A _ A _ _
                    // _ C _ _ _ _ _ _ C _
                    // _ _ T T _ _ T _ _ _
                    // _ _ _ _ G _ _ _ _ G
                    new Chain("ACTTGATACG"),

                    // C C A C G C T T A C
                    // C C _ C _ C _ _ _ C
                    // _ _ A _ _ _ _ _ A _
                    // _ _ _ _ G _ _ _ _ _
                    // _ _ _ _ _ _ T T _ _
                    new Chain("CCACGCTTAC"),

                    // C G
                    // C _
                    // _ G
                    new Chain("CG"),

                    // C C C C
                    // C C C C
                    new Chain("CCCC"),

                    // A C G T
                    // A _ _ _
                    // _ C _ _
                    // _ _ G _
                    // _ _ _ T
                    new Chain("ACGT"),

                    // A A A A C G T
                    // A A A A _ _ _
                    // _ _ _ _ C _ _
                    // _ _ _ _ _ G _
                    // _ _ _ _ _ _ T
                    new Chain("AAAACGT"),

                    // T A
                    // T _
                    // _ A
                    new Chain("TA"),

                    // T T T T
                    // T T T T
                    new Chain("TTTT"),
                };

        /// <summary>
        /// Gets chains with high order.
        /// </summary>
        public static List<Chain> HighOrderChains
        {
            get
            {
                var result = new List<Chain>();

                // 1 1 3 1 5 4 3 3 1 4
                var chain = new Chain(10)
                                {
                                    [0] = new ValueInt(1),
                                    [1] = new ValueInt(1),
                                    [2] = new ValueInt(3),
                                    [3] = new ValueInt(1),
                                    [4] = new ValueInt(5),
                                    [5] = new ValueInt(4),
                                    [6] = new ValueInt(3),
                                    [7] = new ValueInt(3),
                                    [8] = new ValueInt(1),
                                    [9] = new ValueInt(4)
                                };
                result.Add(chain);

                // 5 7 1 3 5 2 4 3 2 1
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(5),
                                [1] = new ValueInt(7),
                                [2] = new ValueInt(1),
                                [3] = new ValueInt(3),
                                [4] = new ValueInt(5),
                                [5] = new ValueInt(2),
                                [6] = new ValueInt(4),
                                [7] = new ValueInt(3),
                                [8] = new ValueInt(2),
                                [9] = new ValueInt(1)
                            };
                result.Add(chain);

                // 1 2 3 1 5 5 3 2 7 5
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(1),
                                [1] = new ValueInt(2),
                                [2] = new ValueInt(3),
                                [3] = new ValueInt(1),
                                [4] = new ValueInt(5),
                                [5] = new ValueInt(5),
                                [6] = new ValueInt(3),
                                [7] = new ValueInt(2),
                                [8] = new ValueInt(7),
                                [9] = new ValueInt(5)
                            };
                result.Add(chain);

                // 1 4 1 3 3 4 4 1 2 1
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(1),
                                [1] = new ValueInt(4),
                                [2] = new ValueInt(1),
                                [3] = new ValueInt(3),
                                [4] = new ValueInt(3),
                                [5] = new ValueInt(4),
                                [6] = new ValueInt(4),
                                [7] = new ValueInt(1),
                                [8] = new ValueInt(2),
                                [9] = new ValueInt(1)
                            };
                result.Add(chain);

                // 1 4 1 3 3 4 4 6 6 1
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(1),
                                [1] = new ValueInt(4),
                                [2] = new ValueInt(1),
                                [3] = new ValueInt(3),
                                [4] = new ValueInt(3),
                                [5] = new ValueInt(4),
                                [6] = new ValueInt(6),
                                [7] = new ValueInt(1),
                                [8] = new ValueInt(6),
                                [9] = new ValueInt(1)
                            };
                result.Add(chain);

                // 1 1 6 1 6 4 3 3 1 4
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(1),
                                [1] = new ValueInt(1),
                                [2] = new ValueInt(6),
                                [3] = new ValueInt(1),
                                [4] = new ValueInt(6),
                                [5] = new ValueInt(4),
                                [6] = new ValueInt(3),
                                [7] = new ValueInt(3),
                                [8] = new ValueInt(1),
                                [9] = new ValueInt(4)
                            };
                result.Add(chain);

                // 2 4 5 1 6 1 4 2 2 1
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(2),
                                [1] = new ValueInt(4),
                                [2] = new ValueInt(5),
                                [3] = new ValueInt(1),
                                [4] = new ValueInt(6),
                                [5] = new ValueInt(1),
                                [6] = new ValueInt(4),
                                [7] = new ValueInt(2),
                                [8] = new ValueInt(2),
                                [9] = new ValueInt(1)
                            };
                result.Add(chain);

                return result;
            }
        }

        /// <summary>
        /// Gets the dissimilar chains.
        /// </summary>
        public static List<Chain> DissimilarChains
        {
            get
            {
                var result = new List<Chain>();

                // 1 2 1 2 1 3 3 2 3 4
                var chain = new Chain(10)
                                {
                                    [0] = new ValueInt(1),
                                    [1] = new ValueInt(2),
                                    [2] = new ValueInt(1),
                                    [3] = new ValueInt(2),
                                    [4] = new ValueInt(1),
                                    [5] = new ValueInt(3),
                                    [6] = new ValueInt(3),
                                    [7] = new ValueInt(2),
                                    [8] = new ValueInt(3),
                                    [9] = new ValueInt(4)
                                };
                result.Add(chain);

                // 1 1 1 2 1 2 3 3 2 2
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(1),
                                [1] = new ValueInt(1),
                                [2] = new ValueInt(1),
                                [3] = new ValueInt(2),
                                [4] = new ValueInt(1),
                                [5] = new ValueInt(2),
                                [6] = new ValueInt(3),
                                [7] = new ValueInt(3),
                                [8] = new ValueInt(2),
                                [9] = new ValueInt(2)
                            };
                result.Add(chain);

                // 1 2 1 3 1 4 1 2 2 5
                chain = new Chain(10)
                            {
                                [0] = new ValueInt(1),
                                [1] = new ValueInt(2),
                                [2] = new ValueInt(1),
                                [3] = new ValueInt(3),
                                [4] = new ValueInt(1),
                                [5] = new ValueInt(4),
                                [6] = new ValueInt(1),
                                [7] = new ValueInt(2),
                                [8] = new ValueInt(2),
                                [9] = new ValueInt(5)
                            };
                result.Add(chain);

                return result;
            }
        }

        /// <summary>
        /// Gets the congeneric chains.
        /// </summary>
        public static List<CongenericChain> CongenericChains =>
            new List<CongenericChain>
                {
                    // 0  _ _ _ a a _ _ a _ _
                    new CongenericChain(new[] { 3, 4, 7 }, Elements["A"], 10),

                    // 1  _ _ _ b _ b b _ _ _ _ b _ _ _
                    new CongenericChain(new[] { 3, 5, 6, 11 }, Elements["B"], 15),

                    // 2  a
                    new CongenericChain(new[] { 0 }, Elements["A"], 1),

                    // 3  _ _ _ _ _ _ _ a
                    new CongenericChain(new[] { 7 }, Elements["A"], 8),

                    // 4
                    new CongenericChain(new[] { 100, 100000, 500000 }, Elements["A"], 1000000),

                    // 5  a a a a a
                    new CongenericChain(new[] { 0, 1, 2, 3, 4 }, Elements["A"], 5),

                    // 6  a _ _ a _ _ _ _ _ _ _ _ _ _ _ _ _ _
                    new CongenericChain(new[] { 0, 3 }, Elements["A"], 18),

                    // 7  _ _ a _ _ _ _ _ _ _ _ _ _ _ _ _ _ a
                    new CongenericChain(new[] { 2, 17 }, Elements["A"], 18),

                    // 8  a _ _ _ _ a _ _ _ _ _ a _ _ _ _ _ _ _ a _ _ _ _ a _ _ _ _
                    new CongenericChain(new[] { 0, 5, 11, 19, 24 }, Elements["A"], 30),

                    // 9  _ _ a _ _ _ a _ _ _ _ _ _ _ _ a _ _ _ _ _ _ _ a _ _ a _ _
                    new CongenericChain(new[] { 2, 6, 15, 23, 26 }, Elements["A"], 30),

                    // 10 a _ _ _ _ _ _ _ a _ a _ _ a _ _ _ _ _ _
                    new CongenericChain(new[] { 0, 8, 10, 13 }, Elements["A"], 20),

                    // 11 _ a a _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ a _
                    new CongenericChain(new[] { 1, 2, 18 }, Elements["A"], 20),

                    // 12 a _ _ _ _ _ _ _ a _ _ a _ a _ a _ a _ a _ _ _ _ a _ _
                    new CongenericChain(new[] { 0, 8, 11, 13, 15, 17, 19, 24 }, Elements["A"], 27),

                    // 13 _ a _ a a _ a _ _ a a _ _ _ _ a _ _ _ _ _ _ a _ _ _ a
                    new CongenericChain(new[] { 1, 3, 4, 6, 9, 10, 22, 26 }, Elements["A"], 27),

                    // 14 a _ _ a _ _ _ _ _ a _ a _ _ _ _ _
                    new CongenericChain(new[] { 0, 3, 9, 11 }, Elements["A"], 17),

                    // 15 _ a _ _ _ _ _ a _ _ a _ _ _ a _ _
                    new CongenericChain(new[] { 1, 7, 10, 14 }, Elements["A"], 17),

                    // 16 a _ _ _ a _ _ _ _ _ a _ _ a _ _ _ _ _ _ _ _ _
                    new CongenericChain(new[] { 0, 4, 10, 13 }, Elements["A"], 23),

                    // 17 _ a _ _ _ _ _ _ _ a _ _ a _ _ _ _ _ a _ _ _ _
                    new CongenericChain(new[] { 1, 9, 12, 18 }, Elements["A"], 23),
                };

        /// <summary>
        /// Gets the chains.
        /// </summary>
        public static List<Chain> BinaryChains
        {
            get
            {
                var chains = new List<Chain>();

                // 0
                var chain = new Chain(10);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 1);
                chain.Set(Elements["B"], 2);
                chain.Set(Elements["A"], 3);
                chain.Set(Elements["A"], 5);
                chain.Set(Elements["B"], 8);
                chain.Set(Elements["A"], 9);
                chains.Add(chain);

                // ----------- ������� �� ������ ���������
                // 1
                chain = new Chain(2);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["B"], 1);
                chains.Add(chain);

                // 2
                chain = new Chain(6);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["B"], 3);
                chains.Add(chain);

                // 3
                chain = new Chain(27);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 4);
                chain.Set(Elements["A"], 12);
                chain.Set(Elements["A"], 19);
                chain.Set(Elements["B"], 3);
                chain.Set(Elements["B"], 9);
                chain.Set(Elements["B"], 16);
                chain.Set(Elements["B"], 26);
                chains.Add(chain);

                // 4
                chain = new Chain(5);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["B"], 1);
                chains.Add(chain);

                // 5
                chain = new Chain(12);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["B"], 1);
                chains.Add(chain);

                // 6
                chain = new Chain(13);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["B"], 12);
                chains.Add(chain);

                // 7
                chain = new Chain(29);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 14);
                chain.Set(Elements["A"], 17);
                chain.Set(Elements["A"], 18);
                chain.Set(Elements["A"], 19);
                chain.Set(Elements["A"], 22);
                chain.Set(Elements["B"], 8);
                chain.Set(Elements["B"], 10);
                chain.Set(Elements["B"], 12);
                chain.Set(Elements["B"], 13);
                chain.Set(Elements["B"], 28);
                chains.Add(chain);

                // 8
                chain = new Chain(25);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 3);
                chain.Set(Elements["A"], 12);
                chain.Set(Elements["A"], 13);
                chain.Set(Elements["A"], 15);
                chain.Set(Elements["A"], 17);
                chain.Set(Elements["A"], 23);
                chain.Set(Elements["B"], 6);
                chain.Set(Elements["B"], 21);
                chain.Set(Elements["B"], 24);
                chains.Add(chain);

                // 9
                chain = new Chain(29);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 3);
                chain.Set(Elements["A"], 4);
                chain.Set(Elements["A"], 6);
                chain.Set(Elements["A"], 18);
                chain.Set(Elements["A"], 21);
                chain.Set(Elements["B"], 2);
                chain.Set(Elements["B"], 17);
                chain.Set(Elements["B"], 28);
                chains.Add(chain);

                // 10
                chain = new Chain(28);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 8);
                chain.Set(Elements["A"], 16);
                chain.Set(Elements["A"], 18);
                chain.Set(Elements["B"], 4);
                chain.Set(Elements["B"], 12);
                chain.Set(Elements["B"], 17);
                chain.Set(Elements["B"], 19);
                chains.Add(chain);

                // 11
                chain = new Chain(28);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 9);
                chain.Set(Elements["A"], 16);
                chain.Set(Elements["A"], 24);
                chain.Set(Elements["B"], 2);
                chain.Set(Elements["B"], 11);
                chain.Set(Elements["B"], 19);
                chain.Set(Elements["B"], 25);
                chains.Add(chain);

                // 12
                chain = new Chain(16);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 8);
                chain.Set(Elements["B"], 4);
                chain.Set(Elements["B"], 12);
                chains.Add(chain);

                // 13
                chain = new Chain(30);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 6);
                chain.Set(Elements["A"], 10);
                chain.Set(Elements["A"], 18);
                chain.Set(Elements["B"], 3);
                chain.Set(Elements["B"], 9);
                chain.Set(Elements["B"], 13);
                chain.Set(Elements["B"], 21);
                chains.Add(chain);

                // 14
                chain = new Chain(23);
                chain.Set(Elements["A"], 4);
                chain.Set(Elements["A"], 8);
                chain.Set(Elements["A"], 14);
                chain.Set(Elements["A"], 18);
                chain.Set(Elements["B"], 5);
                chain.Set(Elements["B"], 9);
                chain.Set(Elements["B"], 15);
                chain.Set(Elements["B"], 19);
                chains.Add(chain);

                // 15
                chain = new Chain(12);
                chain.Set(Elements["A"], 4);
                chain.Set(Elements["B"], 1);
                chain.Set(Elements["B"], 3);
                chain.Set(Elements["B"], 5);
                chain.Set(Elements["B"], 8);
                chains.Add(chain);

                // 16
                chain = new Chain(29);
                chain.Set(Elements["A"], 2);
                chain.Set(Elements["A"], 9);
                chain.Set(Elements["A"], 10);
                chain.Set(Elements["A"], 17);
                chain.Set(Elements["B"], 6);
                chain.Set(Elements["B"], 14);
                chain.Set(Elements["B"], 22);
                chains.Add(chain);

                // -------------- ������ ������� �� ����������
                // 17
                chain = new Chain(26);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 6);
                chain.Set(Elements["A"], 12);
                chain.Set(Elements["B"], 2);
                chain.Set(Elements["B"], 8);
                chain.Set(Elements["B"], 19);
                chains.Add(chain);

                // 18
                chain = new Chain(12);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 4);
                chain.Set(Elements["B"], 1);
                chain.Set(Elements["B"], 3);
                chain.Set(Elements["B"], 5);
                chain.Set(Elements["B"], 8);
                chain.Set(Elements["C"], 2);
                chain.Set(Elements["C"], 6);
                chain.Set(Elements["C"], 7);
                chain.Set(Elements["C"], 9);
                chain.Set(Elements["C"], 10);
                chain.Set(Elements["C"], 11);
                chains.Add(chain);

                // 19
                chain = new Chain(23);
                chain.Set(Elements["A"], 0);
                chain.Set(Elements["A"], 6);
                chain.Set(Elements["A"], 11);
                chain.Set(Elements["A"], 21);
                chain.Set(Elements["B"], 1);
                chain.Set(Elements["B"], 7);
                chain.Set(Elements["B"], 12);
                chain.Set(Elements["B"], 22);
                chains.Add(chain);

                return chains;
            }
        }

        /// <summary>
        /// Gets the intervals.
        /// </summary>
        public static List<Dictionary<Link, List<int>>> Intervals =>
            new List<Dictionary<Link, List<int>>>
                {
                    new Dictionary<Link, List<int>>
                        {
                            { Link.Start, new List<int> { 4, 1, 3 } },
                            { Link.End, new List<int> { 1, 3, 3 } },
                            { Link.Both, new List<int> { 4, 1, 3, 3 } },
                            { Link.Cycle, new List<int> { 1, 3, 6 } },
                            { Link.None, new List<int> { 1, 3 } }
                        },

                    new Dictionary<Link, List<int>>
                        {
                            { Link.Start, new List<int> { 4, 2, 1, 5 } },
                            { Link.End, new List<int> { 2, 1, 5, 4 } },
                            { Link.Both, new List<int> { 4, 2, 1, 5, 4 } },
                            { Link.Cycle, new List<int> { 2, 1, 5, 7 } },
                            { Link.None, new List<int> { 2, 1, 5 } }
                        },

                    new Dictionary<Link, List<int>>
                        {
                            { Link.Start, new List<int> { 1 } },
                            { Link.End, new List<int> { 1 } },
                            { Link.Both, new List<int> { 1, 1 } },
                            { Link.Cycle, new List<int> { 1 } },
                            { Link.None, new List<int>() }
                        },

                    new Dictionary<Link, List<int>>
                        {
                            { Link.Start, new List<int> { 8 } },
                            { Link.End, new List<int> { 1 } },
                            { Link.Both, new List<int> { 8, 1 } },
                            { Link.Cycle, new List<int> { 8 } },
                            { Link.None, new List<int>() }
                        },

                    new Dictionary<Link, List<int>>
                        {
                            { Link.Start, new List<int> { 101, 99900, 400000 } },
                            { Link.End, new List<int> { 99900, 400000, 500000 } },
                            { Link.Both, new List<int> { 101, 99900, 400000, 500000 } },
                            { Link.Cycle, new List<int> { 99900, 400000, 500100 } },
                            { Link.None, new List<int> { 99900, 400000 } }
                        },

                    new Dictionary<Link, List<int>>
                        {
                            { Link.Start, new List<int> { 1, 1, 1, 1, 1 } },
                            { Link.End, new List<int> { 1, 1, 1, 1, 1 } },
                            { Link.Both, new List<int> { 1, 1, 1, 1, 1, 1 } },
                            { Link.Cycle, new List<int> { 1, 1, 1, 1, 1 } },
                            { Link.None, new List<int> { 1, 1, 1, 1 } }
                        }
                };
    }
}
