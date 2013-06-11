using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestMutualDependenceCoefficient
    {
        [Test]
        public void TestK3()
        {
            MutualDependenceCoefficient calculator = new MutualDependenceCoefficient();
            ValueChar messageA = new ValueChar('a');
            ValueChar messageB = new ValueChar('b');

            // ----------- цепочки из работы Морозенко

            Chain chain = new Chain(2);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(6);
            chain.Add(messageA, 0);
            chain.Add(messageB, 3);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

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

            chain = new Chain(5);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 4));

            chain = new Chain(13);
            chain.Add(messageA, 0);
            chain.Add(messageB, 12);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

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
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 2));

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
            Assert.AreEqual(0.15, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

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
            Assert.AreEqual(0.0788, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 4));

            chain = new Chain(28);
            chain.Add(messageA, 0);
            chain.Add(messageA, 8);
            chain.Add(messageA, 16);
            chain.Add(messageA, 18);
            chain.Add(messageB, 4);
            chain.Add(messageB, 12);
            chain.Add(messageB, 17);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.497, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(messageA, 0);
            chain.Add(messageA, 9);
            chain.Add(messageA, 16);
            chain.Add(messageA, 24);
            chain.Add(messageB, 2);
            chain.Add(messageB, 11);
            chain.Add(messageB, 19);
            chain.Add(messageB, 25);
            Assert.AreEqual(0.202, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(16);
            chain.Add(messageA, 0);
            chain.Add(messageA, 8);
            chain.Add(messageB, 4);
            chain.Add(messageB, 12);
            Assert.AreEqual(0.271, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(30);
            chain.Add(messageA, 0);
            chain.Add(messageA, 6);
            chain.Add(messageA, 10);
            chain.Add(messageA, 18);
            chain.Add(messageB, 3);
            chain.Add(messageB, 9);
            chain.Add(messageB, 13);
            chain.Add(messageB, 21);
            Assert.AreEqual(0.515, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(23);
            chain.Add(messageA, 4);
            chain.Add(messageA, 8);
            chain.Add(messageA, 14);
            chain.Add(messageA, 18);
            chain.Add(messageB, 5);
            chain.Add(messageB, 9);
            chain.Add(messageB, 15);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.402, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(messageA, 4);
            chain.Add(messageB, 1);
            chain.Add(messageB, 3);
            chain.Add(messageB, 5);
            chain.Add(messageB, 8);
            Assert.AreEqual(0.3464, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 4));

            chain = new Chain(29);
            chain.Add(messageA, 2);
            chain.Add(messageA, 9);
            chain.Add(messageA, 10);
            chain.Add(messageA, 17);
            chain.Add(messageB, 6);
            chain.Add(messageB, 14);
            chain.Add(messageB, 22);
            Assert.AreEqual(0.385, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            // -------------- дальше цепочки из монографии

            chain = new Chain(26);
            chain.Add(messageA, 0);
            chain.Add(messageA, 6);
            chain.Add(messageA, 12);
            chain.Add(messageB, 2);
            chain.Add(messageB, 8);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.478, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));

            chain = new Chain(23);
            chain.Add(messageA, 0);
            chain.Add(messageA, 6);
            chain.Add(messageA, 11);
            chain.Add(messageA, 21);
            chain.Add(messageB, 1);
            chain.Add(messageB, 7);
            chain.Add(messageB, 12);
            chain.Add(messageB, 22);
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
        }

        [Test]
        public void TestGetK3()
        {
            MutualDependenceCoefficient calculator = new MutualDependenceCoefficient();

            ValueChar messageA = new ValueChar('a');
            ValueChar messageB = new ValueChar('b');
            ValueChar messageC = new ValueChar('c');

            List<List<double>> result;

            Chain chain = new Chain(2);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);

            result = calculator.Calculate(chain, LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);


            chain = new Chain(28);
            chain.Add(messageA, 0);
            chain.Add(messageA, 8);
            chain.Add(messageA, 16);
            chain.Add(messageA, 18);
            chain.Add(messageB, 4);
            chain.Add(messageB, 12);
            chain.Add(messageB, 17);
            chain.Add(messageB, 19);

            result = calculator.Calculate(chain, LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.497, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.497, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            // ABCBABCCBCCC
            chain = new Chain(12);
            chain.Add(messageA, 0);
            chain.Add(messageA, 4);
            chain.Add(messageB, 1);
            chain.Add(messageB, 3);
            chain.Add(messageB, 5);
            chain.Add(messageB, 8);
            chain.Add(messageC, 2);
            chain.Add(messageC, 6);
            chain.Add(messageC, 7);
            chain.Add(messageC, 9);
            chain.Add(messageC, 10);
            chain.Add(messageC, 11);

            result = calculator.Calculate(chain, LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.397, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.236, Math.Round(result[0][2], 3));
            Assert.AreEqual(0.397, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);
            Assert.AreEqual(0.360, Math.Round(result[1][2], 3));
            Assert.AreEqual(0.236, Math.Round(result[2][0], 3));
            Assert.AreEqual(0.360, Math.Round(result[2][1], 3));
            Assert.AreEqual(0, result[2][2]);

        }
    }
}