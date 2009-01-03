using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices
{
    [TestFixture]
    public class TestMarkovService
    {
        private string HashMarkov = null;

        [SetUp]
        public void SetMarkov()
        {
            ServiceManager SM = ServiceManager.Create();
            BinaryFormatter deserializer = new BinaryFormatter();
            FileStream FileS = new FileStream("../TestMarkov.tst", FileMode.Open, FileAccess.Read);
            RequestMarkovChain Request = (RequestMarkovChain)deserializer.Deserialize(FileS);
            FileS.Close();
            HashMarkov = SM.NewCalculation(Request, WebServiceType.MarkovChain);
        }

        [TearDown]
        public void TearMarkov()
        {
            /* Thread.Sleep(2000);*/
            //File.Delete("*.csd");
        }

        [Test]
        public void TestMarkovInput()
        {
            
            Assert.IsInstanceOfType(typeof(String), HashMarkov);
            Assert.IsNotEmpty(HashMarkov);
            Assert.IsNotNull(HashMarkov);
        }

        [Test]
        public void TestMarkovOutputCalculating()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerMarkovChain result = (AnswerMarkovChain)SM.Check(HashMarkov, WebServiceType.MarkovChain);
            Assert.AreEqual(ErrorType.Calculating, result.Error);
        }

        [Test]
        public void TestMarkovOutputWrongId()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerMarkovChain result = (AnswerMarkovChain)SM.Check("asdg214gdrjio8", WebServiceType.MarkovChain);
            Assert.AreEqual(ErrorType.IdError, result.Error);
        }

        [Test]
        public void TestMarkovOutputComplete()
        {
            Thread.Sleep(5000);
            ServiceManager SM = ServiceManager.Create();
            AnswerMarkovChain result = (AnswerMarkovChain)SM.Check(HashMarkov, WebServiceType.MarkovChain);
            Assert.AreEqual(ErrorType.CalculationsComplete, result.Error);
        }

    }
}
