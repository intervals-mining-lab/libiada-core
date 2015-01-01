namespace Segmenter.Model
{
    using System;

    /// <summary>
    /// The algorithm factory.
    /// </summary>
    public static class AlgorithmFactory
    {
        /// <summary>
        /// The make.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Algorithm"/>.
        /// </returns>
        public static Algorithm Make(int index, Input input)
        {
            switch (index)
            {
                case 0: 
                    return new AlgorithmBase(input);
                case 1: 
                    return null;
                default:
                    throw new ArgumentException("Unknown index", "index");
            }
        } 
    }
}
