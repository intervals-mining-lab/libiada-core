using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using PhantomChains.Classes.PhantomChains;

namespace TestPhantomChains.Classes.PhantomChains
{
    ///<summary>
    ///</summary>
    public class ObjectMotherPMessageTest
    {
        private readonly ValuePhantom PM1 = null;
        private readonly ValuePhantom PM2 = null;
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
            PM1 = new ValuePhantom();
            PM1.Add(alpha[2]);
            PM1.Add(alpha[1]);
            PM2 = new ValuePhantom();
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
        public ValuePhantom PhantomMessage_B_C
        {
            get { return (ValuePhantom) PM1.Clone(); }
        }

        ///<summary>
        ///</summary>
        public ValuePhantom PhantomMessage_A
        {
            get { return (ValuePhantom) PM2.Clone(); }
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