namespace MarkovChains.MarkovChain.Generators
{
    using System;

    /// <summary>
    /// Генератор основанный на стандарном Random class
    /// </summary>
    public class SimpleGenerator : IGenerator
    {
        /// <summary>
        /// The random.
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            this.random = new Random(this.random.Next());
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Next()
        {
            return this.random.NextDouble();
        }
    }
}