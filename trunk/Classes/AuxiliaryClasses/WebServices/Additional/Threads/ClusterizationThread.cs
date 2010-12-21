using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    /// <summary>
    /// ���� �������������� ������� �������������
    /// </summary>
    internal class ClusterizationThread : IThread
    {
        private RequestClusterization InputData = null;

        /// <summary>
        /// ����� ������������� �������� ������ ��� ����������.
        /// ��������� ��� ������  <see cref="RequestClusterization"/>.
        /// </summary>
        /// <param name="data">�������� ������</param>
        public override void SetData(Request data)
        {
            InputData = (RequestClusterization) data;
        }


        /// <summary>
        /// ����� ����������� ������������� �������� 
        /// � ����������� ���������� � ���� ���� "���-���.csd".
        /// </summary>
        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerClusterization result = WS.KRAB(InputData);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream File = new FileStream(hashvalue + ".csd", FileMode.CreateNew, FileAccess.Write);
            serializer.Serialize(File, result);
            File.Close();
        }
    }
}