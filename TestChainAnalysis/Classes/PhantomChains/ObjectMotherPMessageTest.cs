using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfSet;

namespace TestChainAnalysis.Classes.PhantomChains
{
    ///<summary>
    ///</summary>
    public class ObjectMotherPMessageTest
    {
        private readonly MessagePhantom PM1 = null;
        private readonly MessagePhantom PM2 = null;
        private readonly BaseChain Chain = null;

        private readonly Alphabet alpha = new Alphabet();
        private readonly BaseChain Chain2;

        ///<summary>
        ///</summary>
        public ObjectMotherPMessageTest()
        {
            Chain = new BaseChain(10);
            Chain2 = new BaseChain(5);

            // M1 = new ValueChar('a');
            alpha.Add((ValueChar) 'a');
            alpha.Add((ValueChar)'b');
            alpha.Add((ValueChar)'c');
            PM1 = new MessagePhantom();
            PM1.Add(alpha[2]);
            PM1.Add(alpha[1]);
            PM2 = new MessagePhantom();
            PM2.Add(alpha[0]);

            Chain.Add(PhantomMessage_B_C,0);
            Chain.Add(PhantomMessage_A,1);
            Chain.Add(PhantomMessage_A, 2);
            Chain.Add(PhantomMessage_B_C, 3);
            Chain.Add(PhantomMessage_A, 4);
            Chain.Add(PhantomMessage_B_C, 5);
            Chain.Add(PhantomMessage_A, 6);
            Chain.Add(PhantomMessage_B_C, 7);
            Chain.Add(PhantomMessage_A, 8);
            Chain.Add(PhantomMessage_A, 9);

            Chain2.Add(alpha[1],0);
            Chain2.Add(PhantomMessage_A, 1);
            Chain2.Add(PhantomMessage_B_C, 2);
            Chain2.Add(alpha[0], 3);
            Chain2.Add(PhantomMessage_B_C, 4);
       
        }


        ///<summary>
        ///</summary>
        public MessagePhantom PhantomMessage_B_C
        {
            get { return (MessagePhantom) PM1.Clone(); }
        }

        ///<summary>
        ///</summary>
        public MessagePhantom PhantomMessage_A
        {
            get { return (MessagePhantom) PM2.Clone(); }
        }

        ///<summary>
        ///</summary>
        public BaseChain SourceChain
        {
            get { return (BaseChain) Chain.Clone(); }
        }

        ///<summary>
        ///</summary>
        public BaseChain UnnormalChain
        {
            get { return Chain2; }
        }
    }
}