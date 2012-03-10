using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public class ObjectMother
    {
        private readonly ValueChar MessageA = new ValueChar('a');
        private readonly ValueChar MessageB = new ValueChar('b');
        private readonly ValueChar MessageC = new ValueChar('c');

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public Chain TestChain()
        {
            Chain TestChain = new Chain(10);

            TestChain.Add(MessageB, 0);
            TestChain.Add(MessageB, 1);
            TestChain.Add(MessageA, 2);

            TestChain.Add(MessageA, 3);
            TestChain.Add(MessageC, 4);
            TestChain.Add(MessageB, 5);

            TestChain.Add(MessageA, 6);
            TestChain.Add(MessageC, 7);
            TestChain.Add(MessageC, 8);

            TestChain.Add(MessageB, 9);

            return TestChain;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public UniformChain TestUniformChain()
        {
            UniformChain TestUChain = new UniformChain(10, MessageA);
            TestUChain.Add(MessageA, 3);
            TestUChain.Add(MessageA, 7);
            TestUChain.Add(MessageA, 4);
            return TestUChain;
        }
    }
}