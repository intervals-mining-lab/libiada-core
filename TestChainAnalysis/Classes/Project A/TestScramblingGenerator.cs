using System.Collections;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using ChainAnalises.Classes.Project_A;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfSet;
using MarkovCompare;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestChainAnalysis.Classes.Project_A
{
    [TestFixture]
    public class TestScramblingGenerator
    {
        private List<BaseChain> testMass;
        
        [SetUp]
        public void Init()
        {
            testMass = new List<BaseChain>();
            Chain chain = new Chain(3);
            chain.Add((ValueString) "a", 0);
            chain.Add((ValueString) "a", 1);
            chain.Add((ValueString) "a", 2);
            testMass.Add(chain);

            chain = new Chain(3);
            chain.Add((ValueString)"a", 0);
            chain.Add((ValueString)"a", 1);
            chain.Add((ValueString)"b", 2);
            testMass.Add(chain);

            chain = new Chain(3);
            chain.Add((ValueString)"a", 0);
            chain.Add((ValueString)"b", 1);
            chain.Add((ValueString)"a", 2);
            testMass.Add(chain);

            chain = new Chain(3);
            chain.Add((ValueString)"a", 0);
            chain.Add((ValueString)"b", 1);
            chain.Add((ValueString)"b", 2);
            testMass.Add(chain);

            chain = new Chain(3);
            chain.Add((ValueString)"a", 0);
            chain.Add((ValueString)"b", 1);
            chain.Add((ValueString)"c", 2);
            testMass.Add(chain);
        }

        [Test]
        public void TestScramblingGeneratorOne()
        {
            Alphabet alph = new Alphabet();
            alph.Add((ValueString)"a");
            alph.Add((ValueString)"b");
            alph.Add((ValueString)"c");
            ScramblingGenerator sg = new ScramblingGenerator();
            List<LinkedUpCharacteristic> ch = new List<LinkedUpCharacteristic>();
            ch.Add(new LinkedUpCharacteristic(CharacteristicsFactory.V, LinkUp.Start));
            ChainPicksWithCharacteristics mass = sg.Generate(alph, 3, ch);
            Assert.AreEqual(mass.Count, 5);
        }

        [Test]
        public void TestScramblingGeneratorForTime()
        {
            Alphabet alph = new Alphabet();
            alph.Add((ValueString)"a");
            alph.Add((ValueString)"b");
            alph.Add((ValueString)"c");
            alph.Add((ValueString)"d");
            alph.Add((ValueString)"e");
            ScramblingGenerator sg = new ScramblingGenerator();
            List<LinkedUpCharacteristic> ch = new List<LinkedUpCharacteristic>();
            ch.Add(new LinkedUpCharacteristic(CharacteristicsFactory.V, LinkUp.Start));
            ChainPicksWithCharacteristics mass = sg.Generate(alph, 5, ch);
            Assert.AreEqual(mass.Count, 52);
        }
    }
}
