namespace LibiadaCore.Tests.Core
{
    using System.Collections.Generic;
    using System.Linq;

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
        public static Dictionary<string, IBaseObject> Elements => new Dictionary<string, IBaseObject>
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
        public static List<Chain> Chains => new List<Chain>
        {
            // B B A A C B A C C B
            // _ _ A A _ _ A _ _ _
            // B B _ _ _ B _ _ _ B
            // _ _ _ _ C _ _ C C _
            new Chain("BBAACBACCB"), // 0

            // A C T T G A T A C G
            // A _ _ _ _ A _ A _ _
            // _ C _ _ _ _ _ _ C _
            // _ _ T T _ _ T _ _ _
            // _ _ _ _ G _ _ _ _ G
            new Chain("ACTTGATACG"), // 1

            // C C A C G C T T A C
            // C C _ C _ C _ _ _ C
            // _ _ A _ _ _ _ _ A _
            // _ _ _ _ G _ _ _ _ _
            // _ _ _ _ _ _ T T _ _
            new Chain("CCACGCTTAC"), // 2

            // C G
            // C _
            // _ G
            new Chain("CG"), // 3

            // C C C C
            // C C C C
            new Chain("CCCC"), // 4

            // A C G T
            // A _ _ _
            // _ C _ _
            // _ _ G _
            // _ _ _ T
            new Chain("ACGT"), // 5

            // A A A A C G T
            // A A A A _ _ _
            // _ _ _ _ C _ _
            // _ _ _ _ _ G _
            // _ _ _ _ _ _ T
            new Chain("AAAACGT"), // 6

            // T A
            // T _
            // _ A
            new Chain("TA"), // 7

            // T T T T
            // T T T T
            new Chain("TTTT"), // 8

            // A B C A B C A B C
            // A _ _ A _ _ A _ _
            // _ B _ _ B _ _ B _
            // _ _ C _ _ C _ _ C
            new Chain("ABCABCABC"), // 9

            // C B C A B C A B C
            // - _ _ A _ _ A _ _
            // _ B _ _ B _ _ B _
            // C _ C _ _ C _ _ C
            new Chain("CBCABCABC"), // 10

            // A B A A B C A B C
            // A _ A A _ _ A _ _
            // _ B _ _ B _ _ B _
            // _ _ _ _ _ C _ _ C
            new Chain("ABAABCABC"), // 11

            // A B B A B C A B C
            // A _ _ A _ _ A _ _
            // _ B B _ B _ _ B _
            // _ _ _ _ _ C _ _ C
            new Chain("ABBABCABC"), // 12

            // A B C A B B A B C
            // A _ _ A _ _ A _ _
            // _ B _ _ B B _ B _
            // _ _ C _ _ _ _ _ C
            new Chain("ABCABBABC"), // 13

            // A B C A B C A A C
            // A _ _ A _ _ A A _
            // _ B _ _ B _ _ _ _
            // _ _ C _ _ C _ _ C
            new Chain("ABCABCAAC"), // 14

            // A B C A B C A C C
            // A _ _ A _ _ A _ _
            // _ B _ _ B _ _ _ _
            // _ _ C _ _ C _ C C
            new Chain("ABCABCACC"), // 15

            // A B C A B C A B B
            // A _ _ A _ _ A _ _
            // _ B _ _ B _ _ B B
            // _ _ C _ _ C _ _ _
            new Chain("ABCABCABB"), // 16

            // A B C A B C A B C
            // A _ _ A _ _ A _ _
            // _ B _ _ B _ _ B _
            // _ _ C _ _ C _ _ C
            new Chain("ABCABCABC"), // 17

            // 18 _ _ _ _ _ _ _ _ _ _
            new Chain(
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance() }),

            // 19 A _ _ _ _ _ _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"] }),

            // 20 _ A _ _ _ _ _ _ _ _
            new Chain(
                new[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"] }),

            // 21 A A _ _ _ _ _ _ _ _
            new Chain(
                new[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"] }),

            // 22 A B _ _ _ _ _ _ _ _
            new Chain(
                new[] { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 23 B _ _ _ _ _ _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["B"] }),

            // 24 A _ _ A _ _ _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"] }),

            // 25 A _ _ _ _ B _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 26 A _ _ B _ B _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 2, 0, 2, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 27 A _ _ _ _ C _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["C"] }),

            // 28 A _ _ B _ C _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 2, 0, 3, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"], Elements["C"] }),

            // 29 _ _ _ _ _ C _ _ _ _
            new Chain(
                new[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["C"] })

        };

        /// <summary>
        /// Gets chains with high order.
        /// </summary>
        public static List<Chain> HighOrderChains => new List<Chain>
        {
            // 1 1 3 1 5 4 3 3 1 4
            new Chain(new ValueInt[] { 1, 1, 3, 1, 5, 4, 3, 3, 1, 4 }.Cast<IBaseObject>().ToList()), // 0

            // 5 7 1 3 5 2 4 3 2 1
            new Chain(new ValueInt[] { 5, 7, 1, 3, 5, 2, 4, 3, 2, 1 }.Cast<IBaseObject>().ToList()), // 1

            // 1 2 3 1 5 5 3 2 7 5
            new Chain(new ValueInt[] { 1, 2, 3, 1, 5, 5, 3, 2, 7, 5 }.Cast<IBaseObject>().ToList()), // 2

            // 1 4 1 3 3 4 4 1 2 1
            new Chain(new ValueInt[] { 1, 4, 1, 3, 3, 4, 4, 1, 2, 1 }.Cast<IBaseObject>().ToList()), // 3

            // 1 4 1 3 3 4 6 1 6 1
            new Chain(new ValueInt[] { 1, 4, 1, 3, 3, 4, 6, 1, 6, 1 }.Cast<IBaseObject>().ToList()), // 4


            // 1 1 6 1 6 4 3 3 1 4
            new Chain(new ValueInt[] { 1, 1, 6, 1, 6, 4, 3, 3, 1, 4 }.Cast<IBaseObject>().ToList()), // 5

            // 2 4 5 1 6 1 4 2 2 1
            new Chain(new ValueInt[] { 2, 4, 5, 1, 6, 1, 4, 2, 2, 1 }.Cast<IBaseObject>().ToList()), // 6
        };

        /// <summary>
        /// Gets the dissimilar chains.
        /// </summary>
        public static List<Chain> DissimilarChains => new List<Chain>
        {
            // 1 2 1 2 1 3 3 2 3 4
            new Chain(new ValueInt[] { 1, 2, 1, 2, 1, 3, 3, 2, 3, 4 }.Cast<IBaseObject>().ToList()), // 0

            // 1 1 1 2 1 2 3 3 2 2
            new Chain(new ValueInt[] { 1, 1, 1, 2, 1, 2, 3, 3, 2, 2 }.Cast<IBaseObject>().ToList()), // 1

            // 1 2 1 3 1 4 1 2 2 5
            new Chain(new ValueInt[] { 1, 2, 1, 3, 1, 4, 1, 2, 2, 5 }.Cast<IBaseObject>().ToList()), // 2

            // 1 1 2 2 3 1 2 3 3 1
            new Chain(new ValueInt[] { 1, 1, 2, 2, 3, 1, 2, 3, 3, 1 }.Cast<IBaseObject>().ToList()), // 3

            // 1 2 3 1 4 2 1 2 3 4
            new Chain(new ValueInt[] { 1, 2, 3, 1, 4, 2, 1, 2, 3, 4 }.Cast<IBaseObject>().ToList()), // 4

            // 1 1 2 1 3 1 4 2 3 1
            new Chain(new ValueInt[] { 1, 1, 2, 1, 3, 1, 4, 2, 3, 1 }.Cast<IBaseObject>().ToList()), // 5
        };

        /// <summary>
        /// Gets the congeneric chains.
        /// </summary>
        public static List<CongenericChain> CongenericChains => new List<CongenericChain>
        {
            // 0  _ _ _ A A _ _ A _ _
            new CongenericChain(new[] { 3, 4, 7 }, Elements["A"], 10),

            // 1  _ _ _ B _ B B _ _ _ _ B _ _ _
            new CongenericChain(new[] { 3, 5, 6, 11 }, Elements["B"], 15),

            // 2  B
            new CongenericChain(new[] { 0 }, Elements["A"], 1),

            // 3  _ _ _ _ _ _ _ B
            new CongenericChain(new[] { 7 }, Elements["A"], 8),

            // 4
            new CongenericChain(new[] { 100, 100000, 500000 }, Elements["A"], 1000000),

            // 5  A A A A A
            new CongenericChain(new[] { 0, 1, 2, 3, 4 }, Elements["A"], 5),

            // 6  A _ _ A _ _ _ _ _ _ _ _ _ _ _ _ _ _
            new CongenericChain(new[] { 0, 3 }, Elements["A"], 18),

            // 7  _ _ A _ _ _ _ _ _ _ _ _ _ _ _ _ _ a
            new CongenericChain(new[] { 2, 17 }, Elements["A"], 18),

            // 8  A _ _ _ _ A _ _ _ _ _ A _ _ _ _ _ _ _ A _ _ _ _ A _ _ _ _
            new CongenericChain(new[] { 0, 5, 11, 19, 24 }, Elements["A"], 30),

            // 9  _ _ A _ _ _ A _ _ _ _ _ _ _ _ A _ _ _ _ _ _ _ A _ _ A _ _
            new CongenericChain(new[] { 2, 6, 15, 23, 26 }, Elements["A"], 30),

            // 10 A _ _ _ _ _ _ _ A _ A _ _ A _ _ _ _ _ _
            new CongenericChain(new[] { 0, 8, 10, 13 }, Elements["A"], 20),

            // 11 _ A a _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ A _
            new CongenericChain(new[] { 1, 2, 18 }, Elements["A"], 20),

            // 12 A _ _ _ _ _ _ _ A _ _ A _ A _ A _ A _ A _ _ _ _ A _ _
            new CongenericChain(new[] { 0, 8, 11, 13, 15, 17, 19, 24 }, Elements["A"], 27),

            // 13 _ A _ A a _ A _ _ A a _ _ _ _ A _ _ _ _ _ _ A _ _ _ A
            new CongenericChain(new[] { 1, 3, 4, 6, 9, 10, 22, 26 }, Elements["A"], 27),

            // 14 A _ _ A _ _ _ _ _ A _ A _ _ _ _ _
            new CongenericChain(new[] { 0, 3, 9, 11 }, Elements["A"], 17),

            // 15 _ A _ _ _ _ _ A _ _ A _ _ _ A _ _
            new CongenericChain(new[] { 1, 7, 10, 14 }, Elements["A"], 17),

            // 16 A _ _ _ A _ _ _ _ _ A _ _ A _ _ _ _ _ _ _ _ _
            new CongenericChain(new[] { 0, 4, 10, 13 }, Elements["A"], 23),

            // 17 _ A _ _ _ _ _ _ _ A _ _ A _ _ _ _ _ A _ _ _ _
            new CongenericChain(new[] { 1, 9, 12, 18 }, Elements["A"], 23),
        };

        /// <summary>
        /// Gets the chains.
        /// </summary>
        public static List<Chain> BinaryChains => new List<Chain>
        {

            // 0 A A B A _ A _ _ B A
            new Chain(
                new[] { 1, 1, 2, 1, 0, 1, 0, 0, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // ----------- sequences from Morozenko's paper -----------
            // 1 A B
            new Chain(
                new[] { 1, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 2 A _ _ B _ _
            new Chain(
                new[] { 1, 0, 0, 2, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 3 A _ _ B A _ _ _ _ B _ _ A _ _ _ B _ _ A _ _ _ _ _ _ B
            new Chain(
                new[] { 1, 0, 0, 2, 1, 0, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 4 A B _ _ _
            new Chain(
                new[] { 1, 2, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 5 A B _ _ _ _ _ _ _ _ _ _
            new Chain(
                new[] { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 6 A _ _ _ _ _ _ _ _ _ _ _ B
            new Chain(
                new[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 7 A _ _ _ _ _ _ _ _ _ B _ B B A _ _ A A A _ _ A _ _ _ _ _ B
            new Chain(
                new[] { 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 8
            // 7 A _ _ A _ _ B _ _ _ _ _ A A _ A _ A _ _ _ B _ A B
            new Chain(
                new[] { 1, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 2, 0, 1, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 9 A _ B A A _ A _ _ _ _ _ _ _ _ _ _ B A _ _ A _ _ _ _ _ _ B
            new Chain(
                new[] { 1, 0, 2, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 10 A _ _ _ B _ _ _ A _ _ _ B _ _ _ A B A B _ _ _ _ _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 1, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 11 A _ B _ _ _ _ _ _ A _ B _ _ _ _ A _ _ B _ _ _ _ A B _ 0
            new Chain(
                new[] { 1, 0, 2, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 1, 2, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 12 A _ _ _ B _ _ _ A _ _ _ B _ _ _
            new Chain(
                new[] { 1, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 13 A _ _ B _ _ A _ _ B A _ _ B _ _ _ _ A _ _ B _ _ _ _ _ _ _ _
            new Chain(
                new[] { 1, 0, 0, 2, 0, 0, 1, 0, 0, 2, 1, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 14 _ _ _ _ A B _ _ A B _ _ _ _ A B _ _ A B _ _ _
            new Chain(
                new[] { 0, 0, 0, 0, 1, 2, 0, 0, 1, 2, 0, 0, 0, 0, 1, 2, 0, 0, 1, 2, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 15 _ B _ B A B _ _ B _ _ _
            new Chain(
                new[] { 0, 2, 0, 2, 1, 2, 0, 0, 2, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 16 _ _ A _ _ _ B _ _ A A _ _ _ B _ _ A _ _ _ _ B _ _ _ _ _ _
            new Chain(
                new[] { 0, 0, 1, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // -------------- sequences from the monograph --------------
            // 17  A _ B _ _ _ A _ B _ _ _ A _ _ _ _ _ _ B _ _ _ _ _ _
            new Chain(
                new[] { 1, 0, 2, 0, 0, 0, 1, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 18 A B C B A B C C B C C C
            new Chain(
                new[] { 1, 2, 3, 2, 1, 2, 3, 3, 2, 3, 3, 3 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"], Elements["C"] }),

            // 19 A B _ _ _ _ A B _ _ _ A B _ _ _ _ _ _ _ _ A B
            new Chain(
                new[] { 1, 2, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2 },
                new Alphabet() { NullValue.Instance(), Elements["A"], Elements["B"] }),

            // 20  A C A _ C C _ A A A C C A
            new Chain(
                new [] { 1, 2, 1, 0, 2, 2, 0, 1, 1, 1, 2, 2, 1 },
                new Alphabet(){ NullValue.Instance(), Elements["A"], Elements["C"] })
        };

        /// <summary>
        /// Gets the intervals.
        /// </summary>
        public static List<Dictionary<Link, List<int>>> Intervals => new List<Dictionary<Link, List<int>>>
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
