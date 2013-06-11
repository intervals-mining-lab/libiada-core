using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestNormalizedPartialDependenceCoefficient
    {
        [Test]
        public void TestNormalizedK1()
        {
            NormalizedPartialDependenceCoefficient calculator = new NormalizedPartialDependenceCoefficient();
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
            Assert.AreEqual(0.121, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(5);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0.3, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(messageA, 0);
            chain.Add(messageB, 1);
            Assert.AreEqual(0.152, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(13);
            chain.Add(messageA, 0);
            chain.Add(messageB, 12);
            Assert.AreEqual(-1.692, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
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
            Assert.AreEqual(-0.03, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 2));
            Assert.AreEqual(0.011, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

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
            Assert.AreEqual(0.086, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.012, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

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
            Assert.AreEqual(0.005, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.042, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(messageA, 0);
            chain.Add(messageA, 8);
            chain.Add(messageA, 16);
            chain.Add(messageA, 18);
            chain.Add(messageB, 4);
            chain.Add(messageB, 12);
            chain.Add(messageB, 17);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.175, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.086, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(28);
            chain.Add(messageA, 0);
            chain.Add(messageA, 9);
            chain.Add(messageA, 16);
            chain.Add(messageA, 24);
            chain.Add(messageB, 2);
            chain.Add(messageB, 11);
            chain.Add(messageB, 19);
            chain.Add(messageB, 25);
            Assert.AreEqual(0.197, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.013, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(16);
            chain.Add(messageA, 0);
            chain.Add(messageA, 8);
            chain.Add(messageB, 4);
            chain.Add(messageB, 12);
            Assert.AreEqual(0.073, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.031, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(30);
            chain.Add(messageA, 0);
            chain.Add(messageA, 6);
            chain.Add(messageA, 10);
            chain.Add(messageA, 18);
            chain.Add(messageB, 3);
            chain.Add(messageB, 9);
            chain.Add(messageB, 13);
            chain.Add(messageB, 21);
            Assert.AreEqual(0.143, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.099, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(23);
            chain.Add(messageA, 4);
            chain.Add(messageA, 8);
            chain.Add(messageA, 14);
            chain.Add(messageA, 18);
            chain.Add(messageB, 5);
            chain.Add(messageB, 9);
            chain.Add(messageB, 15);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.269, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.055, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(12);
            chain.Add(messageA, 4);
            chain.Add(messageB, 1);
            chain.Add(messageB, 3);
            chain.Add(messageB, 5);
            chain.Add(messageB, 8);
            Assert.AreEqual(0.036, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.146, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            chain = new Chain(29);
            chain.Add(messageA, 2);
            chain.Add(messageA, 9);
            chain.Add(messageA, 10);
            chain.Add(messageA, 17);
            chain.Add(messageB, 6);
            chain.Add(messageB, 14);
            chain.Add(messageB, 22);
            Assert.AreEqual(0.09, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.048, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));

            // -------------- дальше цепочки из монографии

            chain = new Chain(26);
            chain.Add(messageA, 0);
            chain.Add(messageA, 6);
            chain.Add(messageA, 12);
            chain.Add(messageB, 2);
            chain.Add(messageB, 8);
            chain.Add(messageB, 19);
            Assert.AreEqual(0.14, Math.Round(calculator.Calculate(chain, messageA, messageB, LinkUp.End), 3));
            Assert.AreEqual(0.058, Math.Round(calculator.Calculate(chain, messageB, messageA, LinkUp.End), 3));
        }

        [Test]
        public void TestGetNormalizedK1()
        {
            NormalizedPartialDependenceCoefficient calculator = new NormalizedPartialDependenceCoefficient();

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
            Assert.AreEqual(0.175, Math.Round(result[0][1], 3));
            Assert.AreEqual(0.086, Math.Round(result[1][0], 3));
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