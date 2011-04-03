using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    /// <summary>
    /// ���� �������������� ������� �������������
    /// </summary>
    internal class ClusterizationThread : IThread
    {
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
            AnswerClusterization result = WS.KRAB((RequestClusterization)InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}