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
        /// The elements.
        /// </summary>
        public static Dictionary<string, IBaseObject> Elements
        {
            get
            {
                return new Dictionary<string, IBaseObject>
                           {
                               { "a", new ValueString("A") },
                               { "b", new ValueString("B") },
                               { "c", new ValueString("C") },
                               { "g", new ValueString("G") },
                               { "t", new ValueString("T") }
                           };
            }
        }

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

                // 20 
                chain = new Chain(10);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["c"], 1);
                chain.Add(Elements["t"], 2);
                chain.Add(Elements["t"], 3);
                chain.Add(Elements["g"], 4);
                chain.Add(Elements["a"], 5);
                chain.Add(Elements["t"], 6);
                chain.Add(Elements["a"], 7);
                chain.Add(Elements["c"], 8);
                chain.Add(Elements["g"], 9);

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
                var firstChain = new CongenericChain(Elements["a"], 10);
                firstChain.Add(Elements["a"], 3);
                firstChain.Add(Elements["a"], 4);
                firstChain.Add(Elements["a"], 7);
                congenericChains.Add(firstChain);

                // _ _ _ b _ b b _ _ _ _ b _ _ _
                var secondChain = new CongenericChain(Elements["b"], 15);
                secondChain.Add(Elements["b"], 3);
                secondChain.Add(Elements["b"], 5);
                secondChain.Add(Elements["b"], 6);
                secondChain.Add(Elements["b"], 11);
                congenericChains.Add(secondChain);

                // a
                var thirdChain = new CongenericChain(Elements["a"], 1);
                thirdChain.Add(Elements["a"], 0);
                congenericChains.Add(thirdChain);

                // _ _ _ _ _ _ _ a
                var fourthChain = new CongenericChain(Elements["a"], 8);
                fourthChain.Add(Elements["a"], 7);
                congenericChains.Add(fourthChain);

                var fifthChain = new CongenericChain(Elements["a"], 1000000);
                fifthChain.Add(Elements["a"], 100);
                fifthChain.Add(Elements["a"], 100000);
                fifthChain.Add(Elements["a"], 500000);
                congenericChains.Add(fifthChain);

                // a a a a a
                var sixthChain = new CongenericChain(Elements["a"], 5);
                for (int i = 0; i < sixthChain.GetLength(); i++)
                {
                    sixthChain.Add(Elements["a"], i);
                }

                congenericChains.Add(sixthChain);

                return congenericChains;
            }
        }

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
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 1);
                chain.Add(Elements["b"], 2);
                chain.Add(Elements["a"], 3);
                chain.Add(Elements["a"], 5);
                chain.Add(Elements["b"], 8);
                chain.Add(Elements["a"], 9);
                chains.Add(chain);

                // ----------- цепочки из работы Морозенко
                // 1
                chain = new Chain(2);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 1);
                chains.Add(chain);

                // 2
                chain = new Chain(6);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 3);
                chains.Add(chain);

                // 3
                chain = new Chain(27);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 4);
                chain.Add(Elements["a"], 12);
                chain.Add(Elements["a"], 19);
                chain.Add(Elements["b"], 3);
                chain.Add(Elements["b"], 9);
                chain.Add(Elements["b"], 16);
                chain.Add(Elements["b"], 26);
                chains.Add(chain);

                // 4
                chain = new Chain(5);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 1);
                chains.Add(chain);

                // 5
                chain = new Chain(12);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 1);
                chains.Add(chain);

                // 6
                chain = new Chain(13);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 12);
                chains.Add(chain);

                // 7
                chain = new Chain(29);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 14);
                chain.Add(Elements["a"], 17);
                chain.Add(Elements["a"], 18);
                chain.Add(Elements["a"], 19);
                chain.Add(Elements["a"], 22);
                chain.Add(Elements["b"], 8);
                chain.Add(Elements["b"], 10);
                chain.Add(Elements["b"], 12);
                chain.Add(Elements["b"], 13);
                chain.Add(Elements["b"], 28);
                chains.Add(chain);

                // 8
                chain = new Chain(25);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 3);
                chain.Add(Elements["a"], 12);
                chain.Add(Elements["a"], 13);
                chain.Add(Elements["a"], 15);
                chain.Add(Elements["a"], 17);
                chain.Add(Elements["a"], 23);
                chain.Add(Elements["b"], 6);
                chain.Add(Elements["b"], 21);
                chain.Add(Elements["b"], 24);
                chains.Add(chain);

                // 9
                chain = new Chain(29);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 3);
                chain.Add(Elements["a"], 4);
                chain.Add(Elements["a"], 6);
                chain.Add(Elements["a"], 18);
                chain.Add(Elements["a"], 21);
                chain.Add(Elements["b"], 2);
                chain.Add(Elements["b"], 17);
                chain.Add(Elements["b"], 28);
                chains.Add(chain);

                // 10
                chain = new Chain(28);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 8);
                chain.Add(Elements["a"], 16);
                chain.Add(Elements["a"], 18);
                chain.Add(Elements["b"], 4);
                chain.Add(Elements["b"], 12);
                chain.Add(Elements["b"], 17);
                chain.Add(Elements["b"], 19);
                chains.Add(chain);

                // 11
                chain = new Chain(28);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 9);
                chain.Add(Elements["a"], 16);
                chain.Add(Elements["a"], 24);
                chain.Add(Elements["b"], 2);
                chain.Add(Elements["b"], 11);
                chain.Add(Elements["b"], 19);
                chain.Add(Elements["b"], 25);
                chains.Add(chain);

                // 12
                chain = new Chain(16);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 8);
                chain.Add(Elements["b"], 4);
                chain.Add(Elements["b"], 12);
                chains.Add(chain);

                // 13
                chain = new Chain(30);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 6);
                chain.Add(Elements["a"], 10);
                chain.Add(Elements["a"], 18);
                chain.Add(Elements["b"], 3);
                chain.Add(Elements["b"], 9);
                chain.Add(Elements["b"], 13);
                chain.Add(Elements["b"], 21);
                chains.Add(chain);

                // 14
                chain = new Chain(23);
                chain.Add(Elements["a"], 4);
                chain.Add(Elements["a"], 8);
                chain.Add(Elements["a"], 14);
                chain.Add(Elements["a"], 18);
                chain.Add(Elements["b"], 5);
                chain.Add(Elements["b"], 9);
                chain.Add(Elements["b"], 15);
                chain.Add(Elements["b"], 19);
                chains.Add(chain);

                // 15
                chain = new Chain(12);
                chain.Add(Elements["a"], 4);
                chain.Add(Elements["b"], 1);
                chain.Add(Elements["b"], 3);
                chain.Add(Elements["b"], 5);
                chain.Add(Elements["b"], 8);
                chains.Add(chain);

                // 16
                chain = new Chain(29);
                chain.Add(Elements["a"], 2);
                chain.Add(Elements["a"], 9);
                chain.Add(Elements["a"], 10);
                chain.Add(Elements["a"], 17);
                chain.Add(Elements["b"], 6);
                chain.Add(Elements["b"], 14);
                chain.Add(Elements["b"], 22);
                chains.Add(chain);

                // -------------- дальше цепочки из монографии
                // 17
                chain = new Chain(26);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 6);
                chain.Add(Elements["a"], 12);
                chain.Add(Elements["b"], 2);
                chain.Add(Elements["b"], 8);
                chain.Add(Elements["b"], 19);
                chains.Add(chain);

                // 18
                chain = new Chain(12);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 4);
                chain.Add(Elements["b"], 1);
                chain.Add(Elements["b"], 3);
                chain.Add(Elements["b"], 5);
                chain.Add(Elements["b"], 8);
                chain.Add(Elements["c"], 2);
                chain.Add(Elements["c"], 6);
                chain.Add(Elements["c"], 7);
                chain.Add(Elements["c"], 9);
                chain.Add(Elements["c"], 10);
                chain.Add(Elements["c"], 11);
                chains.Add(chain);

                // 19
                chain = new Chain(23);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 6);
                chain.Add(Elements["a"], 11);
                chain.Add(Elements["a"], 21);
                chain.Add(Elements["b"], 1);
                chain.Add(Elements["b"], 7);
                chain.Add(Elements["b"], 12);
                chain.Add(Elements["b"], 22);
                chains.Add(chain);

                return chains;
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