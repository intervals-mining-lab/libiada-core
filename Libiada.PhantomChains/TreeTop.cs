﻿namespace Libiada.PhantomChains;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

using MarkovChains.MarkovChain.Generators;

/// <summary>
/// Root node of variants tree.
/// </summary>
public class TreeTop : AbstractNode
{
    /// <summary>
    /// The table.
    /// </summary>
    private readonly PhantomTable table;

    /// <summary>
    /// The generator.
    /// </summary>
    private readonly IGenerator generator;

    /// <summary>
    /// The is string.
    /// </summary>
    private readonly bool isString;

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeTop"/> class,
    /// representing root element of the tree.
    /// </summary>
    /// <param name="source">
    /// The input sequence.
    /// </param>
    /// <param name="generator">
    /// The gen.
    /// </param>
    public TreeTop(Sequence source, IGenerator generator)
    {
        table = new PhantomTable(source);
        this.generator = generator;
        StartPosition = 0;
        Volume = table[0].Volume;
        Level = -1;
        if ((table[1].Content[0] is ValueString) || (table[1].Content[0] is Sequence))
        {
            isString = true;
        }

        if ((source != null) && (source.Length != 0))
        {
            var temp = (ValuePhantom)source[0];
            for (int i = 0; i < temp.Cardinality; i++)
            {
                Children.Add(new TreeNode(this, temp[i], table));
            }
        }
    }

    /// <summary>
    /// Recursive method decrementing variations of current branch.
    /// Also decreases variants count of current node by 1. Called after generation of another value.
    /// </summary>
    /// <returns>
    /// Recursion flag for children.
    /// If true further validation is required.
    /// If false no further validation is required.
    /// </returns>
    public override bool Decrement()
    {
        Volume--;
        for (int i = 0; i < Children.Count; i++)
        {
            if (Children[i].Volume == 0)
            {
                Children.RemoveAt(i);
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Method starting generation of the sequence.
    /// </summary>
    /// <returns>
    /// Generated sequence.
    /// </returns>
    public Sequence Generate()
    {
        int len = table.Length - 1;
        len *= isString ? 3 : 1;
        Sequence result = new(len);

        Find(result, generator, table);
        return result;
    }
}
