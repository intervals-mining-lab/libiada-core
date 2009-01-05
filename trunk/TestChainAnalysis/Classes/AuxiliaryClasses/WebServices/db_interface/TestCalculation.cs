using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ChainAnalises;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Requests;
using ChainAnalises.Classes.DivizionToAccords.Criteria;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using ChainAnalises.Classes.PhantomChains;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using File = ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.File;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    [TestFixture]
    public class TestCalculation
    {
        private DBCalculate db_calculate;

        [SetUp]
        public void init()
        {
            db_calculate = new DBCalculate();
            db_calculate.nids.Add(13);
/*           db_calculate.nids.Add(11);
           db_calculate.nids.Add(12);
*/
            db_calculate.length = 1;
            db_calculate.uid = 11;
        }

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


                SpaceRebuilder<Chain, Chain> RebuildMethod = new SpaceRebuilderFromChainToChainByBlock<Chain, Chain>(action);

                OVB.RebuildSpace(RebuildMethod);

                OVB.Calculate();

                ChainBin Temp = (ChainBin)OVB.Chain.GetBin();

                DBChain db_chain = DBMapping.Convert(Temp);

                session = DBConf.CreateSession();
                tx = session.BeginTransaction();
                db_chain = (DBChain) session.Save(db_chain);
                tx.Commit();
                session.Close();
                Answer.chains.Add(db_chain.nid);
            }
            // Return Answer
        }

        [Test]
        public void TestDBFileType()
        {
            DBConfig DBConf = DBConfig.GetInstance();
            ISession session = DBConf.CreateSession();
            ITransaction tx = session.BeginTransaction();
            DBFileType file = (DBFileType) session.Load(typeof (DBFileType), 10);
            tx.Rollback();
            session.Close();
            Assert.AreEqual("txt", file.name);
            Assert.AreEqual("text", file.mime);
            Assert.AreEqual(1, file.size);
            
        }

        [Test]
        public void TestDBFile()
        {
            DBConfig DBConf = DBConfig.GetInstance();
            ISession session = DBConf.CreateSession();
            ITransaction tx = session.BeginTransaction();
            DBFile file = (DBFile)session.Load(typeof(DBFile), 13);
            tx.Rollback();
            session.Close();
            Assert.AreEqual("test content of file.", file.value);
            Assert.AreEqual("text", file.field_type.mime);
            Assert.AreEqual("txt", file.field_type.name);
            Assert.AreEqual(1, file.field_type.size);

        }
    }

    public class DBChain:Node
    {
    }

    public class AnswerChains:Answer
    {
        [XmlArrayItem(typeof(int))]
        public ArrayList chains = new ArrayList();
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
            temp.Size= field_type.size;
            temp.Name= field_type.name;
            temp.MIME= field_type.mime;
            return temp;
        }

        public static DBChain Convert(ChainBin temp)
        {
            throw new System.NotImplementedException();
        }
    }
}