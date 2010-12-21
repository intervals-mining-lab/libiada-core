/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.IntervalAnalysis;
using NUnit.Framework;
using File=ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.File;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices
{
    [TestFixture]
	[Ignore]
    public class TestAlphabetService
    {
        private string HashAlphabet = null;

        [SetUp]
        public void SetAlphabet()
        {
            ServiceManager SM = ServiceManager.Create();
*/
            /*BinaryFormatter deserializer = new BinaryFormatter();
            FileStream FileS = new FileStream("TestAlphabet.tst", FileMode.Open, FileAccess.Read);
            RequestFiles Request = (RequestFiles)deserializer.Deserialize(FileS);
            FileS.Close();*/
/*
            RequestFiles Request = new RequestFiles();
            Request.Action = ActionType.CreateAlphabetByBlock;
            Request.Files = new File();
            Request.Files.FileType = FileType.Txt;
            Request.Files.Data = "blablabla";
            //Request.Action = new ActionType();
            Request.Action.BlockSize = 3;
            Request.Action.LinkUp = LinkUp.Start;
            HashAlphabet = SM.NewCalculation(Request, WebServiceType.Alphabet);
        }

        [TearDown]
        public void TearAlphabet()
        {
*/
            /* Thread.Sleep(2000);*/
            //File.Delete("*.csd");
/*
        }

        [Test]
        public void TestAlphabetInput()
        {
            Assert.IsInstanceOfType(typeof(String), HashAlphabet);
            Assert.IsNotEmpty(HashAlphabet);
            Assert.IsNotNull(HashAlphabet);
        }

        [Test]
		[Ignore]
        public void TestAlphabetOutputCalculating()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerObjects result = (AnswerObjects)SM.Check(HashAlphabet, WebServiceType.Alphabet);
            Assert.AreEqual(ErrorType.Calculating, result.Error);
        }

        [Test]
		[Ignore]
        public void TestAlphabetOutputWrongId()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerObjects result = (AnswerObjects)SM.Check("asdg214gdrjio8", WebServiceType.Alphabet);
            Assert.AreEqual(ErrorType.IdError, result.Error);
        }

        [Test]
		[Ignore]
        public void TestAlphabetOutputComplete()
        {
            Thread.Sleep(5000);
            ServiceManager SM = ServiceManager.Create();
            AnswerObjects result = (AnswerObjects)SM.Check(HashAlphabet, WebServiceType.Alphabet);
            Assert.AreEqual(ErrorType.CalculationsComplete, result.Error);
        }

    }
}
*/