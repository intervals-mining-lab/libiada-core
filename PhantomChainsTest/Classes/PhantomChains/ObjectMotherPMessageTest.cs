namespace PhantomChainsTest.Classes.PhantomChains
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// The object mother p message test.
    /// </summary>
    public class ObjectMotherPMessageTest
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
        /// Initializes a new instance of the <see cref="ObjectMotherPMessageTest"/> class.
        /// </summary>
        public ObjectMotherPMessageTest()
        {
            this.chain = new BaseChain(10);
            this.chain2 = new BaseChain(5);

            // M1 = new ValueChar('a');
            alpha.Add((ValueChar)'a');
            alpha.Add((ValueChar)'b');
            alpha.Add((ValueChar)'c');
            this.pm1 = new ValuePhantom { alpha[2], alpha[1] };
            this.pm2 = new ValuePhantom { alpha[0] };

            this.chain.Add(this.PhantomMessageBc, 0);
            this.chain.Add(PhantomMessageA, 1);
            this.chain.Add(PhantomMessageA, 2);
            this.chain.Add(this.PhantomMessageBc, 3);
            this.chain.Add(PhantomMessageA, 4);
            this.chain.Add(this.PhantomMessageBc, 5);
            this.chain.Add(PhantomMessageA, 6);
            this.chain.Add(this.PhantomMessageBc, 7);
            this.chain.Add(PhantomMessageA, 8);
            this.chain.Add(PhantomMessageA, 9);

            this.chain2.Add(alpha[1], 0);
            this.chain2.Add(PhantomMessageA, 1);
            this.chain2.Add(this.PhantomMessageBc, 2);
            this.chain2.Add(alpha[0], 3);
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