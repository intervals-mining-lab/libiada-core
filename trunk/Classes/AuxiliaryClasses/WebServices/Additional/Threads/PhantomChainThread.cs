using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    /// <summary>
    /// ���� �������������� ������� ��������� �����
    /// </summary>
    internal class PhantomChainThread : IThread
    {
        private RequestPhantomChains InputData = null;

        /// <summary>
        /// ����� ������������� �������� ������ ��� ����������.
        /// ��������� ��� ������  <see cref="RequestPhantomChains"/>.
        /// </summary>
        /// <param name="data">�������� ������</param>
        public override void SetData(Request data)
        {
            InputData = (RequestPhantomChains) data;
        }

        /// <summary>
        /// ����� ����������� ��������� ��������� ������� 
        /// � ����������� ���������� � ���� ���� "���-���.csd".
        /// </summary>
        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerPhantomChains result = WS.PhantomChains(InputData);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream File = new FileStream(hashvalue + ".csd", FileMode.CreateNew, FileAccess.Write);
            serializer.Serialize(File, result);
            File.Close();
        }
    }
}