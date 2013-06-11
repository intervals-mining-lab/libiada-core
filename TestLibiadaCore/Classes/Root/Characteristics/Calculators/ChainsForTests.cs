using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public class ChainsForTests
    {
        private readonly ValueChar MessageA = new ValueChar('a');
        private readonly ValueChar MessageB = new ValueChar('b');
        private readonly ValueChar MessageC = new ValueChar('c');

        ///<summary>
        /// BBAACBACCB
        ///</summary>
        ///<returns></returns>
        public Chain TestChain()
        {
            Chain testChain = new Chain(10);

            testChain.Add(MessageB, 0);
            testChain.Add(MessageB, 1);
            testChain.Add(MessageA, 2);

            testChain.Add(MessageA, 3);
            testChain.Add(MessageC, 4);
            testChain.Add(MessageB, 5);

            testChain.Add(MessageA, 6);
            testChain.Add(MessageC, 7);
            testChain.Add(MessageC, 8);

            testChain.Add(MessageB, 9);

            return testChain;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public UniformChain TestUniformChain()
        {
            UniformChain testUChain = new UniformChain(10, MessageA);
            testUChain.Add(MessageA, 3);
            testUChain.Add(MessageA, 7);
            testUChain.Add(MessageA, 4);
            return testUChain;
        }
    }
}