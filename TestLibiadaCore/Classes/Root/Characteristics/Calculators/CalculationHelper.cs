using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public static class CalculationHelper
    {
        public static Dictionary<string, IBaseObject> Elements = new Dictionary<string, IBaseObject>()
            {
                {"a", new ValueChar('a')},
                {"b", new ValueChar('b')},
                {"c", new ValueChar('c')}
            };

        public static List<Chain> Chains
        {
            get
            {
                List<Chain> chains = new List<Chain>();

                //b b a a c b a c c b
                //_ _ a a _ _ a _ _ _
                //b b _ _ _ b _ _ _ b
                //_ _ _ _ c _ _ c c _
                Chain chain = new Chain(10);
                chain.Add(Elements["b"], 0);
                chain.Add(Elements["b"], 1);
                chain.Add(Elements["a"], 2);
                chain.Add(Elements["a"], 3);
                chain.Add(Elements["c"], 4);
                chain.Add(Elements["b"], 5);
                chain.Add(Elements["a"], 6);
                chain.Add(Elements["c"], 7);
                chain.Add(Elements["c"], 8);
                chain.Add(Elements["b"], 9);
                chains.Add(chain);

                return chains;
            }
        }

        public static List<UniformChain> UniformChains
        {
            get
            {
                List<UniformChain> uniformChains = new List<UniformChain>();
                // _ _ _ a a _ _ a _ _
                UniformChain uChain = new UniformChain(10, Elements["a"]);
                uChain.Add(Elements["a"], 3);
                uChain.Add(Elements["a"], 4);
                uChain.Add(Elements["a"], 7);
                uniformChains.Add(uChain);

                return uniformChains;
            }
        }
    }
}