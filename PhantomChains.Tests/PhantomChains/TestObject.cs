namespace PhantomChains.Tests.PhantomChains
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// The object mother p message test.
    /// </summary>
    public class TestObject
    {
        /// <summary>
        /// The p m 1.
        /// </summary>
        private readonly ValuePhantom pm1;

        /// <summary>
        /// The p m 2.
        /// </summary>
        private readonly ValuePhantom pm2;

        /// <summary>
        /// The chain.
        /// </summary>
        private readonly BaseChain chain;

        /// <summary>
        /// The alpha.
        /// </summary>
        private readonly Alphabet alpha = new Alphabet();

        /// <summary>
        /// The chain 2.
        /// </summary>
        private readonly BaseChain chain2;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestObject"/> class.
        /// </summary>
        public TestObject()
        {
            this.chain = new BaseChain(10);
            this.chain2 = new BaseChain(5);

            // M1 = new ValueChar('a');
            this.alpha.Add((ValueChar)'a');
            this.alpha.Add((ValueChar)'b');
            this.alpha.Add((ValueChar)'c');
            this.pm1 = new ValuePhantom { this.alpha[2], this.alpha[1] };
            this.pm2 = new ValuePhantom { this.alpha[0] };

            this.chain.Add(this.PhantomMessageBc, 0);
            this.chain.Add(this.PhantomMessageA, 1);
            this.chain.Add(this.PhantomMessageA, 2);
            this.chain.Add(this.PhantomMessageBc, 3);
            this.chain.Add(this.PhantomMessageA, 4);
            this.chain.Add(this.PhantomMessageBc, 5);
            this.chain.Add(this.PhantomMessageA, 6);
            this.chain.Add(this.PhantomMessageBc, 7);
            this.chain.Add(this.PhantomMessageA, 8);
            this.chain.Add(this.PhantomMessageA, 9);

            this.chain2.Add(this.alpha[1], 0);
            this.chain2.Add(this.PhantomMessageA, 1);
            this.chain2.Add(this.PhantomMessageBc, 2);
            this.chain2.Add(this.alpha[0], 3);
            this.chain2.Add(this.PhantomMessageBc, 4);
        }

        /// <summary>
        /// Gets the phantom message bc.
        /// </summary>
        public ValuePhantom PhantomMessageBc
        {
            get
            {
                return (ValuePhantom)this.pm1.Clone();
            }
        }

        /// <summary>
        /// Gets the phantom message a.
        /// </summary>
        public ValuePhantom PhantomMessageA
        {
            get
            {
                return (ValuePhantom)this.pm2.Clone();
            }
        }

        /// <summary>
        /// Gets the source chain.
        /// </summary>
        public BaseChain SourceChain
        {
            get
            {
                return (BaseChain)this.chain.Clone();
            }
        }

        /// <summary>
        /// Gets the unnormal chain.
        /// </summary>
        public BaseChain UnnormalChain
        {
            get
            {
                return this.chain2;
            }
        }
    }
}