namespace Libiada.PhantomChains;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.SpaceReorganizers;

using MarkovChains.MarkovChain.Generators;

/// <summary>
/// Phantom sequences generator.
/// </summary>
public class PhantomChainGenerator
{
    /// <summary>
    /// Number of possible variants for given sequence.
    /// </summary>
    public readonly ulong Variants = ulong.MaxValue;

    /// <summary>
    /// The basic chain length.
    /// </summary>
    private const int BasicChainLength = 30;

    /// <summary>
    /// The temp chains.
    /// </summary>
    private readonly List<BaseChain> tempChains = [];

    /// <summary>
    /// The gen.
    /// </summary>
    private readonly IGenerator generator;

    /// <summary>
    /// Variants trees for separate fragments of phantom sequence (length 30 elements).
    /// </summary>
    private readonly List<TreeTop> tree = [];

    /// <summary>
    /// The total length.
    /// </summary>
    private readonly int totalLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="PhantomChainGenerator"/> class.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="generator">
    /// The gen.
    /// </param>
    public PhantomChainGenerator(BaseChain chain, IGenerator generator)
    {
        this.generator = generator;
        SpacePhantomReorganizer reorganizer = new();
        BaseChain internalChain = (BaseChain)reorganizer.Reorganize(chain);
        for (int w = 0; w < internalChain.Length; w++)
        {
            totalLength += ((ValuePhantom)internalChain[w])[0].ToString().Length;
        }

        ulong tempVariants = 1;
        int counter = 0;
        for (int k = 0; k < (int)Math.Ceiling((double)internalChain.Length / BasicChainLength); k++)
        {
            tempChains.Add(new BaseChain());
            tempChains[k].ClearAndSetNewLength(BasicChainLength);
            tree.Add(null);
        }

        // variants count calculation cycle
        for (int i = 0; i < tempChains.Count; i++)
        {
            for (int j = 0; j < tempChains[i].Length; j++)
            {
                ValuePhantom tempMessage;
                if (counter < internalChain.Length)
                {
                    tempMessage = (ValuePhantom)internalChain[counter];
                    tempChains[i][j] = tempMessage;
                }
                else
                {
                    tempMessage = [new ValueString('a')];
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
    /// Generates given number of sequences.
    /// </summary>
    /// <param name="count">
    /// Required sequences count.
    /// </param>
    /// <returns>
    /// Generated sequences.
    /// </returns>
    public List<BaseChain> Generate(ulong count)
    {
        if (count > Variants)
        {
            throw new Exception();
        }

        List<BaseChain> res = [];
        List<BaseChain> tempRes = [];
        for (int m = 0; m < tree.Count; m++)
        {
            tempRes.Add(null);
        }

        generator.Reset();
        int chainCounter = 0;
        while (res.Count != (uint)count)
        {
            int counter = 0;
            res.Add(new BaseChain(totalLength));
            for (int l = 0; l < tree.Count; l++)
            {
                tempRes[l] = tree[l].Generate();
                for (int u = 0; u < tempRes[l].Length; u++)
                {
                    if (counter < res[chainCounter].Length)
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
                tree[^1] = new TreeTop(tempChains[^1], generator);
            }
        }

        for (int s = 0; s < tree.Count; s++)
        {
            tree[s] = new TreeTop(tempChains[s], generator);
        }

        return res;
    }
}
