using System.Collections;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using ChainAnalises.Classes.Project_A;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfSet;
using System.Collections.Generic;
using MarkovCompare;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.Project_A
{
    [TestFixture]
    public class TestChainFilter
    {
        private Alphabet alph;
        private ScramblingGenerator sg;
        private List<LinkedUpCharacteristic> ch;

        [SetUp]
        public void Init()
        {
            alph = new Alphabet();
            alph.Add((ValueString)"a");
            alph.Add((ValueString)"b");
            alph.Add((ValueString)"c");
            sg = new ScramblingGenerator();
            ch = new List<LinkedUpCharacteristic>();
            ch.Add(new LinkedUpCharacteristic(CharacteristicsFactory.V, LinkUp.Start));
        }

        [Test]
        public void TestFilterByAlphabet()
        {
            ChainPicksWithCharacteristics chains = sg.Generate(alph, 5, ch);
            chains = chains.GetFilteredChainPicks(new ChinFilterByAlphabetPower(3, 3));
            Assert.AreEqual(chains.Count, 25);
        }
    }
}
