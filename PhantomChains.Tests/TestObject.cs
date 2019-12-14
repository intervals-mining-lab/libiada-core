namespace PhantomChains.Tests
{
    using System.Collections.Generic;

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
        private readonly Alphabet alphabet = new Alphabet() { (ValueString)"a", (ValueString)"b", (ValueString)"c" };

        /// <summary>
        /// The chain 2.
        /// </summary>
        private readonly BaseChain chain2;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestObject"/> class.
        /// </summary>
        public TestObject()
        {
            pm1 = new ValuePhantom { alphabet[2], alphabet[1] };
            pm2 = new ValuePhantom { alphabet[0] };

            chain = new BaseChain(new [] { 1, 2, 2, 1, 2, 1, 2, 1, 2, 2 }, new Alphabet() { NullValue.Instance(), PhantomMessageBc, PhantomMessageA });

            chain2 = new BaseChain(new List<IBaseObject>(){ alphabet[1], PhantomMessageA, PhantomMessageBc, alphabet[0], PhantomMessageBc });
        }

        /// <summary>
        /// Gets the phantom message bc.
        /// </summary>
        public ValuePhantom PhantomMessageBc => (ValuePhantom)pm1.Clone();

        /// <summary>
        /// Gets the phantom message a.
        /// </summary>
        public ValuePhantom PhantomMessageA => (ValuePhantom)pm2.Clone();

        /// <summary>
        /// Gets the source chain.
        /// </summary>
        public BaseChain SourceChain => (BaseChain)chain.Clone();

        /// <summary>
        /// Gets the unnormalized chain.
        /// </summary>
        public BaseChain UnnormalizedChain => chain2;
    }
}
