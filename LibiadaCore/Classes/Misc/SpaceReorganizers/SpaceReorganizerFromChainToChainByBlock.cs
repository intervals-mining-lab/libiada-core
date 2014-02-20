namespace LibiadaCore.Classes.Misc.SpaceReorganizers
{
    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// The space reorganizer from chain to chain by block.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of result chain.
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain.
    /// </typeparam>
    public class SpaceReorganizerFromChainToChainByBlock<TResult, TSource> : SpaceReorganizer<TResult, TSource>
        where TResult : BaseChain, new() where TSource : BaseChain, new()
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
        /// Initializes a new instance of the <see cref="SpaceReorganizerFromChainToChainByBlock{TResult,TSource}"/> class.
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
        public override TResult Reorganize(TSource source)
        {
            var result = new TResult();
            result.ClearAndSetNewLength(source.Length / this.blockSize);
            IteratorBase<TResult, TSource> iteratorFrom;
            IWritableIterator<TResult, TResult> iteratorTo;

            if (this.link != Link.End)
            {
                iteratorFrom = new IteratorStart<TResult, TSource>(source, this.blockSize, this.blockSize);
                iteratorTo = new IteratorWritableStart<TResult, TResult>(result);
            }
            else
            {
                iteratorFrom = new IteratorEnd<TResult, TSource>(source, this.blockSize, this.blockSize);
                iteratorTo = new IteratorWritableEnd<TResult, TResult>(result);
            }

            while (iteratorTo.Next() && iteratorFrom.Next())
            {
                var message = new ValuePhantom {iteratorFrom.Current()};

                iteratorTo.WriteValue(message.Power == 0 ? (IBaseObject)NullValue.Instance() : message);
            }
            return result;
        }
    }
}