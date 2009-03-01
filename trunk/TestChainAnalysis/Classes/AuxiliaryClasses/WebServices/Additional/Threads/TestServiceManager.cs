using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    [TestFixture]
    public class TestServiceManager
    {
        [Test]
        public void creation()
        {
            ServiceManager SM1 = ServiceManager.Create();
            ServiceManager SM2 = ServiceManager.Create();
            Assert.AreSame(SM1,SM2);
        }

        [Test]
        public void MultiThreading()
        {
            ServiceManager SM = ServiceManager.Create();
            BinaryFormatter deserializer = new BinaryFormatter();
            FileStream FileS = new FileStream("../TestCalculate.tst", FileMode.Open, FileAccess.Read);
            RequestFiles Request = (RequestFiles)deserializer.Deserialize(FileS);
            FileS.Close();
            SM.NewCalculation(Request, WebServiceType.Calculate);
            SM.NewCalculation(Request, WebServiceType.Calculate);
            SM.NewCalculation(Request, WebServiceType.Calculate);
            SM.NewCalculation(Request, WebServiceType.Calculate);
            Process wp = Process.GetCurrentProcess();
            Assert.AreEqual("15", wp.Threads.Count.ToString());

        }
    }
}
