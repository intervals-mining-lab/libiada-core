﻿namespace Libiada.PhantomChains;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Class, containing data for building tree of variants.
/// </summary>
public class PhantomTable
{
    /// <summary>
    /// List of starts positions of trees in phantom sequence.
    /// </summary>
    public readonly List<int> StartPositions = [];

    /// <summary>
    /// The table.
    /// </summary>
    private readonly List<Record> table = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="PhantomTable"/> class.
    /// </summary>
    /// <param name="source">
    /// Phantom sequence.
    /// </param>
    public PhantomTable(Sequence source)
    {
        Sequence internalSequence = source;
        ulong v = 1;
        StartPositions.Add(0);
        for (int j = 0; j < internalSequence.Length; j++)
        {
            if ((((ValuePhantom)internalSequence[j])[0] is ValueString)
                || (((ValuePhantom)internalSequence[j])[0] is Sequence))
            {
                StartPositions.Add(StartPositions[j] + ((ValuePhantom)internalSequence[j])[0].ToString().Length);
            }
            else
            {
                StartPositions.Add(StartPositions[j] + 1);
            }

            table.Add(null);
        }

        table.Add(null);
        for (int i = internalSequence.Length; i > 0; i--)
        {
            var temp = (ValuePhantom)internalSequence[i - 1];
            table[i] = new Record(temp, v);
            v *= (uint)temp.Cardinality;
        }

        // tree root is associated with phantom message
        ValuePhantom t = [NullValue.Instance()];
        table[0] = new Record(t, v);
    }

    /// <summary>
    /// Gets records count in table.
    /// The value equals number of levels in tree of variants.
    /// </summary>
    public int Length
    {
        get { return table.Count; }
    }

    /// <summary>
    /// Indexer of record value.
    /// </summary>
    /// <param name="index">
    /// Record index.
    /// </param>
    /// <returns>
    /// The <see cref="Record"/>.
    /// </returns>
    public Record this[int index]
    {
        get { return table[index]; }

        set { table[index] = value; }
    }
}
