namespace LibiadaCoreTest.Classes.Root
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// </summary>
    public static class ChainsStorage
    {
        public static Dictionary<string, IBaseObject> Elements = new Dictionary<string, IBaseObject>
            {
                {"a", new ValueChar('a')},
                {"b", new ValueChar('b')},
                {"c", new ValueChar('c')}
            };

        public static List<Chain> Chains
        {
            get
            {
                var chains = new List<Chain>();

                //b b a a c b a c c b
                //_ _ a a _ _ a _ _ _
                //b b _ _ _ b _ _ _ b
                //_ _ _ _ c _ _ c c _
                var chain = new Chain("bbaacbaccb");
                chains.Add(chain);

                return chains;
            }
        }

        public static List<CongenericChain> CongenericChains
        {
            get
            {
                var congenericChains = new List<CongenericChain>();
                // _ _ _ a a _ _ a _ _
                var uChain = new CongenericChain(10, Elements["a"]);
                uChain.Add(Elements["a"], 3);
                uChain.Add(Elements["a"], 4);
                uChain.Add(Elements["a"], 7);
                congenericChains.Add(uChain);

                // _ _ _ b _ b b _ _ _ _ b _ _ _
                uChain = new CongenericChain(15, Elements["b"]);
                uChain.Add(Elements["b"], 3);
                uChain.Add(Elements["b"], 5);
                uChain.Add(Elements["b"], 6);
                uChain.Add(Elements["b"], 11);
                congenericChains.Add(uChain);

                return congenericChains;
            }
        }

        public static List<Dictionary<Link, List<int>>> Intervals
        {
            get
            {
                var result = new List<Dictionary<Link, List<int>>>();
                var firstDictionary = new Dictionary<Link, List<int>>
                {
                    {Link.Start, new List<int> {4, 1, 3}},
                    {Link.End, new List<int> {1, 3, 3}},
                    {Link.Both, new List<int> {4, 1, 3, 3}},
                    {Link.Cycle, new List<int> {1, 3, 6}},
                    {Link.None, new List<int> {1, 3}}
                };
                result.Add(firstDictionary);

                var secondDictionary = new Dictionary<Link, List<int>>
                {
                    {Link.Start, new List<int> {4, 2, 1, 5}},
                    {Link.End, new List<int> {2, 1, 5, 4}},
                    {Link.Both, new List<int> {4, 2, 1, 5, 4}},
                    {Link.Cycle, new List<int> {2, 1, 5, 7}},
                    {Link.None, new List<int> {2, 1, 5}}
                };
                result.Add(secondDictionary);

                return result;
            }
        }
    }
}