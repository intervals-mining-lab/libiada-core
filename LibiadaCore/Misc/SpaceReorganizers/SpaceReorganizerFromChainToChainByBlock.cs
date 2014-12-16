namespace LibiadaCore.Misc.SpaceReorganizers
{
    using Core;
    using Core.SimpleTypes;
    using Iterators;

    /// <summary>
    /// The space reorganizer from chain to chain by block.
    /// </summary>
    public class SpaceReorganizerFromChainToChainByBlock : SpaceReorganizer
    {
        /// <summary>
        /// The link.
        /// </summary>
        private readonly Link link;

        /// <summary>
        /// The block size.
        /// </summary>
        private readonly int blockSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceReorganizerFromChainToChainByBlock"/> class.
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="blockSize">
        /// The block size.
        /// </param>
        public SpaceReorganizerFromChainToChainByBlock(Link link, int blockSize)
        {
            this.link = link;
            this.blockSize = blockSize;
        }

        /// <summary>
        /// Reorganizes <see cref="AbstractChain"/> into <see cref="AbstractChain"/>.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractChain"/>.
        /// </returns>
        public override AbstractChain Reorganize(AbstractChain source)
        {
            var result = new BaseChain();
            result.ClearAndSetNewLength(source.GetLength() / blockSize);
            IteratorBase iteratorFrom;
            IWritableIterator iteratorTo;

            if (link != Link.End)
            {
                iteratorFrom = new IteratorStart(source, blockSize, blockSize);
                iteratorTo = new IteratorWritableStart(result);
            }
            else
            {
                iteratorFrom = new IteratorEnd(source, blockSize, blockSize);
                iteratorTo = new IteratorWritableEnd(result);
            }

            while (iteratorTo.Next() && iteratorFrom.Next())
            {
                var message = new ValuePhantom
                                  {
                                      // TODO: WAT
                                      iteratorFrom.Current() 
                                  };

                iteratorTo.WriteValue(message.Cardinality == 0 ? (IBaseObject)NullValue.Instance() : message);
            }

            return result;
        }
    }
}