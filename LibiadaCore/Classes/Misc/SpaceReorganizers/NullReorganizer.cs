namespace LibiadaCore.Classes.Misc.SpaceReorganizers
{
    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Root;

    /// <summary>
    /// Reorganizer that does nothing.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of result chain.
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain.
    /// </typeparam>
    public class NullReorganizer<TResult, TSource> : SpaceReorganizer<TResult, TSource> 
        where TResult : BaseChain, new() where TSource : BaseChain, new()
    {
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
            var result = source.Clone() as TResult;
            if (result != null)
            {
                return result;
            }

            // TODO: Implement variant when we have Chain Reorganize(BaseChain A)
            result = new TResult();
            result.ClearAndSetNewLength(source.Length);

            var iteratorRead = new IteratorSimpleStart<TSource>(source, 1);
            var iteratorWrite = new IteratorWritableStart<TSource, TResult>(result);
            iteratorRead.Reset();
            iteratorWrite.Reset();
            iteratorRead.Next();
            iteratorWrite.Next();

            for (int i = 0; i < source.Length; i++)
            {
                iteratorWrite.WriteValue(iteratorRead.Current());
                iteratorRead.Next();
                iteratorWrite.Next();
            }

            return result;
        }
    }
}