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
        /// ��������� ��� � ��� ����� ���� ������ ���� �������� ����������.
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
        /// ��������� ��� ������ ���������� ����������� � ��������� ����.
        /// </summary>
        [Test]
		[Ignore]
        public void MultiThreading()
        {
            ServiceManager SM = ServiceManager.Create();
  
            //������� ������ � �������� ������� ��� ����������
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
            file.Data = "�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n��\n�\n�\n�\n�\n��\n�\n�\n�\n��\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n��\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n��\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n�\n��\n�\n�\n��\n�\n��\n�\n�\n��\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n��\n��\n�\n��\n�\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n�\n��\n�\n�\n�\n�\n��\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n�\n��\n�";

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
