using System.Diagnostics;
using ChainAnalises.Classes;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.IntervalAnalysis;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    [TestFixture]
    public class TestServiceManager
    {
        /// <summary>
        /// Проверяем что у нас может быть только один менеджер вычислений.
        /// </summary>
        [Test]
        public void Creation()
        {
            ServiceManager SM1 = ServiceManager.Create();
            ServiceManager SM2 = null;
            Assert.IsNull(SM2);
            SM2 = ServiceManager.Create();
            Assert.IsNotNull(SM2);
            ServiceManager SM3 = ServiceManager.Create();
            Assert.AreSame(SM1, SM2);
            Assert.AreSame(SM2, SM3);
            Assert.AreSame(SM1, SM3);
        }

        /// <summary>
        /// Проверяем что каждое вычисление запускается в отдельной нити.
        /// </summary>
        [Test]
		[Ignore]
        public void MultiThreading()
        {
            ServiceManager SM = ServiceManager.Create();
  
            //создаем объект с входными данными для вычисления
            RequestFiles Request = new RequestFiles();
            ActionType Action = ActionType.Calculate;
            Action.BlockSize = 1;
            Action.LinkUp = LinkUp.Start;
            Request.Action = Action;
            File file = new File();
            file.FileType = FileType.Txt;
            file.FileType.HashCode = 1863149665;
            file.FileType.MIME = "text";
            file.FileType.Name = "fm";
            file.FileType.Size = 1;
            file.Data = "Й\nА\nЙ\nА\nЩ\nЕ\nР\nК\nА\nЙ\nУ\nТЬ\nА\nЩ\nЕ\nЙ\nСЬ\nА\nЭ\nП\nО\nХЬ\nИ\nЩ\nЕ\nМЬ\nА\nЩ\nИ\nЙ\nШ\nЕ\nЛЬ\nЕ\nС\nТ\nЧ\nУ\nФ\nС\nТ\nВЬ\nЕ\nН\nН\nЫ\nХ\nЦ\nЫ\nК\nА\nТ\nХ\nЛ\nА\nП\nУ\nШ\nК\nА\nФ\nО\nК\nУ\nС\nА\nФ\nУ\nБ\nО\nГЬ\nИ\nХ\nТ\nРЬ\nЕ\nВ\nО\nЖ\nН\nЫ\nЙ\nС\nВЬ\nИ\nС\nТ\nР\nЫ\nВ\nО\nК\nП\nА\nВЬ\nЕ\nР\nХ\nА\nГ\nР\nА\nТ\nН\nА\nИ\nТЬ\nИ\nЙ\nЕ\nМЬ\nИ\nН\nУ\nТ\nА\nЛЬ\nИ\nК\nА\nВ\nА\nНЬ\nЙ\nА\nКЬ\nЕ\nЛЬ\nЕ\nЙ\nНЬ\nИ\nК\nА\nИ\nС\nП\nА\nВЬ\nЕ\nД\nА\nЛЬ\nНЬ\nА\nЗЬ\nЕ\nМ\nН\nА\nЙ\nА\nЖ\nЫ\nЗ\nНЬ\nЙ\nЕ\nЩ\nД\nА\nРЬ\nИ\nТ\nГ\nО\nРЬ\nА\nВ\nЫ\nС\nО\nК\nА\nЙ\nЕ\nБ\nЛ\nА\nЖ\nЕ\nН\nС\nТ\nВ\nА\nА\nЛ\nТ\nА\nРЬ\nА";

            Process wp = Process.GetCurrentProcess();
            int ExpectedCount = wp.Threads.Count + 4;

            SM.NewCalculation(Request, WebServiceType.Calculate);
            SM.NewCalculation(Request, WebServiceType.Calculate);
            SM.NewCalculation(Request, WebServiceType.Calculate);
            SM.NewCalculation(Request, WebServiceType.Calculate);
            wp = Process.GetCurrentProcess();
            Assert.AreEqual(ExpectedCount, wp.Threads.Count);
        }
    }
}
