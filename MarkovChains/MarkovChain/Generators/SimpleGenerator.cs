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
            random = new Random(random.Next());
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Next()
        {
            return random.NextDouble();
        }
    }
}