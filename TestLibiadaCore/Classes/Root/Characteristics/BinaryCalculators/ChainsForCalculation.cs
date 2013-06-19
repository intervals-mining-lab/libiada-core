using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public static class ChainsForCalculation
    {
        public static Dictionary<string,IBaseObject> Elements = new Dictionary<string, IBaseObject>()
            {
                {"a", new ValueChar('a')},
                {"b", new ValueChar('b')},
                {"c", new ValueChar('c')},
                {"g", new ValueChar('g')},
                {"t", new ValueChar('t')}
            };


        public static List<Chain> Chains
        {
            get
            {
                List<Chain> chains = new List<Chain>();

                //0
                Chain chain = new Chain(10);
                chain.Add(Elements["c"], 0);
                chain.Add(Elements["c"], 1);
                chain.Add(Elements["a"], 2);
                chain.Add(Elements["c"], 3);
                chain.Add(Elements["g"], 4);
                chain.Add(Elements["c"], 5);
                chain.Add(Elements["t"], 6);
                chain.Add(Elements["t"], 7);
                chain.Add(Elements["a"], 8);
                chain.Add(Elements["c"], 9);
                chains.Add(chain);

                // ----------- цепочки из работы Морозенко
                //1
                chain = new Chain(2);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 1);
                chains.Add(chain);

                //2
                chain = new Chain(6);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 3);
                chains.Add(chain);

                //3
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

                //4
                chain = new Chain(5);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 1);
                chains.Add(chain);

                //5
                chain = new Chain(12);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 1);
                chains.Add(chain);

                //6
                chain = new Chain(13);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["b"], 12);
                chains.Add(chain);

                //7
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

                //8
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

                //9
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

                //10
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

                //11
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

                //12
                chain = new Chain(16);
                chain.Add(Elements["a"], 0);
                chain.Add(Elements["a"], 8);
                chain.Add(Elements["b"], 4);
                chain.Add(Elements["b"], 12);
                chains.Add(chain);

                //13
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

                //14
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

                //15
                chain = new Chain(12);
                chain.Add(Elements["a"], 4);
                chain.Add(Elements["b"], 1);
                chain.Add(Elements["b"], 3);
                chain.Add(Elements["b"], 5);
                chain.Add(Elements["b"], 8);
                chains.Add(chain);

                //16
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
                //17
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

                //19
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
    }
}