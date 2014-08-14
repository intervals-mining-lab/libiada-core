namespace PhantomChains
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.SpaceReorganizers;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Генератор фаонтомных цепей.
    /// </summary>
    public class PhantomChainGenerator
    {
        /// <summary>
        /// Количество возможных вариантов для данной цепи
        /// </summary>
        public readonly ulong Variants = ulong.MaxValue;

        /// <summary>
        /// The basic chain length.
        /// </summary>
        private const int BasicChainLength = 30;

        /// <summary>
        /// The temp chains.
        /// </summary>
        private readonly List<BaseChain> tempChains = new List<BaseChain>();

        /// <summary>
        /// The gen.
        /// </summary>
        private readonly IGenerator generator;

        /// <summary>
        /// Древья вариантов построения для отдельных участков фантомной цепи (длиной 30 элементов)
        /// </summary>
        private readonly List<TreeTop> tree = new List<TreeTop>();

        /// <summary>
        /// The total length.
        /// </summary>
        private readonly int totalLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhantomChainGenerator{TResult,TSource}"/> class.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="gen">
        /// The gen.
        /// </param>
        public PhantomChainGenerator(BaseChain chain, IGenerator gen)
        {
            this.generator = gen;
            var reorganizer = new SpacePhantomReorganizer();
            BaseChain internalChain = (BaseChain)reorganizer.Reorganize(chain);
            for (int w = 0; w < internalChain.GetLength(); w++)
            {
                totalLength += ((ValuePhantom)internalChain[w])[0].ToString().Length;
            }

            ulong tempVariants = 1;
            int counter = 0;
            for (int k = 0; k < (int)Math.Ceiling((double)internalChain.GetLength() / BasicChainLength); k++)
            {
                tempChains.Add(new BaseChain());
                tempChains[k].ClearAndSetNewLength(BasicChainLength);
                tree.Add(null);
            }

            // цикл подсчёта вариантов в каждом дереве 
            // и создания деревьев
            for (int i = 0; i < tempChains.Count; i++)
            {
                for (int j = 0; j < tempChains[i].GetLength(); j++)
                {
                    ValuePhantom tempMessage;
                    if (counter < internalChain.GetLength())
                    {
                        tempMessage = (ValuePhantom)internalChain[counter];
                        tempChains[i][j] = tempMessage;
                    }
                    else
                    {
                        tempMessage = new ValuePhantom { new ValueChar('a') };
                        tempChains[i][j] = tempMessage;
                    }

                    tempVariants *= (uint)tempMessage.Cardinality;
                    counter++;
                }

                if ((i != tempChains.Count - 1) || (tempChains.Count == 1))
                {
                    Variants = Math.Min(Variants, tempVariants);
                }

                tempVariants = 1;
                tree[i] = new TreeTop(tempChains[i], generator);
            }
        }

        /// <summary>
        /// Метод осуществляет генерацию заданного количества цепей
        /// </summary>
        /// <param name="i">Требуемое количество генетических последовательностей</param>
        /// <returns>Массив цепочек</returns>
        public List<BaseChain> Generate(ulong i)
        {
            if (i > Variants)
            {
                throw new Exception();
            }

            var res = new List<BaseChain>();
            var tempRes = new List<BaseChain>();
            for (int m = 0; m < tree.Count; m++)
            {
                tempRes.Add(null);
            }

            generator.Reset();
            int chainCounter = 0;
            while (res.Count != (uint)i)
            {
                int counter = 0;
                res.Add(new BaseChain(totalLength));
                for (int l = 0; l < tree.Count; l++)
                {
                    tempRes[l] = tree[l].Generate();
                    for (int u = 0; u < tempRes[l].GetLength(); u++)
                    {
                        if (counter < res[chainCounter].GetLength())
                        {
                            res[chainCounter][counter] = tempRes[l][u];
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                chainCounter++;
                if (tree.Count != 1)
                {
                    tree[tree.Count - 1] = new TreeTop(tempChains[tempChains.Count - 1], generator);
                }
            }

            for (int s = 0; s < tree.Count; s++)
            {
                tree[s] = new TreeTop(tempChains[s], generator);
            }

            return res;
        }
    }
}