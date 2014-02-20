namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// </summary>
    public static class CalculationHelper
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

                return congenericChains;
            }
        }
    }
}