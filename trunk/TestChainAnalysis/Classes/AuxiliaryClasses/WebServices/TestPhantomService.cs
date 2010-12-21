using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices
{
    //[TestFixture]
    public class TestPhantomService
    {
       /* private string HashPhantom = null;

        [SetUp]
        public void SetPhantom()
        {
            ServiceManager SM = ServiceManager.Create();
            BinaryFormatter deserializer = new BinaryFormatter();
            FileStream FileS = new FileStream("TestPhantom.tst", FileMode.Open, FileAccess.Read);
            RequestPhantomChains Request = (RequestPhantomChains)deserializer.Deserialize(FileS);
            FileS.Close();
            RequestPhantomChains Request = new RequestPhantomChains();
            Request.Generator = GeneratorType.SimpleGenerator;
            Request.Chain = new SoapChainOfChains();
            Request.GenerateChainsCount = 1;
            HashPhantom = SM.NewCalculation(Request, WebServiceType.PhantomChain);
        }

        [TearDown]
        public void TearPhantom()
        {
            
        }

        [Test]
        public void TestPhantomInput()
        {
            Assert.IsInstanceOfType(typeof(String), HashPhantom);
            Assert.IsNotEmpty(HashPhantom);
            Assert.IsNotNull(HashPhantom);
        }

        [Test]
        public void TestPhantomOutputCalculating()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerPhantomChains result = (AnswerPhantomChains)SM.Check(HashPhantom, WebServiceType.PhantomChain);
            Assert.AreEqual(ErrorType.Calculating, result.Error);
        }

        [Test]
        public void TestPhantomOutputWrongId()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerPhantomChains result = (AnswerPhantomChains)SM.Check("asdg214gdrjio8", WebServiceType.PhantomChain);
            Assert.AreEqual(ErrorType.IdError, result.Error);
        }

        [Test]
        public void TestPhantomOutputComplete()
        {
            Thread.Sleep(5000);
            ServiceManager SM = ServiceManager.Create();
            AnswerPhantomChains result = (AnswerPhantomChains)SM.Check(HashPhantom, WebServiceType.PhantomChain);
            Assert.AreEqual(ErrorType.CalculationsComplete, result.Error);
        }*/
    

    }
}
