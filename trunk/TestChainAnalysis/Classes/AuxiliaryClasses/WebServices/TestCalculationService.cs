using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices
{
    [TestFixture]
    public class TestCalculationService
    {
        private string HashCalculating = null;

        [SetUp]
        public void SetCalculation()
        {
            ServiceManager SM = ServiceManager.Create();
            BinaryFormatter deserializer = new BinaryFormatter();
            FileStream FileS = new FileStream("../TestCalculate.tst", FileMode.Open, FileAccess.Read);
            RequestFiles Request = (RequestFiles)deserializer.Deserialize(FileS);
            FileS.Close();
            HashCalculating = SM.NewCalculation(Request, WebServiceType.Calculate);
        }

        [TearDown]
        public void TearCalculation()
        {
           /* Thread.Sleep(2000);*/
            //File.Delete("*.csd");
        }

        [Test]
        public void TestCalculateInput()
        {
            Assert.IsInstanceOfType(typeof(String), HashCalculating);
            Assert.IsNotEmpty(HashCalculating);
            Assert.IsNotNull(HashCalculating);
        }

        [Test]
        public void TestCalculateOutputCalculating()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerChain result = (AnswerChain)SM.Check(HashCalculating, WebServiceType.Calculate);
            Assert.AreEqual(ErrorType.Calculating, result.Error);
        }

        [Test]
        public void TestCalculateOutputWrongId()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerChain result = (AnswerChain)SM.Check("asdg214gdrjio8", WebServiceType.Calculate);
            Assert.AreEqual(ErrorType.IdError, result.Error);
        }

        [Test]
        public void TestCalculateOutputComplete()
        {
            Thread.Sleep(5000);
            ServiceManager SM = ServiceManager.Create();
            AnswerChain result = (AnswerChain)SM.Check(HashCalculating, WebServiceType.Calculate);
            Assert.AreEqual(ErrorType.CalculationsComplete, result.Error);
        }

    }
}
