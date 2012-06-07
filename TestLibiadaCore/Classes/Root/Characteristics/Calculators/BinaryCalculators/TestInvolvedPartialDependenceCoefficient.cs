using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators
{
    [TestFixture]
    public class TestInvolvedPartialDependenceCoefficient
    {
        [Test]
        public void TestK2()
        {
            InvolvedPartialDependenceCoefficient calculator = new InvolvedPartialDependenceCoefficient();
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
            Assert.AreEqual(0.546, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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
            Assert.AreEqual(-0.2, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.1697, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 4));

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
            Assert.AreEqual(0.214, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.105, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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
            Assert.AreEqual(0.0152, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 4));
            Assert.AreEqual(0.4098, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 4));

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
            Assert.AreEqual(0.402, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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
            Assert.AreEqual(0.059, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(16);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 8);
            chain.Add(MessageB, 4);
            chain.Add(MessageB, 12);
            Assert.AreEqual(0.293, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.25, calculator.Calculate(chain, MessageB, MessageA, LinkUp.End));

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
            Assert.AreEqual(0.496, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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
            Assert.AreEqual(0.209, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(MessageA, 4);
            chain.Add(MessageB, 1);
            chain.Add(MessageB, 3);
            chain.Add(MessageB, 5);
            chain.Add(MessageB, 8);
            Assert.AreEqual(0.3429, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 4));
            Assert.AreEqual(0.35, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 2));

            chain = new Chain(29);
            chain.Add(MessageA, 2);
            chain.Add(MessageA, 9);
            chain.Add(MessageA, 10);
            chain.Add(MessageA, 17);
            chain.Add(MessageB, 6);
            chain.Add(MessageB, 14);
            chain.Add(MessageB, 22);
            Assert.AreEqual(0.374, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.396, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            // -------------- дальше цепочки из монографии

            chain = new Chain(26);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 6);
            chain.Add(MessageA, 12);
            chain.Add(MessageB, 2);
            chain.Add(MessageB, 8);
            chain.Add(MessageB, 19);
            Assert.AreEqual(0.607, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.376, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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

        [Test]
        public void TestGetK2()
        {
            InvolvedPartialDependenceCoefficient calculator = new InvolvedPartialDependenceCoefficient();

            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageB = new ValueChar('b');
            ValueChar MessageC = new ValueChar('c');

            List<List<double>> result;

            Chain chain = new Chain(2);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 1);

            result = calculator.Calculate(chain, LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0, result[0][1]);
            Assert.AreEqual(0, result[1][0]);
            Assert.AreEqual(0, result[1][1]);


            chain = new Chain(28);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 8);
            chain.Add(MessageA, 16);
            chain.Add(MessageA, 18);
            chain.Add(MessageB, 4);
            chain.Add(MessageB, 12);
            chain.Add(MessageB, 17);
            chain.Add(MessageB, 19);

            result = calculator.Calculate(chain, LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.614, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.402, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);

            // ABCBABCCBCCC
            chain = new Chain(12);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 4);
            chain.Add(MessageB, 1);
            chain.Add(MessageB, 3);
            chain.Add(MessageB, 5);
            chain.Add(MessageB, 8);
            chain.Add(MessageC, 2);
            chain.Add(MessageC, 6);
            chain.Add(MessageC, 7);
            chain.Add(MessageC, 9);
            chain.Add(MessageC, 10);
            chain.Add(MessageC, 11);

            result = calculator.Calculate(chain, LinkUp.End);

            Assert.AreEqual(0, result[0][0]);
            Assert.AreEqual(0.5407, Math.Round(result[0][1], 4));
            Assert.AreEqual(0.296, Math.Round(result[0][2], 3));
            Assert.AreEqual(0.292, Math.Round(result[1][0], 3));
            Assert.AreEqual(0, result[1][1]);
            Assert.AreEqual(0.418, Math.Round(result[1][2], 3));
            Assert.AreEqual(0.1875, Math.Round(result[2][0], 4));
            Assert.AreEqual(0.311, Math.Round(result[2][1], 3));
            Assert.AreEqual(0, result[2][2]);

        }
    }
}