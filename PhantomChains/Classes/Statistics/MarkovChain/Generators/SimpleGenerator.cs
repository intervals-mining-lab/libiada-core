using System;

namespace PhantomChains.Classes.Statistics.MarkovChain.Generators
{
    ///<summary>
    /// Генератор основанный на стандарном Random class
    ///</summary>
    public class SimpleGenerator:IGenerator
    {
        private Random rnd = new Random();

        public void Reset()
        {
            rnd = new Random(rnd.Next());
        }

        public double Next()
        {
            return rnd.NextDouble();
        }
    }
}