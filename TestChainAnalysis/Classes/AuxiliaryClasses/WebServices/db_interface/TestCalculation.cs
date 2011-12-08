using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.Statistics;
using ChainAnalises.Classes.TheoryOfSet;
using NHibernate;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    [TestFixture]
    public class TestCalculation
    {
        #region Setup/Teardown

        [SetUp]
        public void init()
        {
            db_calculate = new DBCalculate();
            db_calculate.nids.Add(7);
            db_calculate.length = 1;
            db_calculate.uid = 11;
        }

        #endregion

        private DBCalculate db_calculate;

        [Test]
        public void TestCalucation()
        {
            DBConfig DBConf = DBConfig.GetInstance();

            ActionType action = new ActionType();
            action.LinkUp = db_calculate.Link;
            action.BlockSize = db_calculate.length;

            foreach (int nid in db_calculate.nids)
            {
                ISession session = DBConf.CreateSession();
                ITransaction tx = session.BeginTransaction();
                DBFile dbfile = (DBFile) session.Load(typeof (DBFile), nid);
                tx.Commit();
                session.Close();

                File file = DBMapping.Convert(dbfile);

                AnswerChains Answer = new AnswerChains();
                Answer.Error = ErrorType.CalculationsComplete;


                ElementStreamCreator ElStrFactory =
                    ElementStreamBuilderFactory.Create(file.FileType);

                ElementStream ElStream = ElStrFactory.Create(file);

                ObjectVirtualBase<Chain> OVB = new ObjectVirtualBase<Chain>();
                OVB.LoadElements(ElStream);


                SpaceRebuilder<Chain, Chain> RebuildMethod =
                    new SpaceRebuilderFromChainToChainByBlock<Chain, Chain, ChainMessage>(action);

                OVB.RebuildSpace(RebuildMethod);

                OVB.Calculate();

                ChainBin Temp = (ChainBin) OVB.Chain.GetBin();

                DBChain db_chain = DBMapping.Convert(Temp);

                session = DBConf.CreateSession();
                tx = session.BeginTransaction();
                int new_nid = (int) session.Save(db_chain);
                tx.Commit();
                session.Close();
                Answer.chains.Add(db_chain.nid);
            }
            // Return Answer
        }

        [Test]
        public void TestDBElementSave()
        {
            DBMessage mes = new DBMessage();
            mes.value = "A";

            DBConfig DBConf = DBConfig.GetInstance();
            ISession session = DBConf.CreateSession();
            ITransaction tx = session.BeginTransaction();

            int test = (int) session.Save(mes);
            tx.Commit();
            session.Close();
            Assert.IsInstanceOfType(typeof(int), test);
            Assert.Greater(test, 0);
        }

        [Test]
        public void TestDBElementSaveOrUpdate()
        {
            DBMessage mes = new DBMessage();
            DBMessage mesDublicate = new DBMessage();
            mes.value = "A";
            mesDublicate.value = "A";

            DBConfig DBConf = DBConfig.GetInstance();
            ISession session = DBConf.CreateSession();
            ITransaction tx = session.BeginTransaction();

            session.SaveOrUpdate(mes);
            tx.Commit();
            session.Close();

            session = DBConf.CreateSession();
            tx = session.BeginTransaction();

            session.SaveOrUpdate(mesDublicate);
            tx.Commit();
            session.Close();

            Assert.Equals(mes.nid, mesDublicate.nid);
            Assert.Greater(mes.nid, 0);
        }


        [Test]
        public void TestDBMessageSave()
        {
            DBChainMessage mes = new DBChainMessage();

            DBMessage el1 = new DBMessage();
            DBMessage el2 = new DBMessage();
            el1.value = "A";
            el2.value = "B";
            mes.elements.Add(0, el1);
            mes.elements.Add(1, el2);
            mes.elements.Add(2, el1);

            DBConfig DBConf = DBConfig.GetInstance();
            ISession session = DBConf.CreateSession();
            ITransaction tx = session.BeginTransaction();
            
            int test = (int)session.Save(mes);
            tx.Commit();
            session.Close();
            Assert.IsInstanceOfType(typeof(int), test);
            Assert.Greater(test, 0);
        }

        [Test]
        public void TestDBFileLoad()
        {
            DBConfig DBConf = DBConfig.GetInstance();
            ISession session = DBConf.CreateSession();
            ITransaction tx = session.BeginTransaction();
            DBFile file = (DBFile) session.Load(typeof (DBFile), 7);
            tx.Rollback();
            session.Close();
            Assert.AreEqual("This is our test file", file.value);
            Assert.AreEqual("text", file.field_type.mime);
            Assert.AreEqual("txt", file.field_type.name);
            Assert.AreEqual(1, file.field_type.size);
        }

        [Test]
        public void TestDBFileTypeLoad()
        {
            DBConfig DBConf = DBConfig.GetInstance();
            ISession session = DBConf.CreateSession();
            ITransaction tx = session.BeginTransaction();
            DBFileType file = (DBFileType) session.Load(typeof (DBFileType), 4);
            tx.Rollback();
            session.Close();
            Assert.AreEqual("txt", file.name);
            Assert.AreEqual("text", file.mime);
            Assert.AreEqual(1, file.size);
        }
    }

    public static class DBMapping
    {
        public static File Convert(DBFile dbfile)
        {
            File temp = new File();
            temp.Data = dbfile.value;
            temp.FileType = Convert(dbfile.field_type);
            return temp;
        }

        private static FileType Convert(DBFileType field_type)
        {
            FileType temp = new FileType();
            temp.Size = field_type.size;
            temp.Name = field_type.name;
            temp.MIME = field_type.mime;
            return temp;
        }

        public static DBChain Convert(ChainBin input)
        {
            DBChain temp = new DBChain();
            temp.alphabet = Convert(input.Alphabet);
            temp.building = Convert(input.Building);

            temp.characteristics = new ArrayList();

            /*foreach (CharacteristicBin charact in input.Characteristics)
            {
                temp.characteristics.Add(Convert(charact));
            }

            temp.common_intervals = Convert(input.CommonIntervals);
            temp.start_intervals = Convert(input.StartIntervals);
            temp.end_intervals = Convert(input.EndInterval);

            temp.uniformchains = new ArrayList();

            foreach (UniformChainBin uniformchain in input.Characteristics)
            {
                temp.uniformchains.Add(Convert(uniformchain));
            }

            temp.length = input.Building.Length;*/

            return temp;
        }


        private static DBAlphabet Convert(AlphabetBin alphabet)
        {
            DBAlphabet temp = new DBAlphabet();
            temp.elements = new Dictionary<int, DBChainMessage>();
            int pos = 0;
            foreach (ChainMessageBin item in alphabet.Items)
            {
                temp.elements.Add(pos, Convert(item));
                pos++;
            }
            return temp;
        }

        private static DBChainMessage Convert(ChainMessageBin item)
        {
            DBChainMessage temp = new DBChainMessage();
            //temp.elements = new Dictionary<int, DBMessage>();
            int pos = 0;
            foreach (ValueStringBin value in item.values)
            {
                temp.elements.Add(pos, Convert(value));
                //temp.elements.Add(pos, Convert(value));
                pos++;
            }
            return temp;
        }

        private static DBMessage Convert(ValueStringBin value)
        {
            DBMessage temp = new DBMessage();
            temp.value = value.value;
            return temp;
        }

        private static DBBuilding Convert(long[] building)
        {
            DBBuilding temp = new DBBuilding();
            temp.length = building.Length;

            string[] building_as_string = new string[building.Length];
            long pos = 0;
            foreach (long num in building)
            {
                building_as_string.SetValue(num.ToString(), pos);
                pos++;
            }
            temp.value = string.Join("|", building_as_string);
            return temp;
        }

        private static DBCharacteristic Convert(CharacteristicBin charact)
        {
            DBCharacteristic temp = new DBCharacteristic();
            // TODO: Add characterisitc refleactions
                       throw new NotImplementedException();
            return temp;

        }

        private static DBFrequencyList Convert(FrequencyListBin intervals)
        {
            throw new NotImplementedException();
        }

        private static DBUniformChain Convert(UniformChainBin uniformchain)
        {
            throw new NotImplementedException();
        }
    }
}