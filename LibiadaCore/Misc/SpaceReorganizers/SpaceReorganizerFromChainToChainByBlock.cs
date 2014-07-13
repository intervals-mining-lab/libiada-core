namespace LibiadaCore.Misc.SpaceReorganizers
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.Iterators;

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
        /// Reorganizes <see cref="TSource"/> into <see cref="TResult"/>.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        public override AbstractChain Reorganize(AbstractChain source)
        {
            var result = new BaseChain();
            result.ClearAndSetNewLength(source.GetLength() / this.blockSize);
            IteratorBase iteratorFrom;
            IWritableIterator iteratorTo;

            if (this.link != Link.End)
            {
                iteratorFrom = new IteratorStart(source, this.blockSize, this.blockSize);
                iteratorTo = new IteratorWritableStart(result);
            }
            else
            {
                iteratorFrom = new IteratorEnd(source, this.blockSize, this.blockSize);
                iteratorTo = new IteratorWritableEnd(result);
            }

            while (iteratorTo.Next() && iteratorFrom.Next())
            {
                var message = new ValuePhantom
                                  {
                                      // WAT
                                      iteratorFrom.Current() 
                                  };

                iteratorTo.WriteValue(message.Cardinality == 0 ? (IBaseObject)NullValue.Instance() : message);
            }

            return result;
        }
    }
}