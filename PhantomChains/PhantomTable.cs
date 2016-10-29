namespace PhantomChains
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Class, containing data for building tree of variants.
    /// </summary>
    public class PhantomTable
    {
        /// <summary>
        /// List of starts positions of trees in phantom chain.
        /// </summary>
        public readonly List<int> StartPositions = new List<int>();

        /// <summary>
        /// The table.
        /// </summary>
        private readonly List<Record> table = new List<Record>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhantomTable"/> class.
        /// </summary>
        /// <param name="source">
        /// Phantom chain.
        /// </param>
        public PhantomTable(BaseChain source)
        {
            BaseChain internalChain = source;
            ulong v = 1;
            StartPositions.Add(0);
            for (int j = 0; j < internalChain.GetLength(); j++)
            {
                if ((((ValuePhantom)internalChain[j])[0] is ValueString)
                    || (((ValuePhantom)internalChain[j])[0] is BaseChain))
                {
                    StartPositions.Add(StartPositions[j] + ((ValuePhantom)internalChain[j])[0].ToString().Length);
                }
                else
                {
                    StartPositions.Add(StartPositions[j] + 1);
                }

                table.Add(null);
            }

            table.Add(null);
            for (int i = internalChain.GetLength(); i > 0; i--)
            {
                var temp = (ValuePhantom)internalChain[i - 1];
                table[i] = new Record(temp, v);
                v *= (uint)temp.Cardinality;
            }

            // tree root is associated with phantom message
            var t = new ValuePhantom { NullValue.Instance() };
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
}
