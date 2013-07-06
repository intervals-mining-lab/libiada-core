using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace PhantomChainsTest.Classes.PhantomChains
{
    ///<summary>
    ///</summary>
    public class ObjectMotherPMessageTest
    {
        private readonly ValuePhantom PM1;
        private readonly ValuePhantom PM2;
        private readonly BaseChain Chain;

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
            PM1 = new ValuePhantom {alpha[2], alpha[1]};
            PM2 = new ValuePhantom {alpha[0]};

            Chain.Add(PhantomMessageBC,0);
            Chain.Add(PhantomMessageA,1);
            Chain.Add(PhantomMessageA, 2);
            Chain.Add(PhantomMessageBC, 3);
            Chain.Add(PhantomMessageA, 4);
            Chain.Add(PhantomMessageBC, 5);
            Chain.Add(PhantomMessageA, 6);
            Chain.Add(PhantomMessageBC, 7);
            Chain.Add(PhantomMessageA, 8);
            Chain.Add(PhantomMessageA, 9);

            Chain2.Add(alpha[1],0);
            Chain2.Add(PhantomMessageA, 1);
            Chain2.Add(PhantomMessageBC, 2);
            Chain2.Add(alpha[0], 3);
            Chain2.Add(PhantomMessageBC, 4);
       
        }


        ///<summary>
        ///</summary>
        public ValuePhantom PhantomMessageBC
        {
            get { return (ValuePhantom) PM1.Clone(); }
        }

        ///<summary>
        ///</summary>
        public ValuePhantom PhantomMessageA
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