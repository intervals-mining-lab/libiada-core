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
                this.totalLength += ((ValuePhantom)internalChain[w])[0].ToString().Length;
            }

            ulong tempVariants = 1;
            int counter = 0;
            for (int k = 0; k < (int)Math.Ceiling((double)internalChain.GetLength() / BasicChainLength); k++)
            {
                this.tempChains.Add(new BaseChain());
                this.tempChains[k].ClearAndSetNewLength(BasicChainLength);
                this.tree.Add(null);
            }

            // цикл подсчёта вариантов в каждом дереве 
            // и создания деревьев
            for (int i = 0; i < this.tempChains.Count; i++)
            {
                for (int j = 0; j < this.tempChains[i].GetLength(); j++)
                {
                    ValuePhantom tempMessage;
                    if (counter < internalChain.GetLength())
                    {
                        tempMessage = (ValuePhantom)internalChain[counter];
                        this.tempChains[i][j] = tempMessage;
                    }
                    else
                    {
                        tempMessage = new ValuePhantom { new ValueChar('a') };
                        this.tempChains[i][j] = tempMessage;
                    }

                    tempVariants *= (uint)tempMessage.Cardinality;
                    counter++;
                }

                if ((i != this.tempChains.Count - 1) || (this.tempChains.Count == 1))
                {
                    this.Variants = Math.Min(this.Variants, tempVariants);
                }

                tempVariants = 1;
                this.tree[i] = new TreeTop(this.tempChains[i], this.generator);
            }
        }

        /// <summary>
        /// Метод осуществляет генерацию заданного количества цепей
        /// </summary>
        /// <param name="i">Требуемое количество генетических последовательностей</param>
        /// <returns>Массив цепочек</returns>
        public List<BaseChain> Generate(ulong i)
        {
            if (i > this.Variants)
            {
                throw new Exception();
            }

            var res = new List<BaseChain>();
            var tempRes = new List<BaseChain>();
            for (int m = 0; m < this.tree.Count; m++)
            {
                tempRes.Add(null);
            }

            this.generator.Reset();
            int chainCounter = 0;
            while (res.Count != (uint)i)
            {
                int counter = 0;
                res.Add(new BaseChain(this.totalLength));
                for (int l = 0; l < this.tree.Count; l++)
                {
                    tempRes[l] = this.tree[l].Generate();
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
                if (this.tree.Count != 1)
                {
                    this.tree[this.tree.Count - 1] = new TreeTop(this.tempChains[this.tempChains.Count - 1], this.generator);
                }
            }

            for (int s = 0; s < this.tree.Count; s++)
            {
                this.tree[s] = new TreeTop(this.tempChains[s], this.generator);
            }

            return res;
        }
    }
}