namespace LibiadaCore.Tests.Classes.Root
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// The chains storage.
    /// </summary>
    public static class ChainsStorage
    {
        /// <summary>
        /// The elements.
        /// </summary>
        private static readonly Dictionary<string, IBaseObject> Elements = new Dictionary<string, IBaseObject>
            {
                { "a", new ValueChar('a') },
                { "b", new ValueChar('b') },
                { "c", new ValueChar('c') }
            };

        /// <summary>
        /// Gets the chains.
        /// </summary>
        public static List<Chain> Chains
        {
            get
            {
                var chains = new List<Chain>();

                // b b a a c b a c c b
                // _ _ a a _ _ a _ _ _
                // b b _ _ _ b _ _ _ b
                // _ _ _ _ c _ _ c c _
                var chain = new Chain("bbaacbaccb");
                chains.Add(chain);

                return chains;
            }
        }

        /// <summary>
        /// Gets the congeneric chains.
        /// </summary>
        public static List<CongenericChain> CongenericChains
        {
            get
            {
                var congenericChains = new List<CongenericChain>();

                // _ _ _ a a _ _ a _ _
                var firstChain = new CongenericChain(10, Elements["a"]);
                firstChain.Add(Elements["a"], 3);
                firstChain.Add(Elements["a"], 4);
                firstChain.Add(Elements["a"], 7);
                congenericChains.Add(firstChain);

                // _ _ _ b _ b b _ _ _ _ b _ _ _
                var secondChain = new CongenericChain(15, Elements["b"]);
                secondChain.Add(Elements["b"], 3);
                secondChain.Add(Elements["b"], 5);
                secondChain.Add(Elements["b"], 6);
                secondChain.Add(Elements["b"], 11);
                congenericChains.Add(secondChain);

                // a
                var thirdChain = new CongenericChain(1, Elements["a"]);
                thirdChain.Add(Elements["a"], 0);
                congenericChains.Add(thirdChain);

                // _ _ _ _ _ _ _ a
                var fourthChain = new CongenericChain(8, Elements["a"]);
                fourthChain.Add(Elements["a"], 7);
                congenericChains.Add(fourthChain);

                var fifthChain = new CongenericChain(1000000, Elements["a"]);
                fifthChain.Add(Elements["a"], 100);
                fifthChain.Add(Elements["a"], 100000);
                fifthChain.Add(Elements["a"], 500000);
                congenericChains.Add(fifthChain);

                // a a a a a
                var sixthChain = new CongenericChain(5, Elements["a"]);
                for (int i = 0; i < sixthChain.Length; i++)
                {
                    sixthChain.Add(Elements["a"], i);
                }

                congenericChains.Add(sixthChain);

                return congenericChains;
            }
        }

        /// <summary>
        /// Gets the intervals.
        /// </summary>
        public static List<Dictionary<Link, List<int>>> Intervals
        {
            get
            {
                return new List<Dictionary<Link, List<int>>>
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
    }
}