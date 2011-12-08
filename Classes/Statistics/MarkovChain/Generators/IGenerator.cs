namespace ChainAnalises.Classes.Statistics.MarkovChain.Generators
{
    ///<summary>
    /// ��������� ��� ����������� ������������� ��������
    ///</summary>
    public interface IGenerator
    {
        ///<summary>
        /// �������������� ��������� �����.
        ///</summary>
        void Resert();

        ///<summary>
        /// �������� ��������� �������� �������������� ��������.
        ///</summary>
        ///<returns>[0..1] ��������</returns>
        double Next();
    }
}