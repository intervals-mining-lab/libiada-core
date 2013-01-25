using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class RedundancyTest
    {
        [Test]
        public void Redundancy1Test()
        {
            Redundancy calculator = new Redundancy();

            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageB = new ValueChar('b');

            // ----------- цепочки из работы Морозенко

            Chain chain = new Chain(2);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 1);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(6);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 3);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(27);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 4);
            chain.Add(MessageA, 12);
            chain.Add(MessageA, 19);
            chain.Add(MessageB, 3);
            chain.Add(MessageB, 9);
            chain.Add(MessageB, 16);
            chain.Add(MessageB, 26);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.728, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(5);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 1);
            Assert.AreEqual(0.75, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 1);
            Assert.AreEqual(0.9091, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 4));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(13);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 12);
            Assert.AreEqual(-11, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0, calculator.Calculate(chain, MessageB, MessageA, LinkUp.End));

            chain = new Chain(29);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 14);
            chain.Add(MessageA, 17);
            chain.Add(MessageA, 18);
            chain.Add(MessageA, 19);
            chain.Add(MessageA, 22);
            chain.Add(MessageB, 8);
            chain.Add(MessageB, 10);
            chain.Add(MessageB, 12);
            chain.Add(MessageB, 13);
            chain.Add(MessageB, 28);
            Assert.AreEqual(-0.55, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 2));
            Assert.AreEqual(0.933, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(25);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 3);
            chain.Add(MessageA, 12);
            chain.Add(MessageA, 13);
            chain.Add(MessageA, 15);
            chain.Add(MessageA, 17);
            chain.Add(MessageA, 23);
            chain.Add(MessageB, 6);
            chain.Add(MessageB, 21);
            chain.Add(MessageB, 24);
            Assert.AreEqual(0.356, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.261, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(29);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 3);
            chain.Add(MessageA, 4);
            chain.Add(MessageA, 6);
            chain.Add(MessageA, 18);
            chain.Add(MessageA, 21);
            chain.Add(MessageB, 2);
            chain.Add(MessageB, 17);
            chain.Add(MessageB, 28);
            Assert.AreEqual(0.023, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.922, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 8);
            chain.Add(MessageA, 16);
            chain.Add(MessageA, 18);
            chain.Add(MessageB, 4);
            chain.Add(MessageB, 12);
            chain.Add(MessageB, 17);
            chain.Add(MessageB, 19);
            Assert.AreEqual(0.614, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.536, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 9);
            chain.Add(MessageA, 16);
            chain.Add(MessageA, 24);
            chain.Add(MessageB, 2);
            chain.Add(MessageB, 11);
            chain.Add(MessageB, 19);
            chain.Add(MessageB, 25);
            Assert.AreEqual(0.69, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 2));
            Assert.AreEqual(0.079, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(16);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 8);
            chain.Add(MessageB, 4);
            chain.Add(MessageB, 12);
            Assert.AreEqual(0.293, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.5, calculator.Calculate(chain, MessageB, MessageA, LinkUp.End));

            chain = new Chain(30);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 6);
            chain.Add(MessageA, 10);
            chain.Add(MessageA, 18);
            chain.Add(MessageB, 3);
            chain.Add(MessageB, 9);
            chain.Add(MessageB, 13);
            chain.Add(MessageB, 21);
            Assert.AreEqual(0.535, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.661, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(23);
            chain.Add(MessageA, 4);
            chain.Add(MessageA, 8);
            chain.Add(MessageA, 14);
            chain.Add(MessageA, 18);
            chain.Add(MessageB, 5);
            chain.Add(MessageB, 9);
            chain.Add(MessageB, 15);
            chain.Add(MessageB, 19);
            Assert.AreEqual(0.774, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.279, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(MessageA, 4);
            chain.Add(MessageB, 1);
            chain.Add(MessageB, 3);
            chain.Add(MessageB, 5);
            chain.Add(MessageB, 8);
            Assert.AreEqual(0.8571, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 4));
            Assert.AreEqual(0.875, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(29);
            chain.Add(MessageA, 2);
            chain.Add(MessageA, 9);
            chain.Add(MessageA, 10);
            chain.Add(MessageA, 17);
            chain.Add(MessageB, 6);
            chain.Add(MessageB, 14);
            chain.Add(MessageB, 22);
            Assert.AreEqual(0.437, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.694, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            // -------------- дальше цепочки из монографии

            chain = new Chain(26);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 6);
            chain.Add(MessageA, 12);
            chain.Add(MessageB, 2);
            chain.Add(MessageB, 8);
            chain.Add(MessageB, 19);
            Assert.AreEqual(0.607, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.564, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(23);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 6);
            chain.Add(MessageA, 11);
            chain.Add(MessageA, 21);
            chain.Add(MessageB, 1);
            chain.Add(MessageB, 7);
            chain.Add(MessageB, 12);
            chain.Add(MessageB, 22);
            //            Assert.AreEqual(0.798, Math.Round(testChain.PartialDependenceCoefficient(MessageA, MessageB),3));
            //            Assert.AreEqual(-0.046, Math.Round(testChain.PartialDependenceCoefficient(MessageB, MessageA), 3));

            
        }
    }
}