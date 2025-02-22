namespace Libiada.PhantomChains;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.SpaceReorganizers;

using MarkovChains.MarkovChain.Generators;

/// <summary>
/// Phantom sequences generator.
/// </summary>
public class PhantomSequenceGenerator
{
    /// <summary>
    /// Number of possible variants for given sequence.
    /// </summary>
    public readonly ulong Variants = ulong.MaxValue;

    /// <summary>
    /// The basic sequence length.
    /// </summary>
    private const int BasicSequenceLength = 30;

    /// <summary>
    /// The temp sequences.
    /// </summary>
    private readonly List<Sequence> tempSequences = [];

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
    /// Initializes a new instance of the <see cref="PhantomSequenceGenerator"/> class.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="generator">
    /// The gen.
    /// </param>
    public PhantomSequenceGenerator(Sequence sequence, IGenerator generator)
    {
        this.generator = generator;
        SpacePhantomReorganizer reorganizer = new();
        Sequence internalSequence = (Sequence)reorganizer.Reorganize(sequence);
        for (int w = 0; w < internalSequence.Length; w++)
        {
            totalLength += ((ValuePhantom)internalSequence[w])[0].ToString().Length;
        }

        ulong tempVariants = 1;
        int counter = 0;
        for (int k = 0; k < (int)Math.Ceiling((double)internalSequence.Length / BasicSequenceLength); k++)
        {
            tempSequences.Add(new Sequence());
            tempSequences[k].ClearAndSetNewLength(BasicSequenceLength);
            tree.Add(null);
        }

        // variants count calculation cycle
        for (int i = 0; i < tempSequences.Count; i++)
        {
            for (int j = 0; j < tempSequences[i].Length; j++)
            {
                ValuePhantom tempMessage;
                if (counter < internalSequence.Length)
                {
                    tempMessage = (ValuePhantom)internalSequence[counter];
                    tempSequences[i][j] = tempMessage;
                }
                else
                {
                    tempMessage = [new ValueString('a')];
                    tempSequences[i][j] = tempMessage;
                }

                tempVariants *= (uint)tempMessage.Cardinality;
                counter++;
            }

            if ((i != tempSequences.Count - 1) || (tempSequences.Count == 1))
            {
                Variants = Math.Min(Variants, tempVariants);
            }

            tempVariants = 1;
            tree[i] = new TreeTop(tempSequences[i], generator);
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
    public List<Sequence> Generate(ulong count)
    {
        if (count > Variants)
        {
            throw new Exception();
        }

        List<Sequence> res = [];
        List<Sequence> tempRes = [];
        for (int m = 0; m < tree.Count; m++)
        {
            tempRes.Add(null);
        }

        generator.Reset();
        int sequenceCounter = 0;
        while (res.Count != (uint)count)
        {
            int counter = 0;
            res.Add(new Sequence(totalLength));
            for (int l = 0; l < tree.Count; l++)
            {
                tempRes[l] = tree[l].Generate();
                for (int u = 0; u < tempRes[l].Length; u++)
                {
                    if (counter < res[sequenceCounter].Length)
                    {
                        res[sequenceCounter][counter] = tempRes[l][u];
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            sequenceCounter++;
            if (tree.Count != 1)
            {
                tree[^1] = new TreeTop(tempSequences[^1], generator);
            }
        }

        for (int s = 0; s < tree.Count; s++)
        {
            tree[s] = new TreeTop(tempSequences[s], generator);
        }

        return res;
    }
}
