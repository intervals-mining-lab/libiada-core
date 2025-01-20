namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Storage of varios sequences orders and elements for testing.
/// </summary>
public static class SequencesStorage
{
    /// <summary>
    /// Creates dictionary of elements with their string reprasentations as keys.
    /// </summary>
    public static Dictionary<string, IBaseObject> Elements => new()
    {
        { "A", new ValueString("A") },
        { "B", new ValueString("B") },
        { "C", new ValueString("C") },
        { "G", new ValueString("G") },
        { "T", new ValueString("T") }
    };

    /// <summary>
    /// Creates list of sequences.
    /// </summary>
    public static List<ComposedSequence> CompusedSequences =>
    [
        // 0 B B A A C B A C C B
        //   _ _ A A _ _ A _ _ _
        //   B B _ _ _ B _ _ _ B
        //   _ _ _ _ C _ _ C C _
        new ComposedSequence("BBAACBACCB"),

        // 1 A C T T G A T A C G
        //   A _ _ _ _ A _ A _ _
        //   _ C _ _ _ _ _ _ C _
        //   _ _ T T _ _ T _ _ _
        //   _ _ _ _ G _ _ _ _ G
        new ComposedSequence("ACTTGATACG"),

        // 2 C C A C G C T T A C
        //   C C _ C _ C _ _ _ C
        //   _ _ A _ _ _ _ _ A _
        //   _ _ _ _ G _ _ _ _ _
        //   _ _ _ _ _ _ T T _ _
        new ComposedSequence("CCACGCTTAC"),

        // 3 C G
        //   C _
        //   _ G
        new ComposedSequence("CG"),

        // 4 C C C C
        new ComposedSequence("CCCC"),

        // 5 A C G T
        //   A _ _ _
        //   _ C _ _
        //   _ _ G _
        //   _ _ _ T
        new ComposedSequence("ACGT"),

        // 6 A A A A C G T
        //   A A A A _ _ _
        //   _ _ _ _ C _ _
        //   _ _ _ _ _ G _
        //   _ _ _ _ _ _ T
        new ComposedSequence("AAAACGT"),

        // 7 T A
        //   T _
        //   _ A
        new ComposedSequence("TA"),

        // 8 T T T T
        new ComposedSequence("TTTT"),

        // 9 A B C A B C A B C
        //   A _ _ A _ _ A _ _
        //   _ B _ _ B _ _ B _
        //   _ _ C _ _ C _ _ C
        new ComposedSequence("ABCABCABC"),

        // 10 C B C A B C A B C
        //    - _ _ A _ _ A _ _
        //    _ B _ _ B _ _ B _
        //    C _ C _ _ C _ _ C
        new ComposedSequence("CBCABCABC"),

        // 11 A B A A B C A B C
        //    A _ A A _ _ A _ _
        //    _ B _ _ B _ _ B _
        //    _ _ _ _ _ C _ _ C
        new ComposedSequence("ABAABCABC"),

        // 12 A B B A B C A B C
        //    A _ _ A _ _ A _ _
        //    _ B B _ B _ _ B _
        //    _ _ _ _ _ C _ _ C
        new ComposedSequence("ABBABCABC"),

        // 13 A B C A B B A B C
        //    A _ _ A _ _ A _ _
        //    _ B _ _ B B _ B _
        //    _ _ C _ _ _ _ _ C
        new ComposedSequence("ABCABBABC"),

        // 14 A B C A B C A A C
        //    A _ _ A _ _ A A _
        //    _ B _ _ B _ _ _ _
        //    _ _ C _ _ C _ _ C
        new ComposedSequence("ABCABCAAC"),

        // 15 A B C A B C A C C
        //    A _ _ A _ _ A _ _
        //    _ B _ _ B _ _ _ _
        //    _ _ C _ _ C _ C C
        new ComposedSequence("ABCABCACC"),

        // 16 A B C A B C A B B
        //    A _ _ A _ _ A _ _
        //    _ B _ _ B _ _ B B
        //    _ _ C _ _ C _ _ _
        new ComposedSequence("ABCABCABB"),

        // 17 A B C A B C A B C
        //    A _ _ A _ _ A _ _
        //    _ B _ _ B _ _ B _
        //    _ _ C _ _ C _ _ C
        new ComposedSequence("ABCABCABC"),

        // 18 _ _ _ _ _ _ _ _ _ _
        new ComposedSequence(
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance()]),

        // 19 A _ _ _ _ _ _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"]]),

        // 20 _ A _ _ _ _ _ _ _ _
        new ComposedSequence(
            [0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"]]),

        // 21 A A _ _ _ _ _ _ _ _
        new ComposedSequence(
            [1, 1, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"]]),

        // 22 A B _ _ _ _ _ _ _ _
        new ComposedSequence(
            [1, 2, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 23 B _ _ _ _ _ _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["B"]]),

        // 24 A _ _ A _ _ _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"]]),

        // 25 A _ _ _ _ B _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 0, 0, 2, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 26 A _ _ B _ B _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 2, 0, 2, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 27 A _ _ _ _ C _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 0, 0, 2, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["C"]]),

        // 28 A _ _ B _ C _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 2, 0, 3, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"], Elements["C"]]),

        // 29 _ _ _ _ _ C _ _ _ _
        new ComposedSequence(
            [0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["C"]]),

        // 30 A B A A B
        //    A _ A A _
        //    _ B _ _ B
        new ComposedSequence("ABAAB")

    ];

    /// <summary>
    /// Cretes list of sequences of "high order".
    /// </summary>
    public static List<ComposedSequence> HighOrderSequences =>
    [
        // 1 1 3 1 5 4 3 3 1 4
        new ComposedSequence(new List<ValueInt> { 1, 1, 3, 1, 5, 4, 3, 3, 1, 4 }), // 0

        // 5 7 1 3 5 2 4 3 2 1
        new ComposedSequence(new List<ValueInt> { 5, 7, 1, 3, 5, 2, 4, 3, 2, 1 }), // 1

        // 1 2 3 1 5 5 3 2 7 5
        new ComposedSequence(new List<ValueInt> { 1, 2, 3, 1, 5, 5, 3, 2, 7, 5 }), // 2

        // 1 4 1 3 3 4 4 1 2 1
        new ComposedSequence(new List<ValueInt> { 1, 4, 1, 3, 3, 4, 4, 1, 2, 1 }), // 3

        // 1 4 1 3 3 4 6 1 6 1
        new ComposedSequence(new List<ValueInt> { 1, 4, 1, 3, 3, 4, 6, 1, 6, 1 }), // 4


        // 1 1 6 1 6 4 3 3 1 4
        new ComposedSequence(new List<ValueInt> { 1, 1, 6, 1, 6, 4, 3, 3, 1, 4 }), // 5

        // 2 4 5 1 6 1 4 2 2 1
        new ComposedSequence(new List<ValueInt> { 2, 4, 5, 1, 6, 1, 4, 2, 2, 1 }), // 6
    ];

    /// <summary>
    /// Cretes list of sequences for concatenation.
    /// </summary>
    public static List<ComposedSequence> ConcatinationSequences =>
    [
        new ComposedSequence("BBAACBACCB"), // 0
        new ComposedSequence("ACTTGATACG"), // 1
        new ComposedSequence("CCACGCTTAC"), // 2
        new ComposedSequence("BBAACBACCBACTTGATACGCCACGCTTAC"), // 3
        new ComposedSequence("BBAACBACCBCCACGCTTACACTTGATACG"), // 4
        new ComposedSequence("ACTTGATACGBBAACBACCBCCACGCTTAC"), // 5 
        new ComposedSequence("ACTTGATACGCCACGCTTACBBAACBACCB"), // 6
        new ComposedSequence("CCACGCTTACBBAACBACCBACTTGATACG"), // 7
        new ComposedSequence("CCACGCTTACACTTGATACGBBAACBACCB") // 8
    ];


    /// <summary>
    /// Creates list of dissimilar sequences.
    /// </summary>
    public static List<ComposedSequence> DissimilarSequences =>
    [
        // 1 2 1 2 1 3 3 2 3 4
        new ComposedSequence(new List<ValueInt> { 1, 2, 1, 2, 1, 3, 3, 2, 3, 4 }), // 0

        // 1 1 1 2 1 2 3 3 2 2
        new ComposedSequence(new List<ValueInt> { 1, 1, 1, 2, 1, 2, 3, 3, 2, 2 }), // 1

        // 1 2 1 3 1 4 1 2 2 5
        new ComposedSequence(new List<ValueInt> { 1, 2, 1, 3, 1, 4, 1, 2, 2, 5 }), // 2

        // 1 1 2 2 3 1 2 3 3 1
        new ComposedSequence(new List<ValueInt> { 1, 1, 2, 2, 3, 1, 2, 3, 3, 1 }), // 3

        // 1 2 3 1 4 2 1 2 3 4
        new ComposedSequence(new List<ValueInt> { 1, 2, 3, 1, 4, 2, 1, 2, 3, 4 }), // 4

        // 1 1 2 1 3 1 4 2 3 1
        new ComposedSequence(new List<ValueInt> { 1, 1, 2, 1, 3, 1, 4, 2, 3, 1 }), // 5
    ];

    /// <summary>
    /// Creates list of congeneric sequences.
    /// </summary>
    public static List<CongenericSequence> CongenericSequences =>
    [
        // 0  _ _ _ A A _ _ A _ _
        new CongenericSequence([3, 4, 7], Elements["A"], 10),

        // 1  _ _ _ B _ B B _ _ _ _ B _ _ _
        new CongenericSequence([3, 5, 6, 11], Elements["B"], 15),

        // 2  B
        new CongenericSequence([0], Elements["A"], 1),

        // 3  _ _ _ _ _ _ _ B
        new CongenericSequence([7], Elements["A"], 8),

        // 4
        new CongenericSequence([100, 100000, 500000], Elements["A"], 1000000),

        // 5  A A A A A
        new CongenericSequence([0, 1, 2, 3, 4], Elements["A"], 5),

        // 6  A _ _ A _ _ _ _ _ _ _ _ _ _ _ _ _ _
        new CongenericSequence([0, 3], Elements["A"], 18),

        // 7  _ _ A _ _ _ _ _ _ _ _ _ _ _ _ _ _ A
        new CongenericSequence([2, 17], Elements["A"], 18),

        // 8  A _ _ _ _ A _ _ _ _ _ A _ _ _ _ _ _ _ A _ _ _ _ A _ _ _ _
        new CongenericSequence([0, 5, 11, 19, 24], Elements["A"], 30),

        // 9  _ _ A _ _ _ A _ _ _ _ _ _ _ _ A _ _ _ _ _ _ _ A _ _ A _ _
        new CongenericSequence([2, 6, 15, 23, 26], Elements["A"], 30),

        // 10 A _ _ _ _ _ _ _ A _ A _ _ A _ _ _ _ _ _
        new CongenericSequence([0, 8, 10, 13], Elements["A"], 20),

        // 11 _ A A _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ A _
        new CongenericSequence([1, 2, 18], Elements["A"], 20),

        // 12 A _ _ _ _ _ _ _ A _ _ A _ A _ A _ A _ A _ _ _ _ A _ _
        new CongenericSequence([0, 8, 11, 13, 15, 17, 19, 24], Elements["A"], 27),

        // 13 _ A _ A A _ A _ _ A A _ _ _ _ _ _ _ _ _ _ _ A _ _ _ A
        new CongenericSequence([1, 3, 4, 6, 9, 10, 22, 26], Elements["A"], 27),

        // 14 A _ _ A _ _ _ _ _ A _ A _ _ _ _ _
        new CongenericSequence([0, 3, 9, 11], Elements["A"], 17),

        // 15 _ A _ _ _ _ _ A _ _ A _ _ _ A _ _
        new CongenericSequence([1, 7, 10, 14], Elements["A"], 17),

        // 16 A _ _ _ A _ _ _ _ _ A _ _ A _ _ _ _ _ _ _ _ _
        new CongenericSequence([0, 4, 10, 13], Elements["A"], 23),

        // 17 _ A _ _ _ _ _ _ _ A _ _ A _ _ _ _ _ A _ _ _ _
        new CongenericSequence([1, 9, 12, 18], Elements["A"], 23),
    ];

    /// <summary>
    /// Creates list of "binary" sequences.
    /// </summary>
    public static List<ComposedSequence> BinarySequences =>
    [

        // 0 A A B A _ A _ _ B A
        new ComposedSequence(
            [1, 1, 2, 1, 0, 1, 0, 0, 2, 1],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // ----------- sequences from Morozenko's paper -----------
        // 1 A B
        new ComposedSequence(
            [1, 2],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 2 A _ _ B _ _
        new ComposedSequence(
            [1, 0, 0, 2, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 3 A _ _ B A _ _ _ _ B _ _ A _ _ _ B _ _ A _ _ _ _ _ _ B
        new ComposedSequence(
            [1, 0, 0, 2, 1, 0, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 4 A B _ _ _
        new ComposedSequence(
            [1, 2, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 5 A B _ _ _ _ _ _ _ _ _ _
        new ComposedSequence(
            [1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 6 A _ _ _ _ _ _ _ _ _ _ _ B
        new ComposedSequence(
            [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 7 A _ _ _ _ _ _ _ B _ B B A _ _ A A A _ _ A _ _ _ _ _ B
        new ComposedSequence(
            [1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 2],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 8 A _ _ A _ _ B _ _ _ _ _ A A _ A _ A _ _ _ B _ A B
        new ComposedSequence(
            [1, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 2, 0, 1, 2],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 9 A _ B A A _ A _ _ _ _ _ _ _ _ _ _ B A _ _ A _ _ _ _ _ _ B
        new ComposedSequence(
            [1, 0, 2, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 10 A _ _ _ B _ _ _ A _ _ _ B _ _ _ A B A B _ _ _ _ _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 1, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 11 A _ B _ _ _ _ _ _ A _ B _ _ _ _ A _ _ B _ _ _ _ A B _ _
        new ComposedSequence(
            [1, 0, 2, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 1, 2, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 12 A _ _ _ B _ _ _ A _ _ _ B _ _ _
        new ComposedSequence(
            [1, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 13 A _ _ B _ _ A _ _ B A _ _ B _ _ _ _ A _ _ B _ _ _ _ _ _ _ _
        new ComposedSequence(
            [1, 0, 0, 2, 0, 0, 1, 0, 0, 2, 1, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 14 _ _ _ _ A B _ _ A B _ _ _ _ A B _ _ A B _ _ _
        new ComposedSequence(
            [0, 0, 0, 0, 1, 2, 0, 0, 1, 2, 0, 0, 0, 0, 1, 2, 0, 0, 1, 2, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 15 _ B _ B A B _ _ B _ _ _
        new ComposedSequence(
            [0, 2, 0, 2, 1, 2, 0, 0, 2, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 16 _ _ A _ _ _ B _ _ A A _ _ _ B _ _ A _ _ _ _ B _ _ _ _ _ _
        new ComposedSequence(
            [0, 0, 1, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // -------------- sequences from the monograph --------------
        // 17  A _ B _ _ _ A _ B _ _ _ A _ _ _ _ _ _ B _ _ _ _ _ _
        new ComposedSequence(
            [1, 0, 2, 0, 0, 0, 1, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 18 A B C B A B C C B C C C
        new ComposedSequence(
            [1, 2, 3, 2, 1, 2, 3, 3, 2, 3, 3, 3],
            [NullValue.Instance(), Elements["A"], Elements["B"], Elements["C"]]),

        // 19 A B _ _ _ _ A B _ _ _ A B _ _ _ _ _ _ _ _ A B
        new ComposedSequence(
            [1, 2, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2],
            [NullValue.Instance(), Elements["A"], Elements["B"]]),

        // 20  A C A _ C C _ A A A C C A
        new ComposedSequence(
            [1, 2, 1, 0, 2, 2, 0, 1, 1, 1, 2, 2, 1],
            [NullValue.Instance(), Elements["A"], Elements["C"]])
    ];

    /// <summary>
    /// Creates dictionary of intervals with <see cref="Link"/> as keys.
    /// </summary>
    public static List<Dictionary<Link, List<int>>> Intervals =>
    [
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
    ];
}
