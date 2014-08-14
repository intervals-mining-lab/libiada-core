namespace PhantomChains.Tests
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

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
            chain = new BaseChain(10);
            chain2 = new BaseChain(5);

            alpha.Add((ValueChar)'a');
            alpha.Add((ValueChar)'b');
            alpha.Add((ValueChar)'c');
            pm1 = new ValuePhantom { alpha[2], alpha[1] };
            pm2 = new ValuePhantom { alpha[0] };
            
            chain.Add(PhantomMessageBc, 0);
            chain.Add(PhantomMessageA, 1);
            chain.Add(PhantomMessageA, 2);
            chain.Add(PhantomMessageBc, 3);
            chain.Add(PhantomMessageA, 4);
            chain.Add(PhantomMessageBc, 5);
            chain.Add(PhantomMessageA, 6);
            chain.Add(PhantomMessageBc, 7);
            chain.Add(PhantomMessageA, 8);
            chain.Add(PhantomMessageA, 9);

            chain2.Add(alpha[1], 0);
            chain2.Add(PhantomMessageA, 1);
            chain2.Add(PhantomMessageBc, 2);
            chain2.Add(alpha[0], 3);
            chain2.Add(PhantomMessageBc, 4);
        }

        /// <summary>
        /// Gets the phantom message bc.
        /// </summary>
        public ValuePhantom PhantomMessageBc
        {
            get
            {
                return (ValuePhantom)pm1.Clone();
            }
        }

        /// <summary>
        /// Gets the phantom message a.
        /// </summary>
        public ValuePhantom PhantomMessageA
        {
            get
            {
                return (ValuePhantom)pm2.Clone();
            }
        }

        /// <summary>
        /// Gets the source chain.
        /// </summary>
        public BaseChain SourceChain
        {
            get
            {
                return (BaseChain)chain.Clone();
            }
        }

        /// <summary>
        /// Gets the unnormal chain.
        /// </summary>
        public BaseChain UnnormalChain
        {
            get
            {
                return chain2;
            }
        }
    }
}