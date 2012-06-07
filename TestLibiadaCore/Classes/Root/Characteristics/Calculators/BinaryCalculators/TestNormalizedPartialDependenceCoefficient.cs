using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators
{
    [TestFixture]
    public class TestNormalizedPartialDependenceCoefficient
    {
        [Test]
        public void TestNormalizedK1()
        {
            NormalizedPartialDependenceCoefficient calculator = new NormalizedPartialDependenceCoefficient();
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
            Assert.AreEqual(0.121, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(5);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 1);
            Assert.AreEqual(0.3, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 1);
            Assert.AreEqual(0.152, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(13);
            chain.Add(MessageA, 0);
            chain.Add(MessageB, 12);
            Assert.AreEqual(-1.692, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
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
            Assert.AreEqual(-0.03, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 2));
            Assert.AreEqual(0.011, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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
            Assert.AreEqual(0.086, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.012, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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
            Assert.AreEqual(0.005, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.042, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 8);
            chain.Add(MessageA, 16);
            chain.Add(MessageA, 18);
            chain.Add(MessageB, 4);
            chain.Add(MessageB, 12);
            chain.Add(MessageB, 17);
            chain.Add(MessageB, 19);
            Assert.AreEqual(0.175, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.086, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 9);
            chain.Add(MessageA, 16);
            chain.Add(MessageA, 24);
            chain.Add(MessageB, 2);
            chain.Add(MessageB, 11);
            chain.Add(MessageB, 19);
            chain.Add(MessageB, 25);
            Assert.AreEqual(0.197, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.013, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(16);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 8);
            chain.Add(MessageB, 4);
            chain.Add(MessageB, 12);
            Assert.AreEqual(0.073, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.031, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(30);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 6);
            chain.Add(MessageA, 10);
            chain.Add(MessageA, 18);
            chain.Add(MessageB, 3);
            chain.Add(MessageB, 9);
            chain.Add(MessageB, 13);
            chain.Add(MessageB, 21);
            Assert.AreEqual(0.143, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.099, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(23);
            chain.Add(MessageA, 4);
            chain.Add(MessageA, 8);
            chain.Add(MessageA, 14);
            chain.Add(MessageA, 18);
            chain.Add(MessageB, 5);
            chain.Add(MessageB, 9);
            chain.Add(MessageB, 15);
            chain.Add(MessageB, 19);
            Assert.AreEqual(0.269, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.055, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(MessageA, 4);
            chain.Add(MessageB, 1);
            chain.Add(MessageB, 3);
            chain.Add(MessageB, 5);
            chain.Add(MessageB, 8);
            Assert.AreEqual(0.036, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.146, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            chain = new Chain(29);
            chain.Add(MessageA, 2);
            chain.Add(MessageA, 9);
            chain.Add(MessageA, 10);
            chain.Add(MessageA, 17);
            chain.Add(MessageB, 6);
            chain.Add(MessageB, 14);
            chain.Add(MessageB, 22);
            Assert.AreEqual(0.09, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.048, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

            // -------------- дальше цепочки из монографии

            chain = new Chain(26);
            chain.Add(MessageA, 0);
            chain.Add(MessageA, 6);
            chain.Add(MessageA, 12);
            chain.Add(MessageB, 2);
            chain.Add(MessageB, 8);
            chain.Add(MessageB, 19);
            Assert.AreEqual(0.14, Math.Round(calculator.Calculate(chain, MessageA, MessageB, LinkUp.End), 3));
            Assert.AreEqual(0.058, Math.Round(calculator.Calculate(chain, MessageB, MessageA, LinkUp.End), 3));

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
        public void TestGetNormalizedK1()
        {
            NormalizedPartialDependenceCoefficient calculator = new NormalizedPartialDependenceCoefficient();

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
            Assert.AreEqual(0.175, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.086, Math.Round(result[1][0], 3));
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
            Assert.AreEqual(0.1352, Math.Round(result[0][1], 4));
            Assert.AreEqual(0.066, Math.Round(result[0][2], 3));
            Assert.AreEqual(0.0729, Math.Round(result[1][0], 4));
            Assert.AreEqual(0, result[1][1]);
            Assert.AreEqual(0.174, Math.Round(result[1][2], 3));
            Assert.AreEqual(0.062, Math.Round(result[2][0], 3));
            Assert.AreEqual(0.129, Math.Round(result[2][1], 3));
            Assert.AreEqual(0, result[2][2]);
        }
    }
}