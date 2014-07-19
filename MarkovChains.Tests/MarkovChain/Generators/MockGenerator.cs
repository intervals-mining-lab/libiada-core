namespace MarkovChains.Tests.MarkovChain.Generators
{
    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// The mock generator.
    /// </summary>
    public class MockGenerator : IGenerator
    {
        /// <summary>
        /// The vault.
        /// </summary>
        private readonly double[] vault = new double[30];

        /// <summary>
        /// The step.
        /// </summary>
        private int step = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockGenerator"/> class.
        /// </summary>
        public MockGenerator()
        {
            this.vault[0] = 0.77;
            this.vault[1] = 0.15;
            this.vault[2] = 0.96;
            this.vault[3] = 0.61;
            this.vault[4] = 0.15;
            this.vault[5] = 0.85;
            this.vault[6] = 0.67;
            this.vault[7] = 0.51;
            this.vault[8] = 0.71;
            this.vault[9] = 0.2;
            this.vault[10] = 0.77;
            this.vault[11] = 0.15;
            this.vault[12] = 0.96;
            this.vault[13] = 0.61;
            this.vault[14] = 0.15;
            this.vault[15] = 0.85;
            this.vault[16] = 0.67;
            this.vault[17] = 0.51;
            this.vault[18] = 0.71;
            this.vault[19] = 0.2;
            this.vault[20] = 0.77;
            this.vault[21] = 0.15;
            this.vault[22] = 0.96;
            this.vault[23] = 0.61;
            this.vault[24] = 0.15;
            this.vault[25] = 0.85;
            this.vault[26] = 0.67;
            this.vault[27] = 0.51;
            this.vault[28] = 0.71;
            this.vault[29] = 0.2;
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            this.step = -1;
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Next()
        {
            this.step++;
            if (this.step < this.vault.Length)
            {
                return this.vault[this.step];
            }

            return 0;
        }
    }
}