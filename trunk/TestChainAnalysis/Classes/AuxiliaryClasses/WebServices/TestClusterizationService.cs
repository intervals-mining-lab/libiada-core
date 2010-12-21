/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices
{
    [TestFixture]
    public class TestClusterizationService
    {
        private string HashClusterization = null;

        [SetUp]
        public void SetClusterization()
        {
            ServiceManager SM = ServiceManager.Create();
            BinaryFormatter deserializer = new BinaryFormatter();
            FileStream FileS = new FileStream("../TestClusterization.tst", FileMode.Open, FileAccess.Read);
            RequestClusterization Request = (RequestClusterization)deserializer.Deserialize(FileS);
            FileS.Close();
            HashClusterization = SM.NewCalculation(Request, WebServiceType.Clusterization);
        }

        [TearDown]
        public void TearClusterization()
        {
*/
            /* Thread.Sleep(2000);*/
            //File.Delete("*.csd");
/*
        }

        [Test]
        public void TestClusterizationInput()
        {
            Assert.IsInstanceOfType(typeof(String), HashClusterization);
            Assert.IsNotEmpty(HashClusterization);
            Assert.IsNotNull(HashClusterization);
        }

        [Test]
		[Ignore]
        public void TestClusterizationOutputCalculating()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerClusterization result = (AnswerClusterization)SM.Check(HashClusterization, WebServiceType.Clusterization);
            Assert.AreEqual(ErrorType.Calculating, result.Error);
        }

        [Test]
        public void TestClusterizationOutputWrongId()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerClusterization result = (AnswerClusterization)SM.Check("asdg214gdrjio8", WebServiceType.Clusterization);
            Assert.AreEqual(ErrorType.IdError, result.Error);
        }

        [Test]
        public void TestClusterizationOutputComplete()
        {
            Thread.Sleep(5000);
            ServiceManager SM = ServiceManager.Create();
            AnswerClusterization result = (AnswerClusterization)SM.Check(HashClusterization, WebServiceType.Clusterization);
            Assert.AreEqual(ErrorType.CalculationsComplete, result.Error);
        }

    }
}
*/