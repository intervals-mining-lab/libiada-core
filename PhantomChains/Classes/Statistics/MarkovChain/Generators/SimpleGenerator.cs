using System;

namespace PhantomChains.Classes.Statistics.MarkovChain.Generators
{
    ///<summary>
    /// Генератор основанный на стандарном Random class
    ///</summary>
    public class SimpleGenerator:IGenerator
    {
        private Random Rnd = new Random();

        public void Resert()
        {
            Rnd = new Random(Rnd.Next());
        }

        public double Next()
        {
            return Rnd.NextDouble();
        }
    }
}