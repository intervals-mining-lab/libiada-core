using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestRedundancy
    {
        [Test]
        public void RedundancyTest()
        {
            Redundancy calculator = new Redundancy();

            ValueChar messageA = new ValueChar('a');
            ValueChar messageB = new ValueChar('b');

            // ----------- цепочки из работы Морозенко

            Chain chain = new Chain(2);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(6);
            chain.Add(messageA, 0);
            chain.Add(messageB, 3);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(27);
            chain.Add(messageA, 0);
            chain.Add(messageA, 4);
            chain.Add(messageA, 12);
            chain.Add(messageA, 19);
            chain.Add(messageB, 3);
            chain.Add(messageB, 9);
            chain.Add(messageB, 16);
            chain.Add(messageB, 26);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.728, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(5);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0.75, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0.9091, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 4));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(13);
            chain.Add(messageA, 0);
            chain.Add(messageB, 12);
            Assert.AreEqual(-11, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0, calculator.Calculate(chain, messageB, messageA, LinkUp.End));

            chain = new Chain(29);
            chain.Add(messageA, 0);
            chain.Add(messageA, 14);
            chain.Add(messageA, 17);
            chain.Add(messageA, 18);
            chain.Add(messageA, 19);
            chain.Add(messageA, 22);
            chain.Add(messageB, 8);
            chain.Add(messageB, 10);
            chain.Add(messageB, 12);
            chain.Add(messageB, 13);
            chain.Add(messageB, 28);
            Assert.AreEqual(-0.55, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 2));
            Assert.AreEqual(0.933, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(25);
            chain.Add(messageA, 0);
            chain.Add(messageA, 3);
            chain.Add(messageA, 12);
            chain.Add(messageA, 13);
            chain.Add(messageA, 15);
            chain.Add(messageA, 17);
            chain.Add(messageA, 23);
            chain.Add(messageB, 6);
            chain.Add(messageB, 21);
            chain.Add(messageB, 24);
            Assert.AreEqual(0.356, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.261, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(29);
            chain.Add(messageA, 0);
            chain.Add(messageA, 3);
            chain.Add(messageA, 4);
            chain.Add(messageA, 6);
            chain.Add(messageA, 18);
            chain.Add(messageA, 21);
            chain.Add(messageB, 2);
            chain.Add(messageB, 17);
            chain.Add(messageB, 28);
            Assert.AreEqual(0.023, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.922, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(messageA, 0);
            chain.Add(messageA, 8);
            chain.Add(messageA, 16);
            chain.Add(messageA, 18);
            chain.Add(messageB, 4);
            chain.Add(messageB, 12);
            chain.Add(messageB, 17);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.614, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.536, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(messageA, 0);
            chain.Add(messageA, 9);
            chain.Add(messageA, 16);
            chain.Add(messageA, 24);
            chain.Add(messageB, 2);
            chain.Add(messageB, 11);
            chain.Add(messageB, 19);
            chain.Add(messageB, 25);
            Assert.AreEqual(0.69, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 2));
            Assert.AreEqual(0.079, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(16);
            chain.Add(messageA, 0);
            chain.Add(messageA, 8);
            chain.Add(messageB, 4);
            chain.Add(messageB, 12);
            Assert.AreEqual(0.293, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.5, calculator.Calculate(chain, messageB, messageA, LinkUp.End));

            chain = new Chain(30);
            chain.Add(messageA, 0);
            chain.Add(messageA, 6);
            chain.Add(messageA, 10);
            chain.Add(messageA, 18);
            chain.Add(messageB, 3);
            chain.Add(messageB, 9);
            chain.Add(messageB, 13);
            chain.Add(messageB, 21);
            Assert.AreEqual(0.535, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.661, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(23);
            chain.Add(messageA, 4);
            chain.Add(messageA, 8);
            chain.Add(messageA, 14);
            chain.Add(messageA, 18);
            chain.Add(messageB, 5);
            chain.Add(messageB, 9);
            chain.Add(messageB, 15);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.774, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.279, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(messageA, 4);
            chain.Add(messageB, 1);
            chain.Add(messageB, 3);
            chain.Add(messageB, 5);
            chain.Add(messageB, 8);
            Assert.AreEqual(0.8571, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 4));
            Assert.AreEqual(0.875, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(29);
            chain.Add(messageA, 2);
            chain.Add(messageA, 9);
            chain.Add(messageA, 10);
            chain.Add(messageA, 17);
            chain.Add(messageB, 6);
            chain.Add(messageB, 14);
            chain.Add(messageB, 22);
            Assert.AreEqual(0.437, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.694, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            // -------------- дальше цепочки из монографии

            chain = new Chain(26);
            chain.Add(messageA, 0);
            chain.Add(messageA, 6);
            chain.Add(messageA, 12);
            chain.Add(messageB, 2);
            chain.Add(messageB, 8);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.607, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.564, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));
        }
    }
}