using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices
{
    [TestFixture]
    public class TestSegmentationService
    {
        private string HashSegmentation = null;

        [SetUp]
        public void SetSegmentation()
        {
            ServiceManager SM = ServiceManager.Create();
            BinaryFormatter deserializer = new BinaryFormatter();
            FileStream FileS = new FileStream("../TestSegmentation.tst", FileMode.Open, FileAccess.Read);
            RequestSegmentation Request = (RequestSegmentation)deserializer.Deserialize(FileS);
            FileS.Close();
            HashSegmentation = SM.NewCalculation(Request, WebServiceType.Segmentation);
        }

        [TearDown]
        public void TearSegmentation()
        {
            /* Thread.Sleep(2000);*/
            //File.Delete("*.csd");
        }

        [Test]
        public void TestSegmentationInput()
        {
            Assert.IsInstanceOfType(typeof(String), HashSegmentation);
            Assert.IsNotEmpty(HashSegmentation);
            Assert.IsNotNull(HashSegmentation);
        }

        [Test]
        public void TestSegmentationOutputCalculating()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerSegmentation result = (AnswerSegmentation)SM.Check(HashSegmentation, WebServiceType.Segmentation);
            Assert.AreEqual(ErrorType.Calculating, result.Error);
        }

        [Test]
        public void TestSegmentationOutputWrongId()
        {
            ServiceManager SM = ServiceManager.Create();
            AnswerSegmentation result = (AnswerSegmentation)SM.Check("asdg214gdrjio8", WebServiceType.Segmentation);
            Assert.AreEqual(ErrorType.IdError, result.Error);
        }

        [Test]
        public void TestSegmentationOutputComplete()
        {
            Thread.Sleep(10000);
            ServiceManager SM = ServiceManager.Create();
            AnswerSegmentation result = (AnswerSegmentation)SM.Check(HashSegmentation, WebServiceType.Segmentation);
            Assert.AreEqual(ErrorType.CalculationsComplete, result.Error);
        }
    }
}
