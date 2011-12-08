using System;
using System.Diagnostics;
using System.Text;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.Compress
{
    [TestFixture]
    public class TestHennon
    {
        private Chain Source = new Chain(37);

        [SetUp]
        public void init()
        {
            Source.Add((ValueString) "a", 0);
            Source.Add((ValueString) "b", 1);
            Source.Add((ValueString) "b", 2);
            Source.Add((ValueString) "a", 3);
            Source.Add((ValueString) "c", 4);
            Source.Add((ValueString) "a", 5);
            Source.Add((ValueString) "d", 6);
            Source.Add((ValueString) "b", 7);
            Source.Add((ValueString) "c", 8);
            Source.Add((ValueString) "d", 9);
            Source.Add((ValueString) "a", 10);
            Source.Add((ValueString) "b", 11);
            Source.Add((ValueString) "c", 12);
            Source.Add((ValueString) "c", 13);
            Source.Add((ValueString) "b", 14);
            Source.Add((ValueString) "a", 15);
            Source.Add((ValueString) "d", 16);
            Source.Add((ValueString) "b", 17);
            Source.Add((ValueString) "b", 18);
            Source.Add((ValueString) "a", 19);
            Source.Add((ValueString) "d", 20);
            Source.Add((ValueString) "b", 21);
            Source.Add((ValueString) "c", 22);
            Source.Add((ValueString) "a", 23);
            Source.Add((ValueString) "a", 24);
            Source.Add((ValueString) "b", 25);

            Source.Add((ValueString)"a", 26);
            Source.Add((ValueString)"a", 27);
            Source.Add((ValueString)"b", 28);
            Source.Add((ValueString)"a", 29);
            Source.Add((ValueString)"a", 30);
            Source.Add((ValueString)"b", 31);
            Source.Add((ValueString)"a", 32);
            Source.Add((ValueString)"a", 33);
            Source.Add((ValueString)"b", 34);
            Source.Add((ValueString)"b", 35);
        }

        [Test]
        public void TestCode()
        {
            CoderHannon Coder = new CoderHannon();
            Coder.Teach(Source);
            Assert.AreEqual("0", Coder.CodeTable[(ValueString)"a"]);
            Assert.AreEqual("10", Coder.CodeTable[(ValueString)"b"]);
            Assert.AreEqual("110", Coder.CodeTable[(ValueString)"c"]);
            Assert.AreEqual("111", Coder.CodeTable[(ValueString)"d"]);
        }

        [Test]
        public void TestCompress()
        {
            CoderHannon Coder = new CoderHannon();
            Coder.Teach(Source);
            string strpractis = Coder.Compress(Source);
            string strteoretic = "0101001100111101101110101101101001111010011110110001000100010001010";
            Assert.AreEqual(strteoretic, strpractis);
        }

        [Test]
        public void RealTest()
        {
            string temp = "";
            ActionType act = new ActionType();
            act.LinkUp = LinkUp.Start;
            act.BlockSize = 2;
            SpaceRebuilderFromChainToChainByBlock<Chain, Chain, Chain> Rebuilder = new SpaceRebuilderFromChainToChainByBlock<Chain, Chain, Chain>(act);
            Chain Rebuild = Rebuilder.Rebuild(Source);
            Chain Alp = new Chain(Rebuild.Length);
            IteratorSimpleStart<Chain> it = new IteratorSimpleStart<Chain>(Rebuild, 1);
            int j = 0;
            while(it.Next())
            {
                Chain Cur = (Chain) it.Current();
                long[] bild = (Cur).Building;
                foreach (long l in bild)
                {
                    temp += l.ToString();
                }

                Chain ch_temp = new Chain(Cur.Alpahbet.power);
                for(int i = 0; i < Cur.Alpahbet.power; i++)
                {
                    ch_temp.Add(Cur.Alpahbet[i],i);
                }

                Alp.Add(ch_temp, j);
                j++;
            }

            File Data = new File();
            Data.Data = temp;
            Data.FileType = FileType.Txt;

            ElementStreamCreator Estr = ElementStreamBuilderFactory.Create(Data.FileType);
            ElementStream element_str = Estr.Create(Data);

            ObjectVirtualBase<Chain> OVB = new ObjectVirtualBase<Chain>();
            OVB.LoadElements(element_str);
            Chain BuildChain = OVB.Chain;
            CoderHannon Coder = new CoderHannon();
            Coder.Teach(BuildChain);
            string strpractis = Coder.Compress(BuildChain);

            //TODO: Fix bug with value in SortedList.
 /*           Coder = new CoderHannon();
            Coder.Teach(Alp);
            string strpractis2 = Coder.Compress(Alp);
*/

            Assert.GreaterOrEqual(Source.GetCharacteristic(LinkUp.Start, CharacteristicsFactory.H), BuildChain.GetCharacteristic(LinkUp.Start, CharacteristicsFactory.H));
            Assert.GreaterOrEqual(Source.GetCharacteristic(LinkUp.Start, CharacteristicsFactory.H), Alp.GetCharacteristic(LinkUp.Start, CharacteristicsFactory.H));
        } 
    }
}